namespace CommonPlex.Common
{
    ///<summary>
    /// Defines the image url, text, link url, and dimensions for an image.
    ///</summary>
    public class ImagePart
    {
        /// <summary>
        /// Instantiates a new instance of <see cref="ImagePart"/>.
        /// </summary>
        /// <param name="imageUrl">The url to the image.</param>
        /// <param name="text">The text.</param>
        /// <param name="linkUrl">The url to the link.</param>
        /// <param name="dimensions">The dimensions of the image.</param>
        public ImagePart(string imageUrl, string text, string linkUrl, Dimensions dimensions)
        {
            ImageUrl = imageUrl;
            Text = text;
            LinkUrl = linkUrl;
            Dimensions = dimensions;
        }

        /// <summary>
        /// Gets the text of the image.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Gets the url of the image.
        /// </summary>
        public string ImageUrl { get; private set; }

        /// <summary>
        /// Gets the url of the link.
        /// </summary>
        public string LinkUrl { get; private set; }

        /// <summary>
        /// Gets the dimensions of the text.
        /// </summary>
        public Dimensions Dimensions { get; private set; }
    }
}