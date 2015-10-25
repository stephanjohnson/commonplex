
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Tabs: BaseTest
    {
        
        #region Example 001
        [Fact]
        public void Example001()
        {
            Assert.Equal(@"<pre><code>foo	baz		bim
</code></pre>", GetHtml(@"	foo	baz		bim"));
        }

        #endregion

        #region Example 002
        [Fact]
        public void Example002()
        {
            Assert.Equal(@"<pre><code>foo	baz		bim
</code></pre>", GetHtml(@"  	foo	baz		bim"));
        }

        #endregion

        #region Example 003
        [Fact]
        public void Example003()
        {
            Assert.Equal(@"<pre><code>a	a
ὐ	a
</code></pre>", GetHtml(@"    a	a
    ὐ	a"));
        }

        #endregion

        #region Example 004
        [Fact]
        public void Example004()
        {
            Assert.Equal(@"<ul>
<li>
<p>foo</p>
<p>bar</p>
</li>
</ul>", GetHtml(@"  - foo

	bar"));
        }

        #endregion

        #region Example 005
        [Fact]
        public void Example005()
        {
            Assert.Equal(@"<blockquote>
<p>foo	bar</p>
</blockquote>", GetHtml(@">	foo	bar"));
        }

        #endregion

        #region Example 006
        [Fact]
        public void Example006()
        {
            Assert.Equal(@"<pre><code>foo
bar
</code></pre>", GetHtml(@"    foo
	bar"));
        }

        #endregion
    }
}