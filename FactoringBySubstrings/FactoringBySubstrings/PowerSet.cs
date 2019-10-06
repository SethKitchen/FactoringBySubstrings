﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace FactoringBySubstrings
{
    class PowerSet
    {
        public static T[][] FastPowerSet2<T>(T[] seq)
        {
            var powerSet = new T[1 << seq.Length][];
            powerSet[0] = new T[0]; // starting only with empty set
            for (uint i = 1; i < powerSet.Length; i++)
            {
                powerSet[i] = PowerSetItem(i, seq, powerSet.Length);
            }
            return powerSet;
        }

        public static T[] PowerSetItemBig<T>(BigInteger neededSetIndex, T[] p)
        {
            byte[] neededSetBytes = neededSetIndex.ToByteArray();
            BitArray b = new BitArray(neededSetBytes);
            return p.Take(b.Length).Where((s, j) => b[j]).ToArray();
        }

        public static T[] PowerSetItem<T>(uint powersetIndex, T[] sequence, int powersetLength)
        {
            BitArray b = new BitArray(BitConverter.GetBytes(powersetIndex));
            if (b.Length < powersetLength)
            {
                var prefix = new BitArray(powersetLength - b.Length);
                b = Append(prefix, b);
            }

            return sequence.Where((s, j) => b[j]).ToArray();
        }
        public static BitArray Append(BitArray current, BitArray after)
        {
            var bools = new bool[current.Count + after.Count];
            current.CopyTo(bools, 0);
            after.CopyTo(bools, current.Count);
            return new BitArray(bools);
        }
    }
}
