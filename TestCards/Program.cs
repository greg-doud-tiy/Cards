using System;
using GregoryDoud;
using System.Collections.Generic;
using System.Linq;

namespace TestCards {
    
    class MainClass {

		void run() {
			bool quit = false;
			bool isWinner;
			do {
				isWinner = PlayBlackjack();
				Log((isWinner) ? "Winner!" : "Loser...");
				quit = AskToQuit();
			} while (!quit);
		}
		bool AskToQuit() {
			Log("Quit? (Y/N) ");
			return Console.ReadLine().ToUpper().StartsWith("Y");
		}
		void Deal(Player player, Dealer dealer, Deck deck, int nbrOfCards) {
			for(int idx = 0; idx < nbrOfCards; idx++) {
				player.Add(deck.DrawFaceUp());
				if (idx == 0) {
					dealer.Add(deck.Draw());
				} else {
					dealer.Add(deck.DrawFaceUp());
				}
			}
		}
		void DisplayHand(Player player) {
			var str = String.Format("{0}: ", player.Name);
			var comma = string.Empty;
			foreach(Card card in player.Cards) {
				str += String.Format("{0} {1}", comma, card);
				comma = ",";
			}
			var validTotals = from t in player.Total() select t; 
			var strTotals = String.Join(" or ", validTotals);
			str += String.Format(", total: {0}", strTotals);
			Log(str);
		}
		bool AskDrawOrStay(Player player, Deck deck) {
			Log("Draw? (Y/N): ");
			var draw = Console.ReadLine().ToUpper().StartsWith("Y");
			if(draw) {
				Card card = deck.Draw();
				card.Flip();
				player.Add(card);
			}
			return draw;
		}
		int PlayerTurn(Player player, Deck deck) {
			var drewCard = false;
			do {
				DisplayHand(player);
				drewCard = AskDrawOrStay(player, deck);
			} while (drewCard);
			if (player.HasBusted()) {
				return -1;
			} else if (player.HasBlackjack()) {
				return 1;
			}
			return 0;
		}
		int DealerTurn(Dealer dealer, Deck deck) {
			// display all dealer cards
			dealer.ShowAllCards();
			while (dealer.MustDraw()) {
				Card card = deck.Draw();
				card.Flip();
				dealer.Add(card);
			}
			if (dealer.HasBusted()) {
				return -1;
			} else if(dealer.HasBlackjack()) {
				return 1;
			}
			return 0;
		}
		bool PlayBlackjack() { 
            Deck deck = new Deck();
			deck.Shuffle();
			Dealer dealer = new Dealer("Dealer");
			Player player = new Player("Player");
			Deal(player, dealer, deck, 2);
			DisplayHand(dealer);
			int playerResult = PlayerTurn(player, deck);
			if (playerResult == -1) {
				return false;
			} 
			int dealerResult = DealerTurn(dealer, deck);
			dealer.ShowAllCards();
			DisplayHand(dealer);
			// display result
			return player.BestHand() > dealer.BestHand();
		}
		void Log(object obj) {
            Console.WriteLine(obj.ToString());
			System.Diagnostics.Debug.WriteLine(obj.ToString());
        }
        public static void Main(string[] args) {
            new MainClass().run();
        }
    }
}
