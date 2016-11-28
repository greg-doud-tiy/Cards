using System;
namespace GregoryDoud {
    /// <summary>
	/// This is a playing card.
	/// </summary>
    public class Card {
		/// <summary>
		/// The suite. (i.e. Diamonds, Hearts, Clubs, Spades)
		/// </summary>
        public Suite Suite { get; set; }
        public Rank Rank { get; set; }
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
			switch(this.Rank) {
				case Rank.Two:	val =  2; break;
				case Rank.Three:	val =  3; break;
				case Rank.Four:	val =  4; break;
				case Rank.Five:	val =  5; break;
				case Rank.Six:	val =  6; break;
				case Rank.Seven:	val =  7; break;
				case Rank.Eight:	val =  8; break;
				case Rank.Nine:	val =  9; break;
				case Rank.Ten:	val = 10; break;
				case Rank.Jack:	val = 10; break;
				case Rank.Queen:	val = 10; break;
				case Rank.King:	val = 10; break;
				case Rank.Ace:	val = 11; break;
			}
			return val;
		}
        public int Compare(Card card) {
            // a card is greater if the number if greater
            return this.Rank - card.Rank;
        }
        public string Display() {
            string[] rankList = { "Two", "Three", "Four", "Five", "Six", "Seven"
                , "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            string[] suitesList = { "Diamonds", "Hearts", "Clubs", "Spades" };
            string r = rankList[(int)Rank];
            string s = suitesList[(int)Suite];
			if (this.isShowing) {
				return r + " of " + s;
			} else {
				return "Facedown";
			}
        }
        public override string ToString() {
            return this.Display();
        }
        public Card(Suite suite, Rank rank) {
            this.Suite = suite;
            this.Rank = rank;
			this.isShowing = false;
        }
        public Card() {
        }
    }

    public enum Suite {
        Diamonds, Hearts, Clubs, Spades
    };
    public enum Rank {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    };
}
