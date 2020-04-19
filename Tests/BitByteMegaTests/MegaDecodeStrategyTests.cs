namespace BitByteMegaTests
{
    using BitByteMega;
    using NUnit.Framework;
    using System.Text;

    public class MegaDecodeStrategyTests
    {
        private DecodeStrategy twoDimensionalArrayAndConditionMegaStrategy;

        [SetUp]
        public void BeforeEachTest()
        {
            this.twoDimensionalArrayAndConditionMegaStrategy = new TwoDimensionalArrayAndConditionMegaStrategy();           
        }

        [Test]
        public void WhenDecodeANumberMultipleOfThreeThenShouldGetBit()
        {                  
            string bitLettersResult = this.twoDimensionalArrayAndConditionMegaStrategy.DecodeNumber(9);                      
            Assert.That(bitLettersResult, Is.EqualTo(HelperStrategy.BITLETTERS));            
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFiveThenShouldGetByte()
        {          
            string byteLettersResult = this.twoDimensionalArrayAndConditionMegaStrategy.DecodeNumber(5);                                
            Assert.That(byteLettersResult, Is.EqualTo(HelperStrategy.BYTELETTERS));                    
        }

        [Test]
        public void WhenDecodeANumberMultipleOfFifteenThenShouldGetBitByte()
        {
            string bitByteLettersResult = this.twoDimensionalArrayAndConditionMegaStrategy.DecodeNumber(15);
            Assert.That(bitByteLettersResult, Is.EqualTo(HelperStrategy.BITBYTELETTERS));
        }

        [Test]
        public void WhenDecodeANumberNotMultipleOfThreeOrFiveThenShouldGetTheNumber()
        {
            string integerLettersResult = this.twoDimensionalArrayAndConditionMegaStrategy.DecodeNumber(1);
            Assert.That(integerLettersResult, Is.EqualTo("1"));
        }

        [Test]
        public void WhenDecodeANumberThatContainsThreeThenShouldGetMega()
        {
            string megaLettersResult = this.twoDimensionalArrayAndConditionMegaStrategy.DecodeNumber(3);
            Assert.That(megaLettersResult, Is.EqualTo(HelperStrategy.MEGALETTERS));
        }

        [Test]
        public void WhenPassingAListOfStringsThenShouldGetAnAgregatedString()
        {
            var expected = this.GetDecodedNumbersFrom1To20IntoAString();
            var result = this.twoDimensionalArrayAndConditionMegaStrategy.GetDecodedNumbers(this.GetDummyCollectionFrom1To20());
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WhenPassingAListOfStringsThenShouldGetSummaryReport()
        {
            string expected = this.GetSummaryReportFrom1To20();
            var result = this.twoDimensionalArrayAndConditionMegaStrategy.GetSummary(this.GetDummyCollectionFrom1To20());

            Assert.That(result, Is.EqualTo(expected.ToString()));
        }

        private string GetDecodedNumbersFrom1To20IntoAString()
        {
            return "1 2 mega 4 byte bit 7 8 bit byte 11 bit mega 14 bitbyte 16 17 bit 19 byte";
        }

        private string GetSummaryReportFrom1To20()
        {
            StringBuilder dummy = new StringBuilder();
            dummy.AppendLine("bit: 4");
            dummy.AppendLine("byte: 3");
            dummy.AppendLine("bitbyte: 1");
            dummy.AppendLine("mega: 2");
            dummy.Append("integer: 10");
            return dummy.ToString();
        }

        private string[] GetDummyCollectionFrom1To20()
        {
            return new[]
            {
                "1", "2", "mega", "4", "byte",
                "bit", "7", "8", "bit", "byte",
                "11", "bit", "mega", "14", "bitbyte",
                "16", "17", "bit", "19", "byte"
            };
        }
    }
}