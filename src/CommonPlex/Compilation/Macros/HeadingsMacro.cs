using System.Collections.Generic;

namespace CommonPlex.Compilation.Macros
{
    /// <summary>
    /// This macro will display text as headings.
    /// </summary>
    /// <example><code language="none">
    /// # heading 1
    /// ## heading 2
    /// ### heading 3
    /// #### heading 4
    /// ##### heading 5
    /// ###### heading 6
    /// </code></example>
    public class HeadingsMacro : IMacro
    {
        /// <summary>
        /// Gets the id of the macro.
        /// </summary>
        public string Id
        {
            get { return "Headings"; }
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
                                   @"^:*\s?(#\s)[^\r\n]*(\r?\n|$)",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.HeadingOneBegin},
                                           {2, ScopeName.HeadingOneEnd}
                                       }),
                               new MacroRule(
                                   @"^:*\s?(##\s)[^\r\n]*(\r?\n|$)",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.HeadingTwoBegin},
                                           {2, ScopeName.HeadingTwoEnd}
                                       }),
                               new MacroRule(
                                   @"^:*\s?(###\s)[^\r\n]*(\r?\n|$)",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.HeadingThreeBegin},
                                           {2, ScopeName.HeadingThreeEnd}
                                       }),
                               new MacroRule(
                                   @"^:*\s?(####\s)[^\r\n]*(\r?\n|$)",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.HeadingFourBegin},
                                           {2, ScopeName.HeadingFourEnd}
                                       }),
                               new MacroRule(
                                   @"^:*\s?(#####\s)[^\r\n]*(\r?\n|$)",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.HeadingFiveBegin},
                                           {2, ScopeName.HeadingFiveEnd}
                                       }),
                                new MacroRule(
                                   @"^:*\s?(######\s)[^\r\n]*(\r?\n|$)",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.HeadingSixBegin},
                                           {2, ScopeName.HeadingSixEnd}
                                       })
                           };
            }
        }
    }
}