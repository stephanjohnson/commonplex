
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Inlines: BaseTest
    {
        
        #region Example 272
        [Fact]
        public void Example272()
        {
            Assert.Equal(@"<p><code>hi</code>lo`</p>", GetHtml(@"`hi`lo`"));
        }

        #endregion
    }
}