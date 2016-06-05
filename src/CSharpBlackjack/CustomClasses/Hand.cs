using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpBlackjack.CustomClasses
{
    public class Hand
    {
        public List<Card> HandCards { get; set; }
        public int TotalValue { get; set; }

        //public Hand()
        //{
        //    HandCards = new List<Card>();
        //}
    }
}
