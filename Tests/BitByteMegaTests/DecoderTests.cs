namespace BitByteMegaTests
{
    using System.Linq;
    using System.Text;
    using BitByteMega;
    using NUnit.Framework;

    [TestFixture]
    public class DecoderTests
    {
        private DecodeStrategy twoDimensionalArrayAndConditionStrategy;
        private BitByteMega.Decoder context;

        [SetUp]
        public void BeforeEachTest()
        {
            this.twoDimensionalArrayAndConditionStrategy = new DecodeStrategy();
            this.context = new BitByteMega.Decoder(this.twoDimensionalArrayAndConditionStrategy);
        }

        [Test]
        public void WhenDecodingPositiveNumbersThenShouldGetApropiateListOfString()
        {
            var expected = this.GetDummyCollectionFrom1To20();
            var result = this.context.DecodeNumbers(1, 20);
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Has.Exactly(20).Items);
        }

        [Test]
        public void WhenDecodingNegativeNumbersThenShouldGetApropiateListOfString()
        {
            var expected = this.GetDummyCollectionFromMinus3To20();
            var result = this.context.DecodeNumbers(-3, 10);
            Assert.That(result.ToList().Count, Is.EqualTo(expected.Count()));
        }

        [Test]
        public void WhenDecodinWrongRangeThenShouldNotGenerateAnySequence()
        {
            var result = this.context.DecodeNumbers(0, -1).ToList();
            Assert.That(result, Is.Empty);
            Assert.That(result, Is.EqualTo(Enumerable.Empty<string>()));
        }

        [Test]
        public void WhenPassingAListOfStringsThenShouldGetAnAgregatedString()
        {
            var expected = this.GetDecodedNumbersFrom1To20IntoAString();
            var result = this.context.GetResult(this.GetDummyCollectionFrom1To20());
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WhenPassingAListOfStringsThenShouldGenerateSummaryReport()
        {
            string expected = this.GetSummaryReportFrom1To20();
            var result = this.context.GetReport(this.GetDummyCollectionFrom1To20());

            Assert.That(result, Is.EqualTo(expected.ToString()));
        }

        private string GetDecodedNumbersFrom1To20IntoAString()
        {
            return "1 2 bit 4 byte bit 7 8 bit byte 11 bit 13 14 bitbyte 16 17 bit 19 byte";
        }

        private string GetSummaryReportFrom1To20()
        {
            StringBuilder dummy = new StringBuilder();
            dummy.AppendLine(this.GetDecodedNumbersFrom1To20IntoAString());
            dummy.AppendLine("bit: 5");
            dummy.AppendLine("byte: 3");
            dummy.AppendLine("bitbyte: 1");
            dummy.Append("integer: 11");
            return dummy.ToString();
        }

        private string[] GetDummyCollectionFrom1To20()
        {
            return new[]
            {
                "1", "2", "bit", "4", "byte",
                "bit", "7", "8", "bit", "byte",
                "11", "bit", "13", "14", "bitbyte",
                "16", "17", "bit", "19", "byte"
            };
        }

        private string[] GetDummyCollectionFromMinus3To20()
        {
            return new[]
            {
                "-3", "-1", "-2", "bitbyte", "1", "2", "bit", "4", "byte",
                "bit", "7", "8", "bit", "byte"
            };
        }
    }
}