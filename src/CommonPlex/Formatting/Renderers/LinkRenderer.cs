using System;
using System.Collections.Generic;
using CommonPlex.Common;

namespace CommonPlex.Formatting.Renderers
{
    /// <summary>
    /// Will render all link based scopes.
    /// </summary>
    public class LinkRenderer : Renderer
    {
        private const string LinkFormat = "<a href=\"{0}\">{1}</a>";

        /// <summary>
        /// Gets the collection of scope names for this <see cref="IRenderer"/>.
        /// </summary>
        protected override ICollection<string> ScopeNames
        {
            get
            {
                return new[] { 
                                ScopeName.LinkNoText, ScopeName.LinkWithText, 
                                ScopeName.LinkAsMailto,
                                ScopeName.LinkToAnchor
                             };
            }
        }

        /// <summary>
        /// Gets the invalid macro error text.
        /// </summary>
        protected override string InvalidMacroError
        {
            get { return "Cannot resolve link macro, invalid number of parameters."; }
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
            input = input.Trim();

            
                if (scopeName == ScopeName.LinkNoText)
                    return ExpandLinkNoText(input, attributeEncode, htmlEncode);
                if (scopeName == ScopeName.LinkWithText)
                    return ExpandLinkWithText(input, attributeEncode, htmlEncode);
                if (scopeName == ScopeName.LinkAsMailto)
                    return string.Format(LinkFormat, attributeEncode("mailto:" + input), htmlEncode(input));
                if (scopeName == ScopeName.LinkToAnchor)
                    return string.Format(LinkFormat, attributeEncode("#" + input), htmlEncode(input));
            

            return null;
        }

        private static string ExpandLinkWithText(string input, Func<string, string> attributeEncode, Func<string, string> htmlEncode)
        {
            TextPart part = RenderException.ConvertAny(() => Utility.ExtractTextParts(input));
            string url = part.Text;
            if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase) && !url.StartsWith("mailto", StringComparison.OrdinalIgnoreCase))
                url = "http://" + url;

            return string.Format(LinkFormat, attributeEncode(url), htmlEncode(part.FriendlyText));
        }

        private static string ExpandLinkNoText(string input, Func<string, string> attributeEncode, Func<string, string> htmlEncode)
        {
            string url = input;
            if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                url = "http://" + url;

            return string.Format(LinkFormat, attributeEncode(url), htmlEncode(input));
        }
    }
}