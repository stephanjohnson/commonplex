
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Hardlinebreaks: BaseTest
    {
        
        #region Example 580
        [Fact]
        public void Example580()
        {
            Assert.Equal(@"<p>foo<br />
baz</p>
", GetHtml(@"foo  
baz
"));
        }

        #endregion

        #region Example 581
        [Fact]
        public void Example581()
        {
            Assert.Equal(@"<p>foo<br />
baz</p>
", GetHtml(@"foo\
baz
"));
        }

        #endregion

        #region Example 582
        [Fact]
        public void Example582()
        {
            Assert.Equal(@"<p>foo<br />
baz</p>
", GetHtml(@"foo       
baz
"));
        }

        #endregion

        #region Example 583
        [Fact]
        public void Example583()
        {
            Assert.Equal(@"<p>foo<br />
bar</p>
", GetHtml(@"foo  
     bar
"));
        }

        #endregion

        #region Example 584
        [Fact]
        public void Example584()
        {
            Assert.Equal(@"<p>foo<br />
bar</p>
", GetHtml(@"foo\
     bar
"));
        }

        #endregion

        #region Example 585
        [Fact]
        public void Example585()
        {
            Assert.Equal(@"<p><em>foo<br />
bar</em></p>
", GetHtml(@"*foo  
bar*
"));
        }

        #endregion

        #region Example 586
        [Fact]
        public void Example586()
        {
            Assert.Equal(@"<p><em>foo<br />
bar</em></p>
", GetHtml(@"*foo\
bar*
"));
        }

        #endregion

        #region Example 587
        [Fact]
        public void Example587()
        {
            Assert.Equal(@"<p><code>code span</code></p>
", GetHtml(@"`code  
span`
"));
        }

        #endregion

        #region Example 588
        [Fact]
        public void Example588()
        {
            Assert.Equal(@"<p><code>code\ span</code></p>
", GetHtml(@"`code\
span`
"));
        }

        #endregion

        #region Example 589
        [Fact]
        public void Example589()
        {
            Assert.Equal(@"<p><a href=""foo  
bar""></p>
", GetHtml(@"<a href=""foo  
bar"">
"));
        }

        #endregion

        #region Example 590
        [Fact]
        public void Example590()
        {
            Assert.Equal(@"<p><a href=""foo\
bar""></p>
", GetHtml(@"<a href=""foo\
bar"">
"));
        }

        #endregion

        #region Example 591
        [Fact]
        public void Example591()
        {
            Assert.Equal(@"<p>foo\</p>
", GetHtml(@"foo\
"));
        }

        #endregion

        #region Example 592
        [Fact]
        public void Example592()
        {
            Assert.Equal(@"<p>foo</p>
", GetHtml(@"foo  
"));
        }

        #endregion

        #region Example 593
        [Fact]
        public void Example593()
        {
            Assert.Equal(@"<h3>foo\</h3>
", GetHtml(@"### foo\
"));
        }

        #endregion

        #region Example 594
        [Fact]
        public void Example594()
        {
            Assert.Equal(@"<h3>foo</h3>
", GetHtml(@"### foo  
"));
        }

        #endregion
    }
}