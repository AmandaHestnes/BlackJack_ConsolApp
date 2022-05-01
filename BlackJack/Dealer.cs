using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Dealer : Player
    {

        public Dealer(Deck deck) : base(deck)
        {
            DrawCard();
        }
        public new void Play()
        {
            while (cardTotal < 17)
            {
                DrawCard();
            }
        }
        private new void DrawCard()
        {
            base.DrawCard();
        }
        public override void ConsoleWrite(Suit Suit, string Rank, int CardTotal)
        {
            Console.WriteLine("Dealer: {0} of {1}. Total is {2}", Rank, Suit, CardTotal);
        }
    }
}
