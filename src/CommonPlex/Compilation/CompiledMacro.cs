using System.Collections.Generic;
using System.Text.RegularExpressions;
using CommonPlex.Common;

namespace CommonPlex.Compilation
{
    /// <summary>
    /// Will hold a compiled macro that is generated from the <see cref="MacroCompiler"/>.
    /// </summary>
    public class CompiledMacro
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompiledMacro"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="regex">The regular expression.</param>
        /// <param name="captures">The list of captures.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when id is null.
        /// 
        /// -- or --
        /// 
        /// Thrown when regex is null.
        /// 
        /// -- or --
        /// 
        /// Thrown when captures is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when id is empty.
        /// 
        /// -- or --
        /// 
        /// Thrown when captures is empty.
        /// </exception>
        public CompiledMacro(string id, Regex regex, IList<string> captures)
        {
            Guard.NotNullOrEmpty(id, "id");
            Guard.NotNull(regex, "regex");
            Guard.NotNullOrEmpty(captures, "captures");

            Id = id;
            Regex = regex;
            Captures = captures;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public string Id { get; private set; }       

        /// <summary>
        /// Gets the regular expression.
        /// </summary>
        public Regex Regex { get; private set; }

        /// <summary>
        /// Gets the list of captures.
        /// </summary>
        public IList<string> Captures { get; private set; }
    }
}