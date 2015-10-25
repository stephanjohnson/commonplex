
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Codespans: BaseTest
    {
        
        #region Example 298
        [Fact]
        public void Example298()
        {
            Assert.Equal(@"<p><code>foo</code></p>", GetHtml(@"`foo`"));
        }

        #endregion

        #region Example 299
        [Fact]
        public void Example299()
        {
            Assert.Equal(@"<p><code>foo ` bar</code></p>", GetHtml(@"`` foo ` bar  ``"));
        }

        #endregion

        #region Example 300
        [Fact]
        public void Example300()
        {
            Assert.Equal(@"<p><code>``</code></p>", GetHtml(@"` `` `"));
        }

        #endregion

        #region Example 301
        [Fact]
        public void Example301()
        {
            Assert.Equal(@"<p><code>foo</code></p>", GetHtml(@"``
foo
``"));
        }

        #endregion

        #region Example 302
        [Fact]
        public void Example302()
        {
            Assert.Equal(@"<p><code>foo bar baz</code></p>", GetHtml(@"`foo   bar
  baz`"));
        }

        #endregion

        #region Example 303
        [Fact]
        public void Example303()
        {
            Assert.Equal(@"<p><code>foo `` bar</code></p>", GetHtml(@"`foo `` bar`"));
        }

        #endregion

        #region Example 304
        [Fact]
        public void Example304()
        {
            Assert.Equal(@"<p><code>foo\</code>bar`</p>", GetHtml(@"`foo\`bar`"));
        }

        #endregion

        #region Example 305
        [Fact]
        public void Example305()
        {
            Assert.Equal(@"<p>*foo<code>*</code></p>", GetHtml(@"*foo`*`"));
        }

        #endregion

        #region Example 306
        [Fact]
        public void Example306()
        {
            Assert.Equal(@"<p>[not a <code>link](/foo</code>)</p>", GetHtml(@"[not a `link](/foo`)"));
        }

        #endregion

        #region Example 307
        [Fact]
        public void Example307()
        {
            Assert.Equal(@"<p><code>&lt;a href=&quot;</code>&quot;&gt;`</p>", GetHtml(@"`<a href=""`"">`"));
        }

        #endregion

        #region Example 308
        [Fact]
        public void Example308()
        {
            Assert.Equal(@"<p><a href=""`"">`</p>", GetHtml(@"<a href=""`"">`"));
        }

        #endregion

        #region Example 309
        [Fact]
        public void Example309()
        {
            Assert.Equal(@"<p><code>&lt;http://foo.bar.</code>baz&gt;`</p>", GetHtml(@"`<http://foo.bar.`baz>`"));
        }

        #endregion

        #region Example 310
        [Fact]
        public void Example310()
        {
            Assert.Equal(@"<p><a href=""http://foo.bar.%60baz"">http://foo.bar.`baz</a>`</p>", GetHtml(@"<http://foo.bar.`baz>`"));
        }

        #endregion

        #region Example 311
        [Fact]
        public void Example311()
        {
            Assert.Equal(@"<p>```foo``</p>", GetHtml(@"```foo``"));
        }

        #endregion

        #region Example 312
        [Fact]
        public void Example312()
        {
            Assert.Equal(@"<p>`foo</p>", GetHtml(@"`foo"));
        }

        #endregion
    }
}