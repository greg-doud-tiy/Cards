using System;
namespace GregoryDoud {
    
    public class Card {

        Suite suite;
        Number number;
    
        public int Compare(Card card) {
            // a card is greater if the number if greater
            return this.number - card.number;
        }
        public string Display() {
            string[] nbrsList = { "Two", "Three", "Four", "Five", "Six", "Seven"
                , "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            string[] suitesList = { "Diamonds", "Hearts", "Clubs", "Spades" };
            string n = nbrsList[(int)number];
            string s = suitesList[(int)suite];
            return n + " of " + s;
        }
        public override string ToString() {
            return this.Display();
        }
        public Card(Suite suite, Number number) {
            this.suite = suite;
            this.number = number;
        }
        public Card() {
        }
    }

    public enum Suite {
        Diamonds, Hearts, Clubs, Spades
    };
    public enum Number {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    };
}
