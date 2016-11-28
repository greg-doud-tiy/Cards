using System;
using System.Collections.Generic;

namespace GregoryDoud {
    /// <summary>
	/// A Deck is a collection of 52 <see cref="Card"/>Cards.
	/// 
	/// It includes methods to Shuffle & Draw
	/// </summary>
    public class Deck {
        private int _decks;
        List<Card> cards = new List<Card>();
		/// <summary>
		/// Shuffles the cards into random sequence.
		/// Decks can be shuffled multiple times, but
		/// one shuffle is very random.
		/// </summary>
        public void Shuffle() {
			List<Card> unshuffledCards = new List<Card>(cards);
			List<Card> shuffledCards = new List<Card>();
			int[] rndInts = PseudoRandom.GetIntSequence(52);
			foreach(int rndInt in rndInts) {
				shuffledCards.Add(unshuffledCards[rndInt - 1]);
			}
			this.cards = shuffledCards;
		}
		/// <summary>
		/// Draws cards from the deck. Default is 1.
		/// </summary>
		/// <param name="nbr">Number of cards to draw (default 1)</param>
		/// <returns>ICollection of Card</returns>
		public ICollection<Card> Draw(int nbr = 1) {
			List<Card> cards = new List<Card>();
			for(int idx = 0; idx < nbr; idx++) {
				cards.Add(Draw());
			}
			return cards.ToArray();
		}
		/// <summary>
		/// Draws a card face up
		/// </summary>
		/// <returns>A Card.</returns>
		public Card DrawFaceUp() {
			Card card = Draw();
			card.Flip();
			return card;
		}
		/// <summary>
		/// Draws a card face down.
		/// </summary>
		/// <returns>A Card.</returns>
		public Card Draw() {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
		/// <summary>
		/// Returns the number of cards remaining
		/// in the deck.
		/// </summary>
		/// <returns></returns>
        public int Count() {
            return cards.Count;
        }
		/// <summary>
		/// Initializes the deck with 52 cards
		/// </summary>
		/// <param name="decks">Number of 52 cards to include in the deck.</param>
        void Init(int decks) {
            for (int nbrDecks = 0; nbrDecks < this._decks; nbrDecks++) {
                foreach(Suite suite in Enum.GetValues(typeof(Suite))) {
                    foreach (Rank rank in Enum.GetValues(typeof(Rank)))  {
                        cards.Add(new Card(suite, rank));
                    }
                }
            }
        }
		/// <summary>
		/// Constructor for the deck.
		/// </summary>
		/// <param name="decks">Number of decks (default 1)</param>
        public Deck(int decks = 1) {
            this._decks = decks;
            Init(this._decks);
        }
    }
}
