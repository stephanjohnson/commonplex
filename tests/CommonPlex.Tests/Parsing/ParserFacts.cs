using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Moq;
using Should;
using Xunit;
using Xunit.Extensions;
using CommonPlex.Compilation;
using CommonPlex.Compilation.Macros;
using CommonPlex.Parsing;

namespace CommonPlex.Tests.Parsing
{
    public class ParserFacts
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_immediately_return_when_wiki_content_is_not_present(string wikiContent)
        {
            var parser = new Parser(new Mock<MacroCompiler>().Object);
            var macros = new List<IMacro> {new Mock<IMacro>().Object};
            int invocations = 0;

            parser.Parse(wikiContent, macros, new Dictionary<string, IScopeAugmenter>(), s => invocations++);

            invocations.ShouldEqual(0);
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_macros_is_null()
        {
            var parser = new Parser(new Mock<MacroCompiler>().Object);
            int invocations = 0;

            var ex = Record.Exception(() => parser.Parse("content", null, new Dictionary<string, IScopeAugmenter>(), s => invocations++)) as ArgumentNullException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("macros");
        }

        [Fact]
        public void Should_throw_ArgumentException_when_macros_is_empty()
        {
            var parser = new Parser(new Mock<MacroCompiler>().Object);
            var macros = new List<IMacro>();
            int invocations = 0;

            var ex = Record.Exception(() => parser.Parse("content", macros, new Dictionary<string, IScopeAugmenter>(), s => invocations++)) as ArgumentException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("macros");
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_scope_augmenters_is_null()
        {
            var parser = new Parser(new Mock<MacroCompiler>().Object);
            var macro = new Mock<IMacro>();
            macro.Setup(x => x.Id).Returns("Macro");
            var macros = new List<IMacro> { macro.Object };
            var scopeStack = new Stack<IList<Scope>>();

            var ex = Record.Exception(() => parser.Parse("content", macros, null, scopeStack.Push)) as ArgumentNullException;

            ex.ShouldNotBeNull();
        }

        [Fact]
        public void Should_yield_the_correct_matches_from_a_compiled_macro()
        {
            var compiler = new Mock<MacroCompiler>();
            compiler.Setup(x => x.Compile(It.IsAny<IMacro>())).Returns(new CompiledMacro("foo", new Regex("abc"), new List<string> {"All"}));
            var parser = new Parser(compiler.Object);
            var macro = new Mock<IMacro>();
            macro.Setup(x => x.Id).Returns("Macro");
            var macros = new List<IMacro> {macro.Object};
            var scopeStack = new Stack<IList<Scope>>();

            parser.Parse("this is abc content", macros, new Dictionary<string, IScopeAugmenter>(), scopeStack.Push);

            scopeStack.Count.ShouldEqual(1);
            var popped = scopeStack.Pop();
            popped[0].Index.ShouldEqual(8);
            popped[0].Length.ShouldEqual(3);
            popped[0].Name.ShouldEqual("All");
        }

        [Fact]
        public void Should_yield_the_correct_matches_from_a_compiled_macro_with_named_reference_omitted()
        {
            var compiler = new Mock<MacroCompiler>();
            compiler.Setup(x => x.Compile(It.IsAny<IMacro>())).Returns(new CompiledMacro("foo", new Regex("(?<test>abc)"), new List<string> { "All" }));
            var parser = new Parser(compiler.Object);
            var macro = new Mock<IMacro>();
            macro.Setup(x => x.Id).Returns("Macro");
            var macros = new List<IMacro> { macro.Object };
            var scopeStack = new Stack<IList<Scope>>();

            parser.Parse("this is abc content", macros, new Dictionary<string, IScopeAugmenter>(), scopeStack.Push);

            scopeStack.Count.ShouldEqual(1);
            var popped = scopeStack.Pop();
            popped[0].Index.ShouldEqual(8);
            popped[0].Length.ShouldEqual(3);
            popped[0].Name.ShouldEqual("All");
        }

        [Fact]
        public void Should_yield_the_scopes_from_the_augmenter()
        {
            var compiler = new Mock<MacroCompiler>();
            var macro = new Mock<IMacro>();
            var augmenter = new Mock<IScopeAugmenter>();
            var scope = new Scope("Scope", 1);
            macro.Setup(x => x.Id).Returns("Macro");
            compiler.Setup(x => x.Compile(macro.Object)).Returns(new CompiledMacro("foo", new Regex("abc"), new List<string> {"All"}));
            augmenter.Setup(x => x.Augment(macro.Object, It.IsAny<IList<Scope>>(), It.IsAny<string>())).Returns(new List<Scope> { scope });
            var parser = new Parser(compiler.Object);
            var macros = new List<IMacro> {macro.Object};
            var scopeStack = new Stack<IList<Scope>>();
            var augmenters = new Dictionary<string, IScopeAugmenter> {{"Macro", augmenter.Object}};

            parser.Parse("abc", macros, augmenters, scopeStack.Push);

            scopeStack.Count.ShouldEqual(1);
            var popped = scopeStack.Pop();
            popped.Count.ShouldEqual(1);
            popped[0].Name.ShouldEqual("Scope");
            popped[0].Index.ShouldEqual(1);
        }
    }
}