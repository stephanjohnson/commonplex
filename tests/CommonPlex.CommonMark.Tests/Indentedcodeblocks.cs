
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Indentedcodeblocks: BaseTest
    {
        
        #region Example 065
        [Fact]
        public void Example065()
        {
            Assert.Equal(@"<pre><code>a simple
  indented code block
</code></pre>", GetHtml(@"    a simple
      indented code block"));
        }

        #endregion

        #region Example 066
        [Fact]
        public void Example066()
        {
            Assert.Equal(@"<ul>
<li>
<p>foo</p>
<p>bar</p>
</li>
</ul>", GetHtml(@"  - foo

    bar"));
        }

        #endregion

        #region Example 067
        [Fact]
        public void Example067()
        {
            Assert.Equal(@"<ol>
<li>
<p>foo</p>
<ul>
<li>bar</li>
</ul>
</li>
</ol>", GetHtml(@"1.  foo

    - bar"));
        }

        #endregion

        #region Example 068
        [Fact]
        public void Example068()
        {
            Assert.Equal(@"<pre><code>&lt;a/&gt;
*hi*

- one
</code></pre>", GetHtml(@"    <a/>
    *hi*

    - one"));
        }

        #endregion

        #region Example 069
        [Fact]
        public void Example069()
        {
            Assert.Equal(@"<pre><code>chunk1

chunk2



chunk3
</code></pre>", GetHtml(@"    chunk1

    chunk2
  
 
 
    chunk3"));
        }

        #endregion

        #region Example 070
        [Fact]
        public void Example070()
        {
            Assert.Equal(@"<pre><code>chunk1
  
  chunk2
</code></pre>", GetHtml(@"    chunk1
      
      chunk2"));
        }

        #endregion

        #region Example 071
        [Fact]
        public void Example071()
        {
            Assert.Equal(@"<p>Foo
bar</p>", GetHtml(@"Foo
    bar
"));
        }

        #endregion

        #region Example 072
        [Fact]
        public void Example072()
        {
            Assert.Equal(@"<pre><code>foo
</code></pre>
<p>bar</p>", GetHtml(@"    foo
bar"));
        }

        #endregion

        #region Example 073
        [Fact]
        public void Example073()
        {
            Assert.Equal(@"<h1>Header</h1>
<pre><code>foo
</code></pre>
<h2>Header</h2>
<pre><code>foo
</code></pre>
<hr />", GetHtml(@"# Header
    foo
Header
------
    foo
----"));
        }

        #endregion

        #region Example 074
        [Fact]
        public void Example074()
        {
            Assert.Equal(@"<pre><code>    foo
bar
</code></pre>", GetHtml(@"        foo
    bar"));
        }

        #endregion

        #region Example 075
        [Fact]
        public void Example075()
        {
            Assert.Equal(@"<pre><code>foo
</code></pre>", GetHtml(@"
    
    foo
    
"));
        }

        #endregion

        #region Example 076
        [Fact]
        public void Example076()
        {
            Assert.Equal(@"<pre><code>foo  
</code></pre>", GetHtml(@"    foo  "));
        }

        #endregion
    }
}