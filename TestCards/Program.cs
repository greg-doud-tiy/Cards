using System;
using GregoryDoud;
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
            return Console.ReadLine().ToUpper().StartsWith("Y", StringComparison.Ordinal);
        }
        void Deal(Player player, Dealer dealer, Deck deck, int nbrOfCards) {
            for (int idx = 0; idx < nbrOfCards; idx++) {
                player.Add(deck.DrawFaceUp());
                if (idx == 0) {
                    dealer.Add(deck.Draw());
                } else {
                    dealer.Add(deck.DrawFaceUp());
                }
            }
        }
        void DisplayHand(Player player) {
            var str = string.Format("{0}: ", player.Name);
            var comma = string.Empty;
            foreach (Card card in player.Cards) {
                str += string.Format("{0} {1}", comma, card);
                comma = ",";
            }
            var validTotals = from t in player.Total() select t;
            var strTotals = string.Join(" or ", validTotals);
            str += string.Format(", total: {0}", strTotals);
            Log(str);
        }
        bool AskDrawOrStay(Player player, Deck deck) {
            Log("Draw? (Y/N): ");
            var draw = Console.ReadLine().ToUpper().StartsWith("Y", StringComparison.Ordinal);
            if (draw) {
                var card = deck.Draw();
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
                var card = deck.Draw();
                card.Flip();
                dealer.Add(card);
            }
            if (dealer.HasBusted()) {
                return -1;
            } else if (dealer.HasBlackjack()) {
                return 1;
            }
            return 0;
        }
        bool PlayBlackjack() {
            var deck = new Deck();
            deck.Shuffle();
            var dealer = new Dealer("Dealer");
            var player = new Player("Player");
            Deal(player, dealer, deck, 2);
            DisplayHand(dealer);
            var playerResult = PlayerTurn(player, deck);
            if (playerResult == -1) {
                return false;
            }
            var dealerResult = DealerTurn(dealer, deck);
            dealer.ShowAllCards();
            DisplayHand(dealer);
            // display result
            return player.BestHand() > dealer.BestHand();
        }
        void Log(object obj) {
            Console.WriteLine(obj);
            System.Diagnostics.Debug.WriteLine(obj.ToString());
        }
#pragma warning disable RECS0154 // Parameter is never used
        public static void Main(string[] args) {
#pragma warning restore RECS0154 // Parameter is never used
            new MainClass().run();
        }
    }
}
