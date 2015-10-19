using System;
using Should;
using Xunit;
using CommonPlex.Parsing;

namespace CommonPlex.Tests.Parsing
{
    public class ScopeFacts
    {
        public class Constructor_Facts
        {
            [Fact]
            public void Should_set_the_name_and_index_and_length()
            {
                const string name = "The Scope Name";
                const int index = 435;
                const int length = 34;

                var scope = new Scope(name, index, length);

                scope.Name.ShouldEqual("The Scope Name");
                scope.Index.ShouldEqual(435);
                scope.Length.ShouldEqual(34);
            }

            [Fact]
            public void Should_throw_when_name_is_null()
            {
                const string name = null;
                const int index = 435;
                const int length = 34;

                var ex = Record.Exception(() => new Scope(name, index, length)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("name");
            }

            [Fact]
            public void Should_throw_when_name_is_empty()
            {
                string name = string.Empty;
                const int index = 435;
                const int length = 34;

                var ex = Record.Exception(() => new Scope(name, index, length)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("name");
            }

            [Fact]
            public void Should_throw_when_name_is_null_with_no_length()
            {
                const string name = null;
                const int index = 435;

                var ex = Record.Exception(() => new Scope(name, index)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("name");
            }

            [Fact]
            public void Should_throw_when_name_is_empty_with_no_length()
            {
                string name = string.Empty;
                const int index = 435;

                var ex = Record.Exception(() => new Scope(name, index)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("name");
            }

            [Fact]
            public void Should_correctly_set_the_name_index()
            {
                const string name = "The Scope Name";
                const int index = 435;
                
                var scope = new Scope(name, index);

                scope.Name.ShouldEqual(name);
                scope.Index.ShouldEqual(index);
                scope.Length.ShouldEqual(0);
            }
        }
    }
}