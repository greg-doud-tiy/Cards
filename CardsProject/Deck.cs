using System;
using System.Collections.Generic;

namespace GregoryDoud {
    
    public class Deck {
        private int _decks;
        List<Card> cards = new List<Card>();

        public void Shuffle() {
            
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
