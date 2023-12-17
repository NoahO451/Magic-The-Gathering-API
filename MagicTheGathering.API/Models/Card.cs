using System.Text.Json.Serialization;

namespace MagicTheGathering.API.Models
{
    public class Card
    {
        public int CardId { get; set; }

        public string Name { get; set; }


        public string ImageUri { get; set; }

        public int ConvertedManaCost { get; set; }

        public ManaCost ManaCost { get; set; }

        public List<CardType> CardTypes { get; set; }

        public List<CardSubType> CardSubTypes { get; set; }

    }

    public class ManaCost
    {
        public int Colorless { get; set; }
        public int Black { get; set; }
        public int Blue { get; set; }
        public int White { get; set; }
        public int Green { get; set; }
        public int Red { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CardType
    {
        None = 0,
        Artifact = 1,
        Instant = 2,
        Creature = 3,
        Sorcery = 4
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CardSubType
    {
        None = 0,
        Angel = 1,
        Elf = 2,
        Druid = 3,
        Dragon = 4
    }
}
