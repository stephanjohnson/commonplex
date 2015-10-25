
using Xunit;

namespace CommonPlex.CommonMark.Tests
{
    public class Emphasisandstrongemphasis: BaseTest
    {
        
        #region Example 313
        [Fact]
        public void Example313()
        {
            Assert.Equal(@"<p><em>foo bar</em></p>
", GetHtml(@"*foo bar*
"));
        }

        #endregion

        #region Example 314
        [Fact]
        public void Example314()
        {
            Assert.Equal(@"<p>a * foo bar*</p>
", GetHtml(@"a * foo bar*
"));
        }

        #endregion

        #region Example 315
        [Fact]
        public void Example315()
        {
            Assert.Equal(@"<p>a*&quot;foo&quot;*</p>
", GetHtml(@"a*""foo""*
"));
        }

        #endregion

        #region Example 316
        [Fact]
        public void Example316()
        {
            Assert.Equal(@"<p>* a *</p>
", GetHtml(@"* a *
"));
        }

        #endregion

        #region Example 317
        [Fact]
        public void Example317()
        {
            Assert.Equal(@"<p>foo<em>bar</em></p>
", GetHtml(@"foo*bar*
"));
        }

        #endregion

        #region Example 318
        [Fact]
        public void Example318()
        {
            Assert.Equal(@"<p>5<em>6</em>78</p>
", GetHtml(@"5*6*78
"));
        }

        #endregion

        #region Example 319
        [Fact]
        public void Example319()
        {
            Assert.Equal(@"<p><em>foo bar</em></p>
", GetHtml(@"_foo bar_
"));
        }

        #endregion

        #region Example 320
        [Fact]
        public void Example320()
        {
            Assert.Equal(@"<p>_ foo bar_</p>
", GetHtml(@"_ foo bar_
"));
        }

        #endregion

        #region Example 321
        [Fact]
        public void Example321()
        {
            Assert.Equal(@"<p>a_&quot;foo&quot;_</p>
", GetHtml(@"a_""foo""_
"));
        }

        #endregion

        #region Example 322
        [Fact]
        public void Example322()
        {
            Assert.Equal(@"<p>foo_bar_</p>
", GetHtml(@"foo_bar_
"));
        }

        #endregion

        #region Example 323
        [Fact]
        public void Example323()
        {
            Assert.Equal(@"<p>5_6_78</p>
", GetHtml(@"5_6_78
"));
        }

        #endregion

        #region Example 324
        [Fact]
        public void Example324()
        {
            Assert.Equal(@"<p>пристаням_стремятся_</p>
", GetHtml(@"пристаням_стремятся_
"));
        }

        #endregion

        #region Example 325
        [Fact]
        public void Example325()
        {
            Assert.Equal(@"<p>aa_&quot;bb&quot;_cc</p>
", GetHtml(@"aa_""bb""_cc
"));
        }

        #endregion

        #region Example 326
        [Fact]
        public void Example326()
        {
            Assert.Equal(@"<p>foo-<em>(bar)</em></p>
", GetHtml(@"foo-_(bar)_
"));
        }

        #endregion

        #region Example 327
        [Fact]
        public void Example327()
        {
            Assert.Equal(@"<p>_foo*</p>
", GetHtml(@"_foo*
"));
        }

        #endregion

        #region Example 328
        [Fact]
        public void Example328()
        {
            Assert.Equal(@"<p>*foo bar *</p>
", GetHtml(@"*foo bar *
"));
        }

        #endregion

        #region Example 329
        [Fact]
        public void Example329()
        {
            Assert.Equal(@"<p>*foo bar</p>
<ul>
<li></li>
</ul>
", GetHtml(@"*foo bar
*
"));
        }

        #endregion

        #region Example 330
        [Fact]
        public void Example330()
        {
            Assert.Equal(@"<p>*(*foo)</p>
", GetHtml(@"*(*foo)
"));
        }

        #endregion

        #region Example 331
        [Fact]
        public void Example331()
        {
            Assert.Equal(@"<p><em>(<em>foo</em>)</em></p>
", GetHtml(@"*(*foo*)*
"));
        }

        #endregion

        #region Example 332
        [Fact]
        public void Example332()
        {
            Assert.Equal(@"<p><em>foo</em>bar</p>
", GetHtml(@"*foo*bar
"));
        }

        #endregion

        #region Example 333
        [Fact]
        public void Example333()
        {
            Assert.Equal(@"<p>_foo bar _</p>
", GetHtml(@"_foo bar _
"));
        }

        #endregion

        #region Example 334
        [Fact]
        public void Example334()
        {
            Assert.Equal(@"<p>_(_foo)</p>
", GetHtml(@"_(_foo)
"));
        }

        #endregion

        #region Example 335
        [Fact]
        public void Example335()
        {
            Assert.Equal(@"<p><em>(<em>foo</em>)</em></p>
", GetHtml(@"_(_foo_)_
"));
        }

        #endregion

        #region Example 336
        [Fact]
        public void Example336()
        {
            Assert.Equal(@"<p>_foo_bar</p>
", GetHtml(@"_foo_bar
"));
        }

        #endregion

        #region Example 337
        [Fact]
        public void Example337()
        {
            Assert.Equal(@"<p>_пристаням_стремятся</p>
", GetHtml(@"_пристаням_стремятся
"));
        }

        #endregion

        #region Example 338
        [Fact]
        public void Example338()
        {
            Assert.Equal(@"<p><em>foo_bar_baz</em></p>
", GetHtml(@"_foo_bar_baz_
"));
        }

        #endregion

        #region Example 339
        [Fact]
        public void Example339()
        {
            Assert.Equal(@"<p><em>(bar)</em>.</p>
", GetHtml(@"_(bar)_.
"));
        }

        #endregion

        #region Example 340
        [Fact]
        public void Example340()
        {
            Assert.Equal(@"<p><strong>foo bar</strong></p>
", GetHtml(@"**foo bar**
"));
        }

        #endregion

        #region Example 341
        [Fact]
        public void Example341()
        {
            Assert.Equal(@"<p>** foo bar**</p>
", GetHtml(@"** foo bar**
"));
        }

        #endregion

        #region Example 342
        [Fact]
        public void Example342()
        {
            Assert.Equal(@"<p>a**&quot;foo&quot;**</p>
", GetHtml(@"a**""foo""**
"));
        }

        #endregion

        #region Example 343
        [Fact]
        public void Example343()
        {
            Assert.Equal(@"<p>foo<strong>bar</strong></p>
", GetHtml(@"foo**bar**
"));
        }

        #endregion

        #region Example 344
        [Fact]
        public void Example344()
        {
            Assert.Equal(@"<p><strong>foo bar</strong></p>
", GetHtml(@"__foo bar__
"));
        }

        #endregion

        #region Example 345
        [Fact]
        public void Example345()
        {
            Assert.Equal(@"<p>__ foo bar__</p>
", GetHtml(@"__ foo bar__
"));
        }

        #endregion

        #region Example 346
        [Fact]
        public void Example346()
        {
            Assert.Equal(@"<p>__
foo bar__</p>
", GetHtml(@"__
foo bar__
"));
        }

        #endregion

        #region Example 347
        [Fact]
        public void Example347()
        {
            Assert.Equal(@"<p>a__&quot;foo&quot;__</p>
", GetHtml(@"a__""foo""__
"));
        }

        #endregion

        #region Example 348
        [Fact]
        public void Example348()
        {
            Assert.Equal(@"<p>foo__bar__</p>
", GetHtml(@"foo__bar__
"));
        }

        #endregion

        #region Example 349
        [Fact]
        public void Example349()
        {
            Assert.Equal(@"<p>5__6__78</p>
", GetHtml(@"5__6__78
"));
        }

        #endregion

        #region Example 350
        [Fact]
        public void Example350()
        {
            Assert.Equal(@"<p>пристаням__стремятся__</p>
", GetHtml(@"пристаням__стремятся__
"));
        }

        #endregion

        #region Example 351
        [Fact]
        public void Example351()
        {
            Assert.Equal(@"<p><strong>foo, <strong>bar</strong>, baz</strong></p>
", GetHtml(@"__foo, __bar__, baz__
"));
        }

        #endregion

        #region Example 352
        [Fact]
        public void Example352()
        {
            Assert.Equal(@"<p>foo-<strong>(bar)</strong></p>
", GetHtml(@"foo-__(bar)__
"));
        }

        #endregion

        #region Example 353
        [Fact]
        public void Example353()
        {
            Assert.Equal(@"<p>**foo bar **</p>
", GetHtml(@"**foo bar **
"));
        }

        #endregion

        #region Example 354
        [Fact]
        public void Example354()
        {
            Assert.Equal(@"<p>**(**foo)</p>
", GetHtml(@"**(**foo)
"));
        }

        #endregion

        #region Example 355
        [Fact]
        public void Example355()
        {
            Assert.Equal(@"<p><em>(<strong>foo</strong>)</em></p>
", GetHtml(@"*(**foo**)*
"));
        }

        #endregion

        #region Example 356
        [Fact]
        public void Example356()
        {
            Assert.Equal(@"<p><strong>Gomphocarpus (<em>Gomphocarpus physocarpus</em>, syn.
<em>Asclepias physocarpa</em>)</strong></p>
", GetHtml(@"**Gomphocarpus (*Gomphocarpus physocarpus*, syn.
*Asclepias physocarpa*)**
"));
        }

        #endregion

        #region Example 357
        [Fact]
        public void Example357()
        {
            Assert.Equal(@"<p><strong>foo &quot;<em>bar</em>&quot; foo</strong></p>
", GetHtml(@"**foo ""*bar*"" foo**
"));
        }

        #endregion

        #region Example 358
        [Fact]
        public void Example358()
        {
            Assert.Equal(@"<p><strong>foo</strong>bar</p>
", GetHtml(@"**foo**bar
"));
        }

        #endregion

        #region Example 359
        [Fact]
        public void Example359()
        {
            Assert.Equal(@"<p>__foo bar __</p>
", GetHtml(@"__foo bar __
"));
        }

        #endregion

        #region Example 360
        [Fact]
        public void Example360()
        {
            Assert.Equal(@"<p>__(__foo)</p>
", GetHtml(@"__(__foo)
"));
        }

        #endregion

        #region Example 361
        [Fact]
        public void Example361()
        {
            Assert.Equal(@"<p><em>(<strong>foo</strong>)</em></p>
", GetHtml(@"_(__foo__)_
"));
        }

        #endregion

        #region Example 362
        [Fact]
        public void Example362()
        {
            Assert.Equal(@"<p>__foo__bar</p>
", GetHtml(@"__foo__bar
"));
        }

        #endregion

        #region Example 363
        [Fact]
        public void Example363()
        {
            Assert.Equal(@"<p>__пристаням__стремятся</p>
", GetHtml(@"__пристаням__стремятся
"));
        }

        #endregion

        #region Example 364
        [Fact]
        public void Example364()
        {
            Assert.Equal(@"<p><strong>foo__bar__baz</strong></p>
", GetHtml(@"__foo__bar__baz__
"));
        }

        #endregion

        #region Example 365
        [Fact]
        public void Example365()
        {
            Assert.Equal(@"<p><strong>(bar)</strong>.</p>
", GetHtml(@"__(bar)__.
"));
        }

        #endregion

        #region Example 366
        [Fact]
        public void Example366()
        {
            Assert.Equal(@"<p><em>foo <a href=""/url"">bar</a></em></p>
", GetHtml(@"*foo [bar](/url)*
"));
        }

        #endregion

        #region Example 367
        [Fact]
        public void Example367()
        {
            Assert.Equal(@"<p><em>foo
bar</em></p>
", GetHtml(@"*foo
bar*
"));
        }

        #endregion

        #region Example 368
        [Fact]
        public void Example368()
        {
            Assert.Equal(@"<p><em>foo <strong>bar</strong> baz</em></p>
", GetHtml(@"_foo __bar__ baz_
"));
        }

        #endregion

        #region Example 369
        [Fact]
        public void Example369()
        {
            Assert.Equal(@"<p><em>foo <em>bar</em> baz</em></p>
", GetHtml(@"_foo _bar_ baz_
"));
        }

        #endregion

        #region Example 370
        [Fact]
        public void Example370()
        {
            Assert.Equal(@"<p><em><em>foo</em> bar</em></p>
", GetHtml(@"__foo_ bar_
"));
        }

        #endregion

        #region Example 371
        [Fact]
        public void Example371()
        {
            Assert.Equal(@"<p><em>foo <em>bar</em></em></p>
", GetHtml(@"*foo *bar**
"));
        }

        #endregion

        #region Example 372
        [Fact]
        public void Example372()
        {
            Assert.Equal(@"<p><em>foo <strong>bar</strong> baz</em></p>
", GetHtml(@"*foo **bar** baz*
"));
        }

        #endregion

        #region Example 373
        [Fact]
        public void Example373()
        {
            Assert.Equal(@"<p><em>foo</em><em>bar</em><em>baz</em></p>
", GetHtml(@"*foo**bar**baz*
"));
        }

        #endregion

        #region Example 374
        [Fact]
        public void Example374()
        {
            Assert.Equal(@"<p><em><strong>foo</strong> bar</em></p>
", GetHtml(@"***foo** bar*
"));
        }

        #endregion

        #region Example 375
        [Fact]
        public void Example375()
        {
            Assert.Equal(@"<p><em>foo <strong>bar</strong></em></p>
", GetHtml(@"*foo **bar***
"));
        }

        #endregion

        #region Example 376
        [Fact]
        public void Example376()
        {
            Assert.Equal(@"<p><em>foo</em><em>bar</em>**</p>
", GetHtml(@"*foo**bar***
"));
        }

        #endregion

        #region Example 377
        [Fact]
        public void Example377()
        {
            Assert.Equal(@"<p><em>foo <strong>bar <em>baz</em> bim</strong> bop</em></p>
", GetHtml(@"*foo **bar *baz* bim** bop*
"));
        }

        #endregion

        #region Example 378
        [Fact]
        public void Example378()
        {
            Assert.Equal(@"<p><em>foo <a href=""/url""><em>bar</em></a></em></p>
", GetHtml(@"*foo [*bar*](/url)*
"));
        }

        #endregion

        #region Example 379
        [Fact]
        public void Example379()
        {
            Assert.Equal(@"<p>** is not an empty emphasis</p>
", GetHtml(@"** is not an empty emphasis
"));
        }

        #endregion

        #region Example 380
        [Fact]
        public void Example380()
        {
            Assert.Equal(@"<p>**** is not an empty strong emphasis</p>
", GetHtml(@"**** is not an empty strong emphasis
"));
        }

        #endregion

        #region Example 381
        [Fact]
        public void Example381()
        {
            Assert.Equal(@"<p><strong>foo <a href=""/url"">bar</a></strong></p>
", GetHtml(@"**foo [bar](/url)**
"));
        }

        #endregion

        #region Example 382
        [Fact]
        public void Example382()
        {
            Assert.Equal(@"<p><strong>foo
bar</strong></p>
", GetHtml(@"**foo
bar**
"));
        }

        #endregion

        #region Example 383
        [Fact]
        public void Example383()
        {
            Assert.Equal(@"<p><strong>foo <em>bar</em> baz</strong></p>
", GetHtml(@"__foo _bar_ baz__
"));
        }

        #endregion

        #region Example 384
        [Fact]
        public void Example384()
        {
            Assert.Equal(@"<p><strong>foo <strong>bar</strong> baz</strong></p>
", GetHtml(@"__foo __bar__ baz__
"));
        }

        #endregion

        #region Example 385
        [Fact]
        public void Example385()
        {
            Assert.Equal(@"<p><strong><strong>foo</strong> bar</strong></p>
", GetHtml(@"____foo__ bar__
"));
        }

        #endregion

        #region Example 386
        [Fact]
        public void Example386()
        {
            Assert.Equal(@"<p><strong>foo <strong>bar</strong></strong></p>
", GetHtml(@"**foo **bar****
"));
        }

        #endregion

        #region Example 387
        [Fact]
        public void Example387()
        {
            Assert.Equal(@"<p><strong>foo <em>bar</em> baz</strong></p>
", GetHtml(@"**foo *bar* baz**
"));
        }

        #endregion

        #region Example 388
        [Fact]
        public void Example388()
        {
            Assert.Equal(@"<p><em><em>foo</em>bar</em>baz**</p>
", GetHtml(@"**foo*bar*baz**
"));
        }

        #endregion

        #region Example 389
        [Fact]
        public void Example389()
        {
            Assert.Equal(@"<p><strong><em>foo</em> bar</strong></p>
", GetHtml(@"***foo* bar**
"));
        }

        #endregion

        #region Example 390
        [Fact]
        public void Example390()
        {
            Assert.Equal(@"<p><strong>foo <em>bar</em></strong></p>
", GetHtml(@"**foo *bar***
"));
        }

        #endregion

        #region Example 391
        [Fact]
        public void Example391()
        {
            Assert.Equal(@"<p><strong>foo <em>bar <strong>baz</strong>
bim</em> bop</strong></p>
", GetHtml(@"**foo *bar **baz**
bim* bop**
"));
        }

        #endregion

        #region Example 392
        [Fact]
        public void Example392()
        {
            Assert.Equal(@"<p><strong>foo <a href=""/url""><em>bar</em></a></strong></p>
", GetHtml(@"**foo [*bar*](/url)**
"));
        }

        #endregion

        #region Example 393
        [Fact]
        public void Example393()
        {
            Assert.Equal(@"<p>__ is not an empty emphasis</p>
", GetHtml(@"__ is not an empty emphasis
"));
        }

        #endregion

        #region Example 394
        [Fact]
        public void Example394()
        {
            Assert.Equal(@"<p>____ is not an empty strong emphasis</p>
", GetHtml(@"____ is not an empty strong emphasis
"));
        }

        #endregion

        #region Example 395
        [Fact]
        public void Example395()
        {
            Assert.Equal(@"<p>foo ***</p>
", GetHtml(@"foo ***
"));
        }

        #endregion

        #region Example 396
        [Fact]
        public void Example396()
        {
            Assert.Equal(@"<p>foo <em>*</em></p>
", GetHtml(@"foo *\**
"));
        }

        #endregion

        #region Example 397
        [Fact]
        public void Example397()
        {
            Assert.Equal(@"<p>foo <em>_</em></p>
", GetHtml(@"foo *_*
"));
        }

        #endregion

        #region Example 398
        [Fact]
        public void Example398()
        {
            Assert.Equal(@"<p>foo *****</p>
", GetHtml(@"foo *****
"));
        }

        #endregion

        #region Example 399
        [Fact]
        public void Example399()
        {
            Assert.Equal(@"<p>foo <strong>*</strong></p>
", GetHtml(@"foo **\***
"));
        }

        #endregion

        #region Example 400
        [Fact]
        public void Example400()
        {
            Assert.Equal(@"<p>foo <strong>_</strong></p>
", GetHtml(@"foo **_**
"));
        }

        #endregion

        #region Example 401
        [Fact]
        public void Example401()
        {
            Assert.Equal(@"<p>*<em>foo</em></p>
", GetHtml(@"**foo*
"));
        }

        #endregion

        #region Example 402
        [Fact]
        public void Example402()
        {
            Assert.Equal(@"<p><em>foo</em>*</p>
", GetHtml(@"*foo**
"));
        }

        #endregion

        #region Example 403
        [Fact]
        public void Example403()
        {
            Assert.Equal(@"<p>*<strong>foo</strong></p>
", GetHtml(@"***foo**
"));
        }

        #endregion

        #region Example 404
        [Fact]
        public void Example404()
        {
            Assert.Equal(@"<p>***<em>foo</em></p>
", GetHtml(@"****foo*
"));
        }

        #endregion

        #region Example 405
        [Fact]
        public void Example405()
        {
            Assert.Equal(@"<p><strong>foo</strong>*</p>
", GetHtml(@"**foo***
"));
        }

        #endregion

        #region Example 406
        [Fact]
        public void Example406()
        {
            Assert.Equal(@"<p><em>foo</em>***</p>
", GetHtml(@"*foo****
"));
        }

        #endregion

        #region Example 407
        [Fact]
        public void Example407()
        {
            Assert.Equal(@"<p>foo ___</p>
", GetHtml(@"foo ___
"));
        }

        #endregion

        #region Example 408
        [Fact]
        public void Example408()
        {
            Assert.Equal(@"<p>foo <em>_</em></p>
", GetHtml(@"foo _\__
"));
        }

        #endregion

        #region Example 409
        [Fact]
        public void Example409()
        {
            Assert.Equal(@"<p>foo <em>*</em></p>
", GetHtml(@"foo _*_
"));
        }

        #endregion

        #region Example 410
        [Fact]
        public void Example410()
        {
            Assert.Equal(@"<p>foo _____</p>
", GetHtml(@"foo _____
"));
        }

        #endregion

        #region Example 411
        [Fact]
        public void Example411()
        {
            Assert.Equal(@"<p>foo <strong>_</strong></p>
", GetHtml(@"foo __\___
"));
        }

        #endregion

        #region Example 412
        [Fact]
        public void Example412()
        {
            Assert.Equal(@"<p>foo <strong>*</strong></p>
", GetHtml(@"foo __*__
"));
        }

        #endregion

        #region Example 413
        [Fact]
        public void Example413()
        {
            Assert.Equal(@"<p>_<em>foo</em></p>
", GetHtml(@"__foo_
"));
        }

        #endregion

        #region Example 414
        [Fact]
        public void Example414()
        {
            Assert.Equal(@"<p><em>foo</em>_</p>
", GetHtml(@"_foo__
"));
        }

        #endregion

        #region Example 415
        [Fact]
        public void Example415()
        {
            Assert.Equal(@"<p>_<strong>foo</strong></p>
", GetHtml(@"___foo__
"));
        }

        #endregion

        #region Example 416
        [Fact]
        public void Example416()
        {
            Assert.Equal(@"<p>___<em>foo</em></p>
", GetHtml(@"____foo_
"));
        }

        #endregion

        #region Example 417
        [Fact]
        public void Example417()
        {
            Assert.Equal(@"<p><strong>foo</strong>_</p>
", GetHtml(@"__foo___
"));
        }

        #endregion

        #region Example 418
        [Fact]
        public void Example418()
        {
            Assert.Equal(@"<p><em>foo</em>___</p>
", GetHtml(@"_foo____
"));
        }

        #endregion

        #region Example 419
        [Fact]
        public void Example419()
        {
            Assert.Equal(@"<p><strong>foo</strong></p>
", GetHtml(@"**foo**
"));
        }

        #endregion

        #region Example 420
        [Fact]
        public void Example420()
        {
            Assert.Equal(@"<p><em><em>foo</em></em></p>
", GetHtml(@"*_foo_*
"));
        }

        #endregion

        #region Example 421
        [Fact]
        public void Example421()
        {
            Assert.Equal(@"<p><strong>foo</strong></p>
", GetHtml(@"__foo__
"));
        }

        #endregion

        #region Example 422
        [Fact]
        public void Example422()
        {
            Assert.Equal(@"<p><em><em>foo</em></em></p>
", GetHtml(@"_*foo*_
"));
        }

        #endregion

        #region Example 423
        [Fact]
        public void Example423()
        {
            Assert.Equal(@"<p><strong><strong>foo</strong></strong></p>
", GetHtml(@"****foo****
"));
        }

        #endregion

        #region Example 424
        [Fact]
        public void Example424()
        {
            Assert.Equal(@"<p><strong><strong>foo</strong></strong></p>
", GetHtml(@"____foo____
"));
        }

        #endregion

        #region Example 425
        [Fact]
        public void Example425()
        {
            Assert.Equal(@"<p><strong><strong><strong>foo</strong></strong></strong></p>
", GetHtml(@"******foo******
"));
        }

        #endregion

        #region Example 426
        [Fact]
        public void Example426()
        {
            Assert.Equal(@"<p><strong><em>foo</em></strong></p>
", GetHtml(@"***foo***
"));
        }

        #endregion

        #region Example 427
        [Fact]
        public void Example427()
        {
            Assert.Equal(@"<p><strong><strong><em>foo</em></strong></strong></p>
", GetHtml(@"_____foo_____
"));
        }

        #endregion

        #region Example 428
        [Fact]
        public void Example428()
        {
            Assert.Equal(@"<p><em>foo _bar</em> baz_</p>
", GetHtml(@"*foo _bar* baz_
"));
        }

        #endregion

        #region Example 429
        [Fact]
        public void Example429()
        {
            Assert.Equal(@"<p><em><em>foo</em>bar</em>*</p>
", GetHtml(@"**foo*bar**
"));
        }

        #endregion

        #region Example 430
        [Fact]
        public void Example430()
        {
            Assert.Equal(@"<p><em>foo <strong>bar *baz bim</strong> bam</em></p>
", GetHtml(@"*foo __bar *baz bim__ bam*
"));
        }

        #endregion

        #region Example 431
        [Fact]
        public void Example431()
        {
            Assert.Equal(@"<p>**foo <strong>bar baz</strong></p>
", GetHtml(@"**foo **bar baz**
"));
        }

        #endregion

        #region Example 432
        [Fact]
        public void Example432()
        {
            Assert.Equal(@"<p>*foo <em>bar baz</em></p>
", GetHtml(@"*foo *bar baz*
"));
        }

        #endregion

        #region Example 433
        [Fact]
        public void Example433()
        {
            Assert.Equal(@"<p>*<a href=""/url"">bar*</a></p>
", GetHtml(@"*[bar*](/url)
"));
        }

        #endregion

        #region Example 434
        [Fact]
        public void Example434()
        {
            Assert.Equal(@"<p>_foo <a href=""/url"">bar_</a></p>
", GetHtml(@"_foo [bar_](/url)
"));
        }

        #endregion

        #region Example 435
        [Fact]
        public void Example435()
        {
            Assert.Equal(@"<p>*<img src=""foo"" title=""*""/></p>
", GetHtml(@"*<img src=""foo"" title=""*""/>
"));
        }

        #endregion

        #region Example 436
        [Fact]
        public void Example436()
        {
            Assert.Equal(@"<p>**<a href=""**""></p>
", GetHtml(@"**<a href=""**"">
"));
        }

        #endregion

        #region Example 437
        [Fact]
        public void Example437()
        {
            Assert.Equal(@"<p>__<a href=""__""></p>
", GetHtml(@"__<a href=""__"">
"));
        }

        #endregion

        #region Example 438
        [Fact]
        public void Example438()
        {
            Assert.Equal(@"<p><em>a <code>*</code></em></p>
", GetHtml(@"*a `*`*
"));
        }

        #endregion

        #region Example 439
        [Fact]
        public void Example439()
        {
            Assert.Equal(@"<p><em>a <code>_</code></em></p>
", GetHtml(@"_a `_`_
"));
        }

        #endregion

        #region Example 440
        [Fact]
        public void Example440()
        {
            Assert.Equal(@"<p>**a<a href=""http://foo.bar/?q=**"">http://foo.bar/?q=**</a></p>
", GetHtml(@"**a<http://foo.bar/?q=**>
"));
        }

        #endregion

        #region Example 441
        [Fact]
        public void Example441()
        {
            Assert.Equal(@"<p>__a<a href=""http://foo.bar/?q=__"">http://foo.bar/?q=__</a></p>
", GetHtml(@"__a<http://foo.bar/?q=__>
"));
        }

        #endregion
    }
}