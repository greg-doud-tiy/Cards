using System;
namespace GregoryDoud {

	/// <summary>
	/// This models a card as in a deck of cards
	/// </summary>
    public class Card {
		/// <summary>
		/// The suite. (i.e. Diamonds, Hearts, Clubs, Spades)
		/// </summary>
        public Suite Suite { get; set; }
		/// <summary>
		/// The rank. (i.e. Two, Ten, Jack, Ace, etc.)
		/// </summary>
        public Rank Rank { get; set; }
		/// <summary>
		/// If true, the card is showing; otherwise it is face down
		/// </summary>
		bool isShowing;
    
		/// <summary>
		/// If the card is not showing, flipping to causes it to show.
		/// Flipping it again and it is face down.
		/// </summary>
		public void Flip() {
			this.isShowing = !this.isShowing;
		}
		/// <summary>
		/// Returns whether the card is showing or not.
		/// </summary>
		/// <returns>true if the card is show; otherwise false</returns>
		public bool IsShowing() {
			return this.isShowing;
		}
		/// <summary>
		/// Returns the rank of the card. 
		/// </summary>
		/// <returns>Number cards are their face
		/// value. Picture cards are 10. Ace is 11</returns>
		public int Value() {
			int val = 0;
			if(!this.IsShowing()) {
				return val;
			}
			switch(this.Rank) {
				case Rank.Two:		val =  2; break;
				case Rank.Three:	val =  3; break;
				case Rank.Four:		val =  4; break;
				case Rank.Five:		val =  5; break;
				case Rank.Six:		val =  6; break;
				case Rank.Seven:	val =  7; break;
				case Rank.Eight:	val =  8; break;
				case Rank.Nine:		val =  9; break;
				case Rank.Ten:		val = 10; break;
				case Rank.Jack:		val = 10; break;
				case Rank.Queen:	val = 10; break;
				case Rank.King:		val = 10; break;
				case Rank.Ace:		val = 11; break;
			}
			return val;
		}
		/// <summary>
		/// Compares the rank of two cards to which is greater
		/// </summary>
		/// <param name="card">A Card</param>
		/// <returns>-1 if the current card is lesser, zero if the same, and 1 if greater</returns>
        public int Compare(Card card) {
            // a card is greater if the number if greater
            return this.Rank - card.Rank;
        }
		/// <summary>
		/// Returns the text display value of the card as "Ace of Spades"
		/// </summary>
		/// <returns></returns>
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
		/// <summary>
		/// Displays the card value
		/// </summary>
		/// <returns>A string as "Ace of Spades" <see cref="Display"/></returns>
        public override string ToString() {
            return this.Display();
        }
		/// <summary>
		/// Constructor for suite and rank
		/// </summary>
		/// <param name="suite">A Suite</param>
		/// <param name="rank">A Rank <see cref="Rank"/></param>
        public Card(Suite suite, Rank rank) {
            this.Suite = suite;
            this.Rank = rank;
			this.isShowing = false;
        }
		/// <summary>
		/// Default constructor
		/// </summary>
        public Card() {
        }
    }
	/// <summary>
	/// Suites. Diamonds, Hearts, Clubs, Spades
	/// </summary>
    public enum Suite {
        Diamonds, Hearts, Clubs, Spades
    };
	/// <summary>
	/// Ranks. Two, Five, Ten, Jack, Queen, King, Ace
	/// </summary>
    public enum Rank {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    };
}
