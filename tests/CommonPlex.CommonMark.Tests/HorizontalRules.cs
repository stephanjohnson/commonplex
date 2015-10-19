using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class HorizontalRules: BaseTest
    {
        #region Example 08

        [Fact]
        public void Example08_1()
        {
            Assert.Equal("<hr />", GetHtml("***"));
        }

        [Fact]
        public void Example08_2()
        {
            Assert.Equal("<hr />", GetHtml("---"));
        }

        [Fact]
        public void Example08_3()
        {
            Assert.Equal("<hr />", GetHtml("___"));
        }

        #endregion

        #region Example 09

        [Fact]
        public void Example09()
        {
            Assert.Equal("<p>+++</p>", GetHtml("+++"));
        }

        #endregion

        #region Example 10

        [Fact]
        public void Example10()
        {
            Assert.Equal("<p>===</p>", GetHtml("==="));
        }

        #endregion

        #region Example 11

        [Fact]
        public void Example11()
        {
            Assert.Equal("<p>--**__</p>", GetHtml("--\r\n**\r\n__"));
        }

        #endregion

        #region Example 12

        [Fact]
        public void Example12_1()
        {
            Assert.Equal("<hr />", GetHtml(" ***"));
        }

        [Fact]
        public void Example12_2()
        {
            Assert.Equal("<hr />", GetHtml("  ***"));
        }

        [Fact]
        public void Example12_3()
        {
            Assert.Equal("<hr />", GetHtml("   ***"));
        }

        #endregion

        #region Example 13

        [Fact]
        public void Example13()
        {
            Assert.Equal("<pre><code>***</code></pre>", GetHtml("    ***"));
        }

        #endregion

        #region Example 14

        [Fact]
        public void Example14()
        {
            Assert.Equal("<p>Foo***</p>", GetHtml("Foo\r\n    ***"));
        }

        #endregion

        #region Example 15

        [Fact]
        public void Example15()
        {
            Assert.Equal("<hr />", GetHtml("_____________________________________"));
        }

        #endregion

        #region Example 16

        [Fact]
        public void Example16()
        {
            Assert.Equal("<hr />", GetHtml(" - - -"));
        }

        #endregion

        #region Example 17

        [Fact]
        public void Example17()
        {
            Assert.Equal("<hr />", GetHtml(" **  * ** * ** * **"));
        }

        #endregion

        #region Example 18

        [Fact]
        public void Example18()
        {
            Assert.Equal("<hr />", GetHtml("-     -      -      -"));
        }

        #endregion

        #region Example 19

        [Fact]
        public void Example19()
        {
            Assert.Equal("<hr />", GetHtml("- - - -    "));
        }

        #endregion

        #region Example 20

        [Fact]
        public void Example20_1()
        {
            Assert.Equal("<p>_ _ _ _ a</p>", GetHtml("_ _ _ _ a"));
        }

        [Fact]
        public void Example20_2()
        {
            Assert.Equal("<p>a------</p>", GetHtml("a------"));
        }

        [Fact]
        public void Example20_3()
        {
            Assert.Equal("<p>---a---</p>", GetHtml("---a---"));
        }

        #endregion

        #region Example 21

        [Fact]
        public void Example21()
        {
            Assert.Equal("<p><em>-</em></p>", GetHtml(" *-*"));
        }

        #endregion

        #region Example 22

        [Fact]
        public void Example22()
        {
            Assert.Equal("<ul><li>foo</li></ul><hr /><ul><li>bar</li></ul>", GetHtml("- foo\r\n***\r\n- bar"));
        }

        #endregion

        #region Example 23

        [Fact]
        public void Example23()
        {
            Assert.Equal("<p>Foo</p><hr /><p>bar</p>", GetHtml("Foo\r\n***\r\nbar"));
        }

        #endregion

        #region Example 24

        [Fact]
        public void Example24()
        {
            Assert.Equal("<h2>Foo</h2><p>bar</p>", GetHtml("Foo\r\n---\r\nbar"));
        }

        #endregion

        #region Example 25

        [Fact]
        public void Example25()
        {
            Assert.Equal("<ul><li>Foo</li></ul><hr /><ul><li>Bar</li></ul>", GetHtml("* Foo\r\n* * *\r\n* Bar"));
        }

        #endregion

        #region Example 26

        [Fact]
        public void Example26()
        {
            Assert.Equal("<ul><li>Foo</li><li><hr /></li></ul>", GetHtml("- Foo\r\n- * * *"));
        }

        #endregion
    }
}