namespace BitByteMega
{
    using System;

    class Program
    {
        private static void Main(string[] args)
        {
            // The client code picks a concrete strategy and passes it to the context.
            // The client should be aware of the differences between strategies in order to make the right choice.
            DecodeStrategy strategy = new TwoDimensionalArrayAndConditionMegaStrategy();

            var context = new Decoder(strategy);

            var output = context.DecodeNumbers(1, 20);

            var report = context.GetReport(output);

            Console.WriteLine(report);
            Console.ReadLine();
        }
    }
}
