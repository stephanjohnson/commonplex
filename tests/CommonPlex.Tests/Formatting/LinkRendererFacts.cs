using System;
using Should;
using CommonPlex.Formatting.Renderers;
using Xunit;
using Xunit.Extensions;

namespace CommonPlex.Tests.Formatting
{
    public class LinkRendererFacts
    {
        public class CanExpand
        {
            [Theory]
            [InlineData(ScopeName.LinkNoText)]
            [InlineData(ScopeName.LinkWithText)]
            [InlineData(ScopeName.LinkAsMailto)]
            [InlineData(ScopeName.Anchor)]
            [InlineData(ScopeName.LinkToAnchor)]
            public void Should_be_able_to_resolve_scope_name(string scopeName)
            {
                var renderer = new LinkRenderer();

                bool result = renderer.CanExpand(scopeName);

                result.ShouldBeTrue();
            }
        }

        public class Expand
        {
            [Fact]
            public void Should_render_the_link_with_no_text_scope_correctly()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkNoText, "http://localhost", x => x, x => x);

                result.ShouldEqual("<a href=\"http://localhost\">http://localhost</a>");
            }

            [Fact]
            public void Should_render_the_link_with_text_scope_correctly()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkWithText, "Local|http://localhost", x => x, x => x);

                result.ShouldEqual("<a href=\"http://localhost\">Local</a>");
            }

            [Fact]
            public void Should_render_the_link_with_text_scope_and_correctly_encoding_the_text()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkWithText, "&Local|http://localhost", HttpUtility.HtmlEncode, x => x);

                result.ShouldEqual("<a href=\"http://localhost\">&amp;Local</a>");
            }

            [Fact]
            public void Should_render_the_link_as_mailto_scope_correctly()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkAsMailto, "someone@local.com", x => x, x => x);

                result.ShouldEqual("<a href=\"mailto:someone@local.com\">someone@local.com</a>");
            }

            [Fact]
            public void Should_render_the_anchor_scope_correctly()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.Anchor, "something", x => x, x => x);

                result.ShouldEqual("<a name=\"something\"></a>");
            }

            [Fact]
            public void Should_render_the_anchor_scope_correctly_encoding_the_attribute()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.Anchor, "&something", HttpUtility.HtmlEncode, HttpUtility.HtmlAttributeEncode);

                result.ShouldEqual("<a name=\"&amp;something\"></a>");
            }

            [Fact]
            public void Should_render_the_link_to_anchor_scope_correctly()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkToAnchor, "something", x => x, x => x);

                result.ShouldEqual("<a href=\"#something\">something</a>");
            }

            [Fact]
            public void Should_render_the_link_to_anchor_scope_correctly_and_encoding_the_text()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkToAnchor, "&something", HttpUtility.HtmlEncode, HttpUtility.HtmlAttributeEncode);

                result.ShouldEqual("<a href=\"#&amp;something\">&amp;something</a>");
            }

            [Fact]
            public void Should_render_an_unresolved_macro_if_input_has_more_than_two_parts()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkWithText, "a|b|c", x => x, x => x);

                result.ShouldEqual("<span class=\"unresolved\">Cannot resolve link macro, invalid number of parameters.</span>");
            }

            [Fact]
            public void Should_render_a_correct_link_if_not_prefixed_with_http_and_no_friendly_text()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkNoText, "www.microsoft.com", x => x, x => x);

                result.ShouldEqual("<a href=\"http://www.microsoft.com\">www.microsoft.com</a>");
            }

            [Fact]
            public void Should_render_a_correct_link_if_not_prefixed_with_http_and_with_friendly_text()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkWithText, "Test|www.microsoft.com", x => x, x => x);

                result.ShouldEqual("<a href=\"http://www.microsoft.com\">Test</a>");   
            }

            [Fact]
            public void Should_render_a_correct_mailto_link_if_prefixed_with_mailto_and_with_friendly_text()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkWithText, "Test|mailto:test@user.com", x => x, x => x);

                result.ShouldEqual("<a href=\"mailto:test@user.com\">Test</a>");
            }

            [Fact]
            public void Should_trim_url_when_link_has_no_text()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkNoText, " www.microsoft.com", x => x, x => x);

                result.ShouldEqual("<a href=\"http://www.microsoft.com\">www.microsoft.com</a>");
            }

            [Fact]
            public void Should_trim_mailto_correctly()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkAsMailto, " test@test.com ", x => x, x => x);

                result.ShouldEqual("<a href=\"mailto:test@test.com\">test@test.com</a>");
            }

            [Fact]
            public void Should_trim_anchor_correctly()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.Anchor, " test ", x => x, x => x);

                result.ShouldEqual("<a name=\"test\"></a>");
            }

            [Fact]
            public void Should_trim_link_to_anchor_correctly()
            {
                var renderer = new LinkRenderer();

                string result = renderer.Expand(ScopeName.LinkToAnchor, " test ", x => x, x => x);

                result.ShouldEqual("<a href=\"#test\">test</a>");
            }

            [Fact]
            public void Should_throw_ArgumentException_for_invalid_scope_name()
            {
                var renderer = new LinkRenderer();

                var ex = Record.Exception(() => renderer.Expand("foo", "in", x => x, x => x)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("scopeName");
            }
        }
    }
}