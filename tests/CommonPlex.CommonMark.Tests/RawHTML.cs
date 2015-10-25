
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class RawHTML: BaseTest
    {
        
        #region Example 559
        [Fact]
        public void Example559()
        {
            Assert.Equal(@"<p><a><bab><c2c></p>
", GetHtml(@"<a><bab><c2c>
"));
        }

        #endregion

        #region Example 560
        [Fact]
        public void Example560()
        {
            Assert.Equal(@"<p><a/><b2/></p>
", GetHtml(@"<a/><b2/>
"));
        }

        #endregion

        #region Example 561
        [Fact]
        public void Example561()
        {
            Assert.Equal(@"<p><a  /><b2
data=""foo"" ></p>
", GetHtml(@"<a  /><b2
data=""foo"" >
"));
        }

        #endregion

        #region Example 562
        [Fact]
        public void Example562()
        {
            Assert.Equal(@"<p><a foo=""bar"" bam = 'baz <em>""</em>'
_boolean zoop:33=zoop:33 /></p>
", GetHtml(@"<a foo=""bar"" bam = 'baz <em>""</em>'
_boolean zoop:33=zoop:33 />
"));
        }

        #endregion

        #region Example 563
        [Fact]
        public void Example563()
        {
            Assert.Equal(@"<responsive-image src=""foo.jpg"" />
<My-Tag>
foo
</My-Tag>
", GetHtml(@"<responsive-image src=""foo.jpg"" />

<My-Tag>
foo
</My-Tag>
"));
        }

        #endregion

        #region Example 564
        [Fact]
        public void Example564()
        {
            Assert.Equal(@"<p>&lt;33&gt; &lt;__&gt;</p>
", GetHtml(@"<33> <__>
"));
        }

        #endregion

        #region Example 565
        [Fact]
        public void Example565()
        {
            Assert.Equal(@"<p>&lt;a h*#ref=&quot;hi&quot;&gt;</p>
", GetHtml(@"<a h*#ref=""hi"">
"));
        }

        #endregion

        #region Example 566
        [Fact]
        public void Example566()
        {
            Assert.Equal(@"<p>&lt;a href=&quot;hi'&gt; &lt;a href=hi'&gt;</p>
", GetHtml(@"<a href=""hi'> <a href=hi'>
"));
        }

        #endregion

        #region Example 567
        [Fact]
        public void Example567()
        {
            Assert.Equal(@"<p>&lt; a&gt;&lt;
foo&gt;&lt;bar/ &gt;</p>
", GetHtml(@"< a><
foo><bar/ >
"));
        }

        #endregion

        #region Example 568
        [Fact]
        public void Example568()
        {
            Assert.Equal(@"<p>&lt;a href='bar'title=title&gt;</p>
", GetHtml(@"<a href='bar'title=title>
"));
        }

        #endregion

        #region Example 569
        [Fact]
        public void Example569()
        {
            Assert.Equal(@"</a>
</foo >
", GetHtml(@"</a>
</foo >
"));
        }

        #endregion

        #region Example 570
        [Fact]
        public void Example570()
        {
            Assert.Equal(@"<p>&lt;/a href=&quot;foo&quot;&gt;</p>
", GetHtml(@"</a href=""foo"">
"));
        }

        #endregion

        #region Example 571
        [Fact]
        public void Example571()
        {
            Assert.Equal(@"<p>foo <!-- this is a
comment - with hyphen --></p>
", GetHtml(@"foo <!-- this is a
comment - with hyphen -->
"));
        }

        #endregion

        #region Example 572
        [Fact]
        public void Example572()
        {
            Assert.Equal(@"<p>foo &lt;!-- not a comment -- two hyphens --&gt;</p>
", GetHtml(@"foo <!-- not a comment -- two hyphens -->
"));
        }

        #endregion

        #region Example 573
        [Fact]
        public void Example573()
        {
            Assert.Equal(@"<p>foo &lt;!--&gt; foo --&gt;</p>
<p>foo &lt;!-- foo---&gt;</p>
", GetHtml(@"foo <!--> foo -->

foo <!-- foo--->
"));
        }

        #endregion

        #region Example 574
        [Fact]
        public void Example574()
        {
            Assert.Equal(@"<p>foo <?php echo $a; ?></p>
", GetHtml(@"foo <?php echo $a; ?>
"));
        }

        #endregion

        #region Example 575
        [Fact]
        public void Example575()
        {
            Assert.Equal(@"<p>foo <!ELEMENT br EMPTY></p>
", GetHtml(@"foo <!ELEMENT br EMPTY>
"));
        }

        #endregion

        #region Example 576
        [Fact]
        public void Example576()
        {
            Assert.Equal(@"<p>foo <![CDATA[>&<]]></p>
", GetHtml(@"foo <![CDATA[>&<]]>
"));
        }

        #endregion

        #region Example 577
        [Fact]
        public void Example577()
        {
            Assert.Equal(@"<a href=""&ouml;"">
", GetHtml(@"<a href=""&ouml;"">
"));
        }

        #endregion

        #region Example 578
        [Fact]
        public void Example578()
        {
            Assert.Equal(@"<a href=""\*"">
", GetHtml(@"<a href=""\*"">
"));
        }

        #endregion

        #region Example 579
        [Fact]
        public void Example579()
        {
            Assert.Equal(@"<p>&lt;a href=&quot;&quot;&quot;&gt;</p>
", GetHtml(@"<a href=""\"""">
"));
        }

        #endregion
    }
}