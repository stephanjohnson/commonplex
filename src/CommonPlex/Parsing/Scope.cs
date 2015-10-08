using CommonPlex.Common;

namespace CommonPlex.Parsing
{
    /// <summary>
    /// Encapsulates a found scope during parsing.
    /// </summary>
    public class Scope
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Scope"/> class.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="index">The index where the scope was found.</param>
        /// <param name="length">The length of the scope.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when name is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when name is empty.</exception>
        public Scope(string name, int index, int length)
        {
            Guard.NotNullOrEmpty(name, "name");

            Name = name;
            Index = index;
            Length = length;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Scope"/> class.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="index">The index where the scope was found.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when name is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when name is empty.</exception>
        public Scope(string name, int index)
        {
            Guard.NotNullOrEmpty(name, "name");

            Name = name;
            Index = index;
        }

        ///<summary>
        /// Gets the index of the scope.
        ///</summary>
        public int Index { get; private set; }

        /// <summary>
        /// Gets the length of the scope.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; private set; }
    }
}