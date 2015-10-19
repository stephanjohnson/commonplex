using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using CommonPlex.Common;
using CommonPlex.Compilation;
using CommonPlex.Compilation.Macros;
using CommonPlex.Formatting;
using CommonPlex.Formatting.Renderers;
using CommonPlex.Parsing;

namespace CommonPlex
{
    /// <summary>
    /// The public entry point for the wiki engine.
    /// </summary>
    public class RenderEngine : IRenderEngine
    {
        private static readonly MacroCompiler Compiler = new MacroCompiler();
        private static readonly Regex NewLineRegex = new Regex(@"(?<!\r|</tr>|</li>|</ul>|</ol>|<hr />|</blockquote>)(?:\n|&#10;)(?!<h[1-6]>|<hr />|<ul>|<ol>|</li>|</blockquote>)");
        private static readonly Regex PreRegex = new Regex(@"(?s)((?><pre>)(?>.*?</pre>))");

        private readonly Parser parser;

        /// <summary>
        /// Instantiates a new instance of the <see cref="RenderEngine"/>.
        /// </summary>
        public RenderEngine() : this(new Parser(Compiler))
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="RenderEngine"/>.
        /// </summary>
        /// <param name="parser">The macro parser to use.</param>
        protected internal RenderEngine(Parser parser)
        {
            this.parser = parser;
        }

        /// <summary>
        /// Renders the wiki content using the statically registered macros and renderers.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <returns>The rendered html content.</returns>
        public string Render(string wikiContent)
        {
            return Render(wikiContent, Renderers.All);
        }

        /// <summary>
        /// Renders the wiki content using the a custom formatter with statically registered macros.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <param name="formatter">The custom formatter used when rendering.</param>
        /// <returns>The rendered html content.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when formatter is null.</exception>
        public string Render(string wikiContent, Formatter formatter)
        {
            return Render(wikiContent, Macros.All, formatter);
        }

        /// <summary>
        /// Renders the wiki content using the specified macros and statically registered renderers.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <param name="macros">A collection of macros to be used when rendering.</param>
        /// <returns>The rendered html content.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when macros is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when macros is an empty enumerable.</exception>
        public string Render(string wikiContent, IEnumerable<IMacro> macros)
        {
            return Render(wikiContent, macros, Renderers.All);
        }

        /// <summary>
        /// Renders the wiki content using the specified renderers with statically registered macros.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <param name="renderers">A collection of renderers to be used when rendering.</param>
        /// <returns>The rendered html content.</returns>
        public string Render(string wikiContent, IEnumerable<IRenderer> renderers)
        {
            return Render(wikiContent, Macros.All, renderers);
        }

        /// <summary>
        /// Renders the wiki content using the specified macros and renderers.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <param name="macros">A collection of macros to be used when rendering.</param>
        /// <param name="renderers">A collection of renderers to be used when rendering.</param>
        /// <returns>The rendered html content.</returns>
        public string Render(string wikiContent, IEnumerable<IMacro> macros, IEnumerable<IRenderer> renderers)
        {
            Guard.NotNullOrEmpty(renderers, "renderers");

            var formatter = new Formatter(renderers);
            return Render(wikiContent, macros, formatter);
        }

        /// <summary>
        /// Renders the wiki content using the specified macros and custom formatter.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <param name="macros">A collection of macros to be used when rendering.</param>
        /// <param name="formatter">The custom formatter used when rendering.</param>
        /// <returns>The rendered html content.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// <para>Thrown when macros is null.</para>
        /// <para>- or -</para>
        /// <para>Thrown when formatter is null.</para>
        /// </exception>
        /// <exception cref="System.ArgumentException">Thrown when macros is an empty enumerable.</exception>
        public string Render(string wikiContent, IEnumerable<IMacro> macros, Formatter formatter)
        {
            Guard.NotNullOrEmpty(macros, "macros");
            Guard.NotNull(formatter, "formatter");

            if (string.IsNullOrEmpty(wikiContent))
                return wikiContent;

            wikiContent = wikiContent.Replace("\r\n", "\n");

            parser.Parse(wikiContent, macros, ScopeAugmenters.All, formatter.RecordParse);

            return ReplaceNewLines(formatter.Format(wikiContent));
        }

        private static string ReplaceNewLines(string input)
        {
            string replacedInput = NewLineRegex.Replace(input, "<br />");

            var match = PreRegex.Match(replacedInput);
            if (!match.Success)
                return replacedInput;

            // now we need to remove any <br /> tags within <pre></pre> tags
            var output = new StringBuilder(input.Length);
            int currentIndex = 0;
            while (match.Success)
            {
                output.Append(replacedInput.Substring(currentIndex, match.Groups[0].Index - currentIndex));
                output.Append(replacedInput.Substring(match.Groups[0].Index, match.Groups[0].Length).Replace("<br />", "\n"));
                currentIndex = match.Groups[0].Index + match.Groups[0].Length;
                match = match.NextMatch();
            }

            output.Append(replacedInput.Substring(currentIndex));

            return output.ToString();
        }
    }
}