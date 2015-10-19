using System.Collections.Generic;
using Should;
using CommonPlex.Compilation.Macros;
using CommonPlex.Parsing;
using Xunit;

namespace CommonPlex.Tests.Parsing
{
    public class IndentationScopeAugmenterFacts
    {
        [Fact]
        public void Should_return_original_scopes_if_start_is_one_level()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.IndentationBegin, 0, 2),
                                                        new Scope(ScopeName.IndentationEnd, 3, 0)
                                                    });
            var augmenter = new IndentationScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new IndentationMacro(), origScopes, ": a");

            actualScopes.Count.ShouldEqual(2);
        }

        [Fact]
        public void Should_add_begin_and_end_scopes_if_two_level()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.IndentationBegin, 0, 3),
                                                        new Scope(ScopeName.IndentationEnd, 4, 0)
                                                    });
            var augmenter = new IndentationScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new IndentationMacro(), origScopes, ":: a");

            actualScopes.Count.ShouldEqual(4);
            actualScopes[0].Name.ShouldEqual(ScopeName.IndentationBegin);
            actualScopes[1].Name.ShouldEqual(ScopeName.IndentationBegin);
            actualScopes[2].Name.ShouldEqual(ScopeName.IndentationEnd);
            actualScopes[3].Name.ShouldEqual(ScopeName.IndentationEnd);
            actualScopes[0].Index.ShouldEqual(0);
            actualScopes[1].Index.ShouldEqual(0);
            actualScopes[2].Index.ShouldEqual(4);
            actualScopes[3].Index.ShouldEqual(4);
            actualScopes[0].Length.ShouldEqual(3);
            actualScopes[1].Length.ShouldEqual(3);
            actualScopes[2].Length.ShouldEqual(0);
            actualScopes[2].Length.ShouldEqual(0);
        }

        [Fact]
        public void Should_add_begin_and_end_scopes_if_more_than_two_level()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.IndentationBegin, 0, 5),
                                                        new Scope(ScopeName.IndentationEnd, 6, 0)
                                                    });
            var augmenter = new IndentationScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new IndentationMacro(), origScopes, ":::: a");

            actualScopes.Count.ShouldEqual(8);
        }

        [Fact]
        public void Should_correctly_add_scopes_with_multiple_matches()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.IndentationBegin, 0, 3),
                                                        new Scope(ScopeName.IndentationEnd, 4, 0),
                                                        new Scope(ScopeName.IndentationBegin, 5, 4),
                                                        new Scope(ScopeName.IndentationEnd, 10, 0)
                                                    });
            var augmenter = new IndentationScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new IndentationMacro(), origScopes, ":: a\n::: b");

            actualScopes.Count.ShouldEqual(10);

            actualScopes[0].Name.ShouldEqual(ScopeName.IndentationBegin);
            actualScopes[1].Name.ShouldEqual(ScopeName.IndentationBegin);
            actualScopes[4].Name.ShouldEqual(ScopeName.IndentationBegin);
            actualScopes[5].Name.ShouldEqual(ScopeName.IndentationBegin);
            actualScopes[6].Name.ShouldEqual(ScopeName.IndentationBegin);

            actualScopes[2].Name.ShouldEqual(ScopeName.IndentationEnd);
            actualScopes[3].Name.ShouldEqual(ScopeName.IndentationEnd);
            actualScopes[7].Name.ShouldEqual(ScopeName.IndentationEnd);
            actualScopes[8].Name.ShouldEqual(ScopeName.IndentationEnd);
            actualScopes[9].Name.ShouldEqual(ScopeName.IndentationEnd);

            actualScopes[0].Index.ShouldEqual(0);
            actualScopes[1].Index.ShouldEqual(0);
            actualScopes[2].Index.ShouldEqual(4);
            actualScopes[3].Index.ShouldEqual(4);
            actualScopes[4].Index.ShouldEqual(5);
            actualScopes[5].Index.ShouldEqual(5);
            actualScopes[6].Index.ShouldEqual(5);
            actualScopes[7].Index.ShouldEqual(10);
            actualScopes[8].Index.ShouldEqual(10);
            actualScopes[9].Index.ShouldEqual(10);

            actualScopes[0].Length.ShouldEqual(3);
            actualScopes[1].Length.ShouldEqual(3);
            actualScopes[4].Length.ShouldEqual(4);
            actualScopes[5].Length.ShouldEqual(4);
            actualScopes[6].Length.ShouldEqual(4);
        }
    }
}