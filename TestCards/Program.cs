using System;
using GregoryDoud;

namespace TestCards {
    
    class MainClass {
    
        void run() {
            Deck deck = new Deck();
            while (deck.Count() > 0) {
                Card card = deck.Draw();
                Log(card);
            }
        }
        void Log(object obj) {
            Console.WriteLine(obj.ToString());
        }
        public static void Main(string[] args) {
            new MainClass().run();
        }
    }
}
