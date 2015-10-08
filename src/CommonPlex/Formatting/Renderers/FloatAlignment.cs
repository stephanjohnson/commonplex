namespace CommonPlex.Formatting.Renderers
{
    internal enum FloatAlignment
    {
        None,
        Left,
        Right
    }

    internal static class FloatAlignmentExtensions
    {
        internal static string GetStyle(this FloatAlignment alignment)
        {
            switch (alignment)
            {
                case FloatAlignment.Left:
                    return "left";
                case FloatAlignment.Right:
                    return "right";
                default:
                    return string.Empty;
            }
        }

        internal static string GetPadding(this FloatAlignment alignment)
        {
            switch (alignment)
            {
                case FloatAlignment.Left:
                    return "padding-right:.5em;";
                case FloatAlignment.Right:
                    return "padding-left:.5em;";
                default:
                    return string.Empty;
            }
        }
    }
}