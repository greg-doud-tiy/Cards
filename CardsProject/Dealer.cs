using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GregoryDoud {
	/// <summary>
	/// A Dealer is a special Player for blackjack because
	/// of the mandatory rules about drawing cards.
	/// </summary>
	public class Dealer : Player {
		/// <summary>
		/// Determines whether the dealer must
		/// draw a card or not. For the dealer,
		/// an Ace is always 11.
		/// </summary>
		/// <returns></returns>
		public bool MustDraw() {
			// a dealer must draw if total < 17
			// ace is always 11 for the dealer
			var max = 0;
			foreach(var total in Total()) {
				if(total > max) {
					max = total;
				}
			}
			return max < 17;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name"></param>
		public Dealer(string name) : base(name) {
		}
	}
}
