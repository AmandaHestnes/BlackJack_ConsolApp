using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        public List<Card> Cards;
        public Deck()
        {
            Cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    Cards.Add(new Card() { Rank = i, Suit = suit });
                }
            }

        }
        public Card DrawCard()
        {
            int cardIndex = Random();

            Card card = Cards[cardIndex];
            RemoveCard(cardIndex);
            return card;
        }

        private int Random()
        {
            Random randomNumber = new Random();
            int number = randomNumber.Next(0, Cards.Count);
            return number;
        }
        private void RemoveCard(int index)
        {
            Cards.RemoveAt(index);
        }
        public string Rank(Card card)
        {
            switch (card.Rank)
            {
                case 1:
                    return "A";
                case < 10:
                    return card.Rank.ToString();
                case 11:
                    card.Rank = 10;
                    return "J";
                case 12:
                    card.Rank = 10;
                    return "Q";
                case 13:
                    card.Rank = 10;
                    return "K";
            }
            return "";
        }
    }
}
