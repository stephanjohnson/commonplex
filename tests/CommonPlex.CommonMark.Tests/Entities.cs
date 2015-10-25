
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Entities: BaseTest
    {
        
        #region Example 286
        [Fact]
        public void Example286()
        {
            Assert.Equal(@"<p>  &amp; © Æ Ď
¾ ℋ ⅆ
∲ ≧̸</p>
", GetHtml(@"&nbsp; &amp; &copy; &AElig; &Dcaron;
&frac34; &HilbertSpace; &DifferentialD;
&ClockwiseContourIntegral; &ngE;
"));
        }

        #endregion

        #region Example 287
        [Fact]
        public void Example287()
        {
            Assert.Equal(@"<p># Ӓ Ϡ � �</p>
", GetHtml(@"&#35; &#1234; &#992; &#98765432; &#0;
"));
        }

        #endregion

        #region Example 288
        [Fact]
        public void Example288()
        {
            Assert.Equal(@"<p>&quot; ആ ಫ</p>
", GetHtml(@"&#X22; &#XD06; &#xcab;
"));
        }

        #endregion

        #region Example 289
        [Fact]
        public void Example289()
        {
            Assert.Equal(@"<p>&amp;nbsp &amp;x; &amp;#; &amp;#x; &amp;ThisIsWayTooLongToBeAnEntityIsntIt; &amp;hi?;</p>
", GetHtml(@"&nbsp &x; &#; &#x; &ThisIsWayTooLongToBeAnEntityIsntIt; &hi?;
"));
        }

        #endregion

        #region Example 290
        [Fact]
        public void Example290()
        {
            Assert.Equal(@"<p>&amp;copy</p>
", GetHtml(@"&copy
"));
        }

        #endregion

        #region Example 291
        [Fact]
        public void Example291()
        {
            Assert.Equal(@"<p>&amp;MadeUpEntity;</p>
", GetHtml(@"&MadeUpEntity;
"));
        }

        #endregion

        #region Example 292
        [Fact]
        public void Example292()
        {
            Assert.Equal(@"<a href=""&ouml;&ouml;.html"">
", GetHtml(@"<a href=""&ouml;&ouml;.html"">
"));
        }

        #endregion

        #region Example 293
        [Fact]
        public void Example293()
        {
            Assert.Equal(@"<p><a href=""/f%C3%B6%C3%B6"" title=""föö"">foo</a></p>
", GetHtml(@"[foo](/f&ouml;&ouml; ""f&ouml;&ouml;"")
"));
        }

        #endregion

        #region Example 294
        [Fact]
        public void Example294()
        {
            Assert.Equal(@"<p><a href=""/f%C3%B6%C3%B6"" title=""föö"">foo</a></p>
", GetHtml(@"[foo]

[foo]: /f&ouml;&ouml; ""f&ouml;&ouml;""
"));
        }

        #endregion

        #region Example 295
        [Fact]
        public void Example295()
        {
            Assert.Equal(@"<pre><code class=""language-föö"">foo
</code></pre>
", GetHtml(@"``` f&ouml;&ouml;
foo
```
"));
        }

        #endregion

        #region Example 296
        [Fact]
        public void Example296()
        {
            Assert.Equal(@"<p><code>f&amp;ouml;&amp;ouml;</code></p>
", GetHtml(@"`f&ouml;&ouml;`
"));
        }

        #endregion

        #region Example 297
        [Fact]
        public void Example297()
        {
            Assert.Equal(@"<pre><code>f&amp;ouml;f&amp;ouml;
</code></pre>
", GetHtml(@"    f&ouml;f&ouml;
"));
        }

        #endregion
    }
}