using System.Collections.Generic;

namespace CommonPlex.Compilation.Macros
{
    /// <summary>
    /// This macro will output a horizontal line.
    /// </summary>
    /// <example><code language="none">
    /// Content above
    /// ---
    /// Content below
    /// </code></example>
    public class HorizontalLineMacro : IMacro
    {
        /// <summary>
        /// Gets the id of the macro
        /// </summary>
        public string Id
        {
            get { return "Horizontal Line"; }
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
                               new MacroRule(@"^[\s]{0,3}(\*{1,3}[\*\s]+)(\r?\n|$)", ScopeName.HorizontalRule),
                               new MacroRule(@"^[\s]{0,3}(-{1,3}[-\s]+)(\r?\n|$)", ScopeName.HorizontalRule),
                               new MacroRule(@"^[\s]{0,3}(_{1,3}[_\s]+)(\r?\n|$)", ScopeName.HorizontalRule)
                           };
            }
        }
    }
}