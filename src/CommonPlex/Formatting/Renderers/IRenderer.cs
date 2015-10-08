using System;

namespace CommonPlex.Formatting.Renderers
{
    /// <summary>
    /// Defines the fields necessary for a renderer.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Gets the id of a renderer.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Determines if this renderer can expand the given scope name.
        /// </summary>
        /// <param name="scopeName">The scope name to check.</param>
        /// <returns>A boolean value indicating if the renderer can or cannot expand the macro.</returns>
        bool CanExpand(string scopeName);

        /// <summary>
        /// Will expand the input into the appropriate content based on scope.
        /// </summary>
        /// <param name="scopeName">The scope name.</param>
        /// <param name="input">The input to be expanded.</param>
        /// <param name="htmlEncode">Function that will html encode the output.</param>
        /// <param name="attributeEncode">Function that will html attribute encode the output.</param>
        /// <returns>The expanded content.</returns>
        string Expand(string scopeName, string input, Func<string, string> htmlEncode, Func<string, string> attributeEncode);
    }
}