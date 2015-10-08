using System;
using System.Collections.Generic;

namespace CommonPlex.Formatting.Renderers
{
    /// <summary>
    /// This will render the ordered list and unordered list scopes.
    /// </summary>
    public class ListItemRenderer : Renderer
    {
        /// <summary>
        /// Gets the collection of scope names for this <see cref="IRenderer"/>.
        /// </summary>
        protected override ICollection<string> ScopeNames
        {
            get 
            {
                return new[] {
                                ScopeName.OrderedListBeginTag, ScopeName.OrderedListEndTag,
                                ScopeName.UnorderedListBeginTag, ScopeName.UnorderedListEndTag,
                                ScopeName.ListItemBegin, ScopeName.ListItemEnd
                             };
            }
        }

        /// <summary>
        /// Will expand the input into the appropriate content based on scope.
        /// </summary>
        /// <param name="scopeName">The scope name.</param>
        /// <param name="input">The input to be expanded.</param>
        /// <param name="htmlEncode">Function that will html encode the output.</param>
        /// <param name="attributeEncode">Function that will html attribute encode the output.</param>
        /// <returns>The expanded content.</returns>
        protected override string PerformExpand(string scopeName, string input, Func<string, string> htmlEncode, Func<string, string> attributeEncode)
        {
            if (scopeName == ScopeName.OrderedListBeginTag)
                return "<ol><li>";
            if (scopeName == ScopeName.OrderedListEndTag)
                return "</li></ol>";
            if (scopeName == ScopeName.UnorderedListBeginTag)
                return "<ul><li>";
            if (scopeName == ScopeName.UnorderedListEndTag)
                return "</li></ul>";
            if (scopeName == ScopeName.ListItemBegin)
                return "<li>";
            if (scopeName == ScopeName.ListItemEnd)
                return "</li>";

            return null;
        }
    }
}