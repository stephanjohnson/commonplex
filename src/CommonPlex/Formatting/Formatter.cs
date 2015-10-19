using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonPlex.Common;
using CommonPlex.Formatting.Renderers;
using CommonPlex.Parsing;

namespace CommonPlex.Formatting
{
    /// <summary>
    /// Handles formatting wiki content based on recorded scopes.
    /// </summary>
    public class Formatter
    {
        private readonly IEnumerable<IRenderer> renderers;
        private readonly List<Scope> scopes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Formatter"/> class.
        /// </summary>
        public Formatter() : this(CommonPlex.Renderers.All)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Formatter"/> class.
        /// </summary>
        /// <param name="renderers">The renderers to use when formatting.</param>
        /// <exception cref="ArgumentNullException">Thrown when renderers is null.</exception>
        public Formatter(IEnumerable<IRenderer> renderers)
        {
            Guard.NotNullOrEmpty(renderers, "renderers");

            this.renderers = renderers;
            scopes = new List<Scope>();
        }

        /// <summary>
        /// Event that is raised when a scope is rendered.
        /// </summary>
        public event EventHandler<RenderedScopeEventArgs> ScopeRendered;

        /// <summary>
        /// Will record the parsing of scopes.
        /// </summary>
        /// <param name="scopes">The parsed scopes.</param>
        /// <exception cref="ArgumentNullException">Thrown when scopes is null.</exception>
        public void RecordParse(IList<Scope> scopes)
        {
            Guard.NotNull(scopes, "scopes");

            this.scopes.AddRange(scopes);
        }

        /// <summary>
        /// Will format the wiki content based on the recorded scopes and output the content to the writer.
        /// </summary>
        /// <param name="wikiContent">The wiki content to format.</param>
        /// <returns>The formatted wiki content.</returns>
        public virtual string Format(string wikiContent)
        {
            var writer = new StringBuilder(wikiContent.Length);

            int currentIndex = 0;
            var orderedScopes = (from s in scopes
                                 orderby s.Index, s.Length descending
                                 select s).ToList();

            for (int i = 0; i < orderedScopes.Count; i++)
            {
                Scope scope = orderedScopes[i];

                // write all prior content
                writer.Append(EncodeContent(wikiContent.Substring(currentIndex, scope.Index - currentIndex)));

                // format this scope
                string content = wikiContent.Substring(scope.Index, scope.Length);
                RenderScope(writer, scope, content);

                // skip any nested scopes
                int indexOffset = 0;
                for (int j = i; (j + 1) < orderedScopes.Count; j++)
                {
                    Scope peek = orderedScopes[j + 1];
                    if (peek.Index == scope.Index && peek.Length == scope.Length)
                    {
                        indexOffset = scope.Length;
                        break;
                    }

                    if (peek.Index >= (scope.Index + scope.Length))
                        break;

                    i++;
                }

                currentIndex = scope.Index + scope.Length - indexOffset;
            }

            // write to the end
            writer.Append(EncodeContent(wikiContent.Substring(currentIndex)));

            // remove the trailing new line character
            if (writer[writer.Length - 1] == '\r')
                writer.Remove(writer.Length - 1, 1);
            
            return writer.ToString();
        }

        /// <summary>
        /// Method used to encode content during formatting.
        /// </summary>
        /// <param name="input">The input to encode.</param>
        /// <returns>The encoded output.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
        protected virtual string EncodeContent(string input)
        {
            Guard.NotNull(input, "input");

            return input;
        }

        /// <summary>
        /// Method used to encode attributes during formatting.
        /// </summary>
        /// <param name="input">The input to encode.</param>
        /// <returns>The encoded output.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
        protected virtual string EncodeAttributeContent(string input)
        {
            Guard.NotNull(input, "input");

            return input;
        }

        /// <summary>
        /// Handles raising the ScopeRendered event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnScopeRendered(RenderedScopeEventArgs e)
        {
            EventHandler<RenderedScopeEventArgs> handler = ScopeRendered;
            if (handler != null)
                handler(this, e);
        }

        private void RenderScope(StringBuilder writer, Scope scope, string content)
        {
            IRenderer renderer = renderers.FirstOrDefault(r => r.CanExpand(scope.Name));
            string renderedContent;

            try
            {
                renderedContent = renderer == null
                                    ? string.Format("<span class=\"unresolved\">Cannot resolve macro, as no renderers were found.</span>[{0}]", EncodeContent(content))
                                    : renderer.Expand(scope.Name, content, EncodeContent, EncodeAttributeContent);
            }
            catch
            {
                renderedContent = string.Format("<span class=\"unresolved\">Cannot resolve macro, as an unhandled exception occurred.</span>[{0}]", EncodeContent(content));
            }

            writer.Append(renderedContent);
            OnScopeRendered(new RenderedScopeEventArgs(scope, content, renderedContent));
        }
    }
}