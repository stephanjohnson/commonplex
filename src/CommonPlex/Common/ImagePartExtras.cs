using System;

namespace CommonPlex.Common
{
    /// <summary>
    /// Contains the image part extras that should be extracted.
    /// </summary>
    [Flags]
    public enum ImagePartExtras
    {
        /// <summary>
        /// Default. This indicates no extras should be extracted.
        /// </summary>
        None = 0x0,
        
        /// <summary>
        /// Indicates the input contains text.
        /// </summary>
        ContainsText = 0x1,

        /// <summary>
        /// Indicates the input contains a link.
        /// </summary>
        ContainsLink = 0x2,

        /// <summary>
        /// Indicates that the input contains both text and link.
        /// </summary>
        [Obsolete("This should no longer be used. All is no longer correct, it really means (ContainsText | ContainsLink).")]
        All = 0x3,

        /// <summary>
        /// Indicates the input contains data
        /// </summary>
        ContainsData = 0x4
    }
}