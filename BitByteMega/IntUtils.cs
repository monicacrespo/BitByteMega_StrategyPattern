namespace BitByteMega
{
    public static class IntUtils
    {
        /// <summary>
        /// Extension method to add the capability IsMultipleOf to the int type
        /// This capability return whether the first number is a multiple of the second using the modulus operator %
        /// An integer aa is a multiple of an integer b means that a/b=integer: so, as 0 divided by any integer (except zero itself) yields an integer
        /// So, zero is a multiple of every integer (except zero itself).
        /// Modulo is the operation of finding the Remainder when you divide two numbers. Therefore, when you ask "What is 1 mod 10?" you are asking "What is the Remainder when you divide 1 by 10?
        /// And the answer is 1
        /// </summary>
        /// <param name="dividend">first number </param>
        /// <param name="divisor">second number</param>
        /// <returns>True if the remainder after division of one number by another is 0  /// </returns>
        public static bool IsMultipleOf(this int dividend, int divisor)
        {
            return (dividend % divisor) == 0;
        }
    }
}