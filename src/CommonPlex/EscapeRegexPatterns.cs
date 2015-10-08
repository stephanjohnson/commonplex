namespace CommonPlex
{
    /// <summary>
    /// Exposes commonly used regex escape patterns.
    /// </summary>
    public static class EscapeRegexPatterns
    {
        /// <summary>
        /// The regex pattern for escaping content within double curly brace code blocks.
        /// </summary>
        public const string CurlyBraceEscape = @"(?:(?:(?<![<>:]){{?)(?>[^}]*)(?:}}?(?![<>:])))";

        /// <summary>
        /// The regex pattern for escaping content within all code blocks.
        /// </summary>
        public const string FullEscape = @"(?s){{.*?}}|{"".*?""}|(?<![<>:]){(?!"").*?(?<!"")}(?![<>:])|\[.*?\]";
    }
}