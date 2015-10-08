using System.Collections.Generic;

namespace CommonPlex.Compilation.Macros
{
    /// <summary>
    /// This macro will escape all other macros that are contained between ``` and ```.
    /// </summary>
    /// <example><code language="none">
    /// ``` *I will not bold* ```
    /// </code></example>
    public class EscapedMarkupMacro : IMacro
    {
        /// <summary>
        /// Gets the id of the macro.
        /// </summary>
        public string Id
        {
            get { return "Escaped Markup"; }
        }

        /// <summary>
        /// Gets the list of rules.
        /// </summary>
        public IList<MacroRule> Rules
        {
            get
            {
                return new List<MacroRule>
                           {
                               new MacroRule(
                                   @"(?s)(```\n?)(.*?)(\n?```)",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.Remove},
                                           {2, ScopeName.EscapedMarkup},
                                           {3, ScopeName.Remove}
                                       })
                           };
            }
        }
    }
}