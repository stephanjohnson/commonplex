using System;
using Should;
using CommonPlex.Formatting.Renderers;
using Xunit;
using Xunit.Extensions;

namespace CommonPlex.Tests.Formatting
{
    public class ListItemRendererFacts
    {
        public class CanExpand
        {
            [Theory]
            [InlineData(ScopeName.OrderedListBeginTag)]
            [InlineData(ScopeName.OrderedListEndTag)]
            [InlineData(ScopeName.UnorderedListBeginTag)]
            [InlineData(ScopeName.UnorderedListEndTag)]
            [InlineData(ScopeName.ListItemBegin)]
            [InlineData(ScopeName.ListItemEnd)]
            public void Should_be_able_to_resolve_scope_name(string scopeName)
            {
                var renderer = new ListItemRenderer();

                bool result = renderer.CanExpand(scopeName);

                result.ShouldBeTrue();
            }
        }

        public class Expand
        {
            [Fact]
            public void Should_render_the_ordered_list_begin_tag_scope_correctly()
            {
                var renderer = new ListItemRenderer();

                string result = renderer.Expand(ScopeName.OrderedListBeginTag, string.Empty, x => x, x => x);

                result.ShouldEqual("<ol><li>");
            }

            [Fact]
            public void Should_render_the_ordered_list_end_tag_scope_correctly()
            {
                var renderer = new ListItemRenderer();

                string result = renderer.Expand(ScopeName.OrderedListEndTag, string.Empty, x => x, x => x);

                result.ShouldEqual("</li></ol>");
            }

            [Fact]
            public void Should_render_the_unordered_list_begin_tag_scope_correctly()
            {
                var renderer = new ListItemRenderer();

                string result = renderer.Expand(ScopeName.UnorderedListBeginTag, string.Empty, x => x, x => x);

                result.ShouldEqual("<ul><li>");
            }

            [Fact]
            public void Should_render_the_unordered_list_end_tag_scope_correctly()
            {
                var renderer = new ListItemRenderer();

                string result = renderer.Expand(ScopeName.UnorderedListEndTag, string.Empty, x => x, x => x);

                result.ShouldEqual("</li></ul>");
            }

            [Fact]
            public void Should_render_the_list_item_begin_scope_correctly()
            {
                var renderer = new ListItemRenderer();

                string result = renderer.Expand(ScopeName.ListItemBegin, string.Empty, x => x, x => x);

                result.ShouldEqual("<li>");
            }

            [Fact]
            public void Should_render_the_list_item_end_scope_correctly()
            {
                var renderer = new ListItemRenderer();

                string result = renderer.Expand(ScopeName.ListItemEnd, string.Empty, x => x, x => x);

                result.ShouldEqual("</li>");
            }

            [Fact]
            public void Should_throw_ArgumentException_for_invalid_scope_name()
            {
                var renderer = new ListItemRenderer();

                var ex = Record.Exception(() => renderer.Expand("foo", "in", x => x, x => x)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("scopeName");
            }
        }
    }
}