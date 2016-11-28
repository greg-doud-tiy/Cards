// PseudoRandom numbers
using System;
using System.Collections.Generic;
namespace GregoryDoud {
	/// <summary>
	/// Generates pseudo-random numbers in various ways
	/// a single random number
	/// </summary>
	public class PseudoRandom {
		static Random rnd = null;
		/// <summary>
		/// Returns a sequence of ints in random order
		/// </summary>
		public static int[] GetIntSequence(int max = int.MaxValue) {
			List<int> ints = new List<int>();
			while(ints.Count < max) {
				int anInt = GetInt(max);
				if(!ints.Contains(anInt)) {
					ints.Add(anInt);
				}
			}
			return ints.ToArray();
		}
		/// <summary>
		/// Returns a set of integers between 1 & max inclusive
		/// </summar>
		public static int[] GetIntSet(int count = 10, int max = int.MaxValue) {
			List<int> ints = new List<int>();
			for(int idx = 0; idx < count; idx++) {
				ints.Add(GetInt(max));
			}
			return ints.ToArray();
		}
		/// <summary>
		/// Gets a pseudo-random integer between 1 & max inclusive
		/// </summary>
		public static int GetInt(int max = int.MaxValue) {
			return rnd.Next(max) + 1;
		}
		static PseudoRandom() {
			rnd = new Random(DateTime.Now.Millisecond);
		}
	}
}