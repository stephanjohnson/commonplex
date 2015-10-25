
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Blockquotes: BaseTest
    {
        
        #region Example 178
        [Fact]
        public void Example178()
        {
            Assert.Equal(@"<blockquote>
<h1>Foo</h1>
<p>bar
baz</p>
</blockquote>
", GetHtml(@"> # Foo
> bar
> baz
"));
        }

        #endregion

        #region Example 179
        [Fact]
        public void Example179()
        {
            Assert.Equal(@"<blockquote>
<h1>Foo</h1>
<p>bar
baz</p>
</blockquote>
", GetHtml(@"># Foo
>bar
> baz
"));
        }

        #endregion

        #region Example 180
        [Fact]
        public void Example180()
        {
            Assert.Equal(@"<blockquote>
<h1>Foo</h1>
<p>bar
baz</p>
</blockquote>
", GetHtml(@"   > # Foo
   > bar
 > baz
"));
        }

        #endregion

        #region Example 181
        [Fact]
        public void Example181()
        {
            Assert.Equal(@"<pre><code>&gt; # Foo
&gt; bar
&gt; baz
</code></pre>
", GetHtml(@"    > # Foo
    > bar
    > baz
"));
        }

        #endregion

        #region Example 182
        [Fact]
        public void Example182()
        {
            Assert.Equal(@"<blockquote>
<h1>Foo</h1>
<p>bar
baz</p>
</blockquote>
", GetHtml(@"> # Foo
> bar
baz
"));
        }

        #endregion

        #region Example 183
        [Fact]
        public void Example183()
        {
            Assert.Equal(@"<blockquote>
<p>bar
baz
foo</p>
</blockquote>
", GetHtml(@"> bar
baz
> foo
"));
        }

        #endregion

        #region Example 184
        [Fact]
        public void Example184()
        {
            Assert.Equal(@"<blockquote>
<p>foo</p>
</blockquote>
<hr />
", GetHtml(@"> foo
---
"));
        }

        #endregion

        #region Example 185
        [Fact]
        public void Example185()
        {
            Assert.Equal(@"<blockquote>
<ul>
<li>foo</li>
</ul>
</blockquote>
<ul>
<li>bar</li>
</ul>
", GetHtml(@"> - foo
- bar
"));
        }

        #endregion

        #region Example 186
        [Fact]
        public void Example186()
        {
            Assert.Equal(@"<blockquote>
<pre><code>foo
</code></pre>
</blockquote>
<pre><code>bar
</code></pre>
", GetHtml(@">     foo
    bar
"));
        }

        #endregion

        #region Example 187
        [Fact]
        public void Example187()
        {
            Assert.Equal(@"<blockquote>
<pre><code></code></pre>
</blockquote>
<p>foo</p>
<pre><code></code></pre>
", GetHtml(@"> ```
foo
```
"));
        }

        #endregion

        #region Example 188
        [Fact]
        public void Example188()
        {
            Assert.Equal(@"<blockquote>
<p>foo
- bar</p>
</blockquote>
", GetHtml(@"> foo
    - bar
"));
        }

        #endregion

        #region Example 189
        [Fact]
        public void Example189()
        {
            Assert.Equal(@"<blockquote>
</blockquote>
", GetHtml(@">
"));
        }

        #endregion

        #region Example 190
        [Fact]
        public void Example190()
        {
            Assert.Equal(@"<blockquote>
</blockquote>
", GetHtml(@">
>  
> 
"));
        }

        #endregion

        #region Example 191
        [Fact]
        public void Example191()
        {
            Assert.Equal(@"<blockquote>
<p>foo</p>
</blockquote>
", GetHtml(@">
> foo
>  
"));
        }

        #endregion

        #region Example 192
        [Fact]
        public void Example192()
        {
            Assert.Equal(@"<blockquote>
<p>foo</p>
</blockquote>
<blockquote>
<p>bar</p>
</blockquote>
", GetHtml(@"> foo

> bar
"));
        }

        #endregion

        #region Example 193
        [Fact]
        public void Example193()
        {
            Assert.Equal(@"<blockquote>
<p>foo
bar</p>
</blockquote>
", GetHtml(@"> foo
> bar
"));
        }

        #endregion

        #region Example 194
        [Fact]
        public void Example194()
        {
            Assert.Equal(@"<blockquote>
<p>foo</p>
<p>bar</p>
</blockquote>
", GetHtml(@"> foo
>
> bar
"));
        }

        #endregion

        #region Example 195
        [Fact]
        public void Example195()
        {
            Assert.Equal(@"<p>foo</p>
<blockquote>
<p>bar</p>
</blockquote>
", GetHtml(@"foo
> bar
"));
        }

        #endregion

        #region Example 196
        [Fact]
        public void Example196()
        {
            Assert.Equal(@"<blockquote>
<p>aaa</p>
</blockquote>
<hr />
<blockquote>
<p>bbb</p>
</blockquote>
", GetHtml(@"> aaa
***
> bbb
"));
        }

        #endregion

        #region Example 197
        [Fact]
        public void Example197()
        {
            Assert.Equal(@"<blockquote>
<p>bar
baz</p>
</blockquote>
", GetHtml(@"> bar
baz
"));
        }

        #endregion

        #region Example 198
        [Fact]
        public void Example198()
        {
            Assert.Equal(@"<blockquote>
<p>bar</p>
</blockquote>
<p>baz</p>
", GetHtml(@"> bar

baz
"));
        }

        #endregion

        #region Example 199
        [Fact]
        public void Example199()
        {
            Assert.Equal(@"<blockquote>
<p>bar</p>
</blockquote>
<p>baz</p>
", GetHtml(@"> bar
>
baz
"));
        }

        #endregion

        #region Example 200
        [Fact]
        public void Example200()
        {
            Assert.Equal(@"<blockquote>
<blockquote>
<blockquote>
<p>foo
bar</p>
</blockquote>
</blockquote>
</blockquote>
", GetHtml(@"> > > foo
bar
"));
        }

        #endregion

        #region Example 201
        [Fact]
        public void Example201()
        {
            Assert.Equal(@"<blockquote>
<blockquote>
<blockquote>
<p>foo
bar
baz</p>
</blockquote>
</blockquote>
</blockquote>
", GetHtml(@">>> foo
> bar
>>baz
"));
        }

        #endregion

        #region Example 202
        [Fact]
        public void Example202()
        {
            Assert.Equal(@"<blockquote>
<pre><code>code
</code></pre>
</blockquote>
<blockquote>
<p>not code</p>
</blockquote>
", GetHtml(@">     code

>    not code
"));
        }

        #endregion
    }
}