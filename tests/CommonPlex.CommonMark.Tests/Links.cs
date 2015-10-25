
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Links: BaseTest
    {
        
        #region Example 442
        [Fact]
        public void Example442()
        {
            Assert.Equal(@"<p><a href=""/uri"" title=""title"">link</a></p>
", GetHtml(@"[link](/uri ""title"")
"));
        }

        #endregion

        #region Example 443
        [Fact]
        public void Example443()
        {
            Assert.Equal(@"<p><a href=""/uri"">link</a></p>
", GetHtml(@"[link](/uri)
"));
        }

        #endregion

        #region Example 444
        [Fact]
        public void Example444()
        {
            Assert.Equal(@"<p><a href="""">link</a></p>
", GetHtml(@"[link]()
"));
        }

        #endregion

        #region Example 445
        [Fact]
        public void Example445()
        {
            Assert.Equal(@"<p><a href="""">link</a></p>
", GetHtml(@"[link](<>)
"));
        }

        #endregion

        #region Example 446
        [Fact]
        public void Example446()
        {
            Assert.Equal(@"<p>[link](/my uri)</p>
", GetHtml(@"[link](/my uri)
"));
        }

        #endregion

        #region Example 447
        [Fact]
        public void Example447()
        {
            Assert.Equal(@"<p><a href=""/my%20uri"">link</a></p>
", GetHtml(@"[link](</my uri>)
"));
        }

        #endregion

        #region Example 448
        [Fact]
        public void Example448()
        {
            Assert.Equal(@"<p>[link](foo
bar)</p>
", GetHtml(@"[link](foo
bar)
"));
        }

        #endregion

        #region Example 449
        [Fact]
        public void Example449()
        {
            Assert.Equal(@"<p>[link](<foo
bar>)</p>
", GetHtml(@"[link](<foo
bar>)
"));
        }

        #endregion

        #region Example 450
        [Fact]
        public void Example450()
        {
            Assert.Equal(@"<p><a href=""(foo)and(bar)"">link</a></p>
", GetHtml(@"[link]((foo)and(bar))
"));
        }

        #endregion

        #region Example 451
        [Fact]
        public void Example451()
        {
            Assert.Equal(@"<p>[link](foo(and(bar)))</p>
", GetHtml(@"[link](foo(and(bar)))
"));
        }

        #endregion

        #region Example 452
        [Fact]
        public void Example452()
        {
            Assert.Equal(@"<p><a href=""foo(and(bar))"">link</a></p>
", GetHtml(@"[link](foo(and\(bar\)))
"));
        }

        #endregion

        #region Example 453
        [Fact]
        public void Example453()
        {
            Assert.Equal(@"<p><a href=""foo(and(bar))"">link</a></p>
", GetHtml(@"[link](<foo(and(bar))>)
"));
        }

        #endregion

        #region Example 454
        [Fact]
        public void Example454()
        {
            Assert.Equal(@"<p><a href=""foo):"">link</a></p>
", GetHtml(@"[link](foo\)\:)
"));
        }

        #endregion

        #region Example 455
        [Fact]
        public void Example455()
        {
            Assert.Equal(@"<p><a href=""#fragment"">link</a></p>
<p><a href=""http://example.com#fragment"">link</a></p>
<p><a href=""http://example.com?foo=bar&amp;baz#fragment"">link</a></p>
", GetHtml(@"[link](#fragment)

[link](http://example.com#fragment)

[link](http://example.com?foo=bar&baz#fragment)
"));
        }

        #endregion

        #region Example 456
        [Fact]
        public void Example456()
        {
            Assert.Equal(@"<p><a href=""foo%5Cbar"">link</a></p>
", GetHtml(@"[link](foo\bar)
"));
        }

        #endregion

        #region Example 457
        [Fact]
        public void Example457()
        {
            Assert.Equal(@"<p><a href=""foo%20b%C3%A4"">link</a></p>
", GetHtml(@"[link](foo%20b&auml;)
"));
        }

        #endregion

        #region Example 458
        [Fact]
        public void Example458()
        {
            Assert.Equal(@"<p><a href=""%22title%22"">link</a></p>
", GetHtml(@"[link](""title"")
"));
        }

        #endregion

        #region Example 459
        [Fact]
        public void Example459()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title"">link</a>
<a href=""/url"" title=""title"">link</a>
<a href=""/url"" title=""title"">link</a></p>
", GetHtml(@"[link](/url ""title"")
[link](/url 'title')
[link](/url (title))
"));
        }

        #endregion

        #region Example 460
        [Fact]
        public void Example460()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title &quot;&quot;"">link</a></p>
", GetHtml(@"[link](/url ""title \""&quot;"")
"));
        }

        #endregion

        #region Example 461
        [Fact]
        public void Example461()
        {
            Assert.Equal(@"<p>[link](/url &quot;title &quot;and&quot; title&quot;)</p>
", GetHtml(@"[link](/url ""title ""and"" title"")
"));
        }

        #endregion

        #region Example 462
        [Fact]
        public void Example462()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title &quot;and&quot; title"">link</a></p>
", GetHtml(@"[link](/url 'title ""and"" title')
"));
        }

        #endregion

        #region Example 463
        [Fact]
        public void Example463()
        {
            Assert.Equal(@"<p><a href=""/uri"" title=""title"">link</a></p>
", GetHtml(@"[link](   /uri
  ""title""  )
"));
        }

        #endregion

        #region Example 464
        [Fact]
        public void Example464()
        {
            Assert.Equal(@"<p>[link] (/uri)</p>
", GetHtml(@"[link] (/uri)
"));
        }

        #endregion

        #region Example 465
        [Fact]
        public void Example465()
        {
            Assert.Equal(@"<p><a href=""/uri"">link [foo [bar]]</a></p>
", GetHtml(@"[link [foo [bar]]](/uri)
"));
        }

        #endregion

        #region Example 466
        [Fact]
        public void Example466()
        {
            Assert.Equal(@"<p>[link] bar](/uri)</p>
", GetHtml(@"[link] bar](/uri)
"));
        }

        #endregion

        #region Example 467
        [Fact]
        public void Example467()
        {
            Assert.Equal(@"<p>[link <a href=""/uri"">bar</a></p>
", GetHtml(@"[link [bar](/uri)
"));
        }

        #endregion

        #region Example 468
        [Fact]
        public void Example468()
        {
            Assert.Equal(@"<p><a href=""/uri"">link [bar</a></p>
", GetHtml(@"[link \[bar](/uri)
"));
        }

        #endregion

        #region Example 469
        [Fact]
        public void Example469()
        {
            Assert.Equal(@"<p><a href=""/uri"">link <em>foo <strong>bar</strong> <code>#</code></em></a></p>
", GetHtml(@"[link *foo **bar** `#`*](/uri)
"));
        }

        #endregion

        #region Example 470
        [Fact]
        public void Example470()
        {
            Assert.Equal(@"<p><a href=""/uri""><img src=""moon.jpg"" alt=""moon"" /></a></p>
", GetHtml(@"[![moon](moon.jpg)](/uri)
"));
        }

        #endregion

        #region Example 471
        [Fact]
        public void Example471()
        {
            Assert.Equal(@"<p>[foo <a href=""/uri"">bar</a>](/uri)</p>
", GetHtml(@"[foo [bar](/uri)](/uri)
"));
        }

        #endregion

        #region Example 472
        [Fact]
        public void Example472()
        {
            Assert.Equal(@"<p>[foo <em>[bar <a href=""/uri"">baz</a>](/uri)</em>](/uri)</p>
", GetHtml(@"[foo *[bar [baz](/uri)](/uri)*](/uri)
"));
        }

        #endregion

        #region Example 473
        [Fact]
        public void Example473()
        {
            Assert.Equal(@"<p><img src=""uri3"" alt=""[foo](uri2)"" /></p>
", GetHtml(@"![[[foo](uri1)](uri2)](uri3)
"));
        }

        #endregion

        #region Example 474
        [Fact]
        public void Example474()
        {
            Assert.Equal(@"<p>*<a href=""/uri"">foo*</a></p>
", GetHtml(@"*[foo*](/uri)
"));
        }

        #endregion

        #region Example 475
        [Fact]
        public void Example475()
        {
            Assert.Equal(@"<p><a href=""baz*"">foo *bar</a></p>
", GetHtml(@"[foo *bar](baz*)
"));
        }

        #endregion

        #region Example 476
        [Fact]
        public void Example476()
        {
            Assert.Equal(@"<p><em>foo [bar</em> baz]</p>
", GetHtml(@"*foo [bar* baz]
"));
        }

        #endregion

        #region Example 477
        [Fact]
        public void Example477()
        {
            Assert.Equal(@"<p>[foo <bar attr=""](baz)""></p>
", GetHtml(@"[foo <bar attr=""](baz)"">
"));
        }

        #endregion

        #region Example 478
        [Fact]
        public void Example478()
        {
            Assert.Equal(@"<p>[foo<code>](/uri)</code></p>
", GetHtml(@"[foo`](/uri)`
"));
        }

        #endregion

        #region Example 479
        [Fact]
        public void Example479()
        {
            Assert.Equal(@"<p>[foo<a href=""http://example.com/?search=%5D(uri)"">http://example.com/?search=](uri)</a></p>
", GetHtml(@"[foo<http://example.com/?search=](uri)>
"));
        }

        #endregion

        #region Example 480
        [Fact]
        public void Example480()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title"">foo</a></p>
", GetHtml(@"[foo][bar]

[bar]: /url ""title""
"));
        }

        #endregion

        #region Example 481
        [Fact]
        public void Example481()
        {
            Assert.Equal(@"<p><a href=""/uri"">link [foo [bar]]</a></p>
", GetHtml(@"[link [foo [bar]]][ref]

[ref]: /uri
"));
        }

        #endregion

        #region Example 482
        [Fact]
        public void Example482()
        {
            Assert.Equal(@"<p><a href=""/uri"">link [bar</a></p>
", GetHtml(@"[link \[bar][ref]

[ref]: /uri
"));
        }

        #endregion

        #region Example 483
        [Fact]
        public void Example483()
        {
            Assert.Equal(@"<p><a href=""/uri"">link <em>foo <strong>bar</strong> <code>#</code></em></a></p>
", GetHtml(@"[link *foo **bar** `#`*][ref]

[ref]: /uri
"));
        }

        #endregion

        #region Example 484
        [Fact]
        public void Example484()
        {
            Assert.Equal(@"<p><a href=""/uri""><img src=""moon.jpg"" alt=""moon"" /></a></p>
", GetHtml(@"[![moon](moon.jpg)][ref]

[ref]: /uri
"));
        }

        #endregion

        #region Example 485
        [Fact]
        public void Example485()
        {
            Assert.Equal(@"<p>[foo <a href=""/uri"">bar</a>]<a href=""/uri"">ref</a></p>
", GetHtml(@"[foo [bar](/uri)][ref]

[ref]: /uri
"));
        }

        #endregion

        #region Example 486
        [Fact]
        public void Example486()
        {
            Assert.Equal(@"<p>[foo <em>bar <a href=""/uri"">baz</a></em>]<a href=""/uri"">ref</a></p>
", GetHtml(@"[foo *bar [baz][ref]*][ref]

[ref]: /uri
"));
        }

        #endregion

        #region Example 487
        [Fact]
        public void Example487()
        {
            Assert.Equal(@"<p>*<a href=""/uri"">foo*</a></p>
", GetHtml(@"*[foo*][ref]

[ref]: /uri
"));
        }

        #endregion

        #region Example 488
        [Fact]
        public void Example488()
        {
            Assert.Equal(@"<p><a href=""/uri"">foo *bar</a></p>
", GetHtml(@"[foo *bar][ref]

[ref]: /uri
"));
        }

        #endregion

        #region Example 489
        [Fact]
        public void Example489()
        {
            Assert.Equal(@"<p>[foo <bar attr=""][ref]""></p>
", GetHtml(@"[foo <bar attr=""][ref]"">

[ref]: /uri
"));
        }

        #endregion

        #region Example 490
        [Fact]
        public void Example490()
        {
            Assert.Equal(@"<p>[foo<code>][ref]</code></p>
", GetHtml(@"[foo`][ref]`

[ref]: /uri
"));
        }

        #endregion

        #region Example 491
        [Fact]
        public void Example491()
        {
            Assert.Equal(@"<p>[foo<a href=""http://example.com/?search=%5D%5Bref%5D"">http://example.com/?search=][ref]</a></p>
", GetHtml(@"[foo<http://example.com/?search=][ref]>

[ref]: /uri
"));
        }

        #endregion

        #region Example 492
        [Fact]
        public void Example492()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title"">foo</a></p>
", GetHtml(@"[foo][BaR]

[bar]: /url ""title""
"));
        }

        #endregion

        #region Example 493
        [Fact]
        public void Example493()
        {
            Assert.Equal(@"<p><a href=""/url"">Толпой</a> is a Russian word.</p>
", GetHtml(@"[Толпой][Толпой] is a Russian word.

[ТОЛПОЙ]: /url
"));
        }

        #endregion

        #region Example 494
        [Fact]
        public void Example494()
        {
            Assert.Equal(@"<p><a href=""/url"">Baz</a></p>
", GetHtml(@"[Foo
  bar]: /url

[Baz][Foo bar]
"));
        }

        #endregion

        #region Example 495
        [Fact]
        public void Example495()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title"">foo</a></p>
", GetHtml(@"[foo] [bar]

[bar]: /url ""title""
"));
        }

        #endregion

        #region Example 496
        [Fact]
        public void Example496()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title"">foo</a></p>
", GetHtml(@"[foo]
[bar]

[bar]: /url ""title""
"));
        }

        #endregion

        #region Example 497
        [Fact]
        public void Example497()
        {
            Assert.Equal(@"<p><a href=""/url1"">bar</a></p>
", GetHtml(@"[foo]: /url1

[foo]: /url2

[bar][foo]
"));
        }

        #endregion

        #region Example 498
        [Fact]
        public void Example498()
        {
            Assert.Equal(@"<p>[bar][foo!]</p>
", GetHtml(@"[bar][foo\!]

[foo!]: /url
"));
        }

        #endregion

        #region Example 499
        [Fact]
        public void Example499()
        {
            Assert.Equal(@"<p>[foo][ref[]</p>
<p>[ref[]: /uri</p>
", GetHtml(@"[foo][ref[]

[ref[]: /uri
"));
        }

        #endregion

        #region Example 500
        [Fact]
        public void Example500()
        {
            Assert.Equal(@"<p>[foo][ref[bar]]</p>
<p>[ref[bar]]: /uri</p>
", GetHtml(@"[foo][ref[bar]]

[ref[bar]]: /uri
"));
        }

        #endregion

        #region Example 501
        [Fact]
        public void Example501()
        {
            Assert.Equal(@"<p>[[[foo]]]</p>
<p>[[[foo]]]: /url</p>
", GetHtml(@"[[[foo]]]

[[[foo]]]: /url
"));
        }

        #endregion

        #region Example 502
        [Fact]
        public void Example502()
        {
            Assert.Equal(@"<p><a href=""/uri"">foo</a></p>
", GetHtml(@"[foo][ref\[]

[ref\[]: /uri
"));
        }

        #endregion

        #region Example 503
        [Fact]
        public void Example503()
        {
            Assert.Equal(@"<p>[]</p>
<p>[]: /uri</p>
", GetHtml(@"[]

[]: /uri
"));
        }

        #endregion

        #region Example 504
        [Fact]
        public void Example504()
        {
            Assert.Equal(@"<p>[
]</p>
<p>[
]: /uri</p>
", GetHtml(@"[
 ]

[
 ]: /uri
"));
        }

        #endregion

        #region Example 505
        [Fact]
        public void Example505()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title"">foo</a></p>
", GetHtml(@"[foo][]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 506
        [Fact]
        public void Example506()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title""><em>foo</em> bar</a></p>
", GetHtml(@"[*foo* bar][]

[*foo* bar]: /url ""title""
"));
        }

        #endregion

        #region Example 507
        [Fact]
        public void Example507()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title"">Foo</a></p>
", GetHtml(@"[Foo][]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 508
        [Fact]
        public void Example508()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title"">foo</a></p>
", GetHtml(@"[foo] 
[]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 509
        [Fact]
        public void Example509()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title"">foo</a></p>
", GetHtml(@"[foo]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 510
        [Fact]
        public void Example510()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title""><em>foo</em> bar</a></p>
", GetHtml(@"[*foo* bar]

[*foo* bar]: /url ""title""
"));
        }

        #endregion

        #region Example 511
        [Fact]
        public void Example511()
        {
            Assert.Equal(@"<p>[<a href=""/url"" title=""title""><em>foo</em> bar</a>]</p>
", GetHtml(@"[[*foo* bar]]

[*foo* bar]: /url ""title""
"));
        }

        #endregion

        #region Example 512
        [Fact]
        public void Example512()
        {
            Assert.Equal(@"<p>[[bar <a href=""/url"">foo</a></p>
", GetHtml(@"[[bar [foo]

[foo]: /url
"));
        }

        #endregion

        #region Example 513
        [Fact]
        public void Example513()
        {
            Assert.Equal(@"<p><a href=""/url"" title=""title"">Foo</a></p>
", GetHtml(@"[Foo]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 514
        [Fact]
        public void Example514()
        {
            Assert.Equal(@"<p><a href=""/url"">foo</a> bar</p>
", GetHtml(@"[foo] bar

[foo]: /url
"));
        }

        #endregion

        #region Example 515
        [Fact]
        public void Example515()
        {
            Assert.Equal(@"<p>[foo]</p>
", GetHtml(@"\[foo]

[foo]: /url ""title""
"));
        }

        #endregion

        #region Example 516
        [Fact]
        public void Example516()
        {
            Assert.Equal(@"<p>*<a href=""/url"">foo*</a></p>
", GetHtml(@"[foo*]: /url

*[foo*]
"));
        }

        #endregion

        #region Example 517
        [Fact]
        public void Example517()
        {
            Assert.Equal(@"<p><a href=""/url2"">foo</a></p>
", GetHtml(@"[foo][bar]

[foo]: /url1
[bar]: /url2
"));
        }

        #endregion

        #region Example 518
        [Fact]
        public void Example518()
        {
            Assert.Equal(@"<p>[foo]<a href=""/url"">bar</a></p>
", GetHtml(@"[foo][bar][baz]

[baz]: /url
"));
        }

        #endregion

        #region Example 519
        [Fact]
        public void Example519()
        {
            Assert.Equal(@"<p><a href=""/url2"">foo</a><a href=""/url1"">baz</a></p>
", GetHtml(@"[foo][bar][baz]

[baz]: /url1
[bar]: /url2
"));
        }

        #endregion

        #region Example 520
        [Fact]
        public void Example520()
        {
            Assert.Equal(@"<p>[foo]<a href=""/url1"">bar</a></p>
", GetHtml(@"[foo][bar][baz]

[baz]: /url1
[foo]: /url2
"));
        }

        #endregion
    }
}