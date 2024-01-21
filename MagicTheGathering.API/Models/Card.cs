using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MagicTheGathering.API.Models
{
    public class Card
    {

        [Required]
        public int CardId { get; set; }

        public string Name { get; set; }

        public string ImageUri { get; set; }

        public int ConvertedManaCost{ get; set; }

        public ManaCost ManaCost { get; set; }

        public List<CardType> CardTypes { get; set; }

        public List<CardSubType>? CardSubTypes { get; set; }
    }

    public class ManaCost
    {
        public int Colorless { get; set; }
        public int White { get; set; }
        public int Blue { get; set; }
        public int Black { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CardType
    {
        None = 0,
        LegendaryCreature = 1,
        Dragon = 2,
        ElfCleric = 3,
        HumanWizard = 4,
        Sphinx = 5,
        DemonBerserker = 6,
        LegendaryPlaneswalker = 7,
        Ajani = 8,
        Creature = 9,
        Archon = 10,
        BirdWarrior = 11,
        Enchantment = 12,
        Bird = 13,
        Sorcery = 14,
        Instant = 15,
        Angel = 16,
        Gideon = 17,
        Spirit = 18,
        BirdSoldier = 19,
        HumanSoldier = 20,
        SpiritCleric = 21,
        Aura = 22,
        Turtle = 23,
        LegendaryEnchantmentArtifact = 24,
        Avatar = 25,
        ZombieWizard = 26,
        Faerie = 27,
        ZombieHorror = 28,
        ArtifactCreature = 29,
        Drake = 30,
        BirdWizard = 31,
        Demon = 32,
        Zombie = 33,
        AuraCurse = 34,
        ZombieWarrior = 35,
        ZombieKnight = 36,
        ZombieBeast = 37,
        Liliana = 38,
        HumanWarlock = 39,
        ZombieGiant = 40,
        ZombieMerfolk = 41,
        Nixilis = 42,
        VampireShaman = 43,
        ZombieDragon = 44,
        Specter = 45,
        HumanWarrior = 46,
        ZombieCleric = 47,
        Goblin = 48,
        Construct = 49,
        DragonWizard = 50,
        HumanBerserker = 51,
        GoblinShaman = 52,
        HumanShaman = 53,
        HumanBarbarianShaman = 54,
        Elemental = 55,
        OgreWarrior = 56,
        Sarkhan = 57,
        ElementalGiant = 58,
        Devil = 59,
        HumanMonk = 60,
        HumanDruid = 61,
        BasicLand = 62
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CardSubType
    {
        None = 0,
        Dragon = 1,
        Elf = 2,
        Cleric = 3,
        Human = 4,
        Wizard = 5,
        Sphinx = 6,
        Demon = 7,
        Berserker = 8,
        Ajani = 9,
        Archon = 10,
        Bird = 11,
        Warrior = 12,
        Angel = 13,
        Gideon = 14,
        Spirit = 15,
        Soldier = 16,
        Aura = 17,
        Turtle = 18,
        Avatar = 19,
        Zombie = 20,
        Faerie = 21,
        Horror = 22,
        Drake = 23,
        Curse = 24,
        Knight = 25,
        Beast = 26,
        Liliana = 27,
        Warlock = 28,
        Giant = 29,
        Merfolk = 30,
        Nixilis = 31,
        Vampire = 32,
        Shaman = 33,
        Specter = 34,
        Goblin = 35,
        Construct = 36,
        Barbarian = 37,
        Elemental = 38,
        Ogre = 39,
        Sarkhan = 40,
        Devil = 41,
        Monk = 42,
        Druid = 43,
        Island = 44, 
        Mountain = 45, 
        Plain = 46, 
        Swamp = 47, 
        Forest = 48
    }
}
