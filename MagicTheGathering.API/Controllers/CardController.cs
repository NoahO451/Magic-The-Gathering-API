using MagicTheGathering.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace MagicTheGathering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        public List<Card> cards;
        public CardController()
        {
            cards = new List<Card>
            {
                new Card { CardId = 1, Name = "Sol Ring", ImageUri = "", ConvertedManaCost = 1, ManaCost = new ManaCost { Colorless = 1 }, CardTypes = new List<CardType> { CardType.Artifact }, CardSubTypes = new List<CardSubType> { CardSubType.None } },
                new Card { CardId = 2, Name = "Lightning Bolt", ImageUri = "", ConvertedManaCost = 1, ManaCost = new ManaCost { Red = 1 }, CardTypes = new List<CardType> { CardType.Instant }, CardSubTypes = new List<CardSubType> { CardSubType.None } },
                new Card { CardId = 3, Name = "Counterspell", ImageUri = "", ConvertedManaCost = 2, ManaCost = new ManaCost { Blue = 1, Colorless = 1 }, CardTypes = new List<CardType> { CardType.Instant }, CardSubTypes = new List<CardSubType> { CardSubType.None } },
                new Card { CardId = 4, Name = "Giant Growth", ImageUri = "", ConvertedManaCost = 1, ManaCost = new ManaCost { Green = 1 }, CardTypes = new List<CardType> { CardType.Instant }, CardSubTypes = new List<CardSubType> { CardSubType.None } },
                new Card { CardId = 5, Name = "Serra Angel", ImageUri = "", ConvertedManaCost = 4, ManaCost = new ManaCost { White = 3, Colorless = 1 }, CardTypes = new List<CardType> { CardType.Creature }, CardSubTypes = new List<CardSubType> { CardSubType.Angel } },
                new Card { CardId = 6, Name = "Dark Ritual", ImageUri = "", ConvertedManaCost = 1, ManaCost = new ManaCost { Black = 1 }, CardTypes = new List<CardType> { CardType.Sorcery }, CardSubTypes = new List<CardSubType> { CardSubType.None } },
                new Card { CardId = 7, Name = "Llanowar Elves", ImageUri = "", ConvertedManaCost = 1, ManaCost = new ManaCost { Green = 1 }, CardTypes = new List<CardType> { CardType.Creature }, CardSubTypes = new List<CardSubType> { CardSubType.Elf, CardSubType.Druid } },
                new Card { CardId = 8, Name = "Shivan Dragon", ImageUri = "", ConvertedManaCost = 6, ManaCost = new ManaCost { Red = 3, Colorless = 3 }, CardTypes = new List<CardType> { CardType.Creature }, CardSubTypes = new List<CardSubType> { CardSubType.Dragon } },
                new Card { CardId = 9, Name = "Swords to Plowshares", ImageUri = "", ConvertedManaCost = 1, ManaCost = new ManaCost { White = 1 }, CardTypes = new List<CardType> { CardType.Instant }, CardSubTypes = new List<CardSubType> { CardSubType.None } },
                new Card { CardId = 10, Name = "Ancestral Recall", ImageUri = "", ConvertedManaCost = 1, ManaCost = new ManaCost { Blue = 1 }, CardTypes = new List<CardType> { CardType.Instant }, CardSubTypes = new List<CardSubType> { CardSubType.None } },
            };
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            return Ok(cards);
        }

        [HttpPost("AddCard")]
        public async Task<IActionResult> AddCard(Card card)
        {
            Card newCard = new Card { CardId = 11, Name = "Sol Ring", ImageUri = "", ConvertedManaCost = 1, ManaCost = new ManaCost { Colorless = 1 }, CardTypes = new List<CardType> { CardType.Artifact }, CardSubTypes = new List<CardSubType> { CardSubType.None } };
            
            cards.Add(newCard);

            return Ok(cards);
        }
    }
}

