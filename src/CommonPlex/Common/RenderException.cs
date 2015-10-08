using System;

namespace CommonPlex.Common
{
    /// <summary>
    /// The exception that is thrown for any generic rendering exceptions.
    /// </summary>
    public class RenderException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderException"/> class.
        /// </summary>
        public RenderException() : this(string.Empty)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderException"/> class.
        /// </summary>
        /// <param name="message">The message that should be displayed.</param>
        public RenderException(string message) : base(message)
        {}

        internal delegate T ExecuteDelegate<T>();

        internal static T ConvertAny<T>(ExecuteDelegate<T> executionDelegate)
        {
            try
            {
                return executionDelegate();
            }
            catch
            {
                throw new RenderException();
            }
        }
    }
}
