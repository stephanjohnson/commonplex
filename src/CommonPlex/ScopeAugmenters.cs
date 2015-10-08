using System.Collections.Generic;
using System.Threading;
using CommonPlex.Common;
using CommonPlex.Compilation.Macros;
using CommonPlex.Parsing;

namespace CommonPlex
{
    /// <summary>
    /// The static entry point for registering <see cref="IScopeAugmenter" />s for all instances of a <see cref="IWikiEngine"/>.
    /// </summary>
    /// <remarks>For convienience, all <see cref="IScopeAugmenter"/>s that are shipped with CommonPlex are already registered.</remarks>
    public static class ScopeAugmenters
    {
        private static readonly ReaderWriterLockSlim augmenterLock;
        private static readonly IDictionary<string, IScopeAugmenter> loadedAugmenters;

        static ScopeAugmenters()
        {
            loadedAugmenters = new Dictionary<string, IScopeAugmenter>();
            augmenterLock = new ReaderWriterLockSlim();

            // register the default scope augmenters
            Register<ListMacro, ListScopeAugmenter>();
        }

        /// <summary>
        /// Gets the entire list of currently registered scope augmenters.
        /// </summary>
        public static IDictionary<string, IScopeAugmenter> All
        {
            get
            {
                augmenterLock.EnterReadLock();
                try
                {
                    return new Dictionary<string, IScopeAugmenter>(loadedAugmenters);
                }
                finally
                {
                    augmenterLock.ExitReadLock();
                }
            }
        }

        /// <summary>
        /// Registers a new <see cref="IScopeAugmenter"/> that is paired with a <see cref="IMacro"/>.
        /// </summary>
        /// <typeparam name="TMacro">The <see cref="IMacro"/> type the <see cref="IScopeAugmenter"/> is paired with. Must have a parameterless constructor.</typeparam>
        /// <typeparam name="TAugmenter">The <see cref="IScopeAugmenter"/> to register. Must have a parameterless constructor.</typeparam>
        public static void Register<TMacro, TAugmenter>()
            where TMacro : class, IMacro, new()
            where TAugmenter : class, IScopeAugmenter, new()
        {
            Register<TMacro>(new TAugmenter());
        }

        /// <summary>
        /// Registers a new <see cref="IScopeAugmenter"/> that is paired with a <see cref="IMacro"/>.
        /// </summary>
        /// <typeparam name="TMacro">The <see cref="IMacro"/> type the <see cref="IScopeAugmenter"/> is paired with. Must have a parameterless constructor.</typeparam>
        /// <param name="augmenter">The scope augmenter to register.</param>
        /// <remarks>This augmenter needs to be thread safe.</remarks>
        /// <exception cref="System.ArgumentNullException">Thrown when the augmenter is null.</exception>
        public static void Register<TMacro>(IScopeAugmenter augmenter)
            where TMacro : class, IMacro, new()
        {
            Guard.NotNull(augmenter, "augmenter");

            augmenterLock.EnterWriteLock();
            try
            {
                loadedAugmenters[(new TMacro()).Id] = augmenter;
            }
            finally
            {
                augmenterLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Un-registers a <see cref="IScopeAugmenter"/> based on it's paired <see cref="IMacro"/>.
        /// </summary>
        /// <typeparam name="TMacro">The <see cref="IMacro"/> type to un-register the <see cref="IScopeAugmenter"/> for.</typeparam>
        public static void Unregister<TMacro>()
            where TMacro : class, IMacro, new()
        {
            augmenterLock.EnterWriteLock();
            try
            {
                var macro = new TMacro();
                if (loadedAugmenters.ContainsKey(macro.Id))
                    loadedAugmenters.Remove(macro.Id);
            }
            finally
            {
                augmenterLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// This extends a dictionary of scope augmenters to find a <see cref="IScopeAugmenter"/> based on a <see cref="IMacro"/>.
        /// </summary>
        /// <typeparam name="TMacro">The <see cref="IMacro"/> to search for the <see cref="IScopeAugmenter"/> by.</typeparam>
        /// <param name="augmenters">The list of augmenters to search.</param>
        /// <returns>The found <see cref="IScopeAugmenter"/>. Null is returned if not found.</returns>
        public static IScopeAugmenter FindByMacro<TMacro>(this IDictionary<string, IScopeAugmenter> augmenters)
            where TMacro : class, IMacro, new()
        {
            return FindByMacro(augmenters, new TMacro());
        }

        /// <summary>
        /// This extends a dictionary of scope augmenters to find a <see cref="IScopeAugmenter"/> based on a <see cref="IMacro"/>.
        /// </summary>
        /// <typeparam name="TMacro">The <see cref="IMacro"/> to search for the <see cref="IScopeAugmenter"/> by.</typeparam>
        /// <param name="augmenters">The list of augmenters to search.</param>
        /// <param name="macro">The <see cref="IMacro"/> to search by.</param>
        /// <returns>The found <see cref="IScopeAugmenter" />. Null is returned if not found.</returns>
        public static IScopeAugmenter FindByMacro<TMacro>(this IDictionary<string, IScopeAugmenter> augmenters,
                                                          TMacro macro)
            where TMacro : class, IMacro
        {
            Guard.NotNull(macro, "macro");
            IScopeAugmenter augmenter;

            augmenters.TryGetValue(macro.Id, out augmenter);

            return augmenter;
        }
    }
}