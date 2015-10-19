using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Template: BaseTest
    {
        #region Example

        [Fact]
        public void Example()
        {
            Assert.Equal("", GetHtml(""));
        }

        #endregion
    }
}