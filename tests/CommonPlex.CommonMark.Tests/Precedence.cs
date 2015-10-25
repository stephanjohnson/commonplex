
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Precedence: BaseTest
    {
        
        #region Example 007
        [Fact]
        public void Example007()
        {
            Assert.Equal(@"<ul>
<li>`one</li>
<li>two`</li>
</ul>", GetHtml(@"- `one
- two`"));
        }

        #endregion
    }
}