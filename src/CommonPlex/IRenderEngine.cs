using System.Collections.Generic;
using CommonPlex.Compilation.Macros;
using CommonPlex.Formatting;
using CommonPlex.Formatting.Renderers;

namespace CommonPlex
{
    /// <summary>
    /// Defines the <see cref="RenderEngine" /> contract.
    /// </summary>
    public interface IRenderEngine
    {
        /// <summary>
        /// Renders the wiki content using the statically registered macros and renderers.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <returns>The rendered html content.</returns>
        string Render(string wikiContent);

        /// <summary>
        /// Renders the wiki content using the a custom formatter with statically registered macros.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <param name="formatter">The custom formatter used when rendering.</param>
        /// <returns>The rendered html content.</returns>
        string Render(string wikiContent, Formatter formatter);

        /// <summary>
        /// Renders the wiki content using the specified macros and statically registered renderers.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <param name="macros">A collection of macros to be used when rendering.</param>
        /// <returns>The rendered html content.</returns>
        string Render(string wikiContent, IEnumerable<IMacro> macros);

        /// <summary>
        /// Renders the wiki content using the specified renderers with statically registered macros.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <param name="renderers">A collection of renderers to be used when rendering.</param>
        /// <returns>The rendered html content.</returns>
        string Render(string wikiContent, IEnumerable<IRenderer> renderers);

        /// <summary>
        /// Renders the wiki content using the specified macros and renderers.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <param name="macros">A collection of macros to be used when rendering.</param>
        /// <param name="renderers">A collection of renderers to be used when rendering.</param>
        /// <returns>The rendered html content.</returns>
        string Render(string wikiContent, IEnumerable<IMacro> macros, IEnumerable<IRenderer> renderers);

        /// <summary>
        /// Renders the wiki content using the specified macros and custom formatter.
        /// </summary>
        /// <param name="wikiContent">The wiki content to be rendered.</param>
        /// <param name="macros">A collection of macros to be used when rendering.</param>
        /// <param name="formatter">The custom formatter used when rendering.</param>
        /// <returns>The rendered html content.</returns>
        string Render(string wikiContent, IEnumerable<IMacro> macros, Formatter formatter);
    }
}