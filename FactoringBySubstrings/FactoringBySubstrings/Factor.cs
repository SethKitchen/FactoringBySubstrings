using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace FactoringBySubstrings
{
    class Factor
    {
        public static BigInteger Sum(List<BigInteger> bis)
        {
            BigInteger toReturn = 0;
            for(int i=0; i<bis.Count; i++)
            {
                toReturn += bis[i];
            }
            return toReturn;
        }

        public static void GetAllMatchingSubstringNumbers(BigInteger toFactor)
        {
            using(StreamWriter sw=new StreamWriter("matchingSubstringNumbers.csv",true))
            {
                sw.AutoFlush = true;
                sw.Write(toFactor.ToString() + ","); // First entry is the number to factor
                var substrings = Substrings.SubstringsOf(toFactor.ToString());
               /* sw.Write("{"); //Write all substrings for this number
                foreach(BigInteger b in substrings)
                {
                    sw.Write(b + ";");
                }
                sw.Write("},");*/
                //sw.Write((BigInteger.Pow(2, substrings.Count))+","); // Second entry is the total number of potential factors using this method
                for (int i = 1; i < substrings.Count; i++)
                {
                    var potentialFactorPS = PowerSet.PowerSetItemBig<BigInteger>(BigInteger.Pow(2,i), substrings.ToArray()).ToList();
                    BigInteger potentialFactor = Sum(potentialFactorPS);
                    if (potentialFactor != 0 && BigInteger.Abs(potentialFactor) != 1 && BigInteger.Abs(potentialFactor) != toFactor && toFactor % potentialFactor == 0)
                    {
                       // Console.WriteLine("#" + i + " : " + potentialFactor + " is a factor of " + toFactor);
                        sw.Write(BigInteger.Pow(2, i) + ",");// Write each Placement in Powerset that matched
                    }
                }
                sw.WriteLine();
            }
        }

        /// <summary>
        /// Returns a single factor of a given number using the Substring Method or -1 if none are found.
        /// </summary>
        /// <param name="toFactor">try 119</param>
        /// <returns>a single factor</returns>
        public static BigInteger GetFactor(BigInteger toFactor)
        {
            var substrings=Substrings.SubstringsOf(toFactor.ToString());
            for (int i = 0; i < (Math.Pow(2, substrings.Count)); i++)
            {
                var potentialFactorPS = PowerSet.PowerSetItemBig<BigInteger>(i, substrings.ToArray()).ToList();
                BigInteger potentialFactor = Sum(potentialFactorPS);
                if(potentialFactor!=0 && BigInteger.Abs(potentialFactor)!=1 && BigInteger.Abs(potentialFactor)!=toFactor && toFactor%potentialFactor==0)
                {
                    Console.WriteLine("#"+i+" : "+potentialFactor + " is a factor of " + toFactor);
                    return potentialFactor;
                }
            }
            return -1;
        }
    }
}
