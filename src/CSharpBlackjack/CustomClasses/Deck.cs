using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpBlackjack.CustomClasses
{

    public class Deck
    {
        public List<Card> Cards { get; set; }
        public static string[] Suits = { "Spades", "Clubs", "Hearts", "Diamonds" };
        public static string[] Faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        public static int[] Values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

        public Deck()
        {
            Cards = new List<Card>();
            for (int i = 0; i < Suits.Length; i++)
            {
                for (int j = 0; j < Faces.Length; j++)
                {
                    Card card = new Card();
                    card.Face = Faces[j];
                    card.Suit = Suits[i];
                    card.Value = Values[j];
                    Cards.Add(card);
                    //Console.WriteLine("{0} of {1}", card.Face, card.Suit);
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            int n = Cards.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(random.NextDouble() * (n - i));
                Card card = Cards[r];
                Cards[r] = Cards[i];
                Cards[i] = card;
            }
        }
    }
}

