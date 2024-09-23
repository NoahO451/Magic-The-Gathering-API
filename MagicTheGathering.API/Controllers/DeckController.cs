using MagicTheGathering.API.Models;
using MagicTheGathering.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MagicTheGathering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : Controller
    {
        private IDeckRepository _deckRepository;

        public DeckController(IDeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }

        [HttpPost ("GenerateDeck")]
        public async Task<IActionResult> GenerateDeck()
        {
            try
            {
                var newDeck = _deckRepository.GenerateDeck();

                return Ok(newDeck); 
            }
            catch (Exception) 
            {
                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpGet ("GetAllDecks")]
        public async Task<IActionResult> GetAllDecks()
        {
            try
            {
                var decks = _deckRepository.GetAllDecks();
                return Ok(decks);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpGet ("GetDeckByID")]

        public async Task<IActionResult> GetDeckByID(int id)
        {
            try
            {
                var deck = _deckRepository.GetDeckByID(id);
                return Ok(deck);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong.");
            }
        }
        [HttpPost ("DeleteDeckByID")]
        public async Task<IActionResult> DeleteDeckByID(int id)
        {
            try
            {
                var deck = _deckRepository.DeleteDeckByID(id);
                return Ok($"The deck with ID: {id} has been successfully removed form the decks list.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}
