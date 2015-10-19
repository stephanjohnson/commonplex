using Should;
using CommonPlex.Formatting.Renderers;
using Xunit;
using Xunit.Extensions;

namespace CommonPlex.Tests.Formatting
{
    public class PlainTextRendererFacts
    {
        public class CanExpand
        {
            [Fact]
            public void Should_return_true_for_anything()
            {
                var renderer = new PlainTextRenderer();

                bool result = renderer.CanExpand("anything");

                result.ShouldBeTrue();
            }
        }

        public class Expand
        {
            [Theory]
            [InlineData(ScopeName.Remove)]
            [InlineData(ScopeName.AlignEnd)]
            [InlineData(ScopeName.BoldBegin)]
            [InlineData(ScopeName.BoldEnd)]
            [InlineData(ScopeName.HeadingOneBegin)]
            [InlineData(ScopeName.HeadingOneEnd)]
            [InlineData(ScopeName.HeadingTwoBegin)]
            [InlineData(ScopeName.HeadingTwoEnd)]
            [InlineData(ScopeName.HeadingThreeBegin)]
            [InlineData(ScopeName.HeadingThreeEnd)]
            [InlineData(ScopeName.HeadingFourBegin)]
            [InlineData(ScopeName.HeadingFourEnd)]
            [InlineData(ScopeName.HeadingFiveBegin)]
            [InlineData(ScopeName.HeadingFiveEnd)]
            [InlineData(ScopeName.HeadingSixBegin)]
            [InlineData(ScopeName.HeadingSixEnd)]
            [InlineData(ScopeName.HorizontalRule)]
            [InlineData(ScopeName.IndentationBegin)]
            [InlineData(ScopeName.IndentationEnd)]
            [InlineData(ScopeName.ItalicsBegin)]
            [InlineData(ScopeName.ItalicsEnd)]
            [InlineData(ScopeName.LeftAlign)]
            [InlineData(ScopeName.OrderedListBeginTag)]
            [InlineData(ScopeName.OrderedListEndTag)]
            [InlineData(ScopeName.RightAlign)]
            [InlineData(ScopeName.StrikethroughBegin)]
            [InlineData(ScopeName.StrikethroughEnd)]
            [InlineData(ScopeName.SubscriptBegin)]
            [InlineData(ScopeName.SubscriptEnd)]
            [InlineData(ScopeName.SuperscriptBegin)]
            [InlineData(ScopeName.SuperscriptEnd)]
            [InlineData(ScopeName.TableBegin)]
            [InlineData(ScopeName.TableEnd)]
            [InlineData(ScopeName.UnderlineBegin)]
            [InlineData(ScopeName.UnderlineEnd)]
            [InlineData(ScopeName.UnorderedListBeginTag)]
            [InlineData(ScopeName.UnorderedListEndTag)]
            [InlineData(ScopeName.SyndicatedFeed)]
            [InlineData(ScopeName.Silverlight)]
            [InlineData(ScopeName.FlashVideo)]
            [InlineData(ScopeName.InvalidVideo)]
            [InlineData(ScopeName.QuickTimeVideo)]
            [InlineData(ScopeName.RealPlayerVideo)]
            [InlineData(ScopeName.VimeoVideo)]
            [InlineData(ScopeName.WindowsMediaVideo)]
            [InlineData(ScopeName.YouTubeVideo)]
            [InlineData(ScopeName.Channel9Video)]
            [InlineData(ScopeName.Anchor)]
            [InlineData(ScopeName.HorizontalRule)]
            [InlineData(ScopeName.ImageLeftAlign)]
            [InlineData(ScopeName.ImageNoAlign)]
            [InlineData(ScopeName.ImageRightAlign)]
            [InlineData(ScopeName.ImageWithLinkNoAlt)]
            [InlineData(ScopeName.ImageWithLinkNoAltLeftAlign)]
            [InlineData(ScopeName.ImageWithLinkNoAltRightAlign)]
            [InlineData(ScopeName.ImageDataLeftAlign)]
            [InlineData(ScopeName.ImageDataNoAlign)]
            [InlineData(ScopeName.ImageDataRightAlign)]
            [InlineData(ScopeName.ImageDataWithLinkNoAlt)]
            [InlineData(ScopeName.ImageDataWithLinkNoAltLeftAlign)]
            [InlineData(ScopeName.ImageDataWithLinkNoAltRightAlign)]
            [InlineData(ScopeName.LinkToAnchor)]
            public void Should_return_an_empty_string_for_the_specified_scope_name(string scopeName)
            {
                var renderer = new PlainTextRenderer();

                string result = renderer.Expand(scopeName, "foo", x => x, x => x);

                result.ShouldBeEmpty();
            }

            [Theory]
            [InlineData(ScopeName.ListItemBegin)]
            [InlineData(ScopeName.ListItemEnd)]
            [InlineData(ScopeName.TableCell)]
            [InlineData(ScopeName.TableCellHeader)]
            [InlineData(ScopeName.TableRowBegin)]
            [InlineData(ScopeName.TableRowEnd)]
            [InlineData(ScopeName.TableRowHeaderBegin)]
            [InlineData(ScopeName.TableRowHeaderEnd)]
            public void Should_return_a_single_space_for_the_specified_scope_name(string scopeName)
            {
                var renderer = new PlainTextRenderer();

                string result = renderer.Expand(scopeName, "foo", x => x, x => x);

                result.ShouldEqual(" ");
            }

            [Theory]
            [InlineData(ScopeName.ImageLeftAlignWithAlt)]
            [InlineData(ScopeName.ImageRightAlignWithAlt)]
            [InlineData(ScopeName.ImageNoAlignWithAlt)]
            [InlineData(ScopeName.ImageWithLinkWithAlt)]
            [InlineData(ScopeName.ImageWithLinkWithAltLeftAlign)]
            [InlineData(ScopeName.ImageWithLinkWithAltRightAlign)]
            [InlineData(ScopeName.ImageDataLeftAlignWithAlt)]
            [InlineData(ScopeName.ImageDataRightAlignWithAlt)]
            [InlineData(ScopeName.ImageDataNoAlignWithAlt)]
            [InlineData(ScopeName.ImageDataWithLinkWithAlt)]
            [InlineData(ScopeName.ImageDataWithLinkWithAltLeftAlign)]
            [InlineData(ScopeName.ImageDataWithLinkWithAltRightAlign)]
            [InlineData(ScopeName.LinkWithText)]
            public void Should_return_the_friendly_text_for_the_specified_scope_name(string scopeName)
            {
                var renderer = new PlainTextRenderer();

                string result = renderer.Expand(scopeName, "Friendly|Other", x => x, x => x);

                result.ShouldEqual("Friendly");
            }

            [Theory]
            [InlineData(ScopeName.EscapedMarkup)]
            [InlineData(ScopeName.ColorCodeAshx)]
            [InlineData(ScopeName.ColorCodeAspxCs)]
            [InlineData(ScopeName.ColorCodeAspxVb)]
            [InlineData(ScopeName.ColorCodeAspxVb)]
            [InlineData(ScopeName.ColorCodeCSharp)]
            [InlineData(ScopeName.ColorCodeCpp)]
            [InlineData(ScopeName.ColorCodeCss)]
            [InlineData(ScopeName.ColorCodeHtml)]
            [InlineData(ScopeName.ColorCodeJava)]
            [InlineData(ScopeName.ColorCodeJavaScript)]
            [InlineData(ScopeName.ColorCodeTypeScript)]
            [InlineData(ScopeName.ColorCodeFSharp)]
            [InlineData(ScopeName.ColorCodePhp)]
            [InlineData(ScopeName.ColorCodePowerShell)]
            [InlineData(ScopeName.ColorCodeSql)]
            [InlineData(ScopeName.ColorCodeVbDotNet)]
            [InlineData(ScopeName.ColorCodeXml)]
            [InlineData(ScopeName.ColorCodeMarkdown)]
            [InlineData(ScopeName.ColorCodeKoka)]
            [InlineData(ScopeName.ColorCodeHaskell)]
            [InlineData(ScopeName.SingleLineCode)]
            [InlineData(ScopeName.MultiLineCode)]
            [InlineData(ScopeName.LinkAsMailto)]
            [InlineData(ScopeName.LinkNoText)]
            public void Should_return_input_for_the_specified_scope_name(string scopeName)
            {
                var renderer = new PlainTextRenderer();

                string result = renderer.Expand(scopeName, "foo", x => x, x => x);

                result.ShouldEqual("foo");
            }
        }
    }
}
