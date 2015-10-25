
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Autolinks: BaseTest
    {
        
        #region Example 543
        [Fact]
        public void Example543()
        {
            Assert.Equal(@"<p><a href=""http://foo.bar.baz"">http://foo.bar.baz</a></p>
", GetHtml(@"<http://foo.bar.baz>
"));
        }

        #endregion

        #region Example 544
        [Fact]
        public void Example544()
        {
            Assert.Equal(@"<p><a href=""http://foo.bar.baz/test?q=hello&amp;id=22&amp;boolean"">http://foo.bar.baz/test?q=hello&amp;id=22&amp;boolean</a></p>
", GetHtml(@"<http://foo.bar.baz/test?q=hello&id=22&boolean>
"));
        }

        #endregion

        #region Example 545
        [Fact]
        public void Example545()
        {
            Assert.Equal(@"<p><a href=""irc://foo.bar:2233/baz"">irc://foo.bar:2233/baz</a></p>
", GetHtml(@"<irc://foo.bar:2233/baz>
"));
        }

        #endregion

        #region Example 546
        [Fact]
        public void Example546()
        {
            Assert.Equal(@"<p><a href=""MAILTO:FOO@BAR.BAZ"">MAILTO:FOO@BAR.BAZ</a></p>
", GetHtml(@"<MAILTO:FOO@BAR.BAZ>
"));
        }

        #endregion

        #region Example 547
        [Fact]
        public void Example547()
        {
            Assert.Equal(@"<p>&lt;http://foo.bar/baz bim&gt;</p>
", GetHtml(@"<http://foo.bar/baz bim>
"));
        }

        #endregion

        #region Example 548
        [Fact]
        public void Example548()
        {
            Assert.Equal(@"<p><a href=""http://example.com/%5C%5B%5C"">http://example.com/\[\</a></p>
", GetHtml(@"<http://example.com/\[\>
"));
        }

        #endregion

        #region Example 549
        [Fact]
        public void Example549()
        {
            Assert.Equal(@"<p><a href=""mailto:foo@bar.example.com"">foo@bar.example.com</a></p>
", GetHtml(@"<foo@bar.example.com>
"));
        }

        #endregion

        #region Example 550
        [Fact]
        public void Example550()
        {
            Assert.Equal(@"<p><a href=""mailto:foo+special@Bar.baz-bar0.com"">foo+special@Bar.baz-bar0.com</a></p>
", GetHtml(@"<foo+special@Bar.baz-bar0.com>
"));
        }

        #endregion

        #region Example 551
        [Fact]
        public void Example551()
        {
            Assert.Equal(@"<p>&lt;foo+@bar.example.com&gt;</p>
", GetHtml(@"<foo\+@bar.example.com>
"));
        }

        #endregion

        #region Example 552
        [Fact]
        public void Example552()
        {
            Assert.Equal(@"<p>&lt;&gt;</p>
", GetHtml(@"<>
"));
        }

        #endregion

        #region Example 553
        [Fact]
        public void Example553()
        {
            Assert.Equal(@"<p>&lt;heck://bing.bong&gt;</p>
", GetHtml(@"<heck://bing.bong>
"));
        }

        #endregion

        #region Example 554
        [Fact]
        public void Example554()
        {
            Assert.Equal(@"<p>&lt; http://foo.bar &gt;</p>
", GetHtml(@"< http://foo.bar >
"));
        }

        #endregion

        #region Example 555
        [Fact]
        public void Example555()
        {
            Assert.Equal(@"<p>&lt;foo.bar.baz&gt;</p>
", GetHtml(@"<foo.bar.baz>
"));
        }

        #endregion

        #region Example 556
        [Fact]
        public void Example556()
        {
            Assert.Equal(@"<p>&lt;localhost:5001/foo&gt;</p>
", GetHtml(@"<localhost:5001/foo>
"));
        }

        #endregion

        #region Example 557
        [Fact]
        public void Example557()
        {
            Assert.Equal(@"<p>http://example.com</p>
", GetHtml(@"http://example.com
"));
        }

        #endregion

        #region Example 558
        [Fact]
        public void Example558()
        {
            Assert.Equal(@"<p>foo@bar.example.com</p>
", GetHtml(@"foo@bar.example.com
"));
        }

        #endregion
    }
}