using System.Collections.Generic;
using Should;
using CommonPlex.Compilation.Macros;
using CommonPlex.Parsing;
using Xunit;

namespace CommonPlex.Tests.Parsing
{
    public class ListScopeAugmenterFacts
    {
        [Fact]
        public void Should_add_block_start_and_end_scopes_for_single_list_item()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0)
                                                    });
            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a");

            actualScopes.Count.ShouldEqual(2);
            actualScopes.Count.ShouldEqual(2);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[0].Index.ShouldEqual(0);
            actualScopes[0].Length.ShouldEqual(2);
            actualScopes[1].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[1].Index.ShouldEqual(3);
            actualScopes[1].Length.ShouldEqual(0);
        }

        [Fact]
        public void Should_yield_the_correct_scopes()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 4, 2),
                                                        new Scope(ScopeName.ListItemEnd, 7, 0)
                                                    });
            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n* b");

            actualScopes.Count.ShouldEqual(4);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[2].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[3].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_yield_the_correct_scopes_with_nested_item_at_end()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 4, 3),
                                                        new Scope(ScopeName.ListItemEnd, 7, 0)
                                                    });
            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n** b");

            actualScopes.Count.ShouldEqual(4);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[2].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[3].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_yield_the_correct_scopes_with_nested_item_in_middle()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 4, 3),
                                                        new Scope(ScopeName.ListItemEnd, 7, 0),
                                                        new Scope(ScopeName.ListItemBegin, 8, 2),
                                                        new Scope(ScopeName.ListItemEnd, 10, 0)
                                                    });
            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n** b\n* a");

            actualScopes.Count.ShouldEqual(6);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[2].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[3].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[4].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[5].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_have_correct_scopes_for_multiple_item_nested_levels()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 4, 2),
                                                        new Scope(ScopeName.ListItemEnd, 7, 0),
                                                        new Scope(ScopeName.ListItemBegin, 8, 3),
                                                        new Scope(ScopeName.ListItemEnd, 12, 0),
                                                        new Scope(ScopeName.ListItemBegin, 13, 3),
                                                        new Scope(ScopeName.ListItemEnd, 17, 0)
                                                    });
            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n* a\n** b\n** b");

            actualScopes.Count.ShouldEqual(8);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[2].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[3].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[4].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[5].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[6].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[7].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_have_correct_scopes_when_walking_up_and_down_nested_levels()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 4, 2),
                                                        new Scope(ScopeName.ListItemEnd, 7, 0),
                                                        new Scope(ScopeName.ListItemBegin, 8, 3),
                                                        new Scope(ScopeName.ListItemEnd, 12, 0),
                                                        new Scope(ScopeName.ListItemBegin, 13, 3),
                                                        new Scope(ScopeName.ListItemEnd, 17, 0),
                                                        new Scope(ScopeName.ListItemBegin, 18, 2),
                                                        new Scope(ScopeName.ListItemEnd, 20, 0)
                                                    });

            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n* a\n** b\n** b\n* a");

            actualScopes.Count.ShouldEqual(10);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[2].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[3].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[4].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[5].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[6].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[7].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[8].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[9].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_yield_the_correct_scopes_with_nested_item_in_middle_three_deep()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 4, 2),
                                                        new Scope(ScopeName.ListItemEnd, 7, 0),
                                                        new Scope(ScopeName.ListItemBegin, 8, 3),
                                                        new Scope(ScopeName.ListItemEnd, 12, 0),
                                                        new Scope(ScopeName.ListItemBegin, 13, 4),
                                                        new Scope(ScopeName.ListItemEnd, 18, 0),
                                                        new Scope(ScopeName.ListItemBegin, 19, 2),
                                                        new Scope(ScopeName.ListItemEnd, 20, 0)
                                                    });

            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n* a\n** b\n*** c\n* a");

            actualScopes.Count.ShouldEqual(10);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[2].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[3].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[4].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[5].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[6].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[7].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[8].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[9].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_yield_the_correct_scopes_with_nested_item_at_end_with_multiple_blocks()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 4, 3),
                                                        new Scope(ScopeName.ListItemEnd, 7, 0),
                                                        new Scope(ScopeName.ListItemBegin, 9, 2),
                                                        new Scope(ScopeName.ListItemEnd, 12, 0)
                                                    });

            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n** b\n\n# a");

            actualScopes.Count.ShouldEqual(6);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[2].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[3].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[4].Name.ShouldEqual(ScopeName.OrderedListBeginTag);
            actualScopes[5].Name.ShouldEqual(ScopeName.OrderedListEndTag);
        }

        [Fact]
        public void Should_yield_the_correct_scopes_when_first_items_index_is_not_one_in_length()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 3),
                                                        new Scope(ScopeName.ListItemEnd, 4, 0),
                                                        new Scope(ScopeName.ListItemBegin, 5, 3),
                                                        new Scope(ScopeName.ListItemEnd, 9, 0),
                                                        new Scope(ScopeName.ListItemBegin, 10, 3),
                                                        new Scope(ScopeName.ListItemEnd, 14)
                                                    });

            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "** a\n** a\n** a");

            actualScopes.Count.ShouldEqual(6);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[2].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[3].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[4].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[5].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_yield_the_correct_scopes_when_first_items_index_is_two_in_length_and_last_item_index_is_one_in_length()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 3),
                                                        new Scope(ScopeName.ListItemEnd, 4, 0),
                                                        new Scope(ScopeName.ListItemBegin, 5, 3),
                                                        new Scope(ScopeName.ListItemEnd, 9, 0),
                                                        new Scope(ScopeName.ListItemBegin, 10, 2),
                                                        new Scope(ScopeName.ListItemEnd, 13)
                                                    });

            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "** a\n** a\n* a");

            actualScopes.Count.ShouldEqual(6);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[2].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[3].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[4].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[5].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_yield_the_correct_scopes_when_second_list_first_items_index_is_not_one_in_length()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 5, 3),
                                                        new Scope(ScopeName.ListItemEnd, 9, 0),
                                                        new Scope(ScopeName.ListItemBegin, 10, 3),
                                                        new Scope(ScopeName.ListItemEnd, 14)
                                                    });

            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n\n** a\n** a");

            actualScopes.Count.ShouldEqual(6);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[2].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[3].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[4].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[5].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_yield_the_correct_scopes_when_second_list_first_items_index_is_not_one_in_length_in_middle()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 5, 3),
                                                        new Scope(ScopeName.ListItemEnd, 9, 0),
                                                        new Scope(ScopeName.ListItemBegin, 10, 3),
                                                        new Scope(ScopeName.ListItemEnd, 14),
                                                        new Scope(ScopeName.ListItemBegin, 16, 2),
                                                        new Scope(ScopeName.ListItemEnd, 18)
                                                    });

            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n\n** a\n** a\n\n* a");

            actualScopes.Count.ShouldEqual(8);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[2].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[3].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[4].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[5].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[6].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[7].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_yield_the_correct_scopes_when_nested_list_is_different_type()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 4, 2),
                                                        new Scope(ScopeName.ListItemEnd, 7, 0),
                                                        new Scope(ScopeName.ListItemBegin, 8, 3),
                                                        new Scope(ScopeName.ListItemEnd, 12, 0),
                                                        new Scope(ScopeName.ListItemBegin, 13, 3),
                                                        new Scope(ScopeName.ListItemEnd, 17, 0),
                                                        new Scope(ScopeName.ListItemBegin, 18, 2),
                                                        new Scope(ScopeName.ListItemEnd, 20, 0)
                                                    });

            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n* a\n## b\n## b\n* a");

            actualScopes.Count.ShouldEqual(10);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[2].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[3].Name.ShouldEqual(ScopeName.OrderedListBeginTag);
            actualScopes[4].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[5].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[6].Name.ShouldEqual(ScopeName.OrderedListEndTag);
            actualScopes[7].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[8].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[9].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_yield_the_correct_scopes_with_nested_item_in_middle_three_deep_when_nested_is_different_type()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 4, 2),
                                                        new Scope(ScopeName.ListItemEnd, 7, 0),
                                                        new Scope(ScopeName.ListItemBegin, 8, 3),
                                                        new Scope(ScopeName.ListItemEnd, 12, 0),
                                                        new Scope(ScopeName.ListItemBegin, 13, 4),
                                                        new Scope(ScopeName.ListItemEnd, 18, 0),
                                                        new Scope(ScopeName.ListItemBegin, 19, 2),
                                                        new Scope(ScopeName.ListItemEnd, 20, 0)
                                                    });

            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n* a\n## b\n### c\n* a");

            actualScopes.Count.ShouldEqual(10);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[2].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[3].Name.ShouldEqual(ScopeName.OrderedListBeginTag);
            actualScopes[4].Name.ShouldEqual(ScopeName.OrderedListBeginTag);
            actualScopes[5].Name.ShouldEqual(ScopeName.OrderedListEndTag);
            actualScopes[6].Name.ShouldEqual(ScopeName.OrderedListEndTag);
            actualScopes[7].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[8].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[9].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_yield_the_correct_scopes_with_nested_item_in_middle_three_deep_when_nested_is_different_type_mixed()
        {
            var origScopes = new List<Scope>(new[]
                                                    {
                                                        new Scope(ScopeName.ListItemBegin, 0, 2),
                                                        new Scope(ScopeName.ListItemEnd, 3, 0),
                                                        new Scope(ScopeName.ListItemBegin, 4, 2),
                                                        new Scope(ScopeName.ListItemEnd, 7, 0),
                                                        new Scope(ScopeName.ListItemBegin, 8, 3),
                                                        new Scope(ScopeName.ListItemEnd, 12, 0),
                                                        new Scope(ScopeName.ListItemBegin, 13, 4),
                                                        new Scope(ScopeName.ListItemEnd, 18, 0),
                                                        new Scope(ScopeName.ListItemBegin, 19, 2),
                                                        new Scope(ScopeName.ListItemEnd, 20, 0)
                                                    });

            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n* a\n## b\n*** c\n* a");

            actualScopes.Count.ShouldEqual(10);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[2].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[3].Name.ShouldEqual(ScopeName.OrderedListBeginTag);
            actualScopes[4].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[5].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[6].Name.ShouldEqual(ScopeName.OrderedListEndTag);
            actualScopes[7].Name.ShouldEqual(ScopeName.ListItemEnd);
            actualScopes[8].Name.ShouldEqual(ScopeName.ListItemBegin);
            actualScopes[9].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }

        [Fact]
        public void Should_yield_correct_scopes_with_indentation_incorrectly_set()
        {
            var origScopes = new List<Scope>(new[]
                                                 {
                                                     new Scope(ScopeName.ListItemBegin, 0, 2),
                                                     new Scope(ScopeName.ListItemEnd, 3, 0),
                                                     new Scope(ScopeName.ListItemBegin, 4, 4),
                                                     new Scope(ScopeName.ListItemEnd, 9, 0)
                                                 });

            var augmenter = new ListScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new ListMacro(), origScopes, "* a\n*** b");

            actualScopes.Count.ShouldEqual(4);
            actualScopes[0].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[1].Name.ShouldEqual(ScopeName.UnorderedListBeginTag);
            actualScopes[2].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
            actualScopes[3].Name.ShouldEqual(ScopeName.UnorderedListEndTag);
        }
    }
}