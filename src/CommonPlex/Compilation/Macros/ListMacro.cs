using System.Collections.Generic;

namespace CommonPlex.Compilation.Macros
{
    /// <summary>
    /// This macro will will consume either an ordered or an unordered list.
    /// </summary>
    /// <example><code language="none">
    /// * item 1
    /// * item 2
    /// ## item 2.1
    /// ## item 2.2
    /// *** item 2.2.1
    /// </code></example>
    public class ListMacro : IMacro
    {
        /// <summary>
        /// Gets the id of the macro.
        /// </summary>
        public string Id
        {
            get { return "List Macro"; }
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
                               new MacroRule(EscapeRegexPatterns.FullEscape),
                               new MacroRule(
                                   @"(?im)(^(?:\*|\-)\s)[^\r\n]+((?:\r\n)?)$",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.ListItemBegin},
                                           {2, ScopeName.ListItemEnd}
                                       })
                           };
            }
        }
    }
}
