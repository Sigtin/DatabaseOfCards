using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triskaidekaphobia.Models;
//using MTGDAL;


namespace Triskaidekaphobia.Services
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
            testCard.MCI_Number = "146";
            testCard.Multiverse_ID = 389541;
            testCard.Power = "2";
            testCard.Toughness = "4";
            testCard.Image = testCard.Multiverse_ID + "";
            model.MTGCards.Add(testCard);

            //using (var db = new TCGEntities())
            //{
            //    var query = db.MTG_Card.Select(x => x);
            //    var cardList = query.ToList();

            //    cardList.ForEach(card => model.MTGCards.Add(new MTGCardModel()
            //    {
            //        Card_Name = card.card_name,
            //        CMC = card.cmc,
            //        MCI_Number = card.mci_number,
            //        Mana_Cost = card.mana_cost,
            //        Card_Id = card.card_id,
            //        Flavor_Text = card.flavor_text,
            //        Power = card.power,
            //        Toughness = card.toughness,
            //        Card_Rarity = (MTGRarity)Enum.Parse(typeof(MTGRarity), card.card_rarity),
            //        Card_Layout = (MTGLayout)Enum.Parse(typeof(MTGLayout), card.card_layout),
            //        Card_Type = card.card_type,
            //        Card_Subtype = card.card_subtype,
            //        Card_Text = card.card_text,
            //        Multiverse_ID = card.multiverse_id,
            //        Card_Colors = card.card_colors,
            //        Card_Color_Identity = card.card_color_identity,
            //        Card_Artist = card.card_artist,
            //        Sets = card.sets
            //    }));
            //}

            return model;
        }
    }
}