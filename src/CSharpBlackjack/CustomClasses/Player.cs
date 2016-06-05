using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpBlackjack.CustomClasses
{
    public class Player
    {
        public int Id { get; set; }
        public List<Card> PlayerHand { get; set; }
        public int TotalValue { get; set; }

        //public HitOrStay()
        //{
        //    Console.WriteLine("Your current hand is _. Would you like to hit or stay?");
        //    string Response = Console.ReadLine();
        //    //if (Response == "hit"
        //    //{HandCards.Add(Cards[0])}
        //    //else {next player};
        //}
    }
}
