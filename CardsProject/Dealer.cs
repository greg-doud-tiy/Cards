using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GregoryDoud {
	public class Dealer : Player {
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
		public Dealer(string name) : base(name) {
		}
	}
}
