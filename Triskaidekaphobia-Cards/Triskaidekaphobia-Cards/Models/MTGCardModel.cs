using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Triskaidekaphobia_Cards.Models
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

    public class MTGCardModel
    {
        string Name { get; set; }
        string Code { get; set; }
        int CMC { get; set; }
        int MCINumber { get; set; }
        string ManaCost { get; set; }
        int Id { get; set; }
        string Flavor { get; set; }
        int Number { get; set; }
        string Power { get; set; }
        string Toughness { get; set; }
        MTGRarity Rarity { get; set; }
        MTGLayout Layout { get; set; }
        string Type { get; set; }
        string Subtype { get; set; }
        string Text { get; set; }
        int MultiverseID { get; set; }
        string Colors { get; set; }
        string ColorIdentity { get; set; }
        string Artist { get; set; }
    }
}