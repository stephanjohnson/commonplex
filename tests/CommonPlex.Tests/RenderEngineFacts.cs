using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Should;
using CommonPlex.Compilation;
using CommonPlex.Compilation.Macros;
using CommonPlex.Formatting;
using CommonPlex.Formatting.Renderers;
using CommonPlex.Parsing;
using Xunit;
using Xunit.Extensions;

namespace CommonPlex.Tests
{
    public class RenderEngineFacts
    {
        public class Render
        {
            [Fact]
            public void Should_return_immediately_if_the_wiki_content_is_null()
            {
                var engine = TestableRenderEngine.Create();

                string result = engine.Render(null);

                result.ShouldBeNull();
            }

            [Fact]
            public void Should_return_immediately_if_the_wiki_content_is_empty()
            {
                var engine = TestableRenderEngine.Create();

                string result = engine.Render(string.Empty);

                result.ShouldBeEmpty();
            }

            [Fact]
            public void Should_throw_ArgumentNullException_if_macros_is_null()
            {
                var engine = TestableRenderEngine.Create();

                var ex = Record.Exception(() => engine.Render("foo", (IMacro[]) null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macros");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_macros_is_empty()
            {
                var engine = TestableRenderEngine.Create();

                var ex = Record.Exception(() => engine.Render("foo", new IMacro[0])) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macros");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_if_renderers_is_null()
            {
                var engine = TestableRenderEngine.Create();

                var ex = Record.Exception(() => engine.Render("foo", new[] { new TestMacro() }, (IEnumerable<IRenderer>)null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderers");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_renderers_is_empty()
            {
                var engine = TestableRenderEngine.Create();

                var ex = Record.Exception(() => engine.Render("foo", new[] {new TestMacro()}, new IRenderer[0])) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderers");
            }

            [Fact]
            public void Should_render_the_wiki_content_successfully()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                formatter.Setup(x => x.Format("input")).Returns("output");

                string result = engine.Render("input", formatter.Object);

                result.ShouldEqual("output");
            }

            [Fact]
            public void Should_render_the_wiki_content_successfully_using_only_the_specified_macro()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                formatter.Setup(x => x.Format("input")).Returns("output");

                engine.Render("input", new[] { new BoldMacro() }, formatter.Object);

                engine.Parser.Verify(x => x.Parse("input", It.Is<IEnumerable<IMacro>>(m => (m.Count() == 1 && m.ElementAt(0) is BoldMacro)), ScopeAugmenters.All, It.IsAny<Action<IList<Scope>>>()));
            }

            [Fact]
            public void Should_convert_line_breaks_to_html_break_tags()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                formatter.Setup(x => x.Format("input")).Returns("text\ntext");

                string result = engine.Render("input", formatter.Object);

                result.ShouldEqual("text<br />text");
            }

            [Fact]
            public void Should_convert_encoded_line_breaks_to_html_break_tags()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                formatter.Setup(x => x.Format("input")).Returns("text&#10;text");

                string result = engine.Render("input", formatter.Object);

                result.ShouldEqual("text<br />text");
            }

            [Fact]
            public void Should_not_convert_line_break_into_html_break_tag_after_unordered_list()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                formatter.Setup(x => x.Format("input")).Returns("<ul><li>text</li></ul>\ntext");

                string result = engine.Render("input", formatter.Object);

                result.ShouldEqual("<ul><li>text</li></ul>\ntext");
            }

            [Fact]
            public void Should_not_convert_line_break_into_html_break_tag_after_ordered_list()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                formatter.Setup(x => x.Format("input")).Returns("<ol><li>text</li></ol>\ntext");

                string result = engine.Render("input", formatter.Object);

                result.ShouldEqual("<ol><li>text</li></ol>\ntext");
            }

            [Fact]
            public void Should_not_convert_line_break_into_html_break_tag_after_blockquote()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                formatter.Setup(x => x.Format("input")).Returns("<blockquote>text</blockquote>\ntext");

                string result = engine.Render("input", formatter.Object);

                result.ShouldEqual("<blockquote>text</blockquote>\ntext");
            }

            [Fact]
            public void Should_not_convert_line_breaks_prior_to_ending_a_blockquote()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                formatter.Setup(x => x.Format("input")).Returns("<blockquote>text\n</blockquote>");

                string result = engine.Render("input", formatter.Object);

                result.ShouldEqual("<blockquote>text\n</blockquote>");
            }

            [Fact]
            public void Should_not_convert_line_breaks_into_html_break_tags_within_pre_tags()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                formatter.Setup(x => x.Format("input")).Returns("<pre>code\ncode</pre>");

                string result = engine.Render("input", formatter.Object);

                result.ShouldEqual("<pre>code\ncode</pre>");
            }

            [Theory]
            [InlineData("<h1>text</h1>")]
            [InlineData("<h2>text</h2>")]
            [InlineData("<h3>text</h3>")]
            [InlineData("<h4>text</h4>")]
            [InlineData("<h5>text</h5>")]
            [InlineData("<h6>text</h6>")]
            [InlineData("<hr />")]
            [InlineData("<ul><li>one</li></ul>")]
            [InlineData("<ol><li>one</li></ol>")]
            public void Should_not_add_a_html_break_tag_right_before_a_tag(string html)
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                string expectation = "text\n" + html;
                formatter.Setup(x => x.Format("input")).Returns(expectation);

                string result = engine.Render("input", formatter.Object);

                result.ShouldEqual(expectation);
            }

            [Fact]
            public void Should_not_add_a_html_break_tag_right_after_a_horizontal_rule_tag()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                const string expectation = "<hr />\ntext";
                formatter.Setup(x => x.Format("input")).Returns(expectation);

                string result = engine.Render("input", formatter.Object);

                result.ShouldEqual(expectation);
            }

            [Fact]
            public void Should_not_add_a_html_break_tag_right_before_a_list_item_tag()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                const string expectation = "<ol><li>one\n</li></ol><ol><li>two</li></ol>";
                formatter.Setup(x => x.Format("input")).Returns(expectation);

                string result = engine.Render("input", formatter.Object);

                result.ShouldEqual(expectation);
            }

            [Fact]
            public void Should_throw_ArgumentNullException_if_macros_is_null_when_specifying_a_formatter()
            {
                var engine = TestableRenderEngine.Create();
                var renderer = new Mock<IRenderer>();

                var formatter = new Formatter(new[] { renderer.Object });
                var ex = Record.Exception(() => engine.Render("*abc*", null, formatter)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macros");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_macros_is_empty_when_specifying_a_formatter()
            {
                var engine = TestableRenderEngine.Create();
                var renderer = new Mock<IRenderer>();

                var formatter = new Formatter(new[] { renderer.Object });
                var ex = Record.Exception(() => engine.Render("*abc*", new IMacro[0], formatter)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macros");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_if_formatter_is_null()
            {
                var engine = TestableRenderEngine.Create();
                
                var ex = Record.Exception(() => engine.Render("*abc*", new[] { new TestMacro() }, (Formatter) null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("formatter");
            }

            [Fact]
            public void Should_return_immediately_if_the_wiki_content_is_empty_passing_a_formatter()
            {
                var engine = TestableRenderEngine.Create();
                var macro = new Mock<IMacro>();
                var formatter = new Mock<Formatter>();

                string result = engine.Render(string.Empty, new[] { macro.Object }, formatter.Object);

                result.ShouldBeEmpty();
            }

            [Fact]
            public void Should_convert_carriage_return_and_new_line_into_only_new_line_prior_to_parsing()
            {
                var engine = TestableRenderEngine.Create();
                var formatter = new Mock<Formatter>();
                formatter.Setup(x => x.Format("before\nafter")).Returns("before\nafter");

                string result = engine.Render("before\r\nafter", formatter.Object);

                result.ShouldEqual("before<br />after");
            }
        }

        private class TestableRenderEngine : RenderEngine
        {
            public readonly Mock<Parser> Parser;

            private TestableRenderEngine(Mock<Parser> parser)
                : base(parser.Object)
            {
                Parser = parser;
            }

            public static TestableRenderEngine Create()
            {
                return new TestableRenderEngine(new Mock<Parser>(new Mock<MacroCompiler>().Object));
            }
        }

        private class TestMacro : IMacro
        {
            public string Id
            {
                get { return "Test"; }
            }

            public IList<MacroRule> Rules
            {
                get
                {
                    return new List<MacroRule>
                {
                    new MacroRule(
                        @"abc",
                        new Dictionary<int, string>
                        {
                            { 0, "Test" }
                        })
                };
                }
            }
        }
    }
}