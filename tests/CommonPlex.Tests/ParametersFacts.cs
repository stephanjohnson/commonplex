using Should;
using System;
using CommonPlex.Common;
using Xunit;
using Xunit.Extensions;

namespace CommonPlex.Tests
{
    public class ParametersFacts
    {
        public class ExtractUrl
        {
            [Fact]
            public void Should_throw_ArgumentException_if_url_is_not_found()
            {
                var ex = Record.Exception(() => Parameters.ExtractUrl(new[] { "foo=bar" })) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("url");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_url_is_empty()
            {
                var ex = Record.Exception(() => Parameters.ExtractUrl(new[] { "url=" })) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("url");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_url_is_not_valid()
            {
                var ex = Record.Exception(() => Parameters.ExtractUrl(new[] { "url=blah" })) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("url");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_url_contains_codeplex()
            {
                var ex = Record.Exception(() => Parameters.ExtractUrl(new[] { "url=http://www.codeplex.com" })) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("url");
            }

            [Fact]
            public void Should_return_url_if_valid()
            {
                string url = Parameters.ExtractUrl(new[] {"url=http://www.foo.com"});

                url.ShouldEqual("http://www.foo.com/");
            }

            [Fact]
            public void Should_not_throw_ArgumentException_if_url_contains_codeplex_but_validateDomain_is_false()
            {
                var ex = Record.Exception(() => Parameters.ExtractUrl(new[] { "url=http://www.codeplex.com" }, false));

                ex.ShouldBeNull();
            }

            [Fact]
            public void Should_combine_parameters_without_key()
            {
                string url = Parameters.ExtractUrl(new[] {"url=http://www.foo.com/image", "a", "b.gif"});

                url.ShouldEqual("http://www.foo.com/image,a,b.gif");
            }

            [Fact]
            public void Should_combine_parameters_without_key_including_valid_ones()
            {
                string url = Parameters.ExtractUrl(new[] { "width=985", "url=http://www.foo.com/image", "a", "b.gif", "height=400" });

                url.ShouldEqual("http://www.foo.com/image,a,b.gif");
            }
        }

        public class ExtractAlign
        {
            [Fact]
            public void Should_return_default_if_align_is_not_found()
            {
                HorizontalAlign align = Parameters.ExtractAlign(new string[0], HorizontalAlign.Center);

                align.ShouldEqual(HorizontalAlign.Center);
            }

            [Fact]
            public void Should_return_default_if_align_is_empty()
            {
                HorizontalAlign align = Parameters.ExtractAlign(new[] {"align="}, HorizontalAlign.Center);

                align.ShouldEqual(HorizontalAlign.Center);
            }

            [Fact]
            public void Should_throw_ArgumentException_if_align_is_not_defined_on_enum()
            {
                var ex = Record.Exception(() => Parameters.ExtractAlign(new[] {"align=foo"}, HorizontalAlign.Center)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("align");
            }

            [Fact]
            public void Should_return_align_if_valid()
            {
                HorizontalAlign align = Parameters.ExtractAlign(new[] {"align=right"}, HorizontalAlign.Center);

                align.ShouldEqual(HorizontalAlign.Right);
            }

            [Theory]
            [InlineData("justify")]
            [InlineData("notset")]
            public void Should_throw_ArgumentException_if_align_is_invalid_value(string align)
            {
                var ex = Record.Exception(() => Parameters.ExtractAlign(new[] { "align=" + align }, HorizontalAlign.Center)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("align");
            }
        }

        public class ExtractDimensions
        {
            [Fact]
            public void Should_return_null_values_if_not_found()
            {
                Dimensions dimensions = Parameters.ExtractDimensions(new[] {"foo=bar"});

                dimensions.Height.ShouldBeNull();
                dimensions.Width.ShouldBeNull();
            }

            [Fact]
            public void Should_return_defaults_if_not_found()
            {
                Dimensions dimensions = Parameters.ExtractDimensions(new[] {"foo=bar"}, 200, 300);

                dimensions.Height.ShouldEqual(200);
                dimensions.Width.ShouldEqual(300);
            }

            [Fact]
            public void Should_return_defaults_if_empty()
            {
                Dimensions dimensions = Parameters.ExtractDimensions(new[] { "height=", "width=" }, 200, 300);

                dimensions.Height.ShouldEqual(200);
                dimensions.Width.ShouldEqual(300);
            }

            [Fact]
            public void Should_return_correct_height_and_width_as_pixels()
            {
                Dimensions dimensions = Parameters.ExtractDimensions(new[] {"height=300", "width=400"}, 200, 200);

                dimensions.Height.ToString().ShouldEqual("300px");
                dimensions.Width.ToString().ShouldEqual("400px");
            }

            [Fact]
            public void Should_return_correct_height_and_width_as_percent()
            {
                Dimensions dimensions = Parameters.ExtractDimensions(new[] {"height=50%", "width=75%"}, 200, 200);

                dimensions.Height.ToString().ShouldEqual("50%");
                dimensions.Width.ToString().ShouldEqual("75%");
            }

            [Theory]
            [InlineData("height")]
            [InlineData("width")]
            public void Should_throw_ArgumentException_if_invalid(string paramName)
            {
                var ex = Record.Exception(() => Parameters.ExtractDimensions(new[] {paramName + "=abc"}, 200, 200)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual(paramName);
            }

            [Theory]
            [InlineData("height")]
            [InlineData("width")]
            public void Should_throw_ArgumentException_if_negative(string paramName)
            {
                var ex = Record.Exception(() => Parameters.ExtractDimensions(new[] {paramName + "=-10"}, 200, 200)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual(paramName);
            }

            [Theory]
            [InlineData("height")]
            [InlineData("width")]
            public void Should_throw_ArgumentException_if_zero(string paramName)
            {
                var ex = Record.Exception(() => Parameters.ExtractDimensions(new[] { paramName + "=0" }, 200, 200)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual(paramName);
            }
        }

        public class ExtractBool
        {
            [Fact]
            public void Should_return_default_if_parameter_is_not_found()
            {
                bool value = Parameters.ExtractBool(new[] {"foo=bar"}, "test", true);

                value.ShouldBeTrue();
            }

            [Fact]
            public void Should_return_default_if_parameter_is_empty()
            {
                bool value = Parameters.ExtractBool(new[] {"test="}, "test", true);

                value.ShouldBeTrue();
            }

            [Fact]
            public void Should_throw_ArgumentException_if_value_is_not_a_boolean()
            {
                var ex = Record.Exception(() => Parameters.ExtractBool(new[] {"test=bar"}, "test", true)) as ArgumentException;

                ex.ShouldNotBeNull();
            }

            [Fact]
            public void Should_return_correct_value()
            {
                bool value = Parameters.ExtractBool(new[] {"test=true"}, "test", false);

                value.ShouldBeTrue();
            }
        }
    }
}