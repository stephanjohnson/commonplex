
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Setextheaders: BaseTest
    {
        
        #region Example 045
        [Fact]
        public void Example045()
        {
            Assert.Equal(@"<h1>Foo <em>bar</em></h1>
<h2>Foo <em>bar</em></h2>", GetHtml(@"Foo *bar*
=========

Foo *bar*
---------"));
        }

        #endregion

        #region Example 046
        [Fact]
        public void Example046()
        {
            Assert.Equal(@"<h2>Foo</h2>
<h1>Foo</h1>", GetHtml(@"Foo
-------------------------

Foo
="));
        }

        #endregion

        #region Example 047
        [Fact]
        public void Example047()
        {
            Assert.Equal(@"<h2>Foo</h2>
<h2>Foo</h2>
<h1>Foo</h1>", GetHtml(@"   Foo
---

  Foo
-----

  Foo
  ==="));
        }

        #endregion

        #region Example 048
        [Fact]
        public void Example048()
        {
            Assert.Equal(@"<pre><code>Foo
---

Foo
</code></pre>
<hr />", GetHtml(@"    Foo
    ---

    Foo
---"));
        }

        #endregion

        #region Example 049
        [Fact]
        public void Example049()
        {
            Assert.Equal(@"<h2>Foo</h2>", GetHtml(@"Foo
   ----      "));
        }

        #endregion

        #region Example 050
        [Fact]
        public void Example050()
        {
            Assert.Equal(@"<p>Foo
---</p>", GetHtml(@"Foo
    ---"));
        }

        #endregion

        #region Example 051
        [Fact]
        public void Example051()
        {
            Assert.Equal(@"<p>Foo
= =</p>
<p>Foo</p>
<hr />", GetHtml(@"Foo
= =

Foo
--- -"));
        }

        #endregion

        #region Example 052
        [Fact]
        public void Example052()
        {
            Assert.Equal(@"<h2>Foo</h2>", GetHtml(@"Foo  
-----"));
        }

        #endregion

        #region Example 053
        [Fact]
        public void Example053()
        {
            Assert.Equal(@"<h2>Foo\</h2>", GetHtml(@"Foo\
----"));
        }

        #endregion

        #region Example 054
        [Fact]
        public void Example054()
        {
            Assert.Equal(@"<h2>`Foo</h2>
<p>`</p>
<h2>&lt;a title=&quot;a lot</h2>
<p>of dashes&quot;/&gt;</p>", GetHtml(@"`Foo
----
`

<a title=""a lot
---
of dashes""/>"));
        }

        #endregion

        #region Example 055
        [Fact]
        public void Example055()
        {
            Assert.Equal(@"<blockquote>
<p>Foo</p>
</blockquote>
<hr />", GetHtml(@"> Foo
---"));
        }

        #endregion

        #region Example 056
        [Fact]
        public void Example056()
        {
            Assert.Equal(@"<ul>
<li>Foo</li>
</ul>
<hr />", GetHtml(@"- Foo
---"));
        }

        #endregion

        #region Example 057
        [Fact]
        public void Example057()
        {
            Assert.Equal(@"<p>Foo
Bar</p>
<hr />
<p>Foo
Bar
===</p>", GetHtml(@"Foo
Bar
---

Foo
Bar
==="));
        }

        #endregion

        #region Example 058
        [Fact]
        public void Example058()
        {
            Assert.Equal(@"<hr />
<h2>Foo</h2>
<h2>Bar</h2>
<p>Baz</p>", GetHtml(@"---
Foo
---
Bar
---
Baz"));
        }

        #endregion

        #region Example 059
        [Fact]
        public void Example059()
        {
            Assert.Equal(@"<p>====</p>", GetHtml(@"
===="));
        }

        #endregion

        #region Example 060
        [Fact]
        public void Example060()
        {
            Assert.Equal(@"<hr />
<hr />", GetHtml(@"---
---"));
        }

        #endregion

        #region Example 061
        [Fact]
        public void Example061()
        {
            Assert.Equal(@"<ul>
<li>foo</li>
</ul>
<hr />", GetHtml(@"- foo
-----"));
        }

        #endregion

        #region Example 062
        [Fact]
        public void Example062()
        {
            Assert.Equal(@"<pre><code>foo
</code></pre>
<hr />", GetHtml(@"    foo
---"));
        }

        #endregion

        #region Example 063
        [Fact]
        public void Example063()
        {
            Assert.Equal(@"<blockquote>
<p>foo</p>
</blockquote>
<hr />", GetHtml(@"> foo
-----"));
        }

        #endregion

        #region Example 064
        [Fact]
        public void Example064()
        {
            Assert.Equal(@"<h2>&gt; foo</h2>", GetHtml(@"\> foo
------"));
        }

        #endregion
    }
}