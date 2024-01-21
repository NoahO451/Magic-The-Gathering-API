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

        [HttpPost]
        public async Task<IActionResult> GenerateDeck()
        {
            try
            {
                var newDeck = _deckRepository.GenerateDeck();

                return Ok(newDeck); //come back here and figure out how I want to return the deck and status of failed or success
            }
            catch (Exception) 
            {
                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}
