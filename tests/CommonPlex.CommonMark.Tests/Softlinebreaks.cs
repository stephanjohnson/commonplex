
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Softlinebreaks: BaseTest
    {
        
        #region Example 595
        [Fact]
        public void Example595()
        {
            Assert.Equal(@"<p>foo
baz</p>", GetHtml(@"foo
baz"));
        }

        #endregion

        #region Example 596
        [Fact]
        public void Example596()
        {
            Assert.Equal(@"<p>foo
baz</p>", GetHtml(@"foo 
 baz"));
        }

        #endregion
    }
}