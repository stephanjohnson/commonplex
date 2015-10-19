using System;
using Should;
using CommonPlex.Common;
using Xunit;

namespace CommonPlex.Tests
{
    public class RenderExceptionFacts
    {
        public class ConvertAny
        {
            [Fact]
            public void Should_throw_RenderException_if_action_throws_an_exception()
            {
                var ex = Record.Exception(() => RenderException.ConvertAny<string>(() => { throw new ArgumentException(); })) as RenderException;

                ex.ShouldNotBeNull();
            }

            [Fact]
            public void Should_return_value_of_action()
            {
                var result = RenderException.ConvertAny(() => "abc");

                result.ShouldEqual("abc");
            }
        }
    }
}
