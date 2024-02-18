using MagicTheGathering.API.Models;

namespace MagicTheGathering.API.Repositories
{
    public interface ICardRepository
    {
        Task<ICollection<Card>> GetAllCards();

        Task<Card> AddCard(Card card);

        Task<bool> RemoveCard(int id);

        Task<Card> GetCardById(int id);

        Task<bool> UpdateCard(Card card);
    }
}
