namespace BitByteMega
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IDecodeStrategy
    {
        string DecodeNumber(int num);
        string GetDecodedNumbers(IEnumerable<string> collection);
        string GetSummary(IEnumerable<string> collection);
    }

    /// <summary>
    /// This class defines an interface common to all supported strategy algorithms and 
    /// it decodes a number to an string with the following criteria:
    /// * the number
    /// * 'bit' for numbers that are multiples of 3
    /// * 'byte' for numbers that are multiples of 5
    /// * 'bitbyte' for numbers that are multiples of 15
    /// A number divisible by 3 and 5 is also divisible by 3 * 5
    /// A number that divides by both three and five should already cause both Bit and Byte to print one after the other
    public class DecodeStrategy : IDecodeStrategy
    {
        protected IEnumerable<string> reportEntries;

        public DecodeStrategy()
        {
            this.reportEntries = new List<string> { HelperStrategy.BITLETTERS, HelperStrategy.BYTELETTERS, HelperStrategy.BITBYTELETTERS, "integer" };
        }

        public virtual string DecodeNumber(int num)
        {
            var markers = new[]
            {
                new { Name = HelperStrategy.BITBYTELETTERS, Condition = HelperStrategy.IsBitByteMatch(num) },
                new { Name = HelperStrategy.BITLETTERS, Condition = HelperStrategy.IsBitMatch(num) },
                new { Name = HelperStrategy.BYTELETTERS, Condition = HelperStrategy.IsByteMatch(num) },
                new { Name = num.ToString(), Condition = HelperStrategy.IsDefaultMatch(num) }
            };

            var names = markers.Where(kv => kv.Condition).Select(kv => kv.Name);

            return names.FirstOrDefault();
        }

        public string GetDecodedNumbers(IEnumerable<string> collection)
        {
            var output = collection.Aggregate(string.Empty, (y, x) => string.Format("{0} {1}", y, x)).Trim(); // collection.ToList().Aggregate((a, i) => a + " " + i)

            return output;
        }

        public string GetSummary(IEnumerable<string> collection)
        {
            string delimiter = ": ";

            var valuesReport = this.reportEntries
                         .Select(e => new
                         {
                             Name = e,
                             Counter = collection.Where(x => x.Equals(e)).Count()  // collection.Count(x => x.Equals(e))
                         }).ToDictionary(y => y.Name, y => y.Counter);

            valuesReport["integer"] = collection.Count() - valuesReport.Sum(x => x.Value);

            var lines = valuesReport.Select(kvp => kvp.Key + delimiter + kvp.Value.ToString());

            return string.Join(Environment.NewLine, lines).Trim();
        }
    }

    /// This class represents an strategy and decodes a number with a string with the following criteria:
    /// * the number
    /// * 'bit' for numbers that are multiples of 3
    /// * 'byte' for numbers that are multiples of 5
    /// * 'bitbyte' for numbers that are multiples of 15
    /// * 'mega' for numbers that contains a three
    public class TwoDimensionalArrayAndConditionMegaStrategy : DecodeStrategy, IDecodeStrategy
    {
        public TwoDimensionalArrayAndConditionMegaStrategy()
        {
            this.reportEntries = new List<string> { HelperStrategy.BITLETTERS, HelperStrategy.BYTELETTERS, HelperStrategy.BITBYTELETTERS, HelperStrategy.MEGALETTERS, "integer" };
        }
        
        // Strategy using Delegate <int, int, bool> and Two-Dimensional Array including the condition       
        public override string DecodeNumber(int num)
        {
            if (HelperStrategy.IsMegaMatch(num))
            {
                return HelperStrategy.MEGALETTERS;
            }

            return base.DecodeNumber(num);
        }
    }   
}