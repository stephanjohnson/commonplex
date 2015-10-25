
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Paragraphs: BaseTest
    {
        
        #region Example 169
        [Fact]
        public void Example169()
        {
            Assert.Equal(@"<p>aaa</p>
<p>bbb</p>
", GetHtml(@"aaa

bbb
"));
        }

        #endregion

        #region Example 170
        [Fact]
        public void Example170()
        {
            Assert.Equal(@"<p>aaa
bbb</p>
<p>ccc
ddd</p>
", GetHtml(@"aaa
bbb

ccc
ddd
"));
        }

        #endregion

        #region Example 171
        [Fact]
        public void Example171()
        {
            Assert.Equal(@"<p>aaa</p>
<p>bbb</p>
", GetHtml(@"aaa


bbb
"));
        }

        #endregion

        #region Example 172
        [Fact]
        public void Example172()
        {
            Assert.Equal(@"<p>aaa
bbb</p>
", GetHtml(@"  aaa
 bbb
"));
        }

        #endregion

        #region Example 173
        [Fact]
        public void Example173()
        {
            Assert.Equal(@"<p>aaa
bbb
ccc</p>
", GetHtml(@"aaa
             bbb
                                       ccc
"));
        }

        #endregion

        #region Example 174
        [Fact]
        public void Example174()
        {
            Assert.Equal(@"<p>aaa
bbb</p>
", GetHtml(@"   aaa
bbb
"));
        }

        #endregion

        #region Example 175
        [Fact]
        public void Example175()
        {
            Assert.Equal(@"<pre><code>aaa
</code></pre>
<p>bbb</p>
", GetHtml(@"    aaa
bbb
"));
        }

        #endregion

        #region Example 176
        [Fact]
        public void Example176()
        {
            Assert.Equal(@"<p>aaa<br />
bbb</p>
", GetHtml(@"aaa     
bbb     
"));
        }

        #endregion
    }
}