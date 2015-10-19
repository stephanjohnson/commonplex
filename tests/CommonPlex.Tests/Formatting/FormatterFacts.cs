using System;
using System.Collections.Generic;
using Moq;
using Should;
using CommonPlex.Formatting.Renderers;
using Xunit;
using CommonPlex.Formatting;
using CommonPlex.Parsing;

namespace CommonPlex.Tests.Formatting
{
    public class FormatterFacts
    {
        public class Constructor
        {
            [Fact]
            public void Should_throw_ArgumentNullException_if_renderers_is_null()
            {
                var ex = Record.Exception(() => new Formatter(null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderers");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_renderers_is_empty()
            {
                var ex = Record.Exception(() => new Formatter(new IRenderer[0])) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderers");
            }
        }

        public class RecordParse
        {
            [Fact]
            public void Should_throw_ArgumentNullException_if_scopes_is_null()
            {
                var renderer = new Mock<IRenderer>();
                var formatter = new Formatter(new[] {renderer.Object});

                var ex = Record.Exception(() => formatter.RecordParse(null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("scopes");
            }
        }

        public class Format
        {
            [Fact]
            public void Should_format_a_list_of_scopes_in_order()
            {
                var renderer = new Mock<IRenderer>();
                const string scope = "scope";
                renderer.Setup(x => x.CanExpand(scope)).Returns(true);
                renderer.Setup(x => x.Expand(scope, "ab", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Returns("<b>ab</b>");
                renderer.Setup(x => x.Expand(scope, "abc", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Returns("<b>abc</b>");
                var formatter = new Formatter(new[] {renderer.Object});
                var scopes = new List<Scope> {new Scope(scope, 7, 3), new Scope(scope, 4, 2)};
                formatter.RecordParse(scopes);

                string result = formatter.Format("the ab abc code");

                result.ShouldEqual("the <b>ab</b> <b>abc</b> code");
            }

            [Fact]
            public void Should_format_the_string_when_it_cannot_resolve_a_macro()
            {
                var renderer = new Mock<IRenderer>();
                const string scope = "scope";
                renderer.Setup(x => x.CanExpand(scope)).Returns(false);
                var formatter = new Formatter(new[] {renderer.Object});
                var scopes = new List<Scope> {new Scope(scope, 4, 2)};
                formatter.RecordParse(scopes);

                string result = formatter.Format("the ab abc code");

                result.ShouldEqual("the <span class=\"unresolved\">Cannot resolve macro, as no renderers were found.</span>[ab] abc code");
            }

            [Fact]
            public void Should_html_encode_the_content_when_it_cannot_resolve_a_macro()
            {
                var renderer = new Mock<IRenderer>();
                const string scope = "scope";
                renderer.Setup(x => x.CanExpand(scope)).Returns(false);
                var formatter = new Formatter(new[] { renderer.Object });
                var scopes = new List<Scope> { new Scope(scope, 4, 3) };
                formatter.RecordParse(scopes);

                string result = formatter.Format("the &ab abc code");

                result.ShouldEqual("the <span class=\"unresolved\">Cannot resolve macro, as no renderers were found.</span>[&amp;ab] abc code");
            }

            [Fact]
            public void Should_remove_the_line_break_at_the_end_of_the_formatted_text()
            {
                var renderer = new Mock<IRenderer>();
                renderer.Setup(x => x.CanExpand(It.IsAny<string>())).Returns(true);
                renderer.Setup(x => x.Expand(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Returns("<h1>end</h1>\r");
                var formatter = new Formatter(new[] {renderer.Object});
                var scopes = new List<Scope> {new Scope("foo", 0, 1)};
                formatter.RecordParse(scopes);

                string result = formatter.Format("f");

                result.ShouldEqual("<h1>end</h1>");
            }

            [Fact]
            public void Should_skip_nested_scopes()
            {
                var renderer = new Mock<IRenderer>();
                const string scope = "scope";
                renderer.Setup(x => x.CanExpand(scope)).Returns(true);
                renderer.Verify(x => x.Expand(scope, "bc", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>()), Times.Never());
                renderer.Setup(x => x.Expand(scope, "abc", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Returns("notskipped");
                var formatter = new Formatter(new[] { renderer.Object });
                var scopes = new List<Scope> { new Scope(scope, 4, 3), new Scope(scope, 5, 2) };
                formatter.RecordParse(scopes);

                string result = formatter.Format("the abc code");

                result.ShouldEqual("the notskipped code");
                renderer.Verify();
            }

            [Fact]
            public void Should_not_skip_scopes_with_same_index_and_length()
            {
                var renderer = new Mock<IRenderer>();
                const string scope = "scope";
                renderer.Setup(x => x.CanExpand(scope)).Returns(true);
                renderer.Verify(x => x.Expand(scope, "bc", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>()), Times.Never());
                renderer.Setup(x => x.Expand(scope, "abc", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Returns("notskipped");
                var formatter = new Formatter(new[] { renderer.Object });
                var scopes = new List<Scope> { new Scope(scope, 4, 3), new Scope(scope, 4, 3) };
                formatter.RecordParse(scopes);

                string result = formatter.Format("the abc code");

                result.ShouldEqual("the notskippednotskipped code");
                renderer.Verify();
            }

            [Fact]
            public void Should_html_encode_the_text_between_scopes()
            {
                var renderer = new Mock<IRenderer>();
                const string scope = "scope";
                renderer.Setup(x => x.CanExpand(scope)).Returns(true);
                renderer.Setup(x => x.Expand(scope, "ab", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Returns("<b>ab</b>");
                renderer.Setup(x => x.Expand(scope, "abc", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Returns("<b>abc</b>");
                var formatter = new Formatter(new[] { renderer.Object });
                var scopes = new List<Scope> { new Scope(scope, 8, 3), new Scope(scope, 5, 2) };
                formatter.RecordParse(scopes);

                string result = formatter.Format("the& ab abc code");

                result.ShouldEqual("the&amp; <b>ab</b> <b>abc</b> code");
            }

            [Fact]
            public void Should_html_encode_the_text_when_writing_to_the_end()
            {
                var renderer = new Mock<IRenderer>();
                const string scope = "scope";
                renderer.Setup(x => x.CanExpand(scope)).Returns(true);
                renderer.Setup(x => x.Expand(scope, "ab", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Returns("<b>ab</b>");
                renderer.Setup(x => x.Expand(scope, "abc", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Returns("<b>abc</b>");
                var formatter = new Formatter(new[] { renderer.Object });
                var scopes = new List<Scope> { new Scope(scope, 7, 3), new Scope(scope, 4, 2) };
                formatter.RecordParse(scopes);

                string result = formatter.Format("the ab abc &code");

                result.ShouldEqual("the <b>ab</b> <b>abc</b> &amp;code");
            }

            [Fact]
            public void Should_capture_any_exception_when_resolving_a_scope_and_render_it_as_an_unresolved_macro()
            {
                var renderer = new Mock<IRenderer>();
                const string scope = "scope";
                renderer.Setup(x => x.CanExpand(scope)).Returns(true);
                renderer.Setup(x => x.Expand(scope, "ab", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Throws<Exception>();
                var formatter = new Formatter(new[] {renderer.Object});
                var scopes = new List<Scope> {new Scope(scope, 0, 2)};
                formatter.RecordParse(scopes);

                string result = formatter.Format("ab");

                result.ShouldEqual("<span class=\"unresolved\">Cannot resolve macro, as an unhandled exception occurred.</span>[ab]");
            }

            [Fact]
            public void Should_html_encode_content_while_capturing_any_exception_when_resolving_a_scope_and_render_it_as_an_unresolved_macro()
            {
                var renderer = new Mock<IRenderer>();
                const string scope = "scope";
                renderer.Setup(x => x.CanExpand(scope)).Returns(true);
                renderer.Setup(x => x.Expand(scope, "&ab", It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Throws<Exception>();
                var formatter = new Formatter(new[] { renderer.Object });
                var scopes = new List<Scope> { new Scope(scope, 0, 3) };
                formatter.RecordParse(scopes);

                string result = formatter.Format("&ab");

                result.ShouldEqual("<span class=\"unresolved\">Cannot resolve macro, as an unhandled exception occurred.</span>[&amp;ab]");
            }

            [Fact]
            public void Should_raise_ScopeRendered_event_correctly()
            {
                var renderer = new Mock<IRenderer>();
                const string scope = "scope";
                const string expectedContent = "ab";
                renderer.Setup(x => x.CanExpand(scope)).Returns(true);
                renderer.Setup(x => x.Expand(scope, expectedContent, It.IsAny<Func<string, string>>(), It.IsAny<Func<string, string>>())).Returns(expectedContent);
                var formatter = new Formatter(new[] { renderer.Object });
                var expectedScope = new Scope(scope, 0, 2);
                var scopes = new List<Scope> { expectedScope };
                formatter.RecordParse(scopes);
                Scope actualScope = null;
                string actualContent = null;
                string actualRenderedContent = null;

                formatter.ScopeRendered += delegate(object obj, RenderedScopeEventArgs e)
                                               {
                                                   actualContent = e.Content;
                                                   actualRenderedContent = e.RenderedContent;
                                                   actualScope = e.Scope;
                                               };

                formatter.Format(expectedContent);

                actualScope.ShouldEqual(expectedScope);
                actualContent.ShouldEqual(expectedContent);
                actualRenderedContent.ShouldEqual(expectedContent);
            }
        }

        public class EncodeContent
        {
            [Fact]
            public void Should_throw_ArgumentNullException_if_content_is_null()
            {
                var formatter = new TestableFormatter();

                var ex = Record.Exception(() => formatter.DoEncodeContent(null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("input");
            }

            [Fact]
            public void Should_html_encode_content()
            {
                var formatter = new TestableFormatter();

                const string input = "<script>alert('hi')</script>";
                string result = formatter.DoEncodeContent(input);

                result.ShouldEqual(HttpUtility.HtmlEncode(input));
            }
        }

        public class AttributeEncodeContent
        {
            [Fact]
            public void Should_throw_ArgumentNullException_if_content_is_null()
            {
                var formatter = new TestableFormatter();

                var ex = Record.Exception(() => formatter.DoAttributeEncodeContent(null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("input");
            }

            [Fact]
            public void Should_html_encode_content()
            {
                var formatter = new TestableFormatter();

                const string input = "hi\"hi";
                string result = formatter.DoAttributeEncodeContent(input);

                result.ShouldEqual(HttpUtility.HtmlAttributeEncode(input));
            }
        }

        class TestableFormatter : Formatter
        {
            public string DoEncodeContent(string input)
            {
                return EncodeContent(input);
            }

            public string DoAttributeEncodeContent(string input)
            {
                return EncodeAttributeContent(input);
            }
        }
    }
}