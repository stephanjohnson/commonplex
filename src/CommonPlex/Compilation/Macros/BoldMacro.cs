using System.Collections.Generic;

namespace CommonPlex.Compilation.Macros
{
    /// <summary>
    /// This macro will display text as bolded.
    /// </summary>
    /// <example><code language="none">
    /// **i am bolded**
    /// __i am bolded__
    /// </code></example>
    public class BoldMacro : IMacro
    {
        /// <summary>
        /// Gets the id of the macro.
        /// </summary>
        public string Id
        {
            get { return "Bold"; }
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
                                   @"(?-s)(?:((?!\*\*+\s)\*\*)(?>[^{[\*\*\n]*)(?>(?:{{?|\[)(?>[^}\]\n]*)(?>(?:}}?|\])*)|.)*?(?>[^{[\*\*\n]*(\*\*)))",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.BoldBegin},
                                           {2, ScopeName.BoldEnd}
                                       }),
                               new MacroRule(
                                   @"(?-s)(?:((?!__+\s)__)(?>[^{[__\n]*)(?>(?:{{?|\[)(?>[^}\]\n]*)(?>(?:}}?|\])*)|.)*?(?>[^{[__\n]*(__)))",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.BoldBegin},
                                           {2, ScopeName.BoldEnd}
                                       })
                           };
            }
        }
    }
}