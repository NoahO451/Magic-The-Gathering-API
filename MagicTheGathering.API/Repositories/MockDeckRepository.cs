using MagicTheGathering.API.Models;

namespace MagicTheGathering.API.Repositories
{
    public class MockDeckRepository : IDeckRepository
    {
        public List<Deck> decks;

        private ICardRepository _cardRepository;

        public MockDeckRepository(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
            decks = new List<Deck>();
        }

        public Deck GenerateDeck()
        {
            var deck = new Deck();
            var cards = _cardRepository.GetAllCards();

            if (decks.Count == 0)
            {
                deck.DeckID = 1;
            } 
            else
            {
                deck.DeckID = decks.Count + 1;
            }
            decks.Add(deck);
            return deck;
        }
    }
}
