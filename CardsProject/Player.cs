using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GregoryDoud {
	public class Player {
		public string Name { get; set; }
		public List<Card> Cards = new List<Card>();
		public void ShowAllCards() {
			foreach(Card card in Cards) {
				if(!card.IsShowing()) {
					card.Flip();
				}
			}
		}
		public int BestHand() {
			// a best hand is a total closest to 21
			var bestHand = 0;
			foreach (var total in Total()) {
				if (total > bestHand && total <= 21) {
					bestHand = total;
				}
			}
			return bestHand;
		}
		public bool HasBlackjack() {
			// a player has Blackjack if any total is 21
			foreach (var total in Total()) {
				if (total == 21) {
					return true;
				}
			}
			return false;
		}
		public bool HasBusted() {
			// a player busts when all totals are > 21
			foreach(var total in Total()) {
				if(total <= 21) {
					return false;
				}
			}
			return true;
		}
		public void Add(Card card) {
			Cards.Add(card);
		}
		public IEnumerable<int> Total() {
			List<int> totals = new List<int>() { 0 };
			foreach(Card card in this.Cards) {
				if(!card.IsShowing()) { // skip it
					continue; 
				}
				if(card.Number == Number.Ace) {
					totals.AddRange(totals.ToArray());
					for(var idx = 0; idx < totals.Count; idx++) {
						if (idx % 2 == 0) { // even
							totals[idx] += 1;
						} else {
							totals[idx] += 11;
						}
					}
				} else {
					for(var idx = 0; idx < totals.Count; idx++) {
						totals[idx] += card.Value();
					}
				}
			}
			return totals.ToArray();
		}
		public Player(string name) {
			this.Name = name;
		}
	}
}
