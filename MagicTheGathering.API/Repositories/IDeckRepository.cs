using MagicTheGathering.API.Models;

namespace MagicTheGathering.API.Repositories
{
    public interface IDeckRepository
    {
        Deck GenerateDeck();

        ICollection<Deck> GetAllDecks();

        Deck GetDeckByID(int id);

        Deck DeleteDeckByID(int id);
    }
}
