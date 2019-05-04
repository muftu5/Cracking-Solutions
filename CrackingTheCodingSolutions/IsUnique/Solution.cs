using System.Collections.Generic;
using System.Linq;

namespace IsUnique
{
    public static class Solution
    {
        //Implement an algorithm to determine if a string has all unique characters.
        //What if you cannot use additional data structures?

        public static bool HasUniqueChars(string s)
        {
            var dict = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (dict.ContainsKey(c))
                    dict[c] += 1;
                else
                    dict.Add(c, 1);
            }

            return dict.Values.All(x => x == 1);
        }
    }
}
