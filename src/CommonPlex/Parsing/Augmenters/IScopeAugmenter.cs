using System.Collections.Generic;
using CommonPlex.Compilation.Macros;

namespace CommonPlex.Parsing
{
    /// <summary>
    /// Defines the methods necessary for a scope augmenter.
    /// </summary>
    public interface IScopeAugmenter
    {
        /// <summary>
        /// This will insert new, remove, or re-order scopes.
        /// </summary>
        /// <param name="macro">The current macro.</param>
        /// <param name="capturedScopes">The list of captured scopes.</param>
        /// <param name="content">The wiki content being parsed.</param>
        /// <returns>A new list of augmented scopes.</returns>
        IList<Scope> Augment(IMacro macro, IList<Scope> capturedScopes, string content);
    }
}