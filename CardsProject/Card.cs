using System;
namespace GregoryDoud {
    
    public class Card {

        public Suite Suite { get; set; }
        public Number Number { get; set; }
		bool isShowing;
    
		public void Flip() {
			this.isShowing = !this.isShowing;
		}
		public bool IsShowing() {
			return this.isShowing;
		}
		public int Value() {
			int val = 0;
			if(!this.IsShowing()) {
				return val;
			}
			switch(this.Number) {
				case Number.Two:	val =  2; break;
				case Number.Three:	val =  3; break;
				case Number.Four:	val =  4; break;
				case Number.Five:	val =  5; break;
				case Number.Six:	val =  6; break;
				case Number.Seven:	val =  7; break;
				case Number.Eight:	val =  8; break;
				case Number.Nine:	val =  9; break;
				case Number.Ten:	val = 10; break;
				case Number.Jack:	val = 10; break;
				case Number.Queen:	val = 10; break;
				case Number.King:	val = 10; break;
				case Number.Ace:	val = 11; break;
			}
			return val;
		}
        public int Compare(Card card) {
            // a card is greater if the number if greater
            return this.Number - card.Number;
        }
        public string Display() {
            string[] nbrsList = { "Two", "Three", "Four", "Five", "Six", "Seven"
                , "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            string[] suitesList = { "Diamonds", "Hearts", "Clubs", "Spades" };
            string n = nbrsList[(int)Number];
            string s = suitesList[(int)Suite];
			if (this.isShowing) {
				return n + " of " + s;
			} else {
				return "Face down";
			}
        }
        public override string ToString() {
            return this.Display();
        }
        public Card(Suite suite, Number number) {
            this.Suite = suite;
            this.Number = number;
			this.isShowing = false;
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
