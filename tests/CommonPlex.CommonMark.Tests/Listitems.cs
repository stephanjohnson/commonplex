
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Listitems: BaseTest
    {
        
        #region Example 203
        [Fact]
        public void Example203()
        {
            Assert.Equal(@"<p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote>
", GetHtml(@"A paragraph
with two lines.

    indented code

> A block quote.
"));
        }

        #endregion

        #region Example 204
        [Fact]
        public void Example204()
        {
            Assert.Equal(@"<ol>
<li>
<p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote>
</li>
</ol>
", GetHtml(@"1.  A paragraph
    with two lines.

        indented code

    > A block quote.
"));
        }

        #endregion

        #region Example 205
        [Fact]
        public void Example205()
        {
            Assert.Equal(@"<ul>
<li>one</li>
</ul>
<p>two</p>
", GetHtml(@"- one

 two
"));
        }

        #endregion

        #region Example 206
        [Fact]
        public void Example206()
        {
            Assert.Equal(@"<ul>
<li>
<p>one</p>
<p>two</p>
</li>
</ul>
", GetHtml(@"- one

  two
"));
        }

        #endregion

        #region Example 207
        [Fact]
        public void Example207()
        {
            Assert.Equal(@"<ul>
<li>one</li>
</ul>
<pre><code> two
</code></pre>
", GetHtml(@" -    one

     two
"));
        }

        #endregion

        #region Example 208
        [Fact]
        public void Example208()
        {
            Assert.Equal(@"<ul>
<li>
<p>one</p>
<p>two</p>
</li>
</ul>
", GetHtml(@" -    one

      two
"));
        }

        #endregion

        #region Example 209
        [Fact]
        public void Example209()
        {
            Assert.Equal(@"<blockquote>
<blockquote>
<ol>
<li>
<p>one</p>
<p>two</p>
</li>
</ol>
</blockquote>
</blockquote>
", GetHtml(@"   > > 1.  one
>>
>>     two
"));
        }

        #endregion

        #region Example 210
        [Fact]
        public void Example210()
        {
            Assert.Equal(@"<blockquote>
<blockquote>
<ul>
<li>one</li>
</ul>
<p>two</p>
</blockquote>
</blockquote>
", GetHtml(@">>- one
>>
  >  > two
"));
        }

        #endregion

        #region Example 211
        [Fact]
        public void Example211()
        {
            Assert.Equal(@"<p>-one</p>
<p>2.two</p>
", GetHtml(@"-one

2.two
"));
        }

        #endregion

        #region Example 212
        [Fact]
        public void Example212()
        {
            Assert.Equal(@"<ul>
<li>
<p>foo</p>
<p>bar</p>
</li>
<li>
<p>foo</p>
</li>
</ul>
<p>bar</p>
<ul>
<li>
<pre><code>foo


bar
</code></pre>
</li>
<li>
<p>baz</p>
<ul>
<li>
<pre><code>foo


bar
</code></pre>
</li>
</ul>
</li>
</ul>
", GetHtml(@"- foo

  bar

- foo


  bar

- ```
  foo


  bar
  ```

- baz

  + ```
    foo


    bar
    ```
"));
        }

        #endregion

        #region Example 213
        [Fact]
        public void Example213()
        {
            Assert.Equal(@"<ol>
<li>
<p>foo</p>
<pre><code>bar
</code></pre>
<p>baz</p>
<blockquote>
<p>bam</p>
</blockquote>
</li>
</ol>
", GetHtml(@"1.  foo

    ```
    bar
    ```

    baz

    > bam
"));
        }

        #endregion

        #region Example 214
        [Fact]
        public void Example214()
        {
            Assert.Equal(@"<ol start=""123456789"">
<li>ok</li>
</ol>
", GetHtml(@"123456789. ok
"));
        }

        #endregion

        #region Example 215
        [Fact]
        public void Example215()
        {
            Assert.Equal(@"<p>1234567890. not ok</p>
", GetHtml(@"1234567890. not ok
"));
        }

        #endregion

        #region Example 216
        [Fact]
        public void Example216()
        {
            Assert.Equal(@"<ol start=""0"">
<li>ok</li>
</ol>
", GetHtml(@"0. ok
"));
        }

        #endregion

        #region Example 217
        [Fact]
        public void Example217()
        {
            Assert.Equal(@"<ol start=""3"">
<li>ok</li>
</ol>
", GetHtml(@"003. ok
"));
        }

        #endregion

        #region Example 218
        [Fact]
        public void Example218()
        {
            Assert.Equal(@"<p>-1. not ok</p>
", GetHtml(@"-1. not ok
"));
        }

        #endregion

        #region Example 219
        [Fact]
        public void Example219()
        {
            Assert.Equal(@"<ul>
<li>
<p>foo</p>
<pre><code>bar
</code></pre>
</li>
</ul>
", GetHtml(@"- foo

      bar
"));
        }

        #endregion

        #region Example 220
        [Fact]
        public void Example220()
        {
            Assert.Equal(@"<ol start=""10"">
<li>
<p>foo</p>
<pre><code>bar
</code></pre>
</li>
</ol>
", GetHtml(@"  10.  foo

           bar
"));
        }

        #endregion

        #region Example 221
        [Fact]
        public void Example221()
        {
            Assert.Equal(@"<pre><code>indented code
</code></pre>
<p>paragraph</p>
<pre><code>more code
</code></pre>
", GetHtml(@"    indented code

paragraph

    more code
"));
        }

        #endregion

        #region Example 222
        [Fact]
        public void Example222()
        {
            Assert.Equal(@"<ol>
<li>
<pre><code>indented code
</code></pre>
<p>paragraph</p>
<pre><code>more code
</code></pre>
</li>
</ol>
", GetHtml(@"1.     indented code

   paragraph

       more code
"));
        }

        #endregion

        #region Example 223
        [Fact]
        public void Example223()
        {
            Assert.Equal(@"<ol>
<li>
<pre><code> indented code
</code></pre>
<p>paragraph</p>
<pre><code>more code
</code></pre>
</li>
</ol>
", GetHtml(@"1.      indented code

   paragraph

       more code
"));
        }

        #endregion

        #region Example 224
        [Fact]
        public void Example224()
        {
            Assert.Equal(@"<p>foo</p>
<p>bar</p>
", GetHtml(@"   foo

bar
"));
        }

        #endregion

        #region Example 225
        [Fact]
        public void Example225()
        {
            Assert.Equal(@"<ul>
<li>foo</li>
</ul>
<p>bar</p>
", GetHtml(@"-    foo

  bar
"));
        }

        #endregion

        #region Example 226
        [Fact]
        public void Example226()
        {
            Assert.Equal(@"<ul>
<li>
<p>foo</p>
<p>bar</p>
</li>
</ul>
", GetHtml(@"-  foo

   bar
"));
        }

        #endregion

        #region Example 227
        [Fact]
        public void Example227()
        {
            Assert.Equal(@"<ul>
<li>foo</li>
<li>
<pre><code>bar
</code></pre>
</li>
<li>
<pre><code>baz
</code></pre>
</li>
</ul>
", GetHtml(@"-
  foo
-
  ```
  bar
  ```
-
      baz
"));
        }

        #endregion

        #region Example 228
        [Fact]
        public void Example228()
        {
            Assert.Equal(@"<ul>
<li></li>
</ul>
<p>foo</p>
", GetHtml(@"-

  foo
"));
        }

        #endregion

        #region Example 229
        [Fact]
        public void Example229()
        {
            Assert.Equal(@"<ul>
<li>foo</li>
<li></li>
<li>bar</li>
</ul>
", GetHtml(@"- foo
-
- bar
"));
        }

        #endregion

        #region Example 230
        [Fact]
        public void Example230()
        {
            Assert.Equal(@"<ul>
<li>foo</li>
<li></li>
<li>bar</li>
</ul>
", GetHtml(@"- foo
-   
- bar
"));
        }

        #endregion

        #region Example 231
        [Fact]
        public void Example231()
        {
            Assert.Equal(@"<ol>
<li>foo</li>
<li></li>
<li>bar</li>
</ol>
", GetHtml(@"1. foo
2.
3. bar
"));
        }

        #endregion

        #region Example 232
        [Fact]
        public void Example232()
        {
            Assert.Equal(@"<ul>
<li></li>
</ul>
", GetHtml(@"*
"));
        }

        #endregion

        #region Example 233
        [Fact]
        public void Example233()
        {
            Assert.Equal(@"<ol>
<li>
<p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote>
</li>
</ol>
", GetHtml(@" 1.  A paragraph
     with two lines.

         indented code

     > A block quote.
"));
        }

        #endregion

        #region Example 234
        [Fact]
        public void Example234()
        {
            Assert.Equal(@"<ol>
<li>
<p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote>
</li>
</ol>
", GetHtml(@"  1.  A paragraph
      with two lines.

          indented code

      > A block quote.
"));
        }

        #endregion

        #region Example 235
        [Fact]
        public void Example235()
        {
            Assert.Equal(@"<ol>
<li>
<p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote>
</li>
</ol>
", GetHtml(@"   1.  A paragraph
       with two lines.

           indented code

       > A block quote.
"));
        }

        #endregion

        #region Example 236
        [Fact]
        public void Example236()
        {
            Assert.Equal(@"<pre><code>1.  A paragraph
    with two lines.

        indented code

    &gt; A block quote.
</code></pre>
", GetHtml(@"    1.  A paragraph
        with two lines.

            indented code

        > A block quote.
"));
        }

        #endregion

        #region Example 237
        [Fact]
        public void Example237()
        {
            Assert.Equal(@"<ol>
<li>
<p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote>
</li>
</ol>
", GetHtml(@"  1.  A paragraph
with two lines.

          indented code

      > A block quote.
"));
        }

        #endregion

        #region Example 238
        [Fact]
        public void Example238()
        {
            Assert.Equal(@"<ol>
<li>A paragraph
with two lines.</li>
</ol>
", GetHtml(@"  1.  A paragraph
    with two lines.
"));
        }

        #endregion

        #region Example 239
        [Fact]
        public void Example239()
        {
            Assert.Equal(@"<blockquote>
<ol>
<li>
<blockquote>
<p>Blockquote
continued here.</p>
</blockquote>
</li>
</ol>
</blockquote>
", GetHtml(@"> 1. > Blockquote
continued here.
"));
        }

        #endregion

        #region Example 240
        [Fact]
        public void Example240()
        {
            Assert.Equal(@"<blockquote>
<ol>
<li>
<blockquote>
<p>Blockquote
continued here.</p>
</blockquote>
</li>
</ol>
</blockquote>
", GetHtml(@"> 1. > Blockquote
> continued here.
"));
        }

        #endregion

        #region Example 241
        [Fact]
        public void Example241()
        {
            Assert.Equal(@"<ul>
<li>foo
<ul>
<li>bar
<ul>
<li>baz</li>
</ul>
</li>
</ul>
</li>
</ul>
", GetHtml(@"- foo
  - bar
    - baz
"));
        }

        #endregion

        #region Example 242
        [Fact]
        public void Example242()
        {
            Assert.Equal(@"<ul>
<li>foo</li>
<li>bar</li>
<li>baz</li>
</ul>
", GetHtml(@"- foo
 - bar
  - baz
"));
        }

        #endregion

        #region Example 243
        [Fact]
        public void Example243()
        {
            Assert.Equal(@"<ol start=""10"">
<li>foo
<ul>
<li>bar</li>
</ul>
</li>
</ol>
", GetHtml(@"10) foo
    - bar
"));
        }

        #endregion

        #region Example 244
        [Fact]
        public void Example244()
        {
            Assert.Equal(@"<ol start=""10"">
<li>foo</li>
</ol>
<ul>
<li>bar</li>
</ul>
", GetHtml(@"10) foo
   - bar
"));
        }

        #endregion

        #region Example 245
        [Fact]
        public void Example245()
        {
            Assert.Equal(@"<ul>
<li>
<ul>
<li>foo</li>
</ul>
</li>
</ul>
", GetHtml(@"- - foo
"));
        }

        #endregion

        #region Example 246
        [Fact]
        public void Example246()
        {
            Assert.Equal(@"<ol>
<li>
<ul>
<li>
<ol start=""2"">
<li>foo</li>
</ol>
</li>
</ul>
</li>
</ol>
", GetHtml(@"1. - 2. foo
"));
        }

        #endregion

        #region Example 247
        [Fact]
        public void Example247()
        {
            Assert.Equal(@"<ul>
<li>
<h1>Foo</h1>
</li>
<li>
<h2>Bar</h2>
baz</li>
</ul>
", GetHtml(@"- # Foo
- Bar
  ---
  baz
"));
        }

        #endregion
    }
}