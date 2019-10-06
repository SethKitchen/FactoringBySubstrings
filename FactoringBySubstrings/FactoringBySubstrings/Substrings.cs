using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace FactoringBySubstrings
{
    class Substrings
    {
        /// <summary>
        /// https://stackoverflow.com/questions/49377193/c-sharp-code-optimization-to-get-all-substrings-from-a-string
        /// </summary>
        /// <param name="value">Big Number to Factor</param>
        /// <returns>Small Numbers that combine to be a factor of big number</returns>
        public static List<BigInteger> SubstringsOf(string s)
        {
            var stringList = new List<BigInteger>();
            for (int i = 0; i < s.Length; i++)
                for (int j = i; j < s.Length; j++)
                {
                    var str = s.Substring(i, j - i + 1);
                    stringList.Add(BigInteger.Parse("-"+str));
                    stringList.Add(BigInteger.Parse(str));
                }
            //stringList.Distinct();
            return stringList;
        }
    }
}
