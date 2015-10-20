using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class SetextHeaders : BaseTest
    {
        #region Example 45

        [Fact]
        public void Example45_H1()
        {
            Assert.Equal("<h1>Foo <em>bar</em></h1>", GetHtml("Foo *bar*\r\n========="));
        }

        [Fact]
        public void Example45_H2()
        {
            Assert.Equal("<h2>Foo <em>bar</em></h2>", GetHtml("Foo *bar*\r\n---------"));
        }

        #endregion

        #region Example 46

        [Fact]
        public void Example46_H1()
        {
            Assert.Equal("<h1>Foo</h1>", GetHtml("Foo\r\n="));
        }

        [Fact]
        public void Example46_H2()
        {
            Assert.Equal("<h2>Foo</h2>", GetHtml("Foo\r\n-------------------------"));
        }

        #endregion

        #region Example 47

        [Fact]
        public void Example47_H1()
        {
            Assert.Equal("<h1>Foo</h1>", GetHtml("  Foo\r\n  ==="));
        }

        [Fact]
        public void Example47_H2_1()
        {
            Assert.Equal("<h2>Foo</h2>", GetHtml("  Foo\r\n---"));
        }

        [Fact]
        public void Example47_H2_2()
        {
            Assert.Equal("<h2>Foo</h2>", GetHtml("  Foo\r\n-----"));
        }

        #endregion

        #region Example 48

        [Fact]
        public void Example48()
        {
            Assert.Equal("<pre><code>Foo---Foo</code></pre><hr />", GetHtml("    Foo\r\n    ---\r\n\r\n    Foo\r\n---"));
        }

        #endregion

        #region Example 49

        [Fact]
        public void Example49()
        {
            Assert.Equal("<h2>Foo</h2>", GetHtml("Foo\r\n   ----      "));
        }

        #endregion

        #region Example 50

        [Fact]
        public void Example50()
        {
            Assert.Equal("<p>Foo---</p>", GetHtml("Foo\r\n    ----"));
        }

        #endregion

        #region Example 51

        [Fact]
        public void Example51_1()
        {
            Assert.Equal("<p>Foo= =</p>", GetHtml("Foo\r\n= ="));
        }

        [Fact]
        public void Example51_2()
        {
            Assert.Equal("<p>Foo</p><hr />", GetHtml("Foo\r\n--- -"));
        }

        #endregion

        #region Example 52

        [Fact]
        public void Example52()
        {
            Assert.Equal("<h2>Foo</h2>", GetHtml("Foo  \r\n-----"));
        }

        #endregion

        #region Example 53

        [Fact]
        public void Example53()
        {
            Assert.Equal("<h2>Foo</h2>", GetHtml("Foo\\\r\n----"));
        }

        #endregion

        #region Example 54

        [Fact]
        public void Example54_1()
        {
            Assert.Equal("<h2>`Foo</h2><p>`</p>", GetHtml("`Foo\r\n----\r\n`"));
        }

        [Fact]
        public void Example54_2()
        {
            Assert.Equal("<h2>&lt;a title=&quot;a lot</h2><p>of dashes&quot;/&gt;</p>", GetHtml("<a title=\"a lot\r\n-- -\r\nof dashes\"/>"));
        }

        #endregion

        #region Example 55

        [Fact]
        public void Example55()
        {
            Assert.Equal("<blockquote><p>Foo</p></blockquote><hr />", GetHtml("> Foo\r\n---"));
        }

        #endregion

        #region Example 56

        [Fact]
        public void Example56()
        {
            Assert.Equal("<ul><li>Foo</li></ul><hr />", GetHtml("- Foo\r\n---"));
        }

        #endregion

        #region Example 57

        [Fact]
        public void Example57()
        {
            Assert.Equal("<p>FooBar</p><hr /><p>FooBar===</p>", GetHtml("Foo\r\nBar\r\n---\r\n\r\nFoo\r\nBar\r\n==="));
        }

        #endregion

        #region Example 58

        [Fact]
        public void Example58()
        {
            Assert.Equal("<hr /><h2>Foo</h2><h2>Bar</h2><p>Baz</p>", GetHtml("---\r\nFoo\r\n---\r\nBar\r\n---\r\nBaz"));
        }

        #endregion

        #region Example 59

        [Fact]
        public void Example59()
        {
            Assert.Equal("<p>====</p>", GetHtml("\r\n===="));
        }

        #endregion

        #region Example 60

        [Fact]
        public void Example60()
        {
            Assert.Equal("<hr /><hr />", GetHtml("---\r\n---"));
        }

        #endregion

        #region Example 61

        [Fact]
        public void Example61()
        {
            Assert.Equal("<ul><li>foo</li></ul><hr />", GetHtml("- foo\r\n-----"));
        }

        #endregion

        #region Example 62

        [Fact]
        public void Example62()
        {
            Assert.Equal("<pre><code>foo</code></pre><hr />", GetHtml("    foo\r\n---"));
        }

        #endregion

        #region Example 63

        [Fact]
        public void Example63()
        {
            Assert.Equal("<blockquote><p>foo</p></blockquote><hr />", GetHtml("> foo\r\n-----"));
        }

        #endregion

        #region Example 64

        [Fact]
        public void Example64()
        {
            Assert.Equal("<h2>&gt; foo</h2>", GetHtml("\\> foo\r\n------"));
        }

        #endregion
    }
}