using System;
using Should;
using CommonPlex.Formatting.Renderers;
using Xunit;
using Xunit.Extensions;

namespace CommonPlex.Tests.Formatting
{
    public class TextFormattingRendererFacts
    {
        public class CanExpand
        {
            [Theory]
            [InlineData(ScopeName.BoldBegin)]
            [InlineData(ScopeName.BoldEnd)]
            [InlineData(ScopeName.ItalicsBegin)]
            [InlineData(ScopeName.ItalicsEnd)]
            [InlineData(ScopeName.HeadingOneBegin)]
            [InlineData(ScopeName.HeadingOneEnd)]
            [InlineData(ScopeName.HeadingTwoBegin)]
            [InlineData(ScopeName.HeadingTwoEnd)]
            [InlineData(ScopeName.HeadingThreeBegin)]
            [InlineData(ScopeName.HeadingThreeEnd)]
            [InlineData(ScopeName.HeadingFourBegin)]
            [InlineData(ScopeName.HeadingFourEnd)]
            [InlineData(ScopeName.HeadingFiveBegin)]
            [InlineData(ScopeName.HeadingFiveEnd)]
            [InlineData(ScopeName.HeadingSixBegin)]
            [InlineData(ScopeName.HeadingSixEnd)]
            [InlineData(ScopeName.Remove)]
            [InlineData(ScopeName.HorizontalRule)]
            [InlineData(ScopeName.EscapedMarkup)]
            public void Should_be_able_to_resolve_scope_name(string scopeName)
            {
                var renderer = new TextFormattingRenderer();

                bool result = renderer.CanExpand(scopeName);

                result.ShouldBeTrue();
            }
        }

        public class Expand
        {
            [Theory]
            [InlineData(ScopeName.BoldBegin, "strong")]
            [InlineData(ScopeName.BoldEnd, "/strong")]
            [InlineData(ScopeName.ItalicsBegin, "em")]
            [InlineData(ScopeName.ItalicsEnd, "/em")]
            [InlineData(ScopeName.HeadingOneBegin, "h1")]
            [InlineData(ScopeName.HeadingTwoBegin, "h2")]
            [InlineData(ScopeName.HeadingThreeBegin, "h3")]
            [InlineData(ScopeName.HeadingFourBegin, "h4")]
            [InlineData(ScopeName.HeadingFiveBegin, "h5")]
            [InlineData(ScopeName.HeadingSixBegin, "h6")]
            [InlineData(ScopeName.HorizontalRule, "hr /")]
            public void Should_resolve_the_scope_correctly_for_tags(string scopeName, string tagName)
            {
                var renderer = new TextFormattingRenderer();

                string result = renderer.Expand(scopeName, "in", x => x, x => x);

                result.ShouldEqual(string.Format("<{0}>", tagName));
            }

            [Theory]
            [InlineData(ScopeName.HeadingOneEnd, "h1")]
            [InlineData(ScopeName.HeadingTwoEnd, "h2")]
            [InlineData(ScopeName.HeadingThreeEnd, "h3")]
            [InlineData(ScopeName.HeadingFourEnd, "h4")]
            [InlineData(ScopeName.HeadingFiveEnd, "h5")]
            [InlineData(ScopeName.HeadingSixEnd, "h6")]
            public void Should_resolve_heading_scopes_correctly(string scopeName, string endTagName)
            {
                var renderer = new TextFormattingRenderer();

                string result = renderer.Expand(scopeName, "in", x => x, x => x);

                result.ShouldEqual(string.Format("</{0}>\r", endTagName));
            }

            [Fact]
            public void Should_resolve_the_remove_scope_correctly()
            {
                var renderer = new TextFormattingRenderer();

                string result = renderer.Expand(ScopeName.Remove, "in", x => x, x => x);

                result.ShouldBeEmpty();
            }

            [Fact]
            public void Should_resolve_the_escaped_markup_scope_correctly()
            {
                var renderer = new TextFormattingRenderer();

                string result = renderer.Expand(ScopeName.EscapedMarkup, "this is content", x => x, x => x);

                result.ShouldEqual("this is content");
            }

            [Fact]
            public void Should_resolve_the_escaped_markup_scope_correctly_and_html_encode_it()
            {
                var renderer = new TextFormattingRenderer();

                string result = renderer.Expand(ScopeName.EscapedMarkup, "this is &content", HttpUtility.HtmlEncode, x => x);

                result.ShouldEqual("this is &amp;content");
            }

            [Fact]
            public void Should_throw_ArgumentException_for_invalid_scope_name()
            {
                var renderer = new TextFormattingRenderer();

                var ex = Record.Exception(() => renderer.Expand("foo", "in", x => x, x => x)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("scopeName");
            }
        }
    }
}