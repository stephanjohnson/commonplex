namespace CommonPlex.Common
{
    /// <summary>
    /// Defines a text and friendly text part.
    /// </summary>
    public class TextPart
    {
        /// <summary>
        /// Instantiates a new instance of <see cref="TextPart"/>.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="friendlyText">The friendly text.</param>
        public TextPart(string text, string friendlyText)
        {
            Text = text;
            FriendlyText = friendlyText;
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Gets the friendly text.
        /// </summary>
        public string FriendlyText { get; private set; }
    }
}