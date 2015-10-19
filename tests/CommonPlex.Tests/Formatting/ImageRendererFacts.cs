using System;
using Should;
using CommonPlex.Formatting.Renderers;
using Xunit;
using Xunit.Extensions;

namespace CommonPlex.Tests.Formatting
{
    public class ImageRendererFacts
    {
        public class CanExpand
        {
            [Theory]
            [InlineData(ScopeName.ImageWithLinkNoAltLeftAlign)]
            [InlineData(ScopeName.ImageWithLinkNoAltRightAlign)]
            [InlineData(ScopeName.ImageWithLinkNoAlt)]
            [InlineData(ScopeName.ImageWithLinkWithAltLeftAlign)]
            [InlineData(ScopeName.ImageWithLinkWithAltRightAlign)]
            [InlineData(ScopeName.ImageWithLinkWithAlt)]
            [InlineData(ScopeName.ImageLeftAlign)]
            [InlineData(ScopeName.ImageRightAlign)]
            [InlineData(ScopeName.ImageNoAlign)]
            [InlineData(ScopeName.ImageLeftAlignWithAlt)]
            [InlineData(ScopeName.ImageRightAlignWithAlt)]
            [InlineData(ScopeName.ImageNoAlignWithAlt)]
            [InlineData(ScopeName.ImageDataWithLinkNoAltLeftAlign)]
            [InlineData(ScopeName.ImageDataWithLinkNoAltRightAlign)]
            [InlineData(ScopeName.ImageDataWithLinkNoAlt)]
            [InlineData(ScopeName.ImageDataWithLinkWithAltLeftAlign)]
            [InlineData(ScopeName.ImageDataWithLinkWithAltRightAlign)]
            [InlineData(ScopeName.ImageDataWithLinkWithAlt)]
            [InlineData(ScopeName.ImageDataLeftAlign)]
            [InlineData(ScopeName.ImageDataRightAlign)]
            [InlineData(ScopeName.ImageDataNoAlign)]
            [InlineData(ScopeName.ImageDataLeftAlignWithAlt)]
            [InlineData(ScopeName.ImageDataRightAlignWithAlt)]
            [InlineData(ScopeName.ImageDataNoAlignWithAlt)]
            public void Should_be_able_to_resolve_scope_name(string scopeName)
            {
                var renderer = new ImageRenderer();

                bool result = renderer.CanExpand(scopeName);

                result.ShouldBeTrue();
            }
        }

        public class Expand
        {
            [Fact]
            public void Should_render_the_image_tag_with_left_alignment_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageLeftAlign, "http://localhost/image.gif", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"http://localhost/image.gif\" />");
            }

            [Fact]
            public void Should_render_the_image_data_tag_with_left_alignment_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataLeftAlign, "data:image/png;base64,aabb==", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"data:image/png;base64,aabb==\" />");
            }

            [Fact]
            public void Should_render_the_image_tag_with_right_alignment_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageRightAlign, "http://localhost/image.gif", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:right;padding-left:.5em;\" src=\"http://localhost/image.gif\" />");
            }

            [Fact]
            public void Should_render_the_image_data_tag_with_right_alignment_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataRightAlign, "data:image/png;base64,aabb==", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:right;padding-left:.5em;\" src=\"data:image/png;base64,aabb==\" />");
            }

            [Fact]
            public void Should_render_the_image_tag_with_no_alignment_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageNoAlign, "http://localhost/image.gif", x => x, x => x);

                result.ShouldEqual("<img src=\"http://localhost/image.gif\" />");
            }

            [Fact]
            public void Should_render_the_image_data_tag_with_no_alignment_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataNoAlign, "data:image/png;base64,aabb==", x => x, x => x);

                result.ShouldEqual("<img src=\"data:image/png;base64,aabb==\" />");
            }

            [Fact]
            public void Should_render_the_image_tag_with_left_alignment_and_alt_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageLeftAlignWithAlt, "Friendly|http://localhost/image.gif", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"http://localhost/image.gif\" alt=\"Friendly\" title=\"Friendly\" />");
            }

            [Fact]
            public void Should_render_the_image_data_tag_with_left_alignment_and_alt_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataLeftAlignWithAlt, "Friendly|data:image/png;base64,aabb==", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"data:image/png;base64,aabb==\" alt=\"Friendly\" title=\"Friendly\" />");
            }

            [Fact]
            public void Should_render_the_image_tag_with_right_alignment_and_alt_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageRightAlignWithAlt, "Friendly|http://localhost/image.gif", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:right;padding-left:.5em;\" src=\"http://localhost/image.gif\" alt=\"Friendly\" title=\"Friendly\" />");
            }

            [Fact]
            public void Should_render_the_image_data_tag_with_right_alignment_and_alt_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataRightAlignWithAlt, "Friendly|data:image/png;base64,aabb==", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:right;padding-left:.5em;\" src=\"data:image/png;base64,aabb==\" alt=\"Friendly\" title=\"Friendly\" />");
            }

            [Fact]
            public void Should_render_the_image_tag_with_no_alignment_and_alt_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageNoAlignWithAlt, "Friendly|http://localhost/image.gif", x => x, x => x);

                result.ShouldEqual("<img src=\"http://localhost/image.gif\" alt=\"Friendly\" title=\"Friendly\" />");
            }

            [Fact]
            public void Should_render_the_image_data_tag_with_no_alignment_and_alt_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataNoAlignWithAlt, "Friendly|data:image/png;base64,aabb==", x => x, x => x);

                result.ShouldEqual("<img src=\"data:image/png;base64,aabb==\" alt=\"Friendly\" title=\"Friendly\" />");
            }

            [Fact]
            public void Should_render_the_image_right_align_with_alt_scope_and_attribute_encode_the_source_and_alt()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageRightAlignWithAlt, "MyImage|http://localhost/image.gif", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:right;padding-left:.5em;\" src=\"safe!\" alt=\"safe!\" title=\"safe!\" />");
            }

            [Fact]
            public void Should_render_the_image_data_right_align_with_alt_scope_and_attribute_encode_the_source_and_alt()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataRightAlignWithAlt, "MyImage|data:image/png;base64,aabb==", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:right;padding-left:.5em;\" src=\"safe!\" alt=\"safe!\" title=\"safe!\" />");
            }

            [Fact]
            public void Should_render_the_image_left_align_with_alt_scope_and_attribute_encode_the_source_and_alt()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageLeftAlignWithAlt, "MyImage|http://localhost/image.gif", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"safe!\" alt=\"safe!\" title=\"safe!\" />");
            }

            [Fact]
            public void Should_render_the_image_data_left_align_with_alt_scope_and_attribute_encode_the_source_and_alt()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataLeftAlignWithAlt, "MyImage|data:image/png;base64,aabb==", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"safe!\" alt=\"safe!\" title=\"safe!\" />");
            }

            [Fact]
            public void Should_render_the_image_with_alt_scope_and_attribute_encode_the_source_and_alt()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageNoAlignWithAlt, "MyImage|http://localhost/image.gif", x => x, x => "safe!");

                result.ShouldEqual("<img src=\"safe!\" alt=\"safe!\" title=\"safe!\" />");
            }

            [Fact]
            public void Should_render_the_image_data_with_alt_scope_and_attribute_encode_the_source_and_alt()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataNoAlignWithAlt, "MyImage|data:image/png;base64,aabb==", x => x, x => "safe!");

                result.ShouldEqual("<img src=\"safe!\" alt=\"safe!\" title=\"safe!\" />");
            }

            [Fact]
            public void Should_render_macro_with_more_than_two_parts_without_link_indication_right_align()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageRightAlignWithAlt, "MyImage|http://localhost/image.gif|foo", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:right;padding-left:.5em;\" src=\"http://localhost/image.gif\" alt=\"MyImage\" title=\"MyImage\" />");
            }

            [Fact]
            public void Should_render_macro_with_more_than_two_parts_without_link_indication_right_align_with_data()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataRightAlignWithAlt, "MyImage|data:image/png;base64,aabb==|foo", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:right;padding-left:.5em;\" src=\"data:image/png;base64,aabb==\" alt=\"MyImage\" title=\"MyImage\" />");
            }

            [Fact]
            public void Should_render_macro_with_more_than_two_parts_without_link_indication_left_align()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageLeftAlignWithAlt, "MyImage|http://localhost/image.gif|foo", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"http://localhost/image.gif\" alt=\"MyImage\" title=\"MyImage\" />");
            }

            [Fact]
            public void Should_render_macro_with_more_than_two_parts_without_link_indication_left_align_with_data()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataLeftAlignWithAlt, "MyImage|data:image/png;base64,aabb==|foo", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"data:image/png;base64,aabb==\" alt=\"MyImage\" title=\"MyImage\" />");
            }

            [Fact]
            public void Should_render_macro_with_more_than_two_parts_without_link_indication()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageNoAlignWithAlt, "MyImage|http://localhost/image.gif|foo", x => x, x => x);

                result.ShouldEqual("<img src=\"http://localhost/image.gif\" alt=\"MyImage\" title=\"MyImage\" />");
            }

            [Fact]
            public void Should_render_macro_with_more_than_two_parts_without_link_indication_with_data()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataNoAlignWithAlt, "MyImage|data:image/png;base64,aabb==|foo", x => x, x => x);

                result.ShouldEqual("<img src=\"data:image/png;base64,aabb==\" alt=\"MyImage\" title=\"MyImage\" />");
            }

            [Fact]
            public void Should_render_the_image_with_link_no_alt_scope_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkNoAlt, "http://localhost/image.gif|http://localhost", x => x, x => x);

                result.ShouldEqual("<a href=\"http://localhost\"><img style=\"border:none;\" src=\"http://localhost/image.gif\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_no_alt_scope_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkNoAlt, "data:image/png;base64,aabb==|http://localhost", x => x, x => x);

                result.ShouldEqual("<a href=\"http://localhost\"><img style=\"border:none;\" src=\"data:image/png;base64,aabb==\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_link_no_alt_scope_and_attribute_encode_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkNoAlt, "http://localhost/image.gif|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<a href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_no_alt_scope_and_attribute_encode_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkNoAlt, "data:image/png;base64,aabb==|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<a href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_link_no_alt_left_aligned_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkNoAltLeftAlign, "http://localhost/image.gif|http://localhost", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"http://localhost\"><img style=\"border:none;\" src=\"http://localhost/image.gif\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_no_alt_left_aligned_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkNoAltLeftAlign, "data:image/png;base64,aabb==|http://localhost", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"http://localhost\"><img style=\"border:none;\" src=\"data:image/png;base64,aabb==\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_link_no_alt_left_aligned_and_attribute_encode_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkNoAltLeftAlign, "http://localhost/image.gif|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_no_alt_left_aligned_and_attribute_encode_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkNoAltLeftAlign, "data:image/png;base64,aabb==|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_link_no_alt_right_aligned_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkNoAltRightAlign, "http://localhost/image.gif|http://localhost", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:right;padding-left:.5em;\" href=\"http://localhost\"><img style=\"border:none;\" src=\"http://localhost/image.gif\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_no_alt_right_aligned_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkNoAltRightAlign, "data:image/png;base64,aabb==|http://localhost", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:right;padding-left:.5em;\" href=\"http://localhost\"><img style=\"border:none;\" src=\"data:image/png;base64,aabb==\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_link_no_alt_right_aligned_and_attribute_encode_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkNoAltRightAlign, "http://localhost/image.gif|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:right;padding-left:.5em;\" href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_no_alt_right_aligned_and_attribute_encode_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkNoAltRightAlign, "data:image/png;base64,aabb==|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:right;padding-left:.5em;\" href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_link_with_alt_scope_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkWithAlt, "Friendly|http://localhost/image.gif|http://localhost", x => x, x => x);

                result.ShouldEqual("<a href=\"http://localhost\"><img style=\"border:none;\" src=\"http://localhost/image.gif\" alt=\"Friendly\" title=\"Friendly\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_with_alt_scope_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkWithAlt, "Friendly|data:image/png;base64,aabb==|http://localhost", x => x, x => x);

                result.ShouldEqual("<a href=\"http://localhost\"><img style=\"border:none;\" src=\"data:image/png;base64,aabb==\" alt=\"Friendly\" title=\"Friendly\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_link_with_alt_scope_and_attribute_encode_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkWithAlt, "Friendly|http://localhost/image.gif|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<a href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" alt=\"safe!\" title=\"safe!\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_with_alt_scope_and_attribute_encode_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkWithAlt, "Friendly|data:image/png;base64,aabb==|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<a href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" alt=\"safe!\" title=\"safe!\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_link_with_alt_left_aligned_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkWithAltLeftAlign, "Friendly|http://localhost/image.gif|http://localhost", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"http://localhost\"><img style=\"border:none;\" src=\"http://localhost/image.gif\" alt=\"Friendly\" title=\"Friendly\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_with_alt_left_aligned_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkWithAltLeftAlign, "Friendly|data:image/png;base64,aabb==|http://localhost", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"http://localhost\"><img style=\"border:none;\" src=\"data:image/png;base64,aabb==\" alt=\"Friendly\" title=\"Friendly\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_link_with_alt_left_aligned_and_attribute_encode_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkWithAltLeftAlign, "Friendly|http://localhost/image.gif|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" alt=\"safe!\" title=\"safe!\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_with_alt_left_aligned_and_attribute_encode_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkWithAltLeftAlign, "Friendly|data:image/png;base64,aabb==|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" alt=\"safe!\" title=\"safe!\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_link_with_alt_right_aligned_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkWithAltRightAlign, "Friendly|http://localhost/image.gif|http://localhost", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:right;padding-left:.5em;\" href=\"http://localhost\"><img style=\"border:none;\" src=\"http://localhost/image.gif\" alt=\"Friendly\" title=\"Friendly\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_with_alt_right_aligned_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkWithAltRightAlign, "Friendly|data:image/png;base64,aabb==|http://localhost", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:right;padding-left:.5em;\" href=\"http://localhost\"><img style=\"border:none;\" src=\"data:image/png;base64,aabb==\" alt=\"Friendly\" title=\"Friendly\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_link_with_alt_right_aligned_and_attribute_encoded_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkWithAltRightAlign, "Friendly|http://localhost/image.gif|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:right;padding-left:.5em;\" href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" alt=\"safe!\" title=\"safe!\" /></a>");
            }

            [Fact]
            public void Should_render_the_image_with_data_with_link_with_alt_right_aligned_and_attribute_encoded_correctly()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkWithAltRightAlign, "Friendly|data:image/png;base64,aabb==|http://localhost", x => x, x => "safe!");

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:right;padding-left:.5em;\" href=\"safe!\"><img style=\"border:none;\" src=\"safe!\" alt=\"safe!\" title=\"safe!\" /></a>");
            }

            [Theory]
            [InlineData(ScopeName.ImageWithLinkWithAlt)]
            [InlineData(ScopeName.ImageWithLinkWithAltLeftAlign)]
            [InlineData(ScopeName.ImageWithLinkWithAltRightAlign)]
            [InlineData(ScopeName.ImageDataWithLinkWithAlt)]
            [InlineData(ScopeName.ImageDataWithLinkWithAltLeftAlign)]
            [InlineData(ScopeName.ImageDataWithLinkWithAltRightAlign)]
            public void Should_render_an_unresolved_macro_when_more_than_three_parts_exist(string scopeName)
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(scopeName, "a|b|c|d", x => x, x => x);

                result.ShouldEqual("<span class=\"unresolved\">Cannot resolve image macro, invalid number of parameters.</span>");
            }

            [Fact]
            public void Should_throw_ArgumentException_for_invalid_scope_name()
            {
                var renderer = new ImageRenderer();

                var ex = Record.Exception(() => renderer.Expand("foo", "in", x => x, x => x)) as ArgumentException;

                ex.ShouldNotBeNull();
                ex.ParamName.ShouldEqual("scopeName");
            }

            [Fact]
            public void Should_render_no_link_with_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageNoAlign, "http://localhost/image.gif,height=220,width=380", x => x, x => x);

                result.ShouldEqual("<img src=\"http://localhost/image.gif\" height=\"220px\" width=\"380px\" />");
            }

            [Fact]
            public void Should_render_no_link_with_alignment_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageLeftAlign, "http://localhost/image.gif,height=220,width=380", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"http://localhost/image.gif\" height=\"220px\" width=\"380px\" />");
            }

            [Fact]
            public void Should_render_no_link_with_alt_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageNoAlignWithAlt, "Friendly|http://localhost/image.gif,height=220,width=380", x => x, x => x);

                result.ShouldEqual("<img src=\"http://localhost/image.gif\" alt=\"Friendly\" title=\"Friendly\" height=\"220px\" width=\"380px\" />");
            }

            [Fact]
            public void Should_render_no_link_with_alt_alignment_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageLeftAlignWithAlt, "Friendly|http://localhost/image.gif,height=220,width=380", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"http://localhost/image.gif\" alt=\"Friendly\" title=\"Friendly\" height=\"220px\" width=\"380px\" />");
            }

            [Fact]
            public void Should_render_with_link_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkNoAlt, "http://localhost/image.gif,height=220,width=380|http://link", x => x, x => x);

                result.ShouldEqual("<a href=\"http://link\"><img style=\"border:none;\" src=\"http://localhost/image.gif\" height=\"220px\" width=\"380px\" /></a>");
            }

            [Fact]
            public void Should_render_with_link_alignment_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkNoAltLeftAlign, "http://localhost/image.gif,height=220,width=380|http://link", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"http://link\"><img style=\"border:none;\" src=\"http://localhost/image.gif\" height=\"220px\" width=\"380px\" /></a>");
            }

            [Fact]
            public void Should_render_with_link_alt_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkWithAlt, "Friendly|http://localhost/image.gif,height=220,width=380|http://link", x => x, x => x);

                result.ShouldEqual("<a href=\"http://link\"><img style=\"border:none;\" src=\"http://localhost/image.gif\" alt=\"Friendly\" title=\"Friendly\" height=\"220px\" width=\"380px\" /></a>");
            }

            [Fact]
            public void Should_render_with_link_alt_alignment_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageWithLinkWithAltLeftAlign, "Friendly|http://localhost/image.gif,height=220,width=380|http://link", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"http://link\"><img style=\"border:none;\" src=\"http://localhost/image.gif\" alt=\"Friendly\" title=\"Friendly\" height=\"220px\" width=\"380px\" /></a>");
            }

            [Fact]
            public void Should_render_no_link_with_data_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataNoAlign, "data:image/png;base64,aabb==,height=220,width=380", x => x, x => x);

                result.ShouldEqual("<img src=\"data:image/png;base64,aabb==\" height=\"220px\" width=\"380px\" />");
            }

            [Fact]
            public void Should_render_no_link_with_data_alignment_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataLeftAlign, "data:image/png;base64,aabb==,height=220,width=380", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"data:image/png;base64,aabb==\" height=\"220px\" width=\"380px\" />");
            }

            [Fact]
            public void Should_render_no_link_with_data_alt_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataNoAlignWithAlt, "Friendly|data:image/png;base64,aabb==,height=220,width=380", x => x, x => x);

                result.ShouldEqual("<img src=\"data:image/png;base64,aabb==\" alt=\"Friendly\" title=\"Friendly\" height=\"220px\" width=\"380px\" />");
            }

            [Fact]
            public void Should_render_no_link_with_data_alt_alignment_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataLeftAlignWithAlt, "Friendly|data:image/png;base64,aabb==,height=220,width=380", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><img style=\"float:left;padding-right:.5em;\" src=\"data:image/png;base64,aabb==\" alt=\"Friendly\" title=\"Friendly\" height=\"220px\" width=\"380px\" />");
            }

            [Fact]
            public void Should_render_with_data_link_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkNoAlt, "data:image/png;base64,aabb==,height=220,width=380|http://link", x => x, x => x);

                result.ShouldEqual("<a href=\"http://link\"><img style=\"border:none;\" src=\"data:image/png;base64,aabb==\" height=\"220px\" width=\"380px\" /></a>");
            }

            [Fact]
            public void Should_render_with_data_link_alignment_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkNoAltLeftAlign, "data:image/png;base64,aabb==,height=220,width=380|http://link", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"http://link\"><img style=\"border:none;\" src=\"data:image/png;base64,aabb==\" height=\"220px\" width=\"380px\" /></a>");
            }

            [Fact]
            public void Should_render_with_data_link_alt_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkWithAlt, "Friendly|data:image/png;base64,aabb==,height=220,width=380|http://link", x => x, x => x);

                result.ShouldEqual("<a href=\"http://link\"><img style=\"border:none;\" src=\"data:image/png;base64,aabb==\" alt=\"Friendly\" title=\"Friendly\" height=\"220px\" width=\"380px\" /></a>");
            }

            [Fact]
            public void Should_render_with_data_link_alt_alignment_height_width()
            {
                var renderer = new ImageRenderer();

                string result = renderer.Expand(ScopeName.ImageDataWithLinkWithAltLeftAlign, "Friendly|data:image/png;base64,aabb==,height=220,width=380|http://link", x => x, x => x);

                result.ShouldEqual("<div style=\"clear:both;height:0;\">&nbsp;</div><a style=\"float:left;padding-right:.5em;\" href=\"http://link\"><img style=\"border:none;\" src=\"data:image/png;base64,aabb==\" alt=\"Friendly\" title=\"Friendly\" height=\"220px\" width=\"380px\" /></a>");
            }
        }
    }
}