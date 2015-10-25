
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Images: BaseTest
    {
        
        #region Example 521
        [Fact]
        public void Example521()
        {
            Assert.Equal(@"<p><img src=""/url"" alt=""foo"" title=""title"" /></p>
", GetHtml(@"![foo](/url ""title"")
"));
        }

        #endregion

        #region Example 522
        [Fact]
        public void Example522()
        {
            Assert.Equal(@"<p><img src=""train.jpg"" alt=""foo bar"" title=""train &amp; tracks"" /></p>
", GetHtml(@"![foo *bar*]

[foo *bar*]: train.jpg ""train & tracks""
"));
        }

        #endregion

        #region Example 523
        [Fact]
        public void Example523()
        {
            Assert.Equal(@"<p><img src=""/url2"" alt=""foo bar"" /></p>
", GetHtml(@"![foo ![bar](/url)](/url2)
"));
        }

        #endregion

        #region Example 524
        [Fact]
        public void Example524()
        {
            Assert.Equal(@"<p><img src=""/url2"" alt=""foo bar"" /></p>
", GetHtml(@"![foo [bar](/url)](/url2)
"));
        }

        #endregion

        #region Example 525
        [Fact]
        public void Example525()
        {
            Assert.Equal(@"<p><img src=""train.jpg"" alt=""foo bar"" title=""train &amp; tracks"" /></p>
", GetHtml(@"![foo *bar*][]

[foo *bar*]: train.jpg ""train & tracks""
"));
        }

        #endregion

        #region Example 526
        [Fact]
        public void Example526()
        {
            Assert.Equal(@"<p><img src=""train.jpg"" alt=""foo bar"" title=""train &amp; tracks"" /></p>
", GetHtml(@"![foo *bar*][foobar]

[FOOBAR]: train.jpg ""train & tracks""
"));
        }

        #endregion

        #region Example 527
        [Fact]
        public void Example527()
        {
            Assert.Equal(@"<p><img src=""train.jpg"" alt=""foo"" /></p>
", GetHtml(@"![foo](train.jpg)
"));
        }

        #endregion

        #region Example 528
        [Fact]
        public void Example528()
        {
            Assert.Equal(@"<p>My <img src=""/path/to/train.jpg"" alt=""foo bar"" title=""title"" /></p>
", GetHtml(@"My ![foo bar](/path/to/train.jpg  ""title""   )
"));
        }

        #endregion

        #region Example 529
        [Fact]
        public void Example529()
        {
            Assert.Equal(@"<p><img src=""url"" alt=""foo"" /></p>
", GetHtml(@"![foo](<url>)
"));
        }

        #endregion

        #region Example 530
        [Fact]
        public void Example530()
        {
            Assert.Equal(@"<p><img src=""/url"" alt="""" /></p>
", GetHtml(@"![](/url)
"));
        }

        #endregion

        #region Example 531
        [Fact]
        public void Example531()
        {
            Assert.Equal(@"<p><img src=""/url"" alt=""foo"" /></p>
", GetHtml(@"![foo] [bar]

[bar]: /url
"));
        }

        #endregion

        #region Example 532
        [Fact]
        public void Example532()
        {
            Assert.Equal(@"<p><img src=""/url"" alt=""foo"" /></p>
", GetHtml(@"![foo] [bar]

[BAR]: /url
"));
        }

        #endregion

        #region Example 533
        [Fact]
        public void Example533()
        {
            Assert.Equal(@"<p><img src=""/url"" alt=""foo"" title=""title"" /></p>
", GetHtml(@"![foo][]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 534
        [Fact]
        public void Example534()
        {
            Assert.Equal(@"<p><img src=""/url"" alt=""foo bar"" title=""title"" /></p>
", GetHtml(@"![*foo* bar][]

[*foo* bar]: /url ""title""
"));
        }

        #endregion

        #region Example 535
        [Fact]
        public void Example535()
        {
            Assert.Equal(@"<p><img src=""/url"" alt=""Foo"" title=""title"" /></p>
", GetHtml(@"![Foo][]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 536
        [Fact]
        public void Example536()
        {
            Assert.Equal(@"<p><img src=""/url"" alt=""foo"" title=""title"" /></p>
", GetHtml(@"![foo] 
[]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 537
        [Fact]
        public void Example537()
        {
            Assert.Equal(@"<p><img src=""/url"" alt=""foo"" title=""title"" /></p>
", GetHtml(@"![foo]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 538
        [Fact]
        public void Example538()
        {
            Assert.Equal(@"<p><img src=""/url"" alt=""foo bar"" title=""title"" /></p>
", GetHtml(@"![*foo* bar]

[*foo* bar]: /url ""title""
"));
        }

        #endregion

        #region Example 539
        [Fact]
        public void Example539()
        {
            Assert.Equal(@"<p>![[foo]]</p>
<p>[[foo]]: /url &quot;title&quot;</p>
", GetHtml(@"![[foo]]

[[foo]]: /url ""title""
"));
        }

        #endregion

        #region Example 540
        [Fact]
        public void Example540()
        {
            Assert.Equal(@"<p><img src=""/url"" alt=""Foo"" title=""title"" /></p>
", GetHtml(@"![Foo]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 541
        [Fact]
        public void Example541()
        {
            Assert.Equal(@"<p>![foo]</p>
", GetHtml(@"\!\[foo]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 542
        [Fact]
        public void Example542()
        {
            Assert.Equal(@"<p>!<a href=""/url"" title=""title"">foo</a></p>
", GetHtml(@"\![foo]

[foo]: /url ""title""
"));
        }

        #endregion
    }
}