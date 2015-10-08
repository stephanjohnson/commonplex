using System;
using System.Collections.Generic;
using CommonPlex.Common;

namespace CommonPlex.Formatting.Renderers
{
    /// <summary>
    /// The base class for a <see cref="IRenderer"/>.
    /// </summary>
    public abstract class Renderer : IRenderer
    {
        private const string UnresolvedError = @"<span class=""unresolved"">{0}</span>";
        private string rendererId;
        private HashSet<string> scopeNames;

        /// <summary>
        /// Gets the id of a renderer.
        /// </summary>
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(rendererId))
                    rendererId = GetType().Name.Replace("Renderer", string.Empty);
                
                return rendererId;
            }
        }

        /// <summary>
        /// Gets the collection of scope names for this <see cref="IRenderer"/>.
        /// </summary>
        protected abstract ICollection<string> ScopeNames
        {
            get;
        }

        /// <summary>
        /// Gets the invalid macro error text.
        /// </summary>
        protected virtual string InvalidMacroError
        {
            get { return "Cannot resolve macro."; }
        }

        /// <summary>
        /// Gets the invalid argument error text.
        /// </summary>
        protected virtual string InvalidArgumentError
        {
            get { return "Cannot resolve macro, invalid parameter '{0}'."; }
        }

        /// <summary>
        /// Determines if this renderer can expand the given scope name.
        /// </summary>
        /// <param name="scopeName">The scope name to check.</param>
        /// <returns>A boolean value indicating if the renderer can or cannot expand the macro.</returns>
        public bool CanExpand(string scopeName)
        {
            if (scopeNames == null)
                scopeNames = new HashSet<string>(ScopeNames);

            return scopeNames.Contains(scopeName);
        }

        /// <summary>
        /// Will expand the input into the appropriate content based on scope.
        /// </summary>
        /// <param name="scopeName">The scope name.</param>
        /// <param name="input">The input to be expanded.</param>
        /// <param name="htmlEncode">Function that will html encode the output.</param>
        /// <param name="attributeEncode">Function that will html attribute encode the output.</param>
        /// <returns>The expanded content.</returns>
        public string Expand(string scopeName, string input, Func<string, string> htmlEncode, Func<string, string> attributeEncode)
        {
            if (!CanExpand(scopeName))
                throw new ArgumentException("Invalid scope name for this renderer.", "scopeName");

            try
            {
                return PerformExpand(scopeName, input, htmlEncode, attributeEncode);
            }
            catch (ArgumentException ex)
            {
                return string.Format(UnresolvedError, string.Format(InvalidArgumentError, ex.ParamName));
            }
            catch (RenderException ex)
            {
                return string.Format(UnresolvedError, string.IsNullOrEmpty(ex.Message) ? InvalidMacroError : ex.Message);
            }
            catch
            {
                return string.Format(UnresolvedError, InvalidMacroError);
            }
        }

        /// <summary>
        /// Will expand the input into the appropriate content based on scope for the derived types.
        /// </summary>
        /// <param name="scopeName">The scope name.</param>
        /// <param name="input">The input to be expanded.</param>
        /// <param name="htmlEncode">Function that will html encode the output.</param>
        /// <param name="attributeEncode">Function that will html attribute encode the output.</param>
        /// <returns>The expanded content.</returns>
        protected abstract string PerformExpand(string scopeName, string input, Func<string, string> htmlEncode, Func<string, string> attributeEncode);
    }
}
