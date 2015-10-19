using System;
using System.Collections.Generic;
using System.Reflection;
using Moq;
using Should;
using CommonPlex.Compilation;
using CommonPlex.Compilation.Macros;
using Xunit;

namespace CommonPlex.Tests.Compilation
{
    public class MacroCompilerFacts
    {
        public class Compile
        {
            [Fact]
            public void Should_throw_ArgumentNullException_if_macro_is_null()
            {
                var compiler = new MacroCompiler();

                var ex = Record.Exception(() => compiler.Compile(null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_if_macro_identifier_is_null()
            {
                var compiler = new MacroCompiler();
                var macro = new Mock<IMacro>();

                var ex = Record.Exception(() => compiler.Compile(macro.Object)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_macro_identifier_is_empty()
            {
                var compiler = new MacroCompiler();
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns(string.Empty);

                var ex = Record.Exception(() => compiler.Compile(macro.Object)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_if_macro_rules_is_null()
            {
                var compiler = new MacroCompiler();
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns("foo");

                var ex = Record.Exception(() => compiler.Compile(macro.Object)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro rules must not be null or empty");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_macro_rules_is_empty()
            {
                var compiler = new MacroCompiler();
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns("foo");
                macro.Setup(x => x.Rules).Returns(new List<MacroRule>());

                var ex = Record.Exception(() => compiler.Compile(macro.Object)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro rules must not be null or empty");
            }

            [Fact]
            public void Should_correctly_compile_a_macro_using_the_identifier_from_the_macro()
            {
                var compiler = new MacroCompiler();
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns("foo");
                macro.Setup(x => x.Rules).Returns(new List<MacroRule>
                                                      {new MacroRule("abc", new Dictionary<int, string> {{0, "All"}})});

                CompiledMacro compiledMacro = compiler.Compile(macro.Object);

                compiledMacro.Id.ShouldEqual("foo");
            }

            [Fact]
            public void Should_correctly_compile_a_macro_with_a_single_rule_and_whole_capture()
            {
                var compiler = new MacroCompiler();
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns("foo");
                macro.Setup(x => x.Rules).Returns(new List<MacroRule>
                                                      {new MacroRule("abc", new Dictionary<int, string> {{0, "All"}})});

                CompiledMacro compiledMacro = compiler.Compile(macro.Object);

                compiledMacro.Regex.ToString().ShouldEqual(@"(?x)
(?-xis)(?m)(abc)(?x)");
                compiledMacro.Captures[0].ShouldBeNull();
                compiledMacro.Captures[1].ShouldEqual("All");
            }

            [Fact]
            public void Should_correctly_compile_a_macro_with_a_single_rule_and_partial_capture()
            {
                var compiler = new MacroCompiler();
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns("foo");
                macro.Setup(x => x.Rules).Returns(new List<MacroRule>
                                                      {
                                                          new MacroRule("(a) (b) (c)",
                                                                        new Dictionary<int, string>
                                                                            {{1, "a"}, {2, "b"}, {3, "c"}})
                                                      });

                CompiledMacro compiledMacro = compiler.Compile(macro.Object);

                compiledMacro.Regex.ToString().ShouldEqual(@"(?x)
(?-xis)(?m)((a) (b) (c))(?x)");
                compiledMacro.Captures[0].ShouldBeNull();
                compiledMacro.Captures[1].ShouldBeNull();
                compiledMacro.Captures[2].ShouldEqual("a");
                compiledMacro.Captures[3].ShouldEqual("b");
                compiledMacro.Captures[4].ShouldEqual("c");
            }

            [Fact]
            public void Should_correctly_compile_a_macro_with_a_single_rule_and_partial_capture_with_whole_capture()
            {
                var compiler = new MacroCompiler();
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns("foo");
                macro.Setup(x => x.Rules).Returns(new List<MacroRule>
                                                      {
                                                          new MacroRule("(a) (b) (c)",
                                                                        new Dictionary<int, string>
                                                                            {{0, "whole"}, {1, "a"}, {2, "b"}, {3, "c"}})
                                                      });

                CompiledMacro compiledMacro = compiler.Compile(macro.Object);

                compiledMacro.Regex.ToString().ShouldEqual(@"(?x)
(?-xis)(?m)((a) (b) (c))(?x)");
                compiledMacro.Captures[0].ShouldBeNull();
                compiledMacro.Captures[1].ShouldEqual("whole");
                compiledMacro.Captures[2].ShouldEqual("a");
                compiledMacro.Captures[3].ShouldEqual("b");
                compiledMacro.Captures[4].ShouldEqual("c");
            }

            [Fact]
            public void Should_correctly_compile_a_macro_with_multiple_rules()
            {
                var compiler = new MacroCompiler();
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns("foo");
                macro.Setup(x => x.Rules).Returns(new List<MacroRule>
                                                      {
                                                          new MacroRule("(a) (b) (c)",
                                                                        new Dictionary<int, string>
                                                                            {{0, "whole"}, {1, "a"}, {2, "b"}, {3, "c"}}),
                                                          new MacroRule("a (second) rule",
                                                                        new Dictionary<int, string> {{1, "second"}})
                                                      });

                CompiledMacro compiledMacro = compiler.Compile(macro.Object);

                compiledMacro.Regex.ToString().ShouldEqual(@"(?x)
(?-xis)(?m)((a) (b) (c))(?x)

|

(?-xis)(?m)(a (second) rule)(?x)");
                compiledMacro.Captures[0].ShouldBeNull();
                compiledMacro.Captures[1].ShouldEqual("whole");
                compiledMacro.Captures[2].ShouldEqual("a");
                compiledMacro.Captures[3].ShouldEqual("b");
                compiledMacro.Captures[4].ShouldEqual("c");
                compiledMacro.Captures[5].ShouldBeNull();
                compiledMacro.Captures[6].ShouldEqual("second");
            }

            [Fact]
            public void Should_use_previously_compiled_macro()
            {
                var compiler = new MacroCompiler();
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns("foo");
                macro.Setup(x => x.Rules).Returns(new List<MacroRule>
                                                      {
                                                          new MacroRule("(a) (b) (c)",
                                                                        new Dictionary<int, string>
                                                                            {{0, "whole"}, {1, "a"}, {2, "b"}, {3, "c"}})
                                                      });

                CompiledMacro compiledMacro1 = compiler.Compile(macro.Object);
                CompiledMacro compiledMacro2 = compiler.Compile(macro.Object);

                compiledMacro1.ShouldEqual(compiledMacro2);
            }
        }

        public class Flush
        {
            [Fact]
            public void Should_flush_the_compiled_macros()
            {
                var compiler = new MacroCompiler();
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns("foo");
                macro.Setup(x => x.Rules).Returns(new List<MacroRule>
                                                      {
                                                          new MacroRule("(a) (b) (c)",
                                                                        new Dictionary<int, string>
                                                                            {{0, "whole"}, {1, "a"}, {2, "b"}, {3, "c"}})
                                                      });
                compiler.Compile(macro.Object);

                compiler.Flush();

                FieldInfo macrosField = typeof (MacroCompiler).GetField("compiledMacros",
                                                                        BindingFlags.Instance | BindingFlags.NonPublic);
                var compiledMacros = (Dictionary<string, CompiledMacro>) macrosField.GetValue(compiler);
                compiledMacros.ShouldBeEmpty();
            }
        }
    }
}