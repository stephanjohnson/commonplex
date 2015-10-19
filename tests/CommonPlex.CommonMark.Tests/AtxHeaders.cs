using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class AtxHeaders: BaseTest
    {
        #region Example 27

        [Fact]
        public void Example27_H1()
        {
            Assert.Equal("<h1>foo</h1>", GetHtml("# foo"));
        }

        [Fact]
        public void Example27_H2()
        {
            Assert.Equal("<h2>foo</h2>", GetHtml("## foo"));
        }

        [Fact]
        public void Example27_H3()
        {
            Assert.Equal("<h3>foo</h3>", GetHtml("### foo"));
        }

        [Fact]
        public void Example27_H4()
        {
            Assert.Equal("<h4>foo</h4>", GetHtml("#### foo"));
        }

        [Fact]
        public void Example27_H5()
        {
            Assert.Equal("<h5>foo</h5>", GetHtml("##### foo"));
        }

        [Fact]
        public void Example27_H6()
        {
            Assert.Equal("<h6>foo</h6>", GetHtml("###### foo"));
        }

        #endregion

        #region Example 28

        [Fact]
        public void Example28()
        {
            Assert.Equal("<p>####### foo</p>", GetHtml("####### foo"));
        }

        #endregion

        #region Example 29

        [Fact]
        public void Example29_1()
        {
            Assert.Equal("<p>#5 bolt</p>", GetHtml("#5 bolt"));
        }

        [Fact]
        public void Example29_2()
        {
            Assert.Equal("<p>#foobar</p>", GetHtml("#foobar"));
        }

        #endregion

        #region Example 30

        [Fact]
        public void Example30()
        {
            Assert.Equal("<p>## foo</p>", GetHtml("\\## foo"));
        }

        #endregion

        #region Example 31

        [Fact]
        public void Example31()
        {
            Assert.Equal("<h1>foo <em>bar</em> *baz*</h1>", GetHtml("# foo *bar* \\*baz\\*"));
        }

        #endregion

        #region Example 32

        [Fact]
        public void Example32()
        {
            Assert.Equal("<h1>foo</h1>", GetHtml("#                  foo                     "));
        }

        #endregion

        #region Example 33

        [Fact]
        public void Example33_H3()
        {
            Assert.Equal("<h3>foo</h3>", GetHtml(" ### foo"));
        }

        [Fact]
        public void Example33_H2()
        {
            Assert.Equal("<h2>foo</h2>", GetHtml("  ## foo"));
        }

        [Fact]
        public void Example33_H1()
        {
            Assert.Equal("<h1>foo</h1>", GetHtml("   # foo"));
        }

        #endregion

        #region Example 34

        [Fact]
        public void Example34()
        {
            Assert.Equal("<pre><code># foo</code></pre>", GetHtml("    # foo"));
        }

        #endregion

        #region Example 35

        [Fact]
        public void Example35()
        {
            Assert.Equal("<p>foo# bar</p>", GetHtml("foo    # bar"));
        }

        #endregion

        #region Example 36

        [Fact]
        public void Example36_H2()
        {
            Assert.Equal("<h2>foo</h2>", GetHtml("## foo ##"));
        }

        [Fact]
        public void Example36_H3()
        {
            Assert.Equal("<h3>foo</h3>", GetHtml("  ###   bar    ###"));
        }

        #endregion

        #region Example 37

        [Fact]
        public void Example37_H1()
        {
            Assert.Equal("<h1>foo</h1>", GetHtml("# foo ##################################"));
        }

        [Fact]
        public void Example37_H5()
        {
            Assert.Equal("<h5>foo</h5>", GetHtml("##### foo ##"));
        }

        #endregion

        #region Example 38

        [Fact]
        public void Example38()
        {
            Assert.Equal("<h3>foo</h3>", GetHtml("### foo ###     "));
        }

        #endregion

        #region Example 39

        [Fact]
        public void Example39()
        {
            Assert.Equal("<h3>foo ### b</h3>", GetHtml("### foo ### b"));
        }

        #endregion

        #region Example 40

        [Fact]
        public void Example40()
        {
            Assert.Equal("<h1>foo#</h1>", GetHtml("# foo#"));
        }

        #endregion

        #region Example 41

        [Fact]
        public void Example41_H3()
        {
            Assert.Equal("<h3>foo ###</h3>", GetHtml("### foo \\###"));
        }

        [Fact]
        public void Example41_H2()
        {
            Assert.Equal("<h2>foo ###</h2>", GetHtml("## foo #\\##"));
        }

        [Fact]
        public void Example41_H1()
        {
            Assert.Equal("<h1>foo #</h1>", GetHtml("# foo \\#"));
        }

        #endregion

        #region Example 42

        [Fact]
        public void Example42()
        {
            Assert.Equal("<hr /><h2>foo</h2><hr />", GetHtml("****## foo****"));
        }

        #endregion

        #region Example 43

        [Fact]
        public void Example43()
        {
            Assert.Equal("<p>Foo bar</p><h1>baz</h1><p>Bar foo</p>", GetHtml("Foo bar# bazBar foo"));
        }

        #endregion

        #region Example 44

        [Fact]
        public void Example44()
        {
            Assert.Equal("<h2></h2><h1></h1><h3></h3>", GetHtml("## #### ###"));
        }

        #endregion
    }
}