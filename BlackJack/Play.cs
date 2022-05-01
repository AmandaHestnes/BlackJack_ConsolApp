namespace BlackJack
{
    public class Play
    {
        Deck deck = new Deck();
        private Player _player;
        private Dealer _dealer;
        public Play()
        {
            Intro();
            _player = new Player(deck);
            _dealer = new Dealer(deck);
            StartGame();
        }
        private void Intro()
        {
            System.Console.WriteLine("Let's play Blackjack");
        }
        private void StartGame()
        {
            _player.Play();
            if(_player.cardTotal > 21)
            {
                EndGame();
            }
            else
            {
                _dealer.Play();
                EndGame();
            }
        }
        private void EndGame()
        {

            if (_dealer.cardTotal >= _player.cardTotal && _dealer.cardTotal <= 21 || _player.cardTotal > 21)
            {
                System.Console.WriteLine("\nDealer wins ");
            }
            else if(_player.cardTotal <= 21)
            {
                System.Console.WriteLine("\nYou winn !!!!");
            }
        }
    }
}
