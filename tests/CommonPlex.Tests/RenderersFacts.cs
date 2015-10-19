using Should;
using System;
using System.Linq;
using Moq;
using CommonPlex.Formatting.Renderers;
using Xunit;

namespace CommonPlex.Tests
{
    public class RenderersFacts
    {
        private class EmptyIdRenderer : IRenderer
        {
            public string Id
            {
                get { return string.Empty; }
            }

            public bool CanExpand(string scopeName)
            {
                throw new NotImplementedException();
            }

            public string Expand(string scopeName, string input, Func<string, string> htmlEncode, Func<string, string> attributeEncode)
            {
                throw new NotImplementedException();
            }
        }

        private class NullIdRenderer : IRenderer
        {
            public string Id
            {
                get { return null; }
            }

            public bool CanExpand(string scopeName)
            {
                throw new NotImplementedException();
            }

            public string Expand(string scopeName, string input, Func<string, string> htmlEncode, Func<string, string> attributeEncode)
            {
                throw new NotImplementedException();
            }
        }

        public class Register
        {
            [Fact]
            public void Should_throw_ArgumentNullException_when_renderer_is_null()
            {
                var ex = Record.Exception(() => Renderers.Register(null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderer");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_when_renderer_id_is_null()
            {
                var macro = new Mock<IRenderer>();

                var ex = Record.Exception(() => Renderers.Register(macro.Object)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderer");
                ex.Message.ShouldStartWith("The renderer identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_when_renderer_id_is_null_by_type()
            {
                var ex = Record.Exception(() => Renderers.Register<NullIdRenderer>()) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderer");
                ex.Message.ShouldStartWith("The renderer identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentException_when_renderer_id_is_empty()
            {
                var macro = new Mock<IRenderer>();
                macro.Setup(x => x.Id).Returns(string.Empty);

                var ex = Record.Exception(() => Renderers.Register(macro.Object)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderer");
                ex.Message.ShouldStartWith("The renderer identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentException_when_renderer_id_is_empty_by_type()
            {
                var ex = Record.Exception(() => Renderers.Register<EmptyIdRenderer>()) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderer");
                ex.Message.ShouldStartWith("The renderer identifier must not be null or empty.");
            }

            [Fact]
            public void Should_correctly_load_the_renderer_by_object()
            {
                var renderer = new Mock<IRenderer>();
                renderer.Setup(x => x.Id).Returns("foo");

                Renderers.Register(renderer.Object);

                Renderers.All.ShouldContain(renderer.Object);
                Renderers.Unregister(renderer.Object);
            }

            [Fact]
            public void Should_correctly_load_the_renderer_by_type()
            {
                Renderers.Register<ValidRenderer>();

                Renderers.All.Select(r => r.GetType()).ShouldContain(typeof(ValidRenderer));
                Renderers.Unregister<ValidRenderer>();
            }

            [Fact]
            public void Should_replace_an_existing_renderer_with_the_same_identifier()
            {
                var renderer1 = new Mock<IRenderer>();
                renderer1.Setup(x => x.Id).Returns("foo");
                var renderer2 = new Mock<IRenderer>();
                renderer2.Setup(x => x.Id).Returns("foo");

                Renderers.Register(renderer1.Object);
                Renderers.Register(renderer2.Object);

                Renderers.All.ShouldNotContain(renderer1.Object);
                Renderers.All.ShouldContain(renderer2.Object);
                Renderers.Unregister(renderer2.Object);
            }

            [Fact]
            public void Should_add_multiple_renderers_with_the_a_different_identifier()
            {
                var renderer1 = new Mock<IRenderer>();
                renderer1.Setup(x => x.Id).Returns("foo");
                var renderer2 = new Mock<IRenderer>();
                renderer2.Setup(x => x.Id).Returns("bar");

                Renderers.Register(renderer1.Object);
                Renderers.Register(renderer2.Object);

                Renderers.All.ShouldContain(renderer1.Object);
                Renderers.All.ShouldContain(renderer2.Object);
                Renderers.Unregister(renderer1.Object);
                Renderers.Unregister(renderer2.Object);
            }
        }

        public class Unregister
        {
            [Fact]
            public void Should_throw_ArgumentNullException_when_renderer_is_null()
            {
                var ex = Record.Exception(() => Renderers.Unregister(null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderer");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_when_renderer_id_is_null()
            {
                var renderer = new Mock<IRenderer>();

                var ex = Record.Exception(() => Renderers.Unregister(renderer.Object)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderer");
                ex.Message.ShouldStartWith("The renderer identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentNullException_when_renderer_id_is_null_by_type()
            {
                var ex = Record.Exception(() => Renderers.Unregister<NullIdRenderer>()) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderer");
                ex.Message.ShouldStartWith("The renderer identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentException_when_renderer_id_is_empty()
            {
                var renderer = new Mock<IRenderer>();
                renderer.Setup(x => x.Id).Returns(string.Empty);

                var ex = Record.Exception(() => Renderers.Unregister(renderer.Object)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderer");
                ex.Message.ShouldStartWith("The renderer identifier must not be null or empty.");
            }

            [Fact]
            public void Should_throw_ArgumentException_when_renderer_id_is_empty_by_type()
            {
                var ex = Record.Exception(() => Renderers.Unregister<EmptyIdRenderer>()) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("renderer");
                ex.Message.ShouldStartWith("The renderer identifier must not be null or empty.");
            }

            [Fact]
            public void Should_correctly_unregister_the_renderer_by_object()
            {
                var renderer = new Mock<IRenderer>();
                renderer.Setup(x => x.Id).Returns("foo");
                Renderers.Register(renderer.Object);

                Renderers.Unregister(renderer.Object);

                Renderers.All.ShouldNotContain(renderer.Object);
            }

            [Fact]
            public void Should_correctly_unregister_the_renderer_by_type()
            {
                Renderers.Register<ValidRenderer>();

                Renderers.Unregister<ValidRenderer>();

                Renderers.All.Select(r => r.GetType()).ShouldNotContain(typeof(ValidRenderer));
            }
        }

        private class ValidRenderer : IRenderer
        {
            public string Id
            {
                get { return "foo"; }
            }

            public bool CanExpand(string scopeName)
            {
                throw new NotImplementedException();
            }

            public string Expand(string scopeName, string input, Func<string, string> htmlEncode, Func<string, string> attributeEncode)
            {
                throw new NotImplementedException();
            }
        }
    }
}