using Should;
using System;
using System.Collections.Generic;
using CommonPlex.Compilation;
using CommonPlex.Compilation.Macros;
using CommonPlex.Parsing;
using Xunit;

namespace CommonPlex.Tests
{
    public class ScopeAugmentersFacts
    {
        public class Constructor
        {
            [Fact]
            public void Should_contain_the_correct_scope_augmenters()
            {
                ScopeAugmenters.All.Count.ShouldEqual(3);
                ScopeAugmenters.All.FindByMacro<TableMacro>().ShouldBeType<TableScopeAugmenter>();
                ScopeAugmenters.All.FindByMacro<ListMacro>().ShouldBeType<ListScopeAugmenter>();
                ScopeAugmenters.All.FindByMacro<IndentationMacro>().ShouldBeType<IndentationScopeAugmenter>();
            }
        }

        private class FakeAugmenter : IScopeAugmenter
        {
            public IList<Scope> Augment(IMacro macro, IList<Scope> capturedScopes, string content)
            {
                throw new NotImplementedException();
            }
        }

        private class FakeMacro : IMacro
        {
            public string Id
            {
                get { return "Fake"; }
            }

            public IList<MacroRule> Rules
            {
                get { throw new NotImplementedException(); }
            }
        }

        public class FindByMacro
        {
            [Fact]
            public void Should_return_null_if_augmenter_not_found()
            {
                IDictionary<string, IScopeAugmenter> augmenters = new Dictionary<string, IScopeAugmenter>();
                IScopeAugmenter result = augmenters.FindByMacro<FakeMacro>();

                result.ShouldBeNull();
            }

            [Fact]
            public void Should_return_the_augmenter_for_a_macro()
            {
                var augmenter = new FakeAugmenter();
                var augmenters = new Dictionary<string, IScopeAugmenter> {{"Fake", augmenter}};

                IScopeAugmenter result = augmenters.FindByMacro<FakeMacro>();

                result.ShouldEqual(augmenter);
                ScopeAugmenters.Unregister<FakeMacro>();
            }

            [Fact]
            public void Should_throw_ArgumentNullException_if_macro_object_is_null()
            {
                var augmenters = new Dictionary<string, IScopeAugmenter>();
                Exception ex = Record.Exception(() => augmenters.FindByMacro<FakeMacro>(null));

                ex.ShouldBeType<ArgumentNullException>();
            }

            [Fact]
            public void Should_return_the_augmenter_for_a_macro_object()
            {
                var augmenter = new FakeAugmenter();
                var augmenters = new Dictionary<string, IScopeAugmenter> {{"Fake", augmenter}};

                IScopeAugmenter result = augmenters.FindByMacro(new FakeMacro());

                result.ShouldEqual(augmenter);
            }
        }

        public class Register
        {
            [Fact]
            public void Should_throw_ArgumentNullException_when_augmenter_is_null()
            {
                Exception ex = Record.Exception(() => ScopeAugmenters.Register<FakeMacro>(null));

                ex.ShouldBeType<ArgumentNullException>();
            }

            [Fact]
            public void Should_correctly_load_the_augmenter_by_object()
            {
                try
                {
                    var augmenter = new FakeAugmenter();

                    ScopeAugmenters.Register<FakeMacro>(augmenter);

                    ScopeAugmenters.All.Keys.ShouldContain("Fake");
                    ScopeAugmenters.All.Values.ShouldContain(augmenter);
                }
                finally
                {
                    ScopeAugmenters.Unregister<FakeMacro>();
                }
            }

            [Fact]
            public void Should_correctly_load_the_augmenter_by_type()
            {
                try
                {
                    ScopeAugmenters.Register<FakeMacro, FakeAugmenter>();

                    ScopeAugmenters.All.Keys.ShouldContain("Fake");
                    ScopeAugmenters.All["Fake"].ShouldBeType<FakeAugmenter>();
                }
                finally
                {
                    ScopeAugmenters.Unregister<FakeMacro>();
                }
            }

            [Fact]
            public void Should_correctly_replace_augmenter_with_same_macro_type()
            {
                try
                {
                    var augmenter = new FakeAugmenter();
                    ScopeAugmenters.Register<FakeMacro, FakeAugmenter>();

                    ScopeAugmenters.Register<FakeMacro>(augmenter);

                    ScopeAugmenters.All["Fake"].ShouldEqual(augmenter);
                }
                finally
                {
                    ScopeAugmenters.Unregister<FakeMacro>();
                }
            }

            [Fact]
            public void Should_correctly_load_multiple_augmenters()
            {
                try
                {
                    var augmenter1 = new FakeAugmenter();
                    var augmenter2 = new SecondFakeAugmenter();

                    ScopeAugmenters.Register<FakeMacro>(augmenter1);
                    ScopeAugmenters.Register<SecondFakeMacro>(augmenter2);

                    ScopeAugmenters.All["Fake"].ShouldEqual(augmenter1);
                    ScopeAugmenters.All["SecondFake"].ShouldEqual(augmenter2);
                }
                finally
                {
                    ScopeAugmenters.Unregister<FakeMacro>();
                    ScopeAugmenters.Unregister<SecondFakeMacro>();
                }
            }
        }

        private class SecondFakeAugmenter : IScopeAugmenter
        {
            public IList<Scope> Augment(IMacro macro, IList<Scope> capturedScopes, string content)
            {
                throw new NotImplementedException();
            }
        }

        private class SecondFakeMacro : IMacro
        {
            public string Id
            {
                get { return "SecondFake"; }
            }

            public IList<MacroRule> Rules
            {
                get { throw new NotImplementedException(); }
            }
        }

        public class Unregister
        {
            [Fact]
            public void Should_unregister_augmenter_by_macro_type_correctly()
            {
                try
                {
                    var augmenter1 = new FakeAugmenter();
                    var augmenter2 = new SecondFakeAugmenter();
                    ScopeAugmenters.Register<FakeMacro>(augmenter1);
                    ScopeAugmenters.Register<SecondFakeMacro>(augmenter2);

                    ScopeAugmenters.Unregister<FakeMacro>();

                    ScopeAugmenters.All.ContainsKey("Fake").ShouldBeFalse();
                    ScopeAugmenters.All["SecondFake"].ShouldEqual(augmenter2);
                }
                finally
                {
                    ScopeAugmenters.Unregister<SecondFakeMacro>();
                }
            }
        }
    }
}