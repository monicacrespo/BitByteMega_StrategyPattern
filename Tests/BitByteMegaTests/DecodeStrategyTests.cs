namespace BitByteMegaTests
{
    using System.Text;
    using BitByteMega;
    using NUnit.Framework;

    [TestFixture]
    public class DecodeStrategyTests
    {
        private DecodeStrategy twoDimensionalArrayAndConditionStrategy;      

        [SetUp]
        public void BeforeEachTest()
        {
            this.twoDimensionalArrayAndConditionStrategy = new DecodeStrategy();           
        }

        [Test]
        public void WhenDecodeANumberMultipleOfThreeThenShouldGetBit()
        {
            string bitLettersResult = this.twoDimensionalArrayAndConditionStrategy.DecodeNumber(9);
            Assert.That(bitLettersResult, Is.EqualTo(HelperStrategy.BITLETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFiveThenShouldGetByte()
        {
            string byteLettersResult = this.twoDimensionalArrayAndConditionStrategy.DecodeNumber(5);
            Assert.That(byteLettersResult, Is.EqualTo(HelperStrategy.BYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFifteenThenShouldGetBitByte()
        {
            string bitByteLettersResult = this.twoDimensionalArrayAndConditionStrategy.DecodeNumber(15);
            Assert.That(bitByteLettersResult, Is.EqualTo(HelperStrategy.BITBYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberNotMultipleOfThreeOrFiveThenShouldGetTheNumber()
        {
            string integerLettersResult = this.twoDimensionalArrayAndConditionStrategy.DecodeNumber(1);
            Assert.That(integerLettersResult, Is.EqualTo("1"));
        }

        [Test]
        public void WhenPassingAListOfStringsThenShouldGetAnAgregatedString()
        {
            var expected = this.GetDecodedNumbersFrom1To20IntoAString();
            var result = this.twoDimensionalArrayAndConditionStrategy.GetDecodedNumbers(this.GetDummyCollectionFrom1To20());
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WhenPassingAListOfStringsThenShouldGetSummaryReport()
        {
            string expected = this.GetSummaryReportFrom1To20();
            var result = this.twoDimensionalArrayAndConditionStrategy.GetSummary(this.GetDummyCollectionFrom1To20());

            Assert.That(result, Is.EqualTo(expected.ToString()));
        }

        private string GetDecodedNumbersFrom1To20IntoAString()
        {
            return "1 2 bit 4 byte bit 7 8 bit byte 11 bit 13 14 bitbyte 16 17 bit 19 byte";
        }

        private string GetSummaryReportFrom1To20()
        {
            StringBuilder dummy = new StringBuilder();
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
    }
}