
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Backslashescapes: BaseTest
    {
        
        #region Example 273
        [Fact]
        public void Example273()
        {
            Assert.Equal(@"<p>!&quot;#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^_`{|}~</p>", GetHtml(@"\!\""\#\$\%\&\'\(\)\*\+\,\-\.\/\:\;\<\=\>\?\@\[\\\]\^\_\`\{\|\}\~"));
        }

        #endregion

        #region Example 274
        [Fact]
        public void Example274()
        {
            Assert.Equal(@"<p>\	\A\a\ \3\φ\«</p>", GetHtml(@"\	\A\a\ \3\φ\«"));
        }

        #endregion

        #region Example 275
        [Fact]
        public void Example275()
        {
            Assert.Equal(@"<p>*not emphasized*
&lt;br/&gt; not a tag
[not a link](/foo)
`not code`
1. not a list
* not a list
# not a header
[foo]: /url &quot;not a reference&quot;</p>", GetHtml(@"\*not emphasized*
\<br/> not a tag
\[not a link](/foo)
\`not code`
1\. not a list
\* not a list
\# not a header
\[foo]: /url ""not a reference"""));
        }

        #endregion

        #region Example 276
        [Fact]
        public void Example276()
        {
            Assert.Equal(@"<p>\<em>emphasis</em></p>", GetHtml(@"\\*emphasis*"));
        }

        #endregion

        #region Example 277
        [Fact]
        public void Example277()
        {
            Assert.Equal(@"<p>foo<br />
bar</p>", GetHtml(@"foo\
bar"));
        }

        #endregion

        #region Example 278
        [Fact]
        public void Example278()
        {
            Assert.Equal(@"<p><code>\[\`</code></p>", GetHtml(@"`` \[\` ``"));
        }

        #endregion

        #region Example 279
        [Fact]
        public void Example279()
        {
            Assert.Equal(@"<pre><code>\[\]
</code></pre>", GetHtml(@"    \[\]"));
        }

        #endregion

        #region Example 280
        [Fact]
        public void Example280()
        {
            Assert.Equal(@"<pre><code>\[\]
</code></pre>", GetHtml(@"~~~
\[\]
~~~"));
        }

        #endregion

        #region Example 281
        [Fact]
        public void Example281()
        {
            Assert.Equal(@"<p><a href=""http://example.com?find=%5C*"">http://example.com?find=\*</a></p>", GetHtml(@"<http://example.com?find=\*>"));
        }

        #endregion

        #region Example 282
        [Fact]
        public void Example282()
        {
            Assert.Equal(@"<a href=""/bar\/)"">", GetHtml(@"<a href=""/bar\/)"">"));
        }

        #endregion

        #region Example 283
        [Fact]
        public void Example283()
        {
            Assert.Equal(@"<p><a href=""/bar*"" title=""ti*tle"">foo</a></p>", GetHtml(@"[foo](/bar\* ""ti\*tle"")"));
        }

        #endregion

        #region Example 284
        [Fact]
        public void Example284()
        {
            Assert.Equal(@"<p><a href=""/bar*"" title=""ti*tle"">foo</a></p>", GetHtml(@"[foo]

[foo]: /bar\* ""ti\*tle"""));
        }

        #endregion

        #region Example 285
        [Fact]
        public void Example285()
        {
            Assert.Equal(@"<pre><code class=""language-foo+bar"">foo
</code></pre>", GetHtml(@"``` foo\+bar
foo
```"));
        }

        #endregion
    }
}