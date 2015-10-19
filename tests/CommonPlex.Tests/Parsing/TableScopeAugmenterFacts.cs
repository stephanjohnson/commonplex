using System.Collections.Generic;
using Should;
using CommonPlex.Compilation.Macros;
using CommonPlex.Parsing;
using Xunit;

namespace CommonPlex.Tests.Parsing
{
    public class TableScopeAugmenterFacts
    {
        [Fact]
        public void Should_add_table_begin_and_end_scopes()
        {
            var origScopes = new List<Scope>(new[]
                    {
                        new Scope(ScopeName.TableRowBegin, 0, 1),
                        new Scope(ScopeName.TableCell, 1, 1),
                        new Scope(ScopeName.TableRowEnd, 2, 1)
                    });

            var augmenter = new TableScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new TableMacro(), origScopes, null);

            actualScopes.Count.ShouldEqual(5);
            actualScopes[0].Name.ShouldEqual(ScopeName.TableBegin);
            actualScopes[0].Index.ShouldEqual(0);
            actualScopes[0].Length.ShouldEqual(1);
            actualScopes[4].Name.ShouldEqual(ScopeName.TableEnd);
            actualScopes[4].Index.ShouldEqual(3);
            actualScopes[4].Length.ShouldEqual(0);
        }

        [Fact]
        public void Should_contain_the_correct_captured_scopes()
        {
            var origScopes = new List<Scope>(new[]
                    {
                        new Scope(ScopeName.TableRowBegin, 0, 1),
                        new Scope(ScopeName.TableCell, 1, 1),
                        new Scope(ScopeName.TableRowEnd, 2, 1)
                    });

            var augmenter = new TableScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new TableMacro(), origScopes, null);

            actualScopes.Count.ShouldEqual(5);
            actualScopes[1].ShouldEqual(origScopes[0]);
            actualScopes[2].ShouldEqual(origScopes[1]);
            actualScopes[3].ShouldEqual(origScopes[2]);
        }

        [Fact]
        public void Should_end_and_start_a_new_block()
        {
            var origScopes = new List<Scope>(new[]
                    {
                        new Scope(ScopeName.TableRowBegin, 0, 1),
                        new Scope(ScopeName.TableCell, 1, 1),
                        new Scope(ScopeName.TableRowEnd, 2, 1),
                        new Scope(ScopeName.TableRowBegin, 10, 1),
                        new Scope(ScopeName.TableCell, 11, 1),
                        new Scope(ScopeName.TableRowEnd, 12, 1)
                    });

            var augmenter = new TableScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new TableMacro(), origScopes, null);

            actualScopes.Count.ShouldEqual(10);
            actualScopes[0].Name.ShouldEqual(ScopeName.TableBegin);
            actualScopes[0].Index.ShouldEqual(0);
            actualScopes[0].Length.ShouldEqual(1);
            actualScopes[4].Name.ShouldEqual(ScopeName.TableEnd);
            actualScopes[4].Index.ShouldEqual(3);
            actualScopes[4].Length.ShouldEqual(0);
            actualScopes[5].Name.ShouldEqual(ScopeName.TableBegin);
            actualScopes[5].Index.ShouldEqual(10);
            actualScopes[5].Length.ShouldEqual(1);
            actualScopes[9].Name.ShouldEqual(ScopeName.TableEnd);
            actualScopes[9].Index.ShouldEqual(13);
            actualScopes[9].Length.ShouldEqual(0);
        }

        [Fact]
        public void Should_end_and_start_a_new_block_with_only_headers()
        {
            var origScopes = new List<Scope>(new[]
                    {
                        new Scope(ScopeName.TableRowHeaderBegin, 0, 1),
                        new Scope(ScopeName.TableCellHeader, 1, 1),
                        new Scope(ScopeName.TableRowHeaderEnd, 2, 1),
                        new Scope(ScopeName.TableRowHeaderBegin, 10, 1),
                        new Scope(ScopeName.TableCellHeader, 11, 1),
                        new Scope(ScopeName.TableRowHeaderEnd, 12, 1)
                    });

            var augmenter = new TableScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new TableMacro(), origScopes, null);

            actualScopes.Count.ShouldEqual(10);
            actualScopes[0].Name.ShouldEqual(ScopeName.TableBegin);
            actualScopes[0].Index.ShouldEqual(0);
            actualScopes[0].Length.ShouldEqual(1);
            actualScopes[4].Name.ShouldEqual(ScopeName.TableEnd);
            actualScopes[4].Index.ShouldEqual(3);
            actualScopes[4].Length.ShouldEqual(0);
            actualScopes[5].Name.ShouldEqual(ScopeName.TableBegin);
            actualScopes[5].Index.ShouldEqual(10);
            actualScopes[5].Length.ShouldEqual(1);
            actualScopes[9].Name.ShouldEqual(ScopeName.TableEnd);
            actualScopes[9].Index.ShouldEqual(13);
            actualScopes[9].Length.ShouldEqual(0);
        }

        [Fact]
        public void Should_contain_the_correct_captured_scopes_with_end_and_start_new_block()
        {
            var origScopes = new List<Scope>(new[]
                    {
                        new Scope(ScopeName.TableRowBegin, 0, 1),
                        new Scope(ScopeName.TableCell, 1, 1),
                        new Scope(ScopeName.TableRowEnd, 2, 1),
                        new Scope(ScopeName.TableRowBegin, 10, 1),
                        new Scope(ScopeName.TableCell, 11, 1),
                        new Scope(ScopeName.TableRowEnd, 12, 1)
                    });

            var augmenter = new TableScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new TableMacro(), origScopes, null);

            actualScopes.Count.ShouldEqual(10);
            actualScopes[1].ShouldEqual(origScopes[0]);
            actualScopes[2].ShouldEqual(origScopes[1]);
            actualScopes[3].ShouldEqual(origScopes[2]);
            actualScopes[6].ShouldEqual(origScopes[3]);
            actualScopes[7].ShouldEqual(origScopes[4]);
            actualScopes[8].ShouldEqual(origScopes[5]);
        }

        [Fact]
        public void Should_add_table_row_end_if_next_is_table_row_begin()
        {
            var origScopes = new List<Scope>(new[]
                    {
                        new Scope(ScopeName.TableRowBegin, 0, 1),
                        new Scope(ScopeName.TableCell, 2, 1),
                        new Scope(ScopeName.TableRowBegin, 5, 1),
                        new Scope(ScopeName.TableCell, 7, 1),
                        new Scope(ScopeName.TableRowEnd, 9, 1)
                    });

            var augmenter = new TableScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new TableMacro(), origScopes, "|a|b\n|c|d|");

            actualScopes.Count.ShouldEqual(8);
            actualScopes[3].Name.ShouldEqual(ScopeName.TableRowEnd);
            actualScopes[3].Index.ShouldEqual(4);
            actualScopes[3].Length.ShouldEqual(1);
        }

        [Fact]
        public void Should_add_table_row_end_if_at_end_of_table()
        {
            var origScopes = new List<Scope>(new[]
                    {
                        new Scope(ScopeName.TableRowBegin, 0, 1),
                        new Scope(ScopeName.TableCell, 2, 1)
                    });

            var augmenter = new TableScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new TableMacro(), origScopes, "|a|b");

            actualScopes.Count.ShouldEqual(5);
            actualScopes[0].Name.ShouldEqual(ScopeName.TableBegin);
            actualScopes[3].Name.ShouldEqual(ScopeName.TableRowEnd);
            actualScopes[3].Index.ShouldEqual(4);
            actualScopes[3].Length.ShouldEqual(0);
            actualScopes[4].Name.ShouldEqual(ScopeName.TableEnd);
            actualScopes[4].Index.ShouldEqual(4);
            actualScopes[4].Length.ShouldEqual(0);
        }

        [Fact]
        public void Should_add_table_row_end_if_starting_new_table()
        {
            var origScopes = new List<Scope>(new[]
                    {
                        new Scope(ScopeName.TableRowBegin, 0, 1),
                        new Scope(ScopeName.TableCell, 2, 1),
                        new Scope(ScopeName.TableRowBegin, 6, 1),
                        new Scope(ScopeName.TableCell, 8, 1),
                        new Scope(ScopeName.TableRowEnd, 9, 1)
                    });

            var augmenter = new TableScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new TableMacro(), origScopes, "|a|b\n\n|c|d|");

            actualScopes.Count.ShouldEqual(10);
            actualScopes[3].Name.ShouldEqual(ScopeName.TableRowEnd);
            actualScopes[3].Index.ShouldEqual(4);
            actualScopes[3].Length.ShouldEqual(1);
            actualScopes[4].Name.ShouldEqual(ScopeName.TableEnd);
            actualScopes[4].Index.ShouldEqual(5);
            actualScopes[4].Length.ShouldEqual(0);
        }

        [Fact]
        public void Should_add_table_row_header_end_if_next_is_table_row_begin()
        {
            var origScopes = new List<Scope>(new[]
                    {
                        new Scope(ScopeName.TableRowHeaderBegin, 0, 2),
                        new Scope(ScopeName.TableCellHeader, 3, 2),
                        new Scope(ScopeName.TableRowBegin, 7, 1),
                        new Scope(ScopeName.TableCell, 9, 1),
                        new Scope(ScopeName.TableRowEnd, 11, 1)
                    });

            var augmenter = new TableScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new TableMacro(), origScopes, "||a||b\n|c|d|");

            actualScopes.Count.ShouldEqual(8);
            actualScopes[3].Name.ShouldEqual(ScopeName.TableRowHeaderEnd);
            actualScopes[3].Index.ShouldEqual(6);
            actualScopes[3].Length.ShouldEqual(1);
        }

        [Fact]
        public void Should_add_table_row_header_end_if_at_end_of_table()
        {
            var origScopes = new List<Scope>(new[]
                    {
                        new Scope(ScopeName.TableRowHeaderBegin, 0, 2),
                        new Scope(ScopeName.TableCellHeader, 3, 2)
                    });

            var augmenter = new TableScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new TableMacro(), origScopes, "||a||b");

            actualScopes.Count.ShouldEqual(5);
            actualScopes[0].Name.ShouldEqual(ScopeName.TableBegin);
            actualScopes[3].Name.ShouldEqual(ScopeName.TableRowHeaderEnd);
            actualScopes[3].Index.ShouldEqual(6);
            actualScopes[3].Length.ShouldEqual(0);
            actualScopes[4].Name.ShouldEqual(ScopeName.TableEnd);
            actualScopes[4].Index.ShouldEqual(6);
            actualScopes[4].Length.ShouldEqual(0);
        }

        [Fact]
        public void Should_add_table_row_end_header_if_starting_new_table()
        {
            var origScopes = new List<Scope>(new[]
                    {
                        new Scope(ScopeName.TableRowHeaderBegin, 0, 2),
                        new Scope(ScopeName.TableCellHeader, 3, 2),
                        new Scope(ScopeName.TableRowHeaderBegin, 8, 2),
                        new Scope(ScopeName.TableCellHeader, 11, 2),
                        new Scope(ScopeName.TableRowHeaderEnd, 14, 2)
                    });

            var augmenter = new TableScopeAugmenter();

            IList<Scope> actualScopes = augmenter.Augment(new TableMacro(), origScopes, "||a||b\n\n||c||d||");

            actualScopes.Count.ShouldEqual(10);
            actualScopes[3].Name.ShouldEqual(ScopeName.TableRowHeaderEnd);
            actualScopes[3].Index.ShouldEqual(6);
            actualScopes[3].Length.ShouldEqual(1);
            actualScopes[4].Name.ShouldEqual(ScopeName.TableEnd);
            actualScopes[4].Index.ShouldEqual(7);
            actualScopes[4].Length.ShouldEqual(0);
        }
    }
}