
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class HTMLblocks: BaseTest
    {
        
        #region Example 104
        [Fact]
        public void Example104()
        {
            Assert.Equal(@"<table>
  <tr>
    <td>
           hi
    </td>
  </tr>
</table>
<p>okay.</p>
", GetHtml(@"<table>
  <tr>
    <td>
           hi
    </td>
  </tr>
</table>

okay.
"));
        }

        #endregion

        #region Example 105
        [Fact]
        public void Example105()
        {
            Assert.Equal(@" <div>
  *hello*
         <foo><a>
", GetHtml(@" <div>
  *hello*
         <foo><a>
"));
        }

        #endregion

        #region Example 106
        [Fact]
        public void Example106()
        {
            Assert.Equal(@"</div>
*foo*
", GetHtml(@"</div>
*foo*
"));
        }

        #endregion

        #region Example 107
        [Fact]
        public void Example107()
        {
            Assert.Equal(@"<DIV CLASS=""foo"">
<p><em>Markdown</em></p>
</DIV>
", GetHtml(@"<DIV CLASS=""foo"">

*Markdown*

</DIV>
"));
        }

        #endregion

        #region Example 108
        [Fact]
        public void Example108()
        {
            Assert.Equal(@"<div id=""foo""
  class=""bar"">
</div>
", GetHtml(@"<div id=""foo""
  class=""bar"">
</div>
"));
        }

        #endregion

        #region Example 109
        [Fact]
        public void Example109()
        {
            Assert.Equal(@"<div id=""foo"" class=""bar
  baz"">
</div>
", GetHtml(@"<div id=""foo"" class=""bar
  baz"">
</div>
"));
        }

        #endregion

        #region Example 110
        [Fact]
        public void Example110()
        {
            Assert.Equal(@"<div>
*foo*
<p><em>bar</em></p>
", GetHtml(@"<div>
*foo*

*bar*
"));
        }

        #endregion

        #region Example 111
        [Fact]
        public void Example111()
        {
            Assert.Equal(@"<div id=""foo""
*hi*
", GetHtml(@"<div id=""foo""
*hi*
"));
        }

        #endregion

        #region Example 112
        [Fact]
        public void Example112()
        {
            Assert.Equal(@"<div class
foo
", GetHtml(@"<div class
foo
"));
        }

        #endregion

        #region Example 113
        [Fact]
        public void Example113()
        {
            Assert.Equal(@"<div *???-&&&-<---
*foo*
", GetHtml(@"<div *???-&&&-<---
*foo*
"));
        }

        #endregion

        #region Example 114
        [Fact]
        public void Example114()
        {
            Assert.Equal(@"<div><a href=""bar"">*foo*</a></div>
", GetHtml(@"<div><a href=""bar"">*foo*</a></div>
"));
        }

        #endregion

        #region Example 115
        [Fact]
        public void Example115()
        {
            Assert.Equal(@"<table><tr><td>
foo
</td></tr></table>
", GetHtml(@"<table><tr><td>
foo
</td></tr></table>
"));
        }

        #endregion

        #region Example 116
        [Fact]
        public void Example116()
        {
            Assert.Equal(@"<div></div>
``` c
int x = 33;
```
", GetHtml(@"<div></div>
``` c
int x = 33;
```
"));
        }

        #endregion

        #region Example 117
        [Fact]
        public void Example117()
        {
            Assert.Equal(@"<a href=""foo"">
*bar*
</a>
", GetHtml(@"<a href=""foo"">
*bar*
</a>
"));
        }

        #endregion

        #region Example 118
        [Fact]
        public void Example118()
        {
            Assert.Equal(@"<Warning>
*bar*
</Warning>
", GetHtml(@"<Warning>
*bar*
</Warning>
"));
        }

        #endregion

        #region Example 119
        [Fact]
        public void Example119()
        {
            Assert.Equal(@"<i class=""foo"">
*bar*
</i>
", GetHtml(@"<i class=""foo"">
*bar*
</i>
"));
        }

        #endregion

        #region Example 120
        [Fact]
        public void Example120()
        {
            Assert.Equal(@"</ins>
*bar*
", GetHtml(@"</ins>
*bar*
"));
        }

        #endregion

        #region Example 121
        [Fact]
        public void Example121()
        {
            Assert.Equal(@"<del>
*foo*
</del>
", GetHtml(@"<del>
*foo*
</del>
"));
        }

        #endregion

        #region Example 122
        [Fact]
        public void Example122()
        {
            Assert.Equal(@"<del>
<p><em>foo</em></p>
</del>
", GetHtml(@"<del>

*foo*

</del>
"));
        }

        #endregion

        #region Example 123
        [Fact]
        public void Example123()
        {
            Assert.Equal(@"<p><del><em>foo</em></del></p>
", GetHtml(@"<del>*foo*</del>
"));
        }

        #endregion

        #region Example 124
        [Fact]
        public void Example124()
        {
            Assert.Equal(@"<pre language=""haskell""><code>
import Text.HTML.TagSoup

main :: IO ()
main = print $ parseTags tags
</code></pre>
", GetHtml(@"<pre language=""haskell""><code>
import Text.HTML.TagSoup

main :: IO ()
main = print $ parseTags tags
</code></pre>
"));
        }

        #endregion

        #region Example 125
        [Fact]
        public void Example125()
        {
            Assert.Equal(@"<script type=""text/javascript"">
// JavaScript example

document.getElementById(""demo"").innerHTML = ""Hello JavaScript!"";
</script>
", GetHtml(@"<script type=""text/javascript"">
// JavaScript example

document.getElementById(""demo"").innerHTML = ""Hello JavaScript!"";
</script>
"));
        }

        #endregion

        #region Example 126
        [Fact]
        public void Example126()
        {
            Assert.Equal(@"<style
  type=""text/css"">
h1 {color:red;}

p {color:blue;}
</style>
", GetHtml(@"<style
  type=""text/css"">
h1 {color:red;}

p {color:blue;}
</style>
"));
        }

        #endregion

        #region Example 127
        [Fact]
        public void Example127()
        {
            Assert.Equal(@"<style
  type=""text/css"">

foo
", GetHtml(@"<style
  type=""text/css"">

foo
"));
        }

        #endregion

        #region Example 128
        [Fact]
        public void Example128()
        {
            Assert.Equal(@"<blockquote>
<div>
foo
</blockquote>
<p>bar</p>
", GetHtml(@"> <div>
> foo

bar
"));
        }

        #endregion

        #region Example 129
        [Fact]
        public void Example129()
        {
            Assert.Equal(@"<ul>
<li>
<div>
</li>
<li>foo</li>
</ul>
", GetHtml(@"- <div>
- foo
"));
        }

        #endregion

        #region Example 130
        [Fact]
        public void Example130()
        {
            Assert.Equal(@"<style>p{color:red;}</style>
<p><em>foo</em></p>
", GetHtml(@"<style>p{color:red;}</style>
*foo*
"));
        }

        #endregion

        #region Example 131
        [Fact]
        public void Example131()
        {
            Assert.Equal(@"<!-- foo -->*bar*
<p><em>baz</em></p>
", GetHtml(@"<!-- foo -->*bar*
*baz*
"));
        }

        #endregion

        #region Example 132
        [Fact]
        public void Example132()
        {
            Assert.Equal(@"<script>
foo
</script>1. *bar*
", GetHtml(@"<script>
foo
</script>1. *bar*
"));
        }

        #endregion

        #region Example 133
        [Fact]
        public void Example133()
        {
            Assert.Equal(@"<!-- Foo

bar
   baz -->
", GetHtml(@"<!-- Foo

bar
   baz -->
"));
        }

        #endregion

        #region Example 134
        [Fact]
        public void Example134()
        {
            Assert.Equal(@"<?php

  echo '>';

?>
", GetHtml(@"<?php

  echo '>';

?>
"));
        }

        #endregion

        #region Example 135
        [Fact]
        public void Example135()
        {
            Assert.Equal(@"<!DOCTYPE html>
", GetHtml(@"<!DOCTYPE html>
"));
        }

        #endregion

        #region Example 136
        [Fact]
        public void Example136()
        {
            Assert.Equal(@"<![CDATA[
function matchwo(a,b)
{
  if (a < b && a < 0) then {
    return 1;

  } else {

    return 0;
  }
}
]]>
", GetHtml(@"<![CDATA[
function matchwo(a,b)
{
  if (a < b && a < 0) then {
    return 1;

  } else {

    return 0;
  }
}
]]>
"));
        }

        #endregion

        #region Example 137
        [Fact]
        public void Example137()
        {
            Assert.Equal(@"  <!-- foo -->
<pre><code>&lt;!-- foo --&gt;
</code></pre>
", GetHtml(@"  <!-- foo -->

    <!-- foo -->
"));
        }

        #endregion

        #region Example 138
        [Fact]
        public void Example138()
        {
            Assert.Equal(@"  <div>
<pre><code>&lt;div&gt;
</code></pre>
", GetHtml(@"  <div>

    <div>
"));
        }

        #endregion

        #region Example 139
        [Fact]
        public void Example139()
        {
            Assert.Equal(@"<p>Foo</p>
<div>
bar
</div>
", GetHtml(@"Foo
<div>
bar
</div>
"));
        }

        #endregion

        #region Example 140
        [Fact]
        public void Example140()
        {
            Assert.Equal(@"<div>
bar
</div>
*foo*
", GetHtml(@"<div>
bar
</div>
*foo*
"));
        }

        #endregion

        #region Example 141
        [Fact]
        public void Example141()
        {
            Assert.Equal(@"<p>Foo
<a href=""bar"">
baz</p>
", GetHtml(@"Foo
<a href=""bar"">
baz
"));
        }

        #endregion

        #region Example 142
        [Fact]
        public void Example142()
        {
            Assert.Equal(@"<div>
<p><em>Emphasized</em> text.</p>
</div>
", GetHtml(@"<div>

*Emphasized* text.

</div>
"));
        }

        #endregion

        #region Example 143
        [Fact]
        public void Example143()
        {
            Assert.Equal(@"<div>
*Emphasized* text.
</div>
", GetHtml(@"<div>
*Emphasized* text.
</div>
"));
        }

        #endregion

        #region Example 144
        [Fact]
        public void Example144()
        {
            Assert.Equal(@"<table>
<tr>
<td>
Hi
</td>
</tr>
</table>
", GetHtml(@"<table>

<tr>

<td>
Hi
</td>

</tr>

</table>
"));
        }

        #endregion

        #region Example 145
        [Fact]
        public void Example145()
        {
            Assert.Equal(@"<table>
  <tr>
<pre><code>&lt;td&gt;
  Hi
&lt;/td&gt;
</code></pre>
  </tr>
</table>
", GetHtml(@"<table>

  <tr>

    <td>
      Hi
    </td>

  </tr>

</table>
"));
        }

        #endregion
    }
}