using System.Collections.Generic;

namespace CommonPlex.Compilation.Macros
{
    /// <summary>
    /// This macro will render images.
    /// </summary>
    /// <example><code language="none">
    /// ![alt](http://www.foo.com/bar.jpg)
    /// </code></example>
    public class ImageMacro : IMacro
    {
        /// <summary>
        /// Gets the id of the macro.
        /// </summary>
        public string Id
        {
            get { return "Image"; }
        }

        /// <summary>
        /// Gets the list of rules for the macro.
        /// </summary>
        public IList<MacroRule> Rules
        {
            get
            {
                return new List<MacroRule>()
                           {
                               new MacroRule(
                                   @"(?i)(\[image:)((?>[^\]\|]*\|https?://[^\]\|]*))(\])",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.Remove},
                                           {2, ScopeName.ImageNoAlignWithAlt},
                                           {3, ScopeName.Remove}
                                       }
                                   )
                           };
            }
        }
    }
}