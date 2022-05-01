using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Player
    {
        private List<Card> _hand = new List<Card>();
        public int cardTotal = 0;
        public Deck deck;

        public List<Card> Hand { get { return _hand; } }

        public Player(Deck deck)
        {
            this.deck = deck;
        }
        public void Play()
        {
            while (true)
            {
                Console.WriteLine("Stand, Hit");
                string read = Console.ReadLine().ToLower();
                if (read == "hit" || read == "h")
                {
                    DrawCard();
                    if (cardTotal > 21)
                    {
                        Console.WriteLine("Your total is greater than 21");
                        break;
                    }
                }
                else if (read == "stand" || read == "s")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again");
                }
            }
        }
        public void DrawCard()
        {
            var newCard = deck.DrawCard();
            _hand.Add(newCard);
            string rank = deck.Rank(newCard);
            if (newCard.Rank == 1 && cardTotal < 10)
            {
                newCard.Rank = 11;
            }
            cardTotal = _hand.Sum(x => Math.Min(x.Rank, 11));
            ConsoleWrite(newCard.Suit, rank, cardTotal);
        }
        public virtual void ConsoleWrite(Suit Suit, string Rank, int CardTotal)
        {
            Console.WriteLine("Player: Hit with {0} of {1}. Total is {2}", Rank, Suit, CardTotal);
        }
    }
}

