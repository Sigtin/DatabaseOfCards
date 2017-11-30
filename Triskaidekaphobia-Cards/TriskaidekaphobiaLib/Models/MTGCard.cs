using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriskaidekaphobiaLib.Models;

namespace TriskaidekaphobiaLib.Models
{
    public enum MTGRarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        MYTHIC_RARE,
        BASIC_LAND,
        SPECIAL
    }

    public enum MTGLayout
    {
        NORMAL,
        FLIP,
        TOKEN,
        SPLIT,
        DOUBLE_FACED,
        PHENOMINON,
        PLANE,
        LEVELER,
        VANGUARD,
        AFTERMATH,
        MELD,
        SCHEME
    }
    public class MTGCard
    {
        public string Name { get; set; }
        public double CMC { get; set; }
        public string MCINumber { get; set; }
        public string ManaCost { get; set; }
        public string Id { get; set; }
        public string Flavor { get; set; }
        //public int CardNumber { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public MTGRarity Rarity { get; set; }
        public MTGLayout Layout { get; set; }
        public List<string> Types { get; set; } = new List<string>();
        public List<string> Subtypes { get; set; } = new List<string>();
        public string Text { get; set; }
        public int MultiverseId { get; set; }
        public List<string> Colors { get; set; } = new List<string>();
        public List<string> ColorIdentity { get; set; } = new List<string>();
        public string Artist { get; set; }
        public List<string> Printings { get; set; }
    }
}
