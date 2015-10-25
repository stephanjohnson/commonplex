
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Lists: BaseTest
    {
        
        #region Example 248
        [Fact]
        public void Example248()
        {
            Assert.Equal(@"<ul>
<li>foo</li>
<li>bar</li>
</ul>
<ul>
<li>baz</li>
</ul>", GetHtml(@"- foo
- bar
+ baz"));
        }

        #endregion

        #region Example 249
        [Fact]
        public void Example249()
        {
            Assert.Equal(@"<ol>
<li>foo</li>
<li>bar</li>
</ol>
<ol start=""3"">
<li>baz</li>
</ol>", GetHtml(@"1. foo
2. bar
3) baz"));
        }

        #endregion

        #region Example 250
        [Fact]
        public void Example250()
        {
            Assert.Equal(@"<p>Foo</p>
<ul>
<li>bar</li>
<li>baz</li>
</ul>", GetHtml(@"Foo
- bar
- baz"));
        }

        #endregion

        #region Example 251
        [Fact]
        public void Example251()
        {
            Assert.Equal(@"<p>The number of windows in my house is</p>
<ol start=""14"">
<li>The number of doors is 6.</li>
</ol>", GetHtml(@"The number of windows in my house is
14.  The number of doors is 6."));
        }

        #endregion

        #region Example 252
        [Fact]
        public void Example252()
        {
            Assert.Equal(@"<ul>
<li>
<p>foo</p>
</li>
<li>
<p>bar</p>
</li>
</ul>
<ul>
<li>baz</li>
</ul>", GetHtml(@"- foo

- bar


- baz"));
        }

        #endregion

        #region Example 253
        [Fact]
        public void Example253()
        {
            Assert.Equal(@"<ul>
<li>foo</li>
</ul>
<p>bar</p>
<ul>
<li>baz</li>
</ul>", GetHtml(@"- foo


  bar
- baz"));
        }

        #endregion

        #region Example 254
        [Fact]
        public void Example254()
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
<pre><code>  bim
</code></pre>", GetHtml(@"- foo
  - bar
    - baz


      bim"));
        }

        #endregion

        #region Example 255
        [Fact]
        public void Example255()
        {
            Assert.Equal(@"<ul>
<li>foo</li>
<li>bar</li>
</ul>
<ul>
<li>baz</li>
<li>bim</li>
</ul>", GetHtml(@"- foo
- bar


- baz
- bim"));
        }

        #endregion

        #region Example 256
        [Fact]
        public void Example256()
        {
            Assert.Equal(@"<ul>
<li>
<p>foo</p>
<p>notcode</p>
</li>
<li>
<p>foo</p>
</li>
</ul>
<pre><code>code
</code></pre>", GetHtml(@"-   foo

    notcode

-   foo


    code"));
        }

        #endregion

        #region Example 257
        [Fact]
        public void Example257()
        {
            Assert.Equal(@"<ul>
<li>a</li>
<li>b</li>
<li>c</li>
<li>d</li>
<li>e</li>
<li>f</li>
<li>g</li>
<li>h</li>
<li>i</li>
</ul>", GetHtml(@"- a
 - b
  - c
   - d
    - e
   - f
  - g
 - h
- i"));
        }

        #endregion

        #region Example 258
        [Fact]
        public void Example258()
        {
            Assert.Equal(@"<ol>
<li>
<p>a</p>
</li>
<li>
<p>b</p>
</li>
<li>
<p>c</p>
</li>
</ol>", GetHtml(@"1. a

  2. b

    3. c"));
        }

        #endregion

        #region Example 259
        [Fact]
        public void Example259()
        {
            Assert.Equal(@"<ul>
<li>
<p>a</p>
</li>
<li>
<p>b</p>
</li>
<li>
<p>c</p>
</li>
</ul>", GetHtml(@"- a
- b

- c"));
        }

        #endregion

        #region Example 260
        [Fact]
        public void Example260()
        {
            Assert.Equal(@"<ul>
<li>
<p>a</p>
</li>
<li></li>
<li>
<p>c</p>
</li>
</ul>", GetHtml(@"* a
*

* c"));
        }

        #endregion

        #region Example 261
        [Fact]
        public void Example261()
        {
            Assert.Equal(@"<ul>
<li>
<p>a</p>
</li>
<li>
<p>b</p>
<p>c</p>
</li>
<li>
<p>d</p>
</li>
</ul>", GetHtml(@"- a
- b

  c
- d"));
        }

        #endregion

        #region Example 262
        [Fact]
        public void Example262()
        {
            Assert.Equal(@"<ul>
<li>
<p>a</p>
</li>
<li>
<p>b</p>
</li>
<li>
<p>d</p>
</li>
</ul>", GetHtml(@"- a
- b

  [ref]: /url
- d"));
        }

        #endregion

        #region Example 263
        [Fact]
        public void Example263()
        {
            Assert.Equal(@"<ul>
<li>a</li>
<li>
<pre><code>b


</code></pre>
</li>
<li>c</li>
</ul>", GetHtml(@"- a
- ```
  b


  ```
- c"));
        }

        #endregion

        #region Example 264
        [Fact]
        public void Example264()
        {
            Assert.Equal(@"<ul>
<li>a
<ul>
<li>
<p>b</p>
<p>c</p>
</li>
</ul>
</li>
<li>d</li>
</ul>", GetHtml(@"- a
  - b

    c
- d"));
        }

        #endregion

        #region Example 265
        [Fact]
        public void Example265()
        {
            Assert.Equal(@"<ul>
<li>a
<blockquote>
<p>b</p>
</blockquote>
</li>
<li>c</li>
</ul>", GetHtml(@"* a
  > b
  >
* c"));
        }

        #endregion

        #region Example 266
        [Fact]
        public void Example266()
        {
            Assert.Equal(@"<ul>
<li>a
<blockquote>
<p>b</p>
</blockquote>
<pre><code>c
</code></pre>
</li>
<li>d</li>
</ul>", GetHtml(@"- a
  > b
  ```
  c
  ```
- d"));
        }

        #endregion

        #region Example 267
        [Fact]
        public void Example267()
        {
            Assert.Equal(@"<ul>
<li>a</li>
</ul>", GetHtml(@"- a"));
        }

        #endregion

        #region Example 268
        [Fact]
        public void Example268()
        {
            Assert.Equal(@"<ul>
<li>a
<ul>
<li>b</li>
</ul>
</li>
</ul>", GetHtml(@"- a
  - b"));
        }

        #endregion

        #region Example 269
        [Fact]
        public void Example269()
        {
            Assert.Equal(@"<ol>
<li>
<pre><code>foo
</code></pre>
<p>bar</p>
</li>
</ol>", GetHtml(@"1. ```
   foo
   ```

   bar"));
        }

        #endregion

        #region Example 270
        [Fact]
        public void Example270()
        {
            Assert.Equal(@"<ul>
<li>
<p>foo</p>
<ul>
<li>bar</li>
</ul>
<p>baz</p>
</li>
</ul>", GetHtml(@"* foo
  * bar

  baz"));
        }

        #endregion

        #region Example 271
        [Fact]
        public void Example271()
        {
            Assert.Equal(@"<ul>
<li>
<p>a</p>
<ul>
<li>b</li>
<li>c</li>
</ul>
</li>
<li>
<p>d</p>
<ul>
<li>e</li>
<li>f</li>
</ul>
</li>
</ul>", GetHtml(@"- a
  - b
  - c

- d
  - e
  - f"));
        }

        #endregion
    }
}