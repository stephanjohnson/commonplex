using System.Collections.Generic;
using CommonPlex.Common;

namespace CommonPlex.Compilation
{
    /// <summary>
    /// This will hold a regex and all associated captures that will be used for compilation of a macro.
    /// </summary>
    public class MacroRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MacroRule"/> class.
        /// </summary>
        /// <param name="regex">The regular expression.</param>
        /// <remarks>This will contain no captures.</remarks>
        /// <exception cref="System.ArgumentNullException">Thrown when regex is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when regex is empty.</exception>
        public MacroRule(string regex)
            : this(regex, new Dictionary<int, string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MacroRule"/> class.
        /// </summary>
        /// <param name="regex">The regular expression</param>
        /// <param name="firstScopeCapture">The scope name of the first capture.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when regex is null.
        /// 
        /// -- or --
        /// 
        /// Thrown when firstScopeCapture is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when regex is empty.
        /// 
        /// -- or --
        /// 
        /// Thrown when firstScopeCapture is empty.
        /// </exception>
        public MacroRule(string regex, string firstScopeCapture)
        {
            Guard.NotNullOrEmpty(regex, "regex");
            Guard.NotNullOrEmpty(firstScopeCapture, "firstScopeCapture");

            Regex = regex;
            Captures = new Dictionary<int, string>
                           {
                               { 1, firstScopeCapture }
                           };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MacroRule"/> class.
        /// </summary>
        /// <param name="regex">The regular expression.</param>
        /// <param name="captures">The dictionary of captures.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when regex is null.
        /// 
        /// -- or --
        /// 
        /// Thrown when captures is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">Thrown when regex is empty.</exception>
        public MacroRule(string regex, IDictionary<int, string> captures)
        {
            Guard.NotNullOrEmpty(regex, "regex");
            Guard.NotNull(captures, "captures");

            Regex = regex;
            Captures = captures;
        }

        /// <summary>
        /// Gets or sets the regex.
        /// </summary>
        public string Regex { get; set; }

        /// <summary>
        /// Gets the dictionary of captures.
        /// </summary>
        public IDictionary<int, string> Captures { get; private set; }
    }
}