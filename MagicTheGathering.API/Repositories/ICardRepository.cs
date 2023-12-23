using MagicTheGathering.API.Models;

namespace MagicTheGathering.API.Repositories
{
    public interface ICardRepository
    {
        ICollection<Card> GetAllCards();
        Card AddCard(Card card);
    }
}
