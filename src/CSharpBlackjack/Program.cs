using CSharpBlackjack.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpBlackjack //fix .CustomClasses later
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //generates a new deck and then shuffles it (add multiple decks later)
            var deck1 = new Deck();
            deck1.Shuffle();

            //asks user for number of players
            Console.WriteLine("Welcome! How many players will be playing?");
            int playerCount = int.Parse(Console.ReadLine());

            //creates a new list to hold Players
            List<Player> PlayerPool = new List<Player>();
//------------------------------------------------------------------------Deal (maybe add to Utility Class-------------------------------------------------------------------------//
            //adds new Player to PlayerPool for each player in game and draws 2 cards for each player
            for (int i = 0; i < playerCount; i++)
            {
                Player player = new Player() { Id = i + 1, PlayerHand = deck1.Cards.GetRange(0, 2), TotalValue = deck1.Cards[0].Value + deck1.Cards[1].Value };
                PlayerPool.Add(player);
                deck1.Cards.RemoveRange(0, 2);

                //displays each player's hands and their total value
                Console.WriteLine("Player {0} first card: {1} of {2}", player.Id, player.PlayerHand[0].Face, player.PlayerHand[0].Suit);
                Console.WriteLine("Player {0} second card: {1} of {2}\nPlayer {0} Total:{3}\n", player.Id, player.PlayerHand[1].Face, player.PlayerHand[1].Suit, player.TotalValue);
            }

            //creates dealer Player and draws 2 cards
            Player dealer = new Player() { Id = 0, PlayerHand = deck1.Cards.GetRange(0, 2) };
            deck1.Cards.RemoveRange(0, 2);
            Console.WriteLine("Dealer first card: {0} of {1}", dealer.PlayerHand[0].Face, dealer.PlayerHand[0].Suit);
            Console.WriteLine("Dealer second card is face down\n"); //dealer still has two cards but the second isn't shown to the players until after HitOrStay()

            //loop that asks each player if he wants to hit or stay
            while (PlayerPool[0].TotalValue < 21 || PlayerPool[1].TotalValue < 21) //currently only works for 2 players
            {
                foreach (Player p in PlayerPool)
                {
                    //if player has < 21, ask to hit or stand
                    if (p.TotalValue < 21)
                    {
                        Console.WriteLine("Player {0}, you have {1}. Would you like to hit or stand?", p.Id, p.TotalValue);
                        var response = Console.ReadLine();
                        if (response == "hit")
                        {
                            p.PlayerHand.Add(deck1.Cards[0]);
                            p.TotalValue += deck1.Cards[0].Value;
                            deck1.Cards.Remove(deck1.Cards[0]);
                            Console.WriteLine("Player {0} first card: {1} of {2}", p.Id, p.PlayerHand[0].Face, p.PlayerHand[0].Suit);
                            Console.WriteLine("Player {0} second card: {1} of {2}", p.Id, p.PlayerHand[1].Face, p.PlayerHand[1].Suit, p.TotalValue);
                            Console.WriteLine("Player {0} third card: {1} of {2}\nPlayer {0} Total:{3}\n", p.Id, p.PlayerHand[2].Face, p.PlayerHand[2].Suit, p.TotalValue);
                        }
                    }

                    //if player has greater than 21, print loss
                    else if (p.TotalValue > 21)
                    {
                        Console.WriteLine("player[i], you lose. Total Value: _");
                    }
                    //if player has 21, print win
                    else if (p.TotalValue == 21)
                    {
                        Console.WriteLine("player[i] you got blackjack!");
                    }
                }
            }
            Console.ReadLine();
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        }
    }
}
