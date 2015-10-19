using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Tabs: BaseTest
    {
        #region Example 01

        [Fact]
        public void Example01()
        {
            Assert.Equal("<pre><code>foo\tbaz\t\tbim</code></pre>", GetHtml("\tfoo\tbaz\t\tbim"));
        }

        #endregion

        #region Example 02

        [Fact]
        public void Example02()
        {
            Assert.Equal("<pre><code>foo\tbaz\t\tbim</code></pre>", GetHtml("  \tfoo\tbaz\t\tbim"));
        }

        #endregion

        #region Example 03

        [Fact]
        public void Example03()
        {
            Assert.Equal("<pre><code>a\taὐ\ta</code></pre>", GetHtml("    a\ta\r\n    ὐ\ta"));
        }

        #endregion

        #region Example 04

        [Fact]
        public void Example04()
        {
            Assert.Equal("<ul><li><p>foo</p><p>bar</p></li></ul>", GetHtml("  - foo\r\n\r\n\tbar"));
        }

        #endregion

        #region Example 05

        [Fact]
        public void Example05()
        {
            Assert.Equal("<blockquote><p>foo\tbar</p></blockquote>", GetHtml(">\tfoo\tbar"));
        }

        #endregion

        #region Example 06

        [Fact]
        public void Example06()
        {
            Assert.Equal("<pre><code>foobar</code></pre>", GetHtml("    foo\r\n\tbar"));
        }

        #endregion
    }
}