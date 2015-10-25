
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Linkreferencedefinitions: BaseTest
    {
        
        #region Example 146
        [Fact]
        public void Example146()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title"">foo</a></p>", GetHtml(@"[foo]: /url ""title""

[foo]"));
        }

        #endregion

        #region Example 147
        [Fact]
        public void Example147()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""the title"">foo</a></p>", GetHtml(@"   [foo]: 
      /url  
           'the title'  

[foo]"));
        }

        #endregion

        #region Example 148
        [Fact]
        public void Example148()
        {
            Assert.Equal(@"<p><a href=""my_(url)"" title=""title (with parens)"">Foo*bar]</a></p>", GetHtml(@"[Foo*bar\]]:my_(url) 'title (with parens)'

[Foo*bar\]]"));
        }

        #endregion

        #region Example 149
        [Fact]
        public void Example149()
        {
            Assert.Equal(@"<p><a href=""my%20url"" title=""title"">Foo bar</a></p>", GetHtml(@"[Foo bar]:
<my url>
'title'

[Foo bar]"));
        }

        #endregion

        #region Example 150
        [Fact]
        public void Example150()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""
title
line1
line2
"">foo</a></p>", GetHtml(@"[foo]: /url '
title
line1
line2
'

[foo]"));
        }

        #endregion

        #region Example 151
        [Fact]
        public void Example151()
        {
            Assert.Equal(@"<p>[foo]: /url 'title</p>
<p>with blank line'</p>
<p>[foo]</p>", GetHtml(@"[foo]: /url 'title

with blank line'

[foo]"));
        }

        #endregion

        #region Example 152
        [Fact]
        public void Example152()
        {
            Assert.Equal(@"<p><a href=""/url"">foo</a></p>", GetHtml(@"[foo]:
/url

[foo]"));
        }

        #endregion

        #region Example 153
        [Fact]
        public void Example153()
        {
            Assert.Equal(@"<p>[foo]:</p>
<p>[foo]</p>", GetHtml(@"[foo]:

[foo]"));
        }

        #endregion

        #region Example 154
        [Fact]
        public void Example154()
        {
            Assert.Equal(@"<p><a href=""/url%5Cbar*baz"" title=""foo&quot;bar\baz"">foo</a></p>", GetHtml(@"[foo]: /url\bar\*baz ""foo\""bar\baz""

[foo]"));
        }

        #endregion

        #region Example 155
        [Fact]
        public void Example155()
        {
            Assert.Equal(@"<p><a href=""url"">foo</a></p>", GetHtml(@"[foo]

[foo]: url"));
        }

        #endregion

        #region Example 156
        [Fact]
        public void Example156()
        {
            Assert.Equal(@"<p><a href=""first"">foo</a></p>", GetHtml(@"[foo]

[foo]: first
[foo]: second"));
        }

        #endregion

        #region Example 157
        [Fact]
        public void Example157()
        {
            Assert.Equal(@"<p><a href=""/url"">Foo</a></p>", GetHtml(@"[FOO]: /url

[Foo]"));
        }

        #endregion

        #region Example 158
        [Fact]
        public void Example158()
        {
            Assert.Equal(@"<p><a href=""/%CF%86%CE%BF%CF%85"">αγω</a></p>", GetHtml(@"[ΑΓΩ]: /φου

[αγω]"));
        }

        #endregion

        #region Example 159
        [Fact]
        public void Example159()
        {
            Assert.Equal(@"", GetHtml(@"[foo]: /url"));
        }

        #endregion

        #region Example 160
        [Fact]
        public void Example160()
        {
            Assert.Equal(@"<p>bar</p>", GetHtml(@"[
foo
]: /url
bar"));
        }

        #endregion

        #region Example 161
        [Fact]
        public void Example161()
        {
            Assert.Equal(@"<p>[foo]: /url &quot;title&quot; ok</p>", GetHtml(@"[foo]: /url ""title"" ok"));
        }

        #endregion

        #region Example 162
        [Fact]
        public void Example162()
        {
            Assert.Equal(@"<p>&quot;title&quot; ok</p>", GetHtml(@"[foo]: /url
""title"" ok"));
        }

        #endregion

        #region Example 163
        [Fact]
        public void Example163()
        {
            Assert.Equal(@"<pre><code>[foo]: /url &quot;title&quot;
</code></pre>
<p>[foo]</p>", GetHtml(@"    [foo]: /url ""title""

[foo]"));
        }

        #endregion

        #region Example 164
        [Fact]
        public void Example164()
        {
            Assert.Equal(@"<pre><code>[foo]: /url
</code></pre>
<p>[foo]</p>", GetHtml(@"```
[foo]: /url
```

[foo]"));
        }

        #endregion

        #region Example 165
        [Fact]
        public void Example165()
        {
            Assert.Equal(@"<p>Foo
[bar]: /baz</p>
<p>[bar]</p>", GetHtml(@"Foo
[bar]: /baz

[bar]"));
        }

        #endregion

        #region Example 166
        [Fact]
        public void Example166()
        {
            Assert.Equal(@"<h1><a href=""/url"">Foo</a></h1>
<blockquote>
<p>bar</p>
</blockquote>", GetHtml(@"# [Foo]
[foo]: /url
> bar"));
        }

        #endregion

        #region Example 167
        [Fact]
        public void Example167()
        {
            Assert.Equal(@"<p><a href=""/foo-url"" title=""foo"">foo</a>,
<a href=""/bar-url"" title=""bar"">bar</a>,
<a href=""/baz-url"">baz</a></p>", GetHtml(@"[foo]: /foo-url ""foo""
[bar]: /bar-url
  ""bar""
[baz]: /baz-url

[foo],
[bar],
[baz]"));
        }

        #endregion

        #region Example 168
        [Fact]
        public void Example168()
        {
            Assert.Equal(@"<p><a href=""/url"">foo</a></p>
<blockquote>
</blockquote>", GetHtml(@"[foo]

> [foo]: /url"));
        }

        #endregion
    }
}