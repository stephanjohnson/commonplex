using Should;
using System;
using CommonPlex.Common;
using Xunit;

namespace CommonPlex.Tests
{
    public class UtilityFacts
    {
        public class The_IsDefinedOnEnum_Method
        {
            [Fact]
            public void Should_throw_ArgumentException_if_the_type_is_not_an_enumeration()
            {
                var ex = Record.Exception(() => Utility.IsDefinedOnEnum<int>("foo")) as ArgumentException;

                ex.ShouldNotBeNull();
            }

            [Fact]
            public void Should_return_false_if_string_is_not_defined()
            {
                string input = "Invalid";

                bool result = Utility.IsDefinedOnEnum<TestEnum>(input);

                result.ShouldBeFalse();
            }

            [Fact]
            public void Should_return_true_if_string_is_defined_matching_case()
            {
                string input = "Two";

                bool result = Utility.IsDefinedOnEnum<TestEnum>(input);

                result.ShouldBeTrue();
            }

            [Fact]
            public void Should_return_true_if_string_is_defined_not_matching_case()
            {
                string input = "two";

                bool result = Utility.IsDefinedOnEnum<TestEnum>(input);

                result.ShouldBeTrue();
            }
        }

        public class The_ExtractTextParts_Method
        {
            [Fact]
            public void Should_throw_ArgumentNullException_if_the_input_is_null()
            {
                var ex = Record.Exception(() => Utility.ExtractTextParts(null)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("input");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_the_input_is_empty()
            {
                var ex = Record.Exception(() => Utility.ExtractTextParts(string.Empty)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("input");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_the_input_contains_more_than_two_parts()
            {
                var ex = Record.Exception(() => Utility.ExtractTextParts("a|b|c")) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("input");
                ex.Message.ShouldContain("Invalid number of parts.");
            }

            [Fact]
            public void Should_return_the_text_part_with_only_text_when_it_has_no_friendly_text()
            {
                TextPart part = Utility.ExtractTextParts("a");

                part.ShouldNotBeNull();
                part.Text.ShouldEqual("a");
                part.FriendlyText.ShouldBeNull();
            }

            [Fact]
            public void Should_return_the_fully_loaded_text_part()
            {
                TextPart part = Utility.ExtractTextParts("a|b");

                part.ShouldNotBeNull();
                part.FriendlyText.ShouldEqual("a");
                part.Text.ShouldEqual("b");
            }

            [Fact]
            public void Should_trim_the_content_with_one_part()
            {
                TextPart part = Utility.ExtractTextParts(" a ");

                part.ShouldNotBeNull();
                part.Text.ShouldEqual("a");
            }

            [Fact]
            public void Should_trim_the_content_with_two_parts()
            {
                TextPart part = Utility.ExtractTextParts(" a | b ");

                part.ShouldNotBeNull();
                part.FriendlyText.ShouldEqual("a");
                part.Text.ShouldEqual("b");
            }
        }

        public class The_ExtractImageParts_Method
        {
            [Fact]
            public void Should_throw_ArgumentNullException_if_the_input_is_null()
            {
                var ex = Record.Exception(() => Utility.ExtractImageParts(null, ImagePartExtras.None)) as ArgumentNullException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("input");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_the_input_is_empty()
            {
                var ex = Record.Exception(() => Utility.ExtractImageParts(string.Empty, ImagePartExtras.None)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("input");
            }

            [Fact]
            public void Should_throw_ArgumentException_image_url_cannot_be_determined()
            {
                var ex = Record.Exception(() => Utility.ExtractImageParts("a|b", ImagePartExtras.None)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("input");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_the_input_contains_more_than_three_parts()
            {
                var ex = Record.Exception(() => Utility.ExtractImageParts("a|b|c|d", ImagePartExtras.ContainsLink | ImagePartExtras.ContainsText)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("input");
                ex.Message.ShouldContain("Invalid number of parts.");
            }

            [Fact]
            public void Should_return_the_part_with_only_image_url_when_it_has_no_friendly_text()
            {
                ImagePart part = Utility.ExtractImageParts("http://localhost", ImagePartExtras.None);

                part.ShouldNotBeNull();
                part.ImageUrl.ShouldEqual("http://localhost/");
                part.Text.ShouldBeNull();
                part.LinkUrl.ShouldBeNull();
            }

            [Fact]
            public void Should_return_the_part_with_only_image_url_when_it_has_no_friendly_text_with_height_width()
            {
                ImagePart part = Utility.ExtractImageParts("http://localhost,height=220,width=380", ImagePartExtras.None);

                part.ShouldNotBeNull();
                part.ImageUrl.ShouldEqual("http://localhost/");
                part.Text.ShouldBeNull();
                part.LinkUrl.ShouldBeNull();
                part.Dimensions.Height.ShouldEqual(new Unit(220));
                part.Dimensions.Width.ShouldEqual(new Unit(380));
            }

            [Fact]
            public void Should_return_the_fully_loaded_part()
            {
                ImagePart part = Utility.ExtractImageParts("a|http://localhost|c", ImagePartExtras.ContainsLink | ImagePartExtras.ContainsText);

                part.ShouldNotBeNull();
                part.Text.ShouldEqual("a");
                part.ImageUrl.ShouldEqual("http://localhost/");
                part.LinkUrl.ShouldEqual("c");
            }

            [Fact]
            public void Should_return_the_part_with_dimensions()
            {
                ImagePart part = Utility.ExtractImageParts("a|http://localhost,height=220,width=380", ImagePartExtras.ContainsText);

                part.ShouldNotBeNull();
                part.Text.ShouldEqual("a");
                part.ImageUrl.ShouldEqual("http://localhost/");
                part.Dimensions.Height.ShouldEqual(new Unit(220));
                part.Dimensions.Width.ShouldEqual(new Unit(380));
            }

            [Fact]
            public void Should_return_the_part_with_link()
            {
                ImagePart part = Utility.ExtractImageParts("http://localhost|b", ImagePartExtras.ContainsLink);

                part.ShouldNotBeNull();
                part.ImageUrl.ShouldEqual("http://localhost/");
                part.LinkUrl.ShouldEqual("b");
            }

            [Fact]
            public void Should_trim_the_content_with_one_part()
            {
                ImagePart part = Utility.ExtractImageParts(" http://localhost ", ImagePartExtras.None);

                part.ShouldNotBeNull();
                part.ImageUrl.ShouldEqual("http://localhost/");
            }

            [Fact]
            public void Should_trim_the_content_with_two_parts()
            {
                ImagePart part = Utility.ExtractImageParts(" a | http://localhost ", ImagePartExtras.ContainsText);

                part.ShouldNotBeNull();
                part.Text.ShouldEqual("a");
                part.ImageUrl.ShouldEqual("http://localhost/");
            }

            [Fact]
            public void Should_not_remove_url_parts_with_where_comma_does_not_denote_dimensions()
            {
                ImagePart part = Utility.ExtractImageParts("http://localhost/image,a,b.gif", ImagePartExtras.None);

                part.ShouldNotBeNull();
                part.ImageUrl.ShouldEqual("http://localhost/image,a,b.gif");
            }

            [Fact]
            public void Should_return_the_part_with_link_but_not_parse_url()
            {
                ImagePart part = Utility.ExtractImageParts("localhost|b", ImagePartExtras.ContainsLink, false);

                part.ShouldNotBeNull();
                part.ImageUrl.ShouldEqual("localhost");
                part.LinkUrl.ShouldEqual("b");
            }

            [Fact]
            public void Should_allow_images_hosted_on_codeplex()
            {
                ImagePart part = Utility.ExtractImageParts("http://codeplex.com/image.gif", ImagePartExtras.None);

                part.ShouldNotBeNull();
                part.ImageUrl.ShouldEqual("http://codeplex.com/image.gif");
            }

            [Fact]
            public void Should_throw_ArgumentException_if_ContainsData_but_only_one_parameter()
            {
                var ex = Record.Exception(() => Utility.ExtractImageParts("data:image/png;base64", ImagePartExtras.ContainsData, false)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("input");
                ex.Message.ShouldContain("Invalid number of parameters, cannot find image data.");
            }

            [Fact]
            public void Should_return_the_part_with_image_data()
            {
                ImagePart part = Utility.ExtractImageParts("data:image/png;base64,aabb==", ImagePartExtras.ContainsData);

                part.ShouldNotBeNull();
                part.ImageUrl.ShouldEqual("data:image/png;base64,aabb==");
            }
        }

        public class CountChars
        {
            [Fact]
            public void Should_return_0_for_null_input()
            {
                int result = Utility.CountChars('*', null);

                result.ShouldEqual(0);
            }

            [Fact]
            public void Should_return_correct_count_for_input()
            {
                int result = Utility.CountChars('*', "** a");

                result.ShouldEqual(2);
            }
        }

        private enum TestEnum
        {
            One,
            Two,
            Three
        }
    }
}