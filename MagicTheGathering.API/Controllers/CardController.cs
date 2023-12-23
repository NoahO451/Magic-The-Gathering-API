using MagicTheGathering.API.Models;
using MagicTheGathering.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace MagicTheGathering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private ICardRepository _cardRepository;
        
        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = _cardRepository.GetAllCards();

            return Ok(cards);
        }

        [HttpPost("AddCard")]
        public async Task<IActionResult> AddCard(Card card)
        {

            var  newCard = _cardRepository.AddCard(card);

            return Ok(newCard);
        }
    }
}

