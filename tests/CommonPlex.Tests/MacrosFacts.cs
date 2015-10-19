using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using CommonPlex.Compilation;
using CommonPlex.Compilation.Macros;
using Xunit;

namespace CommonPlex.Tests
{
    public class MacrosFacts
    {
        private class EmptyIdMacro : IMacro
        {
            public string Id
            {
                get { return string.Empty; }
            }

            public IList<MacroRule> Rules
            {
                get { throw new NotImplementedException(); }
            }
        }

        private class NullIdMacro : IMacro
        {
            public string Id
            {
                get { return null; }
            }

            public IList<MacroRule> Rules
            {
                get { throw new NotImplementedException(); }
            }
        }

        public class Register
        {
            [Fact]
            public void Should_throw_ArgumentNullException_when_macro_is_null()
            {
                var ex = Record.Exception(() => Macros.Register(null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_when_macro_id_is_null()
            {
                var macro = new Mock<IMacro>();

                var ex = Record.Exception(() => Macros.Register(macro.Object)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_when_macro_id_is_null_by_type()
            {
                var ex = Record.Exception(() => Macros.Register<NullIdMacro>()) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentException_when_macro_id_is_empty()
            {
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns(string.Empty);

                var ex = Record.Exception(() => Macros.Register(macro.Object)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentException_when_macro_id_is_empty_by_type()
            {
                var ex = Record.Exception(() => Macros.Register<EmptyIdMacro>()) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro identifier must not be null or empty.");
            }

            [Fact]
            public void Should_correctly_load_the_macro_by_object()
            {
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns("foo");

                Macros.Register(macro.Object);

                Macros.All.ShouldContain(macro.Object);
                Macros.Unregister(macro.Object);
            }

            [Fact]
            public void Should_correctly_load_the_macro_by_type()
            {
                Macros.Register<ValidMacro>();

                Macros.All.Select(m => m.GetType()).ShouldContain(typeof(ValidMacro));
                Macros.Unregister(new ValidMacro());
            }

            [Fact]
            public void Should_replace_an_existing_macro_with_the_same_identifier()
            {
                var macro1 = new Mock<IMacro>();
                macro1.Setup(x => x.Id).Returns("foo");
                var macro2 = new Mock<IMacro>();
                macro2.Setup(x => x.Id).Returns("foo");

                Macros.Register(macro1.Object);
                Macros.Register(macro2.Object);

                Macros.All.ShouldNotContain(macro1.Object);
                Macros.All.ShouldContain(macro2.Object);
                Macros.Unregister(macro2.Object);
            }

            [Fact]
            public void Should_add_multiple_macros_with_the_a_different_identifier()
            {
                var macro1 = new Mock<IMacro>();
                macro1.Setup(x => x.Id).Returns("foo");
                var macro2 = new Mock<IMacro>();
                macro2.Setup(x => x.Id).Returns("bar");

                Macros.Register(macro1.Object);
                Macros.Register(macro2.Object);

                Macros.All.ShouldContain(macro1.Object);
                Macros.All.ShouldContain(macro2.Object);
                Macros.Unregister(macro1.Object);
                Macros.Unregister(macro2.Object);
            }
        }

        public class Unregister
        {
            [Fact]
            public void Should_throw_ArgumentNullException_when_macro_is_null()
            {
                var ex = Record.Exception(() => Macros.Unregister(null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_when_macro_id_is_null()
            {
                var macro = new Mock<IMacro>();

                var ex = Record.Exception(() => Macros.Unregister(macro.Object)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_when_macro_id_is_null_by_type()
            {
                var ex = Record.Exception(() => Macros.Unregister<NullIdMacro>()) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentException_when_macro_id_is_empty()
            {
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns(string.Empty);

                var ex = Record.Exception(() => Macros.Unregister(macro.Object)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentException_when_macro_id_is_empty_by_type()
            {
                var ex = Record.Exception(() => Macros.Unregister<EmptyIdMacro>()) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("macro");
                ex.Message.ShouldStartWith("The macro identifier must not be null or empty.");
            }

            [Fact]
            public void Should_correctly_unregister_the_macro_by_object()
            {
                var macro = new Mock<IMacro>();
                macro.Setup(x => x.Id).Returns("foo");
                Macros.Register(macro.Object);

                Macros.Unregister(macro.Object);

                Macros.All.ShouldNotContain(macro.Object);
            }

            [Fact]
            public void Should_correctly_unregister_the_macro_by_type()
            {
                Macros.Register<ValidMacro>();

                Macros.Unregister<ValidMacro>();

                Macros.All.Select(m => m.GetType()).ShouldNotContain(typeof(ValidMacro));
            }
        }

        private class ValidMacro : IMacro
        {
            public string Id
            {
                get { return "foo"; }
            }

            public IList<MacroRule> Rules
            {
                get { throw new NotImplementedException(); }
            }
        }
    }
}