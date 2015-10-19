using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Should;
using Xunit;
using CommonPlex.Compilation;

namespace CommonPlex.Tests.Compilation
{
    public class CompiledMacroFacts
    {
        [Fact]
        public void Should_throw_ArgumentNullException_when_identifier_is_null()
        {
            var regex = new Regex("foo");
            var captures = new List<string> {"foo"};

            var ex = Record.Exception(() => new CompiledMacro(null, regex, captures)) as ArgumentNullException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("id");
        }

        [Fact]
        public void Should_throw_ArgumentException_when_identifier_is_empty()
        {
            var regex = new Regex("foo");
            var captures = new List<string> {"foo"};

            var ex = Record.Exception(() => new CompiledMacro(string.Empty, regex, captures)) as ArgumentException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("id");
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_regex_is_null()
        {
            const string id = "foo";
            var captures = new List<string> {"foo"};

            var ex = Record.Exception(() => new CompiledMacro(id, null, captures)) as ArgumentNullException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("regex");
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_captures_is_null()
        {
            const string id = "foo";
            var regex = new Regex("foo");

            var ex = Record.Exception(() => new CompiledMacro(id, regex, null)) as ArgumentNullException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("captures");
        }

        [Fact]
        public void Should_throw_ArgumentException_when_captures_is_empty()
        {
            const string id = "foo";
            var regex = new Regex("foo");
            var captures = new List<string>();

            var ex = Record.Exception(() => new CompiledMacro(id, regex, captures)) as ArgumentException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("captures");
        }

        [Fact]
        public void Should_properly_set_all_properties()
        {
            const string id = "foo";
            var regex = new Regex("foo");
            var captures = new List<string> {"foo"};

            var compiledMacro = new CompiledMacro(id, regex, captures);

            compiledMacro.Id.ShouldEqual(id);
            compiledMacro.Regex.ShouldEqual(regex);
            compiledMacro.Captures.ShouldEqual(captures);
        }
    }
}