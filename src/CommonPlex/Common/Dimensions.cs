namespace CommonPlex.Common
{
    /// <summary>
    /// Defines a height and width dimension used for images, videos, and silverlight applications.
    /// </summary>
    public class Dimensions
    {
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Overrides the ToString method to output the html height / width attributes.
        /// </summary>
        /// <returns>The height / width attributes string.</returns>
        public override string ToString()
        {
            string output = string.Empty;
            if (Height.HasValue)
                output += "height=\"" + Height + "\" ";
            if (Width.HasValue)
                output += "width=\"" + Width + "\" ";

            return output;
        }
    }
}