using System;
using System.Collections.Generic;
using CommonPlex.Common;

namespace CommonPlex.Formatting.Renderers
{
    /// <summary>
    /// Will render the image scopes.
    /// </summary>
    public class ImageRenderer : Renderer
    {
        private const string ImageNoLinkAndAlt = "<img src=\"{2}\" alt=\"{3}\" title=\"{3}\" {4}/>";

        /// <summary>
        /// Gets the collection of scope names for this <see cref="IRenderer"/>.
        /// </summary>
        protected override ICollection<string> ScopeNames
        {
            get
            {
                return new[] {
                                ScopeName.ImageNoAlignWithAlt
                             };
            }
        }

        /// <summary>
        /// Gets the invalid macro error text.
        /// </summary>
        protected override string InvalidMacroError
        {
            get { return "Cannot resolve image macro, invalid number of parameters."; }
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
            FloatAlignment alignment = GetAlignment(scopeName);
            var renderMethod = GetRenderMethod(scopeName);

            return RenderException.ConvertAny(() => renderMethod(input, alignment, attributeEncode));
        }

        private static FloatAlignment GetAlignment(string scopeName) => FloatAlignment.None;

        private static Func<string, FloatAlignment, Func<string, string>, string> GetRenderMethod(string scopeName)
        {
            switch (scopeName)
            {
                case ScopeName.ImageNoAlignWithAlt:
                    return RenderImageWithAltMacro;
            }

            return null;
        }

        private static string RenderImageWithAltMacro(string input, FloatAlignment alignment, Func<string, string> encode)
        {
            string format = ImageNoLinkAndAlt;
            ImagePart parts = Utility.ExtractImageParts(input, ImagePartExtras.ContainsText);

            return string.Format(format, alignment.GetStyle(), alignment.GetPadding(), encode(parts.ImageUrl), encode(parts.Text), parts.Dimensions);
        }
    }
}