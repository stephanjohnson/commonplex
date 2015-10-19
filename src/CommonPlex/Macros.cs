using System.Collections.Generic;
using System.Threading;
using CommonPlex.Common;
using CommonPlex.Compilation.Macros;

namespace CommonPlex
{
    /// <summary>
    /// The static entry point for registering <see cref="IMacro" />s for all instances of a <see cref="IRenderEngine" />.
    /// </summary>
    /// <remarks>For convienience, all <see cref="IMacro"/>s that are shipped with CommonPlex are already registered.</remarks>
    public static class Macros
    {
        private static readonly IDictionary<string, IMacro> loadedMacros;
        private static readonly ReaderWriterLockSlim macroLock;

        static Macros()
        {
            loadedMacros = new Dictionary<string, IMacro>();
            macroLock = new ReaderWriterLockSlim();

            // load the default macros
            Register<HorizontalLineMacro>();
            Register<BoldMacro>();
            Register<ItalicsMacro>();
            Register<HeadingsMacro>();
            Register<LinkMacro>();
            Register<ImageMacro>();
            Register<ListMacro>();
            Register<EscapedMarkupMacro>();
        }

        /// <summary>
        /// Gets the entire list of currently registered macros.
        /// </summary>
        public static IEnumerable<IMacro> All
        {
            get { return loadedMacros.Values; }
        }

        /// <summary>
        /// Registers a new <see cref="IMacro" />.
        /// </summary>
        /// <typeparam name="TMacro">The <see cref="IMacro" /> to register. Must have a parameterless constructor.</typeparam>
        /// <exception cref="System.ArgumentNullException">Thrown when the Id of the macro is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the Id of the macro is empty.</exception>
        public static void Register<TMacro>()
            where TMacro : class, IMacro, new()
        {
            Register(new TMacro());
        }

        /// <summary>
        /// Registers a new <see cref="IMacro"/>.
        /// </summary>
        /// <param name="macro">The macro used for registration.</param>
        /// <remarks>This macro needs to be thread safe.</remarks>
        /// <exception cref="System.ArgumentNullException">
        /// <para>Thrown when the macro object is null</para>
        /// <para>- or -</para>
        /// <para>Thrown when the Id of the macro is null.</para>
        /// </exception>
        /// <exception cref="System.ArgumentException">Thrown when the Id of the macro is empty.</exception>
        public static void Register(IMacro macro)
        {
            Guard.NotNull(macro, "macro");
            Guard.NotNullOrEmpty(macro.Id, "macro", "The macro identifier must not be null or empty.");

            macroLock.EnterWriteLock();
            try
            {
                loadedMacros[macro.Id] = macro;
            }
            finally
            {
                macroLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Un-registers a <see cref="IMacro"/>.
        /// </summary>
        /// <typeparam name="TMacro">The type of <see cref="IMacro"/> to un-register. This type needs to have a parameterless constructor.</typeparam>
        /// <exception cref="System.ArgumentNullException">Thrown when the Id of the macro is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the Id of the macro is empty.</exception>
        public static void Unregister<TMacro>()
            where TMacro : class, IMacro, new()
        {
            Unregister(new TMacro());
        }

        /// <summary>
        /// Un-registers a <see cref="IMacro"/> based on the Id.
        /// </summary>
        /// <param name="macro">The macro to un-register.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <para>Thrown when the macro object is null</para>
        /// <para>- or -</para>
        /// <para>Thrown when the Id of the macro is null.</para>
        /// </exception>
        /// <exception cref="System.ArgumentException">Thrown when the Id of the macro is empty.</exception>
        public static void Unregister(IMacro macro)
        {
            Guard.NotNull(macro, "macro");
            Guard.NotNullOrEmpty(macro.Id, "macro", "The macro identifier must not be null or empty.");

            macroLock.EnterWriteLock();
            try
            {
                if (loadedMacros.ContainsKey(macro.Id))
                    loadedMacros.Remove(macro.Id);
            }
            finally
            {
                macroLock.ExitWriteLock();
            }
        }
    }
}