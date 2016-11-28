using System;
using System.Collections.Generic;

namespace GregoryDoud {
    
    public class Deck {
        private int _decks;
        List<Card> cards = new List<Card>();

        public void Shuffle() {
			List<Card> unshuffledCards = new List<Card>(cards);
			List<Card> shuffledCards = new List<Card>();
			int[] rndInts = PseudoRandom.GetIntSequence(52);
			foreach(int rndInt in rndInts) {
				shuffledCards.Add(unshuffledCards[rndInt - 1]);
			}
			this.cards = shuffledCards;
		}
		public ICollection<Card> Draw(int nbr = 1) {
			List<Card> cards = new List<Card>();
			for(int idx = 0; idx < nbr; idx++) {
				cards.Add(Draw());
			}
			return cards.ToArray();
		}
		public Card DrawFaceUp() {
			Card card = Draw();
			card.Flip();
			return card;
		}
		public Card Draw() {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        public int Count() {
            return cards.Count;
        }
        void Init(int decks) {
            for (int nbrDecks = 0; nbrDecks < this._decks; nbrDecks++) {
                foreach(Suite suite in Enum.GetValues(typeof(Suite))) {
                    foreach (Number number in Enum.GetValues(typeof(Number)))  {
                        cards.Add(new Card(suite, number));
                    }
                }
            }
        }
        public Deck(int decks = 1) {
            this._decks = decks;
            Init(this._decks);
        }
    }
}
