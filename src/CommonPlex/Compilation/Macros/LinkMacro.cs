using System.Collections.Generic;

namespace CommonPlex.Compilation.Macros
{
    /// <summary>
    /// This macro will render links.
    /// </summary>
    /// <example><code language="none">
    /// [title](http://www.foo.com)
    /// </code></example>
    public class LinkMacro : IMacro
    {
        /// <summary>
        /// Gets the id of the macro.
        /// </summary>
        public string Id
        {
            get { return "Link"; }
        }

        /// <summary>
        /// Gets the list of rules for the macro.
        /// </summary>
        public IList<MacroRule> Rules
        {
            get
            {
                return new List<MacroRule>
                           {
                               new MacroRule(
                                   @"(?i)(\[url:mailto:)((?>[^]]+))(])",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.Remove},
                                           {2, ScopeName.LinkAsMailto},
                                           {3, ScopeName.Remove}
                                       })
                           };
            }
        }
    }
}