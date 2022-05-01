using System;
using System.Linq;
using NUnit.Framework;

namespace BlackJack.Tests
{
    internal class Play : Scenario
    {
        private Deck _deck;
        private Player _player;
        public override void Given()
        {
            _deck = new Deck();
            _player = new Player(_deck);
        }
        [Test]
        public void Draw_5_cards_should_have_47_cards_left_in_deck()
        {
            for (int i = 0; i < 5; i++)
            {
                _player.DrawCard();
            }
            Assert.AreEqual(47, _deck.Cards.Count);
        }
        [Test]
        public void Dealer_should_not_draw_new_card()
        {
            // Given
            Dealer dealer = new Dealer(_deck);
            dealer.cardTotal = 17;

            //When
            dealer.Play();

            //Then
            Assert.AreEqual(17, dealer.cardTotal);
        }

        [Test]
        [TestCase(Suit.Spades, 11, "J")]
        [TestCase(Suit.Spades, 12, "Q")]
        [TestCase(Suit.Spades, 13, "K")]
        [TestCase(Suit.Spades, 1,  "A")]
        [TestCase(Suit.Spades, 2,  "2")]
        public void Picture_cards_should_return_J_Q_K_A(Suit suit, int rank, string expectedResult)
        {
            //Given
            Card card = new Card()
            {
                Suit = suit,
                Rank = rank,
            };
            //When
            string noe = _deck.Rank(card);
            //Then
            Assert.AreEqual(expectedResult, noe);
        }
        [Test]
        public void Player_should_have_5_cards_on_hand()
        {
            for (int i = 0; i < 5; i++)
            {
                _player.DrawCard();
            }
            Assert.AreEqual(5, _player.Hand.Count);
        }
        [Test]
        public void Dealer_should_have_6_cards_on_hand()
        {
            //Given
            Dealer dealer = new Dealer(_deck);
            //When
            for (int i = 0; i < 5; i++)
            {
                dealer.DrawCard();
            }
            //Then
            Assert.AreEqual(6, dealer.Hand.Count);
        }

    }
}
