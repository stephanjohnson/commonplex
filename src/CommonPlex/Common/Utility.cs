using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommonPlex.Common
{
    /// <summary>
    /// The static utility class containing useful common methods.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Determines if the input is defined on an enumeration.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="input">The input to check.</param>
        /// <returns>A boolean value indicating if the input is defined on the enumeration.</returns>
        /// <exception cref="ArgumentException">Thrown when the type T is not an enum.</exception>
        public static bool IsDefinedOnEnum<T>(object input)
            where T : struct
        {
            Type type = typeof(T);
            Guard.NotEqual(false, Enum.GetUnderlyingType(type) != null, "type");

            if (Enum.IsDefined(type, input))
                return true;

            return Enum.GetNames(type)
                       .Where(n => string.Compare(input.ToString(), n, StringComparison.OrdinalIgnoreCase) == 0)
                       .Count() == 1;
        }

        /// <summary>
        /// Will extract the text single or pair text parts of a string, separated by a |.
        /// </summary>
        /// <param name="input">The input to inspect.</param>
        /// <returns>A new <see cref="TextPart"/>.</returns>
        /// <remarks>If there are 2 parts, the first is the text, and the second is the friendly text. Otherwise, only the text is set.</remarks>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the input is empty.
        /// 
        /// -- or --
        /// 
        /// Thrown when there are more than 2 parts found.
        /// </exception>
        public static TextPart ExtractTextParts(string input)
        {
            Guard.NotNullOrEmpty(input, "input");
            string[] parts = input.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 2)
                throw new ArgumentException("Invalid number of parts.", "input");

            if (parts.Length == 1)
                return new TextPart(parts[0].Trim(), null);

            return new TextPart(parts[1].Trim(), parts[0].Trim());
        }

        /// <summary>
        /// Will extract the single text or pair text parts of a string, separated by a |, including the dimensions for the text part.
        /// </summary>
        /// <param name="input">The input to inspect.</param>
        /// <param name="partExtras">The image part extras to extract.</param>
        /// <returns>A new <see cref="ImagePart"/>.</returns>
        /// <remarks>If there are 2 parts, the first is the text, and the second is the friendly text. Otherwise, only the text is set. Also, should the text contain dimensions, they will be set.</remarks>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the input is empty.
        /// 
        /// -- or --
        /// 
        /// Thrown when there are more than 2 parts found.
        /// 
        /// -- or --
        /// 
        /// Thrown if the extracted url cannot be parsed.
        /// 
        /// -- or --
        /// 
        /// Thrown if the height/width is not a valid unit.
        /// 
        /// -- or --
        /// 
        /// Thrown when the height/width is less than or equal to zero.
        /// </exception>
        public static ImagePart ExtractImageParts(string input, ImagePartExtras partExtras)
        {
            return ExtractImageParts(input, partExtras, true);
        }

        /// <summary>
        /// Will extract the single text or pair text parts of a string, separated by a |, including the dimensions for the text part.
        /// </summary>
        /// <param name="input">The input to inspect.</param>
        /// <param name="partExtras">The image part extras to extract.</param>
        /// <param name="parseUrl">Will parse the url and validate it with <see cref="Uri"/>Uri</param>.
        /// <returns>A new <see cref="ImagePart"/>.</returns>
        /// <remarks>If there are 2 parts, the first is the text, and the second is the friendly text. Otherwise, only the text is set. Also, should the text contain dimensions, they will be set.</remarks>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the input is empty.
        /// 
        /// -- or --
        /// 
        /// Thrown when there are more than 2 parts found.
        /// 
        /// -- or --
        /// 
        /// Thrown if the extracted url cannot be parsed when parseUrl is true.
        ///
        /// 
        /// -- or --
        /// 
        /// Thrown if the height/width is not a valid unit.
        /// 
        /// -- or --
        /// 
        /// Thrown when the height/width is less than or equal to zero.
        /// </exception>
        public static ImagePart ExtractImageParts(string input, ImagePartExtras partExtras, bool parseUrl)
        {
            Guard.NotNullOrEmpty(input, "input");
            string[] parts = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 3)
                throw new ArgumentException("Invalid number of parts.", "input");

            string imageUrl, text = null, linkUrl = null;

            if (parts.Length == 1)
                imageUrl = parts[0].Trim();
            else if ((partExtras & ImagePartExtras.ContainsText) == ImagePartExtras.ContainsText)
                imageUrl = parts[1].Trim();
            else if ((partExtras & ImagePartExtras.ContainsLink) == ImagePartExtras.ContainsLink)
                imageUrl = parts[0].Trim();
            else
                throw new ArgumentException("Invalid number of parts.", "input");

            if (parts.Length > 1 && (partExtras & ImagePartExtras.ContainsText) == ImagePartExtras.ContainsText)
                text = parts[0].Trim();

            if (parts.Length > 1 && (partExtras & ImagePartExtras.ContainsLink) == ImagePartExtras.ContainsLink)
                linkUrl = parts.Length == 3 ? parts[2].Trim() : parts[1].Trim();

            string toSplit = string.Format("{0}{1}", parseUrl ? "url=" : string.Empty, imageUrl);
            string[] parameters = toSplit.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            string url = parseUrl ? Parameters.ExtractUrl(parameters, false) : parameters[0];

            if ((partExtras & ImagePartExtras.ContainsData) == ImagePartExtras.ContainsData && parameters.Length < 2)
                throw new ArgumentException("Invalid number of parameters, cannot find image data.", "input");
            if ((partExtras & ImagePartExtras.ContainsData) == ImagePartExtras.ContainsData)
                url = string.Format("{0},{1}", url, parameters[1]);

            return new ImagePart(url, text, linkUrl, Parameters.ExtractDimensions(parameters));
        }

        /// <summary>
        /// Will count the number of occurences a character is in an string.
        /// </summary>
        /// <param name="toFind">The character to find.</param>
        /// <param name="input">The input string.</param>
        /// <returns>The number of occurrances.</returns>
        public static int CountChars(char toFind, string input)
        {
            return string.IsNullOrEmpty(input) 
                        ? 0 
                        : input.Count(c => c == toFind);
        }

        /// <summary>
        /// Will extract the first group fragment from an input based on a regular expression.
        /// </summary>
        /// <param name="regex">The regex to use.</param>
        /// <param name="input">The input to inspect.</param>
        /// <returns>The extracted fragment, empty string if not found.</returns>
        public static string ExtractFragment(Regex regex, string input)
        {
            Match match = regex.Match(input);
            if (match.Success && match.Groups.Count > 1)
                return match.Groups[1].Value;

            return string.Empty;
        }
    }
}