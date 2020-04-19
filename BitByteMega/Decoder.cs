namespace BitByteMega
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The Context defines the interface of interest to clients, in this case, IDecodeStrategy.    
    /// </summary>
    public class Decoder
    {
        // The Context maintains a reference to one of the Strategy objects. 
        // The Context does not know the concrete class of a strategy. 
        // It should work with all strategies via the Strategy interface.
        private IDecodeStrategy decodeStrategy;

        // Usually, the Context accepts a strategy through the constructor, but
        // also provides a setter to change it at runtime.
        public Decoder(IDecodeStrategy strategy)
        {
            this.decodeStrategy = strategy;
        }

        public IDecodeStrategy GetStrategy()
        {
            return this.decodeStrategy;
        }

        public void SetStrategy(IDecodeStrategy strategy)
        {
            this.decodeStrategy = strategy;
        }

        /// <summary>
        /// The Context delegates some work, DecodeNumber, to the Strategy object instead of
        /// implementing multiple versions of the algorithm on its own.
        /// This method generates a sequence on a range of numbers and decodes them individually
        /// </summary>
        public IEnumerable<string> DecodeNumbers(int start, int end)
        {
            return Enumerable.Range(start, (end - start) + 1)
                .Select(i => this.GetStrategy().DecodeNumber(i)).ToList();
        }

        public string GetResult(IEnumerable<string> collection)
        {
            return this.GetStrategy().GetDecodedNumbers(collection);
        }

        public string GetReport(IEnumerable<string> collection)
        {
            string top = this.GetResult(collection);
            string bottom = this.GetStrategy().GetSummary(collection);

            StringBuilder outputReport = new StringBuilder();
            outputReport.AppendLine(top);
            outputReport.Append(bottom);

            return outputReport.ToString();
        }
    }
}