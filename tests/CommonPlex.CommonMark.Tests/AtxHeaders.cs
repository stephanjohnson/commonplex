
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class ATXheaders: BaseTest
    {
        
        #region Example 027
        [Fact]
        public void Example027()
        {
            Assert.Equal(@"<h1>foo</h1>
<h2>foo</h2>
<h3>foo</h3>
<h4>foo</h4>
<h5>foo</h5>
<h6>foo</h6>", GetHtml(@"# foo
## foo
### foo
#### foo
##### foo
###### foo"));
        }

        #endregion

        #region Example 028
        [Fact]
        public void Example028()
        {
            Assert.Equal(@"<p>####### foo</p>", GetHtml(@"####### foo"));
        }

        #endregion

        #region Example 029
        [Fact]
        public void Example029()
        {
            Assert.Equal(@"<p>#5 bolt</p>
<p>#foobar</p>", GetHtml(@"#5 bolt

#foobar"));
        }

        #endregion

        #region Example 030
        [Fact]
        public void Example030()
        {
            Assert.Equal(@"<p>## foo</p>", GetHtml(@"\## foo"));
        }

        #endregion

        #region Example 031
        [Fact]
        public void Example031()
        {
            Assert.Equal(@"<h1>foo <em>bar</em> *baz*</h1>", GetHtml(@"# foo *bar* \*baz\*"));
        }

        #endregion

        #region Example 032
        [Fact]
        public void Example032()
        {
            Assert.Equal(@"<h1>foo</h1>", GetHtml(@"#                  foo                     "));
        }

        #endregion

        #region Example 033
        [Fact]
        public void Example033()
        {
            Assert.Equal(@"<h3>foo</h3>
<h2>foo</h2>
<h1>foo</h1>", GetHtml(@" ### foo
  ## foo
   # foo"));
        }

        #endregion

        #region Example 034
        [Fact]
        public void Example034()
        {
            Assert.Equal(@"<pre><code># foo
</code></pre>", GetHtml(@"    # foo"));
        }

        #endregion

        #region Example 035
        [Fact]
        public void Example035()
        {
            Assert.Equal(@"<p>foo
# bar</p>", GetHtml(@"foo
    # bar"));
        }

        #endregion

        #region Example 036
        [Fact]
        public void Example036()
        {
            Assert.Equal(@"<h2>foo</h2>
<h3>bar</h3>", GetHtml(@"## foo ##
  ###   bar    ###"));
        }

        #endregion

        #region Example 037
        [Fact]
        public void Example037()
        {
            Assert.Equal(@"<h1>foo</h1>
<h5>foo</h5>", GetHtml(@"# foo ##################################
##### foo ##"));
        }

        #endregion

        #region Example 038
        [Fact]
        public void Example038()
        {
            Assert.Equal(@"<h3>foo</h3>", GetHtml(@"### foo ###     "));
        }

        #endregion

        #region Example 039
        [Fact]
        public void Example039()
        {
            Assert.Equal(@"<h3>foo ### b</h3>", GetHtml(@"### foo ### b"));
        }

        #endregion

        #region Example 040
        [Fact]
        public void Example040()
        {
            Assert.Equal(@"<h1>foo#</h1>", GetHtml(@"# foo#"));
        }

        #endregion

        #region Example 041
        [Fact]
        public void Example041()
        {
            Assert.Equal(@"<h3>foo ###</h3>
<h2>foo ###</h2>
<h1>foo #</h1>", GetHtml(@"### foo \###
## foo #\##
# foo \#"));
        }

        #endregion

        #region Example 042
        [Fact]
        public void Example042()
        {
            Assert.Equal(@"<hr />
<h2>foo</h2>
<hr />", GetHtml(@"****
## foo
****"));
        }

        #endregion

        #region Example 043
        [Fact]
        public void Example043()
        {
            Assert.Equal(@"<p>Foo bar</p>
<h1>baz</h1>
<p>Bar foo</p>", GetHtml(@"Foo bar
# baz
Bar foo"));
        }

        #endregion

        #region Example 044
        [Fact]
        public void Example044()
        {
            Assert.Equal(@"<h2></h2>
<h1></h1>
<h3></h3>", GetHtml(@"## 
#
### ###"));
        }

        #endregion
    }
}