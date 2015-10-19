using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class BaseTest
    {
        static RenderEngine s_renderer = new RenderEngine();

        protected static string GetHtml(string markdown)
        {
            return s_renderer.Render(markdown);
        }
    }
}
