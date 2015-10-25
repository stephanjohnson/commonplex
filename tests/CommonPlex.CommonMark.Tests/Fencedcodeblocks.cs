
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Fencedcodeblocks: BaseTest
    {
        
        #region Example 077
        [Fact]
        public void Example077()
        {
            Assert.Equal(@"<pre><code>&lt;
 &gt;
</code></pre>
", GetHtml(@"```
<
 >
```
"));
        }

        #endregion

        #region Example 078
        [Fact]
        public void Example078()
        {
            Assert.Equal(@"<pre><code>&lt;
 &gt;
</code></pre>
", GetHtml(@"~~~
<
 >
~~~
"));
        }

        #endregion

        #region Example 079
        [Fact]
        public void Example079()
        {
            Assert.Equal(@"<pre><code>aaa
~~~
</code></pre>
", GetHtml(@"```
aaa
~~~
```
"));
        }

        #endregion

        #region Example 080
        [Fact]
        public void Example080()
        {
            Assert.Equal(@"<pre><code>aaa
```
</code></pre>
", GetHtml(@"~~~
aaa
```
~~~
"));
        }

        #endregion

        #region Example 081
        [Fact]
        public void Example081()
        {
            Assert.Equal(@"<pre><code>aaa
```
</code></pre>
", GetHtml(@"````
aaa
```
``````
"));
        }

        #endregion

        #region Example 082
        [Fact]
        public void Example082()
        {
            Assert.Equal(@"<pre><code>aaa
~~~
</code></pre>
", GetHtml(@"~~~~
aaa
~~~
~~~~
"));
        }

        #endregion

        #region Example 083
        [Fact]
        public void Example083()
        {
            Assert.Equal(@"<pre><code></code></pre>
", GetHtml(@"```
"));
        }

        #endregion

        #region Example 084
        [Fact]
        public void Example084()
        {
            Assert.Equal(@"<pre><code>
```
aaa
</code></pre>
", GetHtml(@"`````

```
aaa
"));
        }

        #endregion

        #region Example 085
        [Fact]
        public void Example085()
        {
            Assert.Equal(@"<blockquote>
<pre><code>aaa
</code></pre>
</blockquote>
<p>bbb</p>
", GetHtml(@"> ```
> aaa

bbb
"));
        }

        #endregion

        #region Example 086
        [Fact]
        public void Example086()
        {
            Assert.Equal(@"<pre><code>
  
</code></pre>
", GetHtml(@"```

  
```
"));
        }

        #endregion

        #region Example 087
        [Fact]
        public void Example087()
        {
            Assert.Equal(@"<pre><code></code></pre>
", GetHtml(@"```
```
"));
        }

        #endregion

        #region Example 088
        [Fact]
        public void Example088()
        {
            Assert.Equal(@"<pre><code>aaa
aaa
</code></pre>
", GetHtml(@" ```
 aaa
aaa
```
"));
        }

        #endregion

        #region Example 089
        [Fact]
        public void Example089()
        {
            Assert.Equal(@"<pre><code>aaa
aaa
aaa
</code></pre>
", GetHtml(@"  ```
aaa
  aaa
aaa
  ```
"));
        }

        #endregion

        #region Example 090
        [Fact]
        public void Example090()
        {
            Assert.Equal(@"<pre><code>aaa
 aaa
aaa
</code></pre>
", GetHtml(@"   ```
   aaa
    aaa
  aaa
   ```
"));
        }

        #endregion

        #region Example 091
        [Fact]
        public void Example091()
        {
            Assert.Equal(@"<pre><code>```
aaa
```
</code></pre>
", GetHtml(@"    ```
    aaa
    ```
"));
        }

        #endregion

        #region Example 092
        [Fact]
        public void Example092()
        {
            Assert.Equal(@"<pre><code>aaa
</code></pre>
", GetHtml(@"```
aaa
  ```
"));
        }

        #endregion

        #region Example 093
        [Fact]
        public void Example093()
        {
            Assert.Equal(@"<pre><code>aaa
</code></pre>
", GetHtml(@"   ```
aaa
  ```
"));
        }

        #endregion

        #region Example 094
        [Fact]
        public void Example094()
        {
            Assert.Equal(@"<pre><code>aaa
    ```
</code></pre>
", GetHtml(@"```
aaa
    ```
"));
        }

        #endregion

        #region Example 095
        [Fact]
        public void Example095()
        {
            Assert.Equal(@"<p><code></code>
aaa</p>
", GetHtml(@"``` ```
aaa
"));
        }

        #endregion

        #region Example 096
        [Fact]
        public void Example096()
        {
            Assert.Equal(@"<pre><code>aaa
~~~ ~~
</code></pre>
", GetHtml(@"~~~~~~
aaa
~~~ ~~
"));
        }

        #endregion

        #region Example 097
        [Fact]
        public void Example097()
        {
            Assert.Equal(@"<p>foo</p>
<pre><code>bar
</code></pre>
<p>baz</p>
", GetHtml(@"foo
```
bar
```
baz
"));
        }

        #endregion

        #region Example 098
        [Fact]
        public void Example098()
        {
            Assert.Equal(@"<h2>foo</h2>
<pre><code>bar
</code></pre>
<h1>baz</h1>
", GetHtml(@"foo
---
~~~
bar
~~~
# baz
"));
        }

        #endregion

        #region Example 099
        [Fact]
        public void Example099()
        {
            Assert.Equal(@"<pre><code class=""language-ruby"">def foo(x)
  return 3
end
</code></pre>
", GetHtml(@"```ruby
def foo(x)
  return 3
end
```
"));
        }

        #endregion

        #region Example 100
        [Fact]
        public void Example100()
        {
            Assert.Equal(@"<pre><code class=""language-ruby"">def foo(x)
  return 3
end
</code></pre>
", GetHtml(@"~~~~    ruby startline=3 $%@#$
def foo(x)
  return 3
end
~~~~~~~
"));
        }

        #endregion

        #region Example 101
        [Fact]
        public void Example101()
        {
            Assert.Equal(@"<pre><code class=""language-;""></code></pre>
", GetHtml(@"````;
````
"));
        }

        #endregion

        #region Example 102
        [Fact]
        public void Example102()
        {
            Assert.Equal(@"<p><code>aa</code>
foo</p>
", GetHtml(@"``` aa ```
foo
"));
        }

        #endregion

        #region Example 103
        [Fact]
        public void Example103()
        {
            Assert.Equal(@"<pre><code>``` aaa
</code></pre>
", GetHtml(@"```
``` aaa
```
"));
        }

        #endregion
    }
}