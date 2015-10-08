using System.Collections.Generic;

namespace CommonPlex.Compilation.Macros
{
    /// <summary>
    /// Defines the fields necessary for a macro.
    /// </summary>
    public interface IMacro
    {
        /// <summary>
        /// Gets the id of the macro.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the list of rules for the macro.
        /// </summary>
        IList<MacroRule> Rules { get; }
    }
}