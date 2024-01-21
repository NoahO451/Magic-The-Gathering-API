using System.ComponentModel.DataAnnotations;

namespace MagicTheGathering.API.Models
{
    public class Deck
    {
        [Required]
        public int DeckID { get; set; }

        public string DeckName { get; set; }

        public string DeckCommander {  get; set; }

        public List<Card> Cards { get; set; }
    }
}
