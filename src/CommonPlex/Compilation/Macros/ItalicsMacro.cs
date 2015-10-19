using System.Collections.Generic;

namespace CommonPlex.Compilation.Macros
{
    /// <summary>
    /// This macro will display text in italics.
    /// </summary>
    /// <example><code language="none">
    /// *i am italics*
    /// _i am italics_
    /// </code></example>
    public class ItalicsMacro : IMacro
    {
        /// <summary>
        /// Gets the id of the macro.
        /// </summary>
        public string Id
        {
            get { return "Italics"; }
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
                                   @"(?-s)(?:(_)(?>[^{\[_\n]*)(?>(?:{{?|\[)(?>[^}\]\n]*)(?>(?:}}?|\])*)|.)*?(?>[^{\[_\n]*)(_))",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.ItalicsBegin},
                                           {2, ScopeName.ItalicsEnd}
                                       }),
                               new MacroRule(
                                   @"(?-s)(?:(\*)(?>[^{\[\*\n]*)(?>(?:{{?|\[)(?>[^}\]\n]*)(?>(?:}}?|\])*)|.)*?(?>[^{\[\*\n]*)(\*))",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.ItalicsBegin},
                                           {2, ScopeName.ItalicsEnd}
                                       })
                           };
            }
        }
    }
}