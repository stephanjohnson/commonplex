using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonPlex.Common
{
    /// <summary>
    /// Contains common methods that guard parameter inputs.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Ensures that the object is not null.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="object">The object to check.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <exception cref="ArgumentNullException">Thrown if the object is null</exception>
        public static void NotNull<T>(T @object, string paramName)
            where T : class
        {
            if (@object == null)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Ensures that the object is not null.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="object">The object to check.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message for the exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if the object is null</exception>
        public static void NotNull<T>(T @object, string paramName, string message)
            where T : class
        {
            if (@object == null)
                throw new ArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Ensures that the string is not null or empty.
        /// </summary>
        /// <param name="object">The object to check.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <exception cref="ArgumentNullException">Thrown if the object is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the object is empty.</exception>
        public static void NotNullOrEmpty(string @object, string paramName)
        {
            NotNull(@object, paramName);

            if (string.IsNullOrEmpty(@object))
                throw new ArgumentException("Parameter cannot be empty.", paramName);
        }

        /// <summary>
        /// Ensures that the string is not null or empty.
        /// </summary>
        /// <param name="object">The object to check.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message for the exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if the object is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the object is empty.</exception>
        public static void NotNullOrEmpty(string @object, string paramName, string message)
        {
            NotNull(@object, paramName, message);

            if (string.IsNullOrEmpty(@object))
                throw new ArgumentException(message, paramName);
        }

        /// <summary>
        /// Ensures that the enumerable collection is not null or empty.
        /// </summary>
        /// <param name="object">The enumerable collection to check.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <exception cref="ArgumentNullException">Thrown if the object is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the object is empty.</exception>
        public static void NotNullOrEmpty<T>(IEnumerable<T> @object, string paramName)
        {
            NotNull(@object, paramName);

            if (@object.Count() == 0)
                throw new ArgumentException("Parameter cannot be empty.", paramName);
        }

        /// <summary>
        /// Ensures that the enumerable collection is not null or empty.
        /// </summary>
        /// <param name="object">The enumerable collection to check.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message for the exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if the object is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the object is empty.</exception>
        public static void NotNullOrEmpty<T>(IList<T> @object, string paramName, string message)
        {
            NotNull(@object, paramName, message);

            if (@object.Count == 0)
                throw new ArgumentException(message, paramName);
        }

        /// <summary>
        /// Ensures that two objects do not equal each other.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="compareTo">The object to compare to.</param>
        /// <param name="object">The object to compare against.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <exception cref="ArgumentException">Thrown if the objects are not equal.</exception>
        public static void NotEqual<T>(T compareTo, T @object, string paramName)
            where T : IComparable
        {
            if (@object.CompareTo(compareTo) == 0)
                throw new ArgumentException("Parameter cannot equal '" + compareTo + "'.", paramName);
        }
    }
}