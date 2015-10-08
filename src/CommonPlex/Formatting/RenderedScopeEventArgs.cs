using System;
using CommonPlex.Parsing;

namespace CommonPlex.Formatting
{
    /// <summary>
    /// The event arguments used when a scope is rendered.
    /// </summary>
    public class RenderedScopeEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderedScopeEventArgs"/> class.
        /// </summary>
        /// <param name="scope">The scope name.</param>
        /// <param name="content">The content.</param>
        /// <param name="renderedContent">The rendered content.</param>
        public RenderedScopeEventArgs(Scope scope, string content, string renderedContent)
        {
            Scope = scope;
            Content = content;
            RenderedContent = renderedContent;
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Gets the rendered content.
        /// </summary>
        public string RenderedContent { get; private set; }

        /// <summary>
        /// Gets the scope.
        /// </summary>
        public Scope Scope { get; private set; }
    }
}