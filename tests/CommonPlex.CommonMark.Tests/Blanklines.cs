
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Blanklines: BaseTest
    {
        
        #region Example 177
        [Fact]
        public void Example177()
        {
            Assert.Equal(@"<p>aaa</p>
<h1>aaa</h1>
", GetHtml(@"  

aaa
  

# aaa

  
"));
        }

        #endregion
    }
}