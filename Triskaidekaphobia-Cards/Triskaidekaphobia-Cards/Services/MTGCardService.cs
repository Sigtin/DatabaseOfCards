using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triskaidekaphobia_Cards.Models;

namespace Triskaidekaphobia_Cards.Services
{
    public class MTGCardService
    {
        public MTGCardListModel GetAllMTGCards()
        {
            MTGCardListModel model = new MTGCardListModel();

            MTGCardModel testCard = new MTGCardModel();
            testCard.Card_Artist = "Robbie Trevino";
            testCard.Card_Colors = "Black";
            testCard.Card_Color_Identity = "B";
            testCard.Card_Id = "9a77d560bc690a7a44ac7fb88b99ae3e57a63fc9";
            testCard.Card_Layout = MTGLayout.NORMAL;
            testCard.Card_Name = "Gray Merchant of Asphodel";
            testCard.Card_Rarity = MTGRarity.COMMON;
            testCard.Card_Subtype = "Zombie";
            testCard.Card_Text = "When Gray Merchant of Asphodel enters the battlefield, each opponent loses X life, where X is your devotion to black. You gain life equal to the life lost this way. (Each {B} in the mana costs of permanents you control counts toward your devotion to black.)";
            testCard.Card_Type = "Creature — Zombie";
            testCard.CMC = 5;
            testCard.Flavor_Text = "";
            testCard.Mana_Cost = "{3}{B}{B}";
            testCard.MCI_Number = 146;
            testCard.Multiverse_ID = 389541;
            testCard.Power = "2";
            testCard.Toughness = "4";
            testCard.Image = testCard.Multiverse_ID+"";
            model.MTGCards.Add(testCard);

            return model;
        }
    }
}