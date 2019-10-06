using System;
using System.Numerics;

namespace FactoringBySubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i=12; i<1000; i++)
            {
                Factor.GetAllMatchingSubstringNumbers(i);
            }
        }
    }
}
