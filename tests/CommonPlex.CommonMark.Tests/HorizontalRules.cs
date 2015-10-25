
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Horizontalrules: BaseTest
    {
        
        #region Example 008
        [Fact]
        public void Example008()
        {
            Assert.Equal(@"<hr />
<hr />
<hr />
", GetHtml(@"***
---
___
"));
        }

        #endregion

        #region Example 009
        [Fact]
        public void Example009()
        {
            Assert.Equal(@"<p>+++</p>
", GetHtml(@"+++
"));
        }

        #endregion

        #region Example 010
        [Fact]
        public void Example010()
        {
            Assert.Equal(@"<p>===</p>
", GetHtml(@"===
"));
        }

        #endregion

        #region Example 011
        [Fact]
        public void Example011()
        {
            Assert.Equal(@"<p>--
**
__</p>
", GetHtml(@"--
**
__
"));
        }

        #endregion

        #region Example 012
        [Fact]
        public void Example012()
        {
            Assert.Equal(@"<hr />
<hr />
<hr />
", GetHtml(@" ***
  ***
   ***
"));
        }

        #endregion

        #region Example 013
        [Fact]
        public void Example013()
        {
            Assert.Equal(@"<pre><code>***
</code></pre>
", GetHtml(@"    ***
"));
        }

        #endregion

        #region Example 014
        [Fact]
        public void Example014()
        {
            Assert.Equal(@"<p>Foo
***</p>
", GetHtml(@"Foo
    ***
"));
        }

        #endregion

        #region Example 015
        [Fact]
        public void Example015()
        {
            Assert.Equal(@"<hr />
", GetHtml(@"_____________________________________
"));
        }

        #endregion

        #region Example 016
        [Fact]
        public void Example016()
        {
            Assert.Equal(@"<hr />
", GetHtml(@" - - -
"));
        }

        #endregion

        #region Example 017
        [Fact]
        public void Example017()
        {
            Assert.Equal(@"<hr />
", GetHtml(@" **  * ** * ** * **
"));
        }

        #endregion

        #region Example 018
        [Fact]
        public void Example018()
        {
            Assert.Equal(@"<hr />
", GetHtml(@"-     -      -      -
"));
        }

        #endregion

        #region Example 019
        [Fact]
        public void Example019()
        {
            Assert.Equal(@"<hr />
", GetHtml(@"- - - -    
"));
        }

        #endregion

        #region Example 020
        [Fact]
        public void Example020()
        {
            Assert.Equal(@"<p>_ _ _ _ a</p>
<p>a------</p>
<p>---a---</p>
", GetHtml(@"_ _ _ _ a

a------

---a---
"));
        }

        #endregion

        #region Example 021
        [Fact]
        public void Example021()
        {
            Assert.Equal(@"<p><em>-</em></p>
", GetHtml(@" *-*
"));
        }

        #endregion

        #region Example 022
        [Fact]
        public void Example022()
        {
            Assert.Equal(@"<ul>
<li>foo</li>
</ul>
<hr />
<ul>
<li>bar</li>
</ul>
", GetHtml(@"- foo
***
- bar
"));
        }

        #endregion

        #region Example 023
        [Fact]
        public void Example023()
        {
            Assert.Equal(@"<p>Foo</p>
<hr />
<p>bar</p>
", GetHtml(@"Foo
***
bar
"));
        }

        #endregion

        #region Example 024
        [Fact]
        public void Example024()
        {
            Assert.Equal(@"<h2>Foo</h2>
<p>bar</p>
", GetHtml(@"Foo
---
bar
"));
        }

        #endregion

        #region Example 025
        [Fact]
        public void Example025()
        {
            Assert.Equal(@"<ul>
<li>Foo</li>
</ul>
<hr />
<ul>
<li>Bar</li>
</ul>
", GetHtml(@"* Foo
* * *
* Bar
"));
        }

        #endregion

        #region Example 026
        [Fact]
        public void Example026()
        {
            Assert.Equal(@"<ul>
<li>Foo</li>
<li>
<hr />
</li>
</ul>
", GetHtml(@"- Foo
- * * *
"));
        }

        #endregion
    }
}