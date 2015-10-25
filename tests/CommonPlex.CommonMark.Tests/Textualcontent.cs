
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Textualcontent: BaseTest
    {
        
        #region Example 597
        [Fact]
        public void Example597()
        {
            Assert.Equal(@"<p>hello $.;'there</p>", GetHtml(@"hello $.;'there"));
        }

        #endregion

        #region Example 598
        [Fact]
        public void Example598()
        {
            Assert.Equal(@"<p>Foo χρῆν</p>", GetHtml(@"Foo χρῆν"));
        }

        #endregion

        #region Example 599
        [Fact]
        public void Example599()
        {
            Assert.Equal(@"<p>Multiple     spaces</p>", GetHtml(@"Multiple     spaces"));
        }

        #endregion
    }
}