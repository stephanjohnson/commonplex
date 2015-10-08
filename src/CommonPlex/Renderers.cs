using System.Collections.Generic;
using System.Threading;
using CommonPlex.Common;
using CommonPlex.Formatting;
using CommonPlex.Formatting.Renderers;

namespace CommonPlex
{
    /// <summary>
    /// The static entry point for registering <see cref="IRenderer" />s for all instances of a <see cref="IWikiEngine" />.
    /// </summary>
    /// <remarks>For convienience, all <see cref="IRenderer"/>s that are shipped with CommonPlex are already registered.</remarks>
    public class Renderers
    {
        private static readonly IDictionary<string, IRenderer> loadedRenderers;
        private static readonly ReaderWriterLockSlim rendererLock;

        static Renderers()
        {
            loadedRenderers = new Dictionary<string, IRenderer>();
            rendererLock = new ReaderWriterLockSlim();

            // load the default renderers
            Register<TextFormattingRenderer>();
            Register<LinkRenderer>();
            Register<ImageRenderer>();
            Register<ListItemRenderer>();
        }

        /// <summary>
        /// Gets the entire list of currently registered renderers.
        /// </summary>
        public static IEnumerable<IRenderer> All
        {
            get { return loadedRenderers.Values; }
        }

        /// <summary>
        /// Registers a new <see cref="IRenderer" />.
        /// </summary>
        /// <typeparam name="TRenderer">The <see cref="IRenderer" /> to register. Must have a parameterless constructor.</typeparam>
        /// <exception cref="System.ArgumentNullException">Thrown when the Id of the renderer is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the Id of the renderer is empty.</exception>
        public static void Register<TRenderer>()
            where TRenderer : class, IRenderer, new()
        {
            Register(new TRenderer());
        }

        /// <summary>
        /// Registers a new <see cref="IRenderer"/>.
        /// </summary>
        /// <param name="renderer">The renderer used for registration.</param>
        /// <remarks>This renderer needs to be thread safe.</remarks>
        /// <exception cref="System.ArgumentNullException">
        /// <para>Thrown when the renderer object is null</para>
        /// <para>- or -</para>
        /// <para>Thrown when the Id of the renderer is null.</para>
        /// </exception>
        /// <exception cref="System.ArgumentException">Thrown when the Id of the renderer is empty.</exception>
        public static void Register(IRenderer renderer)
        {
            Guard.NotNull(renderer, "renderer");
            Guard.NotNullOrEmpty(renderer.Id, "renderer", "The renderer identifier must not be null or empty.");

            rendererLock.EnterWriteLock();
            try
            {
                loadedRenderers[renderer.Id] = renderer;
            }
            finally
            {
                rendererLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Un-registers a <see cref="IRenderer"/>.
        /// </summary>
        /// <typeparam name="TRenderer">The type of <see cref="IRenderer"/> to un-register. This type needs to have a parameterless constructor.</typeparam>
        /// <exception cref="System.ArgumentNullException">Thrown when the Id of the renderer is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the Id of the renderer is empty.</exception>
        public static void Unregister<TRenderer>()
            where TRenderer : class, IRenderer, new()
        {
            Unregister(new TRenderer());
        }

        /// <summary>
        /// Un-registers a <see cref="IRenderer"/> based on the Id.
        /// </summary>
        /// <param name="renderer">The renderer to un-register.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <para>Thrown when the renderer object is null</para>
        /// <para>- or -</para>
        /// <para>Thrown when the Id of the renderer is null.</para>
        /// </exception>
        /// <exception cref="System.ArgumentException">Thrown when the Id of the renderer is empty.</exception>
        public static void Unregister(IRenderer renderer)
        {
            Guard.NotNull(renderer, "renderer");
            Guard.NotNullOrEmpty(renderer.Id, "renderer", "The renderer identifier must not be null or empty.");

            rendererLock.EnterWriteLock();
            try
            {
                if (loadedRenderers.ContainsKey(renderer.Id))
                    loadedRenderers.Remove(renderer.Id);
            }
            finally
            {
                rendererLock.ExitWriteLock();
            }
        }
    }
}