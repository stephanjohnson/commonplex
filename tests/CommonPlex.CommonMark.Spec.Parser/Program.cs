using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CommonPlex.CommonMark.Spec.Parser
{
    public class Program
    {
        public void Main(string[] args)
        {
            if (args.Length == 0)
                throw new ArgumentNullException(nameof(args));

            var filename = args[0];

            if (!File.Exists(filename))
                throw new FileNotFoundException("File not found", filename);

            var outputFolder = args[1];

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            var specLines = File.ReadAllLines(filename);
            var heading = string.Empty;

            var sample = string.Empty;
            var sampleBlock = false;

            var html = string.Empty;
            var htmlBlock = false;

            var exampleCounter = 0;
            var facts = new List<string>();

            foreach (var line in specLines.Select(m => m.Replace("\"", "\"\"").Replace("→", "\t")))
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(line, @"^:*\s?(#{1,6}\s)[^\r\n]*(\r?\n|$)") && !sampleBlock && !htmlBlock)
                {
                    if (facts.Count > 0)
                    {
                        var cleanHeading = heading.Replace(" ", "");
                        var testFactFileFormat = @"
using Xunit;

namespace CommonPlex.CommonMark.Tests
{{
    public class {0}: BaseTest
    {{
        {1}
    }}
}}";
                        var testFactFileContent = string.Format(testFactFileFormat, cleanHeading, facts.Aggregate((a, b) => { return $"{a}{Environment.NewLine}{b}"; }));

                        File.WriteAllText($"{outputFolder}\\{cleanHeading}.cs", testFactFileContent);

                        facts.Clear();
                    }

                    heading = line.Split(' ').Skip(1).Aggregate((a, b) => { return $"{a} {b}"; });
                }

                if (line.Equals(".") && !sampleBlock && !htmlBlock)
                {
                    sampleBlock = true;
                    htmlBlock = false;

                    sample = string.Empty;

                    continue;
                }

                if (line.Equals(".") && sampleBlock && !htmlBlock)
                {
                    sampleBlock = false;
                    htmlBlock = true;

                    html = string.Empty;

                    continue;
                }

                if (line.Equals(".") && !sampleBlock && htmlBlock)
                {
                    sampleBlock = false;
                    htmlBlock = false;

                    exampleCounter++;

                    Console.Write($"{heading} ({exampleCounter})\r\n");
                    //Console.Write($"Example: {exampleCounter}\r\n");

                    var factFormat = @"
        #region Example {0,3:000}
        [Fact]
        public void Example{0,3:000}()
        {{
            Assert.Equal(@""{2}"", GetHtml(@""{1}""));
        }}

        #endregion";

                    if (sample.EndsWith(Environment.NewLine))
                        sample = sample.Substring(0, sample.Length - 2);

                    if (html.EndsWith(Environment.NewLine))
                        html = html.Substring(0, html.Length - 2);

                    var fact = string.Format(factFormat, exampleCounter, sample.Replace("\r\n", "\r"), html);


                    facts.Add(fact);

                    sample = string.Empty;
                    html = string.Empty;

                    continue;
                }

                if (sampleBlock)
                {
                    sample += $"{line}{Environment.NewLine}";
                }

                if (htmlBlock)
                {
                    html += $"{line}{Environment.NewLine}";
                }
            }
        }
    }
}
