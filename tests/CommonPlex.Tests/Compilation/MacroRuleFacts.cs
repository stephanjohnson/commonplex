using System;
using System.Collections.Generic;
using Should;
using CommonPlex.Compilation;
using Xunit;

namespace CommonPlex.Tests.Compilation
{
    public class MacroRuleFacts
    {
        [Fact]
        public void Should_throw_ArgumentNullException_when_regex_is_null()
        {
            var captures = new Dictionary<int, string> {{0, "foo"}};

            var ex = Record.Exception(() => new MacroRule(null, captures)) as ArgumentNullException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("regex");
        }

        [Fact]
        public void Should_throw_ArgumentException_when_regex_is_empty()
        {
            var captures = new Dictionary<int, string> {{0, "foo"}};

            var ex = Record.Exception(() => new MacroRule(string.Empty, captures)) as ArgumentException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("regex");
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_captures_is_null()
        {
            const string regex = "foo";

            var ex = Record.Exception(() => new MacroRule(regex, (IDictionary<int, string>) null)) as ArgumentException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("captures");
        }

        [Fact]
        public void Should_properly_set_regex_and_captures()
        {
            const string regex = "foo";
            var captures = new Dictionary<int, string> {{0, "foo"}};

            var rule = new MacroRule(regex, captures);

            rule.Regex.ShouldEqual(regex);
            rule.Captures.ShouldEqual(captures);
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_only_setting_regex_and_is_null()
        {
            var ex = Record.Exception(() => new MacroRule(null)) as ArgumentNullException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("regex");
        }

        [Fact]
        public void Should_throw_ArgumentException_when_only_setting_regex_and_is_empty()
        {
            var ex = Record.Exception(() => new MacroRule(string.Empty)) as ArgumentException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("regex");
        }

        [Fact]
        public void Should_correctly_set_regex_when_only_setting_regex()
        {
            const string regex = "foo";

            var rule = new MacroRule(regex);

            rule.Regex.ShouldEqual(regex);
            rule.Captures.ShouldBeEmpty();
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_setting_first_scope_and_regex_is_null()
        {
            var ex = Record.Exception(() => new MacroRule(null, "capture")) as ArgumentNullException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("regex");
        }

        [Fact]
        public void Should_throw_ArgumentException_when_setting_first_scope_and_regex_is_empty()
        {
            var ex = Record.Exception(() => new MacroRule(string.Empty, "capture")) as ArgumentException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("regex");
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_setting_first_scope_and_is_null()
        {
            const string regex = "foo";

            var ex = Record.Exception(() => new MacroRule(regex, (string) null)) as ArgumentNullException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("firstScopeCapture");
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_setting_first_scope_and_is_empty()
        {
            const string regex = "foo";

            var ex = Record.Exception(() => new MacroRule(regex, string.Empty)) as ArgumentException;

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("firstScopeCapture");
        }

        [Fact]
        public void Should_correctly_set_regex_and_first_scope_capture()
        {
            const string regex = "foo";

            var rule = new MacroRule(regex, "scope");

            rule.Regex.ShouldEqual(regex);
            rule.Captures.Count.ShouldEqual(1);
            rule.Captures[1].ShouldEqual("scope");
        }
    }
}