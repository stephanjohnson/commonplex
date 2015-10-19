using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Precedence : BaseTest
    {
        #region Example 07

        [Fact]
        public void Example07()
        {
            Assert.Equal("<ul><li>`one</li><li>two`</li></ul>", GetHtml("- `one\r\n- two`"));
        }

        #endregion
    }
}