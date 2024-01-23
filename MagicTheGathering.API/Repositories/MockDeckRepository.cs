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

            //find every card in cards with the property type of 1 and make a list out of them
            //find the number of cards in the new list
            //random.next(number of cards) and set deck.DeckCommander as that number
        public Deck GenerateDeck()
        {
            var deck = new Deck();
            deck.Cards = new List<Card>();
            var cards = _cardRepository.GetAllCards();
            var legendCards = new List<Card>();
            var allCards = new List<Card>();
            Random random = new Random();

            //incrementally increases deck id by 1 for each new deck
            if (decks.Count == 0)
            {
                deck.DeckID = 1;
            } 
            else
            {
                deck.DeckID = decks.Count + 1;
            }

            //creates a new list of all legendary cards from the full card list to make the commander
            foreach (var card in cards)
            {
                if(card.CardTypes.Contains(CardType.LegendaryCreature))
                {
                    legendCards.Add(card);
                }
            }

            var commander = legendCards[random.Next(legendCards.Count)];
            deck.Cards.Add(commander);
            deck.DeckCommander = commander.Name;

            //creates a list of all available cards so that it can be indexed in the while loop
            foreach (var card in cards)
            {
                {
                    allCards.Add(card);
                }
            }

            //fills out the remaining cards with a random card that is currently not in the deck.
            while (deck.Cards.Count < 100)
            {
                var tempCard = allCards[random.Next(allCards.Count)];

                if (!deck.Cards.Contains(tempCard))
                {
                    deck.Cards.Add(tempCard);
                }
            }

            //sets deck name
            deck.DeckName = $"{commander.Name}_ID:{deck.DeckID}";

            decks.Add(deck);
            return deck;
        }
    }
}
