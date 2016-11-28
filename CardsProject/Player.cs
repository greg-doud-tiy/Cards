using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GregoryDoud {
	/// <summary>
	/// Represents a player in the card game
	/// </summary>
	public class Player {
		/// <summary>
		/// Player name.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Collection of card in the player's hand
		/// </summary>
		public List<Card> Cards = new List<Card>();
		/// <summary>
		/// Causes all cards to be turned face up.
		/// </summary>
		public void ShowAllCards() {
			foreach(Card card in Cards) {
				if(!card.IsShowing()) {
					card.Flip();
				}
			}
		}
		/// <summary>
		/// For Blackjack, figures the best hand
		/// for the cards being held. Options occur only when
		/// an ace (1 or 11) is held.
		/// </summary>
		/// <returns></returns>
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
		/// <summary>
		/// Determines if the player has a blackjack
		/// </summary>
		/// <returns></returns>
		public bool HasBlackjack() {
			// a player has Blackjack if any total is 21
			foreach (var total in Total()) {
				if (total == 21) {
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// Determines if the player has busted
		/// </summary>
		/// <returns></returns>
		public bool HasBusted() {
			// a player busts when all totals are > 21
			foreach(var total in Total()) {
				if(total <= 21) {
					return false;
				}
			}
			return true;
		}
		/// <summary>
		/// Add the card to the player hand.
		/// </summary>
		/// <param name="card"></param>
		public void Add(Card card) {
			Cards.Add(card);
		}
		/// <summary>
		/// Calculates the cards total for Blackjack.
		/// 
		/// Note: it does NOT count cards that are 
		/// face down.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<int> Total() {
			List<int> totals = new List<int>() { 0 };
			foreach(Card card in this.Cards) {
				if(!card.IsShowing()) { // skip it
					continue; 
				}
				if(card.Rank == Rank.Ace) {
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
		/// <summary>
		/// Constructor. Initializes a player with a name
		/// </summary>
		/// <param name="name"></param>
		public Player(string name) {
			this.Name = name;
		}
	}
}
