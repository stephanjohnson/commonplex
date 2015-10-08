using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonPlex.Common
{
    /// <summary>
    /// The static class to handle parameter extraction that is used across many renderers.
    /// </summary>
    public static class Parameters
    {
        /// <summary>
        /// This will extract a url.
        /// </summary>
        /// <param name="parameters">The collection of parameters.</param>
        /// <returns>The extracted url.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the url cannot be validated.
        /// 
        /// -- or --
        /// 
        /// Thrown if the url contains codeplex.com
        /// </exception>
        public static string ExtractUrl(ICollection<string> parameters)
        {
            return ExtractUrl(parameters, true);
        }

        /// <summary>
        /// This will extract a url.
        /// </summary>
        /// <param name="parameters">The collection of parameters.</param>
        /// <param name="validateDomain">Will validate the domain not allowing codeplex.com</param>
        /// <returns>The extracted url.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the url cannot be validated.
        /// 
        /// -- or --
        /// 
        /// Thrown if the url contains codeplex.com and validateDomain is true.
        /// </exception>
        public static string ExtractUrl(ICollection<string> parameters, bool validateDomain)
        {
            string url = GetValue(parameters, "url");

            try
            {
                var parsedUrl = new Uri(url, UriKind.Absolute);
                url = parsedUrl.AbsoluteUri;
            }
            catch
            {
                throw new ArgumentException("Invalid parameter.", "url");
            }

            if (validateDomain && url.ToLower().Contains("codeplex.com"))
                throw new ArgumentException("Invalid parameter.", "url");

            return url;
        }

        /// <summary>
        /// This will extract the horizontal alignment parameter.
        /// </summary>
        /// <param name="parameters">The collection of parameters.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The <see cref="HorizontalAlign"/> value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if the alignment value is not a valid enum value.
        /// 
        /// -- or --
        /// 
        /// Thrown if the alignment is not Center, Left, or Right
        /// </exception>
        public static HorizontalAlign ExtractAlign(ICollection<string> parameters, HorizontalAlign defaultValue)
        {
            string align;
            if (!TryGetValue(parameters, "align", out align))
                return defaultValue;

            if (!Utility.IsDefinedOnEnum<HorizontalAlign>(align))
                throw new ArgumentException("Invalid parameter.", "align");

            var alignment = (HorizontalAlign) Enum.Parse(typeof (HorizontalAlign), align, true);
            if (alignment != HorizontalAlign.Center && alignment != HorizontalAlign.Left && alignment != HorizontalAlign.Right)
                throw new ArgumentException("Invalid parameter.", "align");

            return alignment;
        }

        /// <summary>
        /// Will extract a boolean parameter.
        /// </summary>
        /// <param name="parameters">The collection of parameters.</param>
        /// <param name="paramName">The parameter name to extract.</param>
        /// <param name="defaultValue">The default value to use if the parameter is not found.</param>
        /// <returns>The parameter value.</returns>
        /// <exception cref="ArgumentException">Thrown if the value is not a valid boolean.</exception>
        public static bool ExtractBool(IEnumerable<string> parameters, string paramName, bool defaultValue)
        {
            string value;
            if (TryGetValue(parameters, paramName, out value))
            {
                bool outValue;
                if (!bool.TryParse(value, out outValue))
                    throw new ArgumentException("Invalid parameter.", paramName);

                return outValue;
            }

            return defaultValue;
        }

        /// <summary>
        /// This will extract the height and width dimensions parameters.
        /// </summary>
        /// <param name="parameters">The colleciton of parameters.</param>
        /// <returns>The <see cref="Dimensions"/> contained in the parameters.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if the height/width is not a valid unit.
        /// 
        /// -- or --
        /// 
        /// Thrown if the height/width is less than or equal to zero.
        /// </exception>
        public static Dimensions ExtractDimensions(ICollection<string> parameters)
        {
            return ExtractDimensions(parameters, null, null);
        }

        /// <summary>
        /// This will extract the height and width dimensions parameters.
        /// </summary>
        /// <param name="parameters">The colleciton of parameters.</param>
        /// <param name="defaultHeight">The default height.</param>
        /// <param name="defaultWidth">The default width.</param>
        /// <returns>The <see cref="Dimensions"/> contained in the parameters.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if the height/width is not a valid unit.
        /// 
        /// -- or --
        /// 
        /// Thrown if the height/width is less than or equal to zero.
        /// </exception>
        public static Dimensions ExtractDimensions(ICollection<string> parameters, int? defaultHeight, int? defaultWidth)
        {
            int? height = ParseUnit(parameters, "height", defaultHeight);
            int? width = ParseUnit(parameters, "width", defaultWidth);

            return new Dimensions {Height = height, Width = width};
        }

        private static int? ParseUnit(IEnumerable<string> parameters, string paramName, int? defaultValue)
        {
            string value;
            if (TryGetValue(parameters, paramName, out value))
            {
                try
                {
                    int unit = int.Parse(value);
                    if (unit <= 0)
                        throw new ArgumentException("Invalid parameter.", paramName);

                    return unit;
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Invalid parameter.", paramName);
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Will get the parameter value.
        /// </summary>
        /// <param name="parameters">The collection of parameters.</param>
        /// <param name="paramName">The parameter name to extract.</param>
        /// <returns>The parameter value.</returns>
        /// <exception cref="ArgumentException">Thrown if the paramName is not present in the collection of parameters.</exception>
        public static string GetValue(IEnumerable<string> parameters, string paramName)
        {
            string value;
            if (!TryGetValue(parameters, paramName, out value))
                throw new ArgumentException("Missing parameter.", paramName);

            return value;
        }

        /// <summary>
        /// Will get the parameter value.
        /// </summary>
        /// <param name="parameters">The collection of parameters.</param>
        /// <param name="paramName">The parameter name to extract.</param>
        /// <param name="value">The output value of the parameter name.</param>
        /// <returns>A boolean value indicating if the value was found or not.</returns>
        public static bool TryGetValue(IEnumerable<string> parameters, string paramName, out string value)
        {
            parameters = Normalize(parameters);

            value = null;
            string paramValue = parameters.FirstOrDefault(s => s.StartsWith(paramName + "=", StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(paramValue))
                return false;

            paramValue = paramValue.Substring(paramName.Length + 1);
            if (string.IsNullOrEmpty(paramValue))
                return false;

            value = paramValue;
            return true;
        }

        private static IEnumerable<string> Normalize(IEnumerable<string> parameters)
        {
            var normalized = new List<string>();

            string current = null;
            foreach (string param in parameters)
            {
                int index = param.IndexOf('=');

                if (index > 0 && index < param.Length - 1)
                {
                    if (!string.IsNullOrEmpty(current))
                        normalized.Add(current);

                    current = param;
                    continue;
                }

                current += string.Format(",{0}", param);
            }

            if (!string.IsNullOrEmpty(current))
                normalized.Add(current);

            return normalized;
        }
    }
}