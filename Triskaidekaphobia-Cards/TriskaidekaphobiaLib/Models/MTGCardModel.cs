using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    public class MTGCardModel
    {
        public string Card_Name { get; set; }
        public int? CMC { get; set; }
        public string MCI_Number { get; set; }
        public string Mana_Cost { get; set; }
        public string Card_Id { get; set; }
        public string Flavor_Text { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public MTGRarity Card_Rarity { get; set; }
        public MTGLayout Card_Layout { get; set; }
        public string Card_Type { get; set; }
        public string Card_Subtype { get; set; }
        public string Card_Text { get; set; }
        public int Multiverse_ID { get; set; }
        public string Card_Colors { get; set; }
        public string Card_Color_Identity { get; set; }
        public string Card_Artist { get; set; }
        public string Sets { get; set; }

        public string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + this.Multiverse_ID + "&type=card";
            }
        }

    }
}