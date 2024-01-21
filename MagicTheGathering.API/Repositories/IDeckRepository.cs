using MagicTheGathering.API.Models;

namespace MagicTheGathering.API.Repositories
{
    public interface IDeckRepository
    {
        Deck GenerateDeck();
    }
}
