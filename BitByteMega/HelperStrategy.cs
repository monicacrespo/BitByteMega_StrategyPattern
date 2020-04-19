namespace BitByteMega
{
    public static class HelperStrategy
    {
        public const string BITLETTERS = "bit";

        public const string BYTELETTERS = "byte";

        public const string BITBYTELETTERS = "bitbyte";

        public const string MEGALETTERS = "mega";

        public const int BITNUMBER = 3;

        public const int BYTENUMBER = 5;

        public const int BITBYTENUMBER = 15;

        public const int MEGANUMBER = 3;

        // IsMultipleOf is an extension method to the int type

        // Use of Delegate <int, bool>
        // Func<int, bool> IsBit = delegate (int i)
        //   {
        //       return i.IsMultipleOf(BITNUMBER);
        //   };
        // Func<int, bool> IsBit = i => i.IsMultipleOf(Helper.BITNUMBER); 
        // When i = 2 then 2 % 3 = 2; when i = 3 then 3 % 3 = 0 so 3 is multiple of 3;
        public static bool IsBit(int i) => i.IsMultipleOf(BITNUMBER);

        public static bool IsByte(int i) => i.IsMultipleOf(BYTENUMBER);

        public static bool IsMega(int i) => i.ToString().Contains(MEGANUMBER.ToString());

        // Use of Delegate <int, int, bool>
        // public Func<int, int, bool> IsMatch2 = (i, marker) => i % marker == 0;
        public static bool IsMatch2(int i, int marker) => i % marker == 0;

        // Strategy using Delegate <int, int, bool> including the condition
        // public Func<int, bool> IsMegaMatch = i => i.ToString().Contains("3");
        public static bool IsMegaMatch(int i) => i.ToString().Contains("3");

        // public Func<int, bool> IsBitByteMatch = i => i % 15 == 0;
        public static bool IsBitByteMatch(int i) => i % 15 == 0;

        // public Func<int, bool> IsBitMatch = i => i % 3 == 0;
        public static bool IsBitMatch(int i) => i % 3 == 0;

        // public Func<int, bool> IsByteMatch = i => i % 5 == 0;
        public static bool IsByteMatch(int i) => i % 5 == 0;

        // public Func<int, bool> IsDefaultMatch = i => true;
        public static bool IsDefaultMatch(int i) => true;
    }
}