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
        public string Name { get; set; }
        public string Code { get; set; }
        public int? CMC { get; set; }
        public int SetCode { get; set; }
        public int MCINumber { get; set; }
        public string ManaCost { get; set; }
        public int Id { get; set; }
        public string Flavor { get; set; }
        public int Number { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public MTGRarity Rarity { get; set; }
        public MTGLayout Layout { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Text { get; set; }
        public int MultiverseID { get; set; }
        public string Colors { get; set; }
        public string ColorIdentity { get; set; }
        public string Artist { get; set; }
        public string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + MultiverseID + "414376&type=card";
            }
        }

    }
}