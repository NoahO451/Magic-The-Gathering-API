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

        [HttpGet("GetAllCards")]
        public async Task<IActionResult> GetAllCards()
        {
            try
            {
                var cards = _cardRepository.GetAllCards();

                var cardList = cards.Result;

                return Ok(cardList);

            }
            catch (Exception)
            {

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpPost("AddCard")]
        public async Task<IActionResult> AddCard(Card card)
        {

            var  newCard = _cardRepository.AddCard(card);

            return Ok(newCard);
        }

        [HttpGet("GetCardByID")]
        public async Task<IActionResult> GetCardByID(int id)
        {
            try
            {
                Task<Card> taskCard = _cardRepository.GetCardById(id);

                Card card = taskCard.Result;

                return Ok(card);
            }
            catch (Exception)
            {

                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}

