using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triskaidekaphobia_Cards.Models;
using MTGDAL;

namespace Triskaidekaphobia_Cards.Services
{
    public class MTGCardService
    {
        public MTGCardListModel GetAllMTGCards()
        {
            MTGCardListModel model = new MTGCardListModel();

            using (var db = new TCGEntities())
            {
                var query = db.MTG_Card.Select(x => x);
                var cardList = query.ToList();

                cardList.ForEach(card => model.MTGCards.Add(new MTGCardModel()
                {
                    Card_Name = card.card_name,
                    CMC = card.cmc,
                    MCI_Number = card.mci_number,
                    Mana_Cost = card.mana_cost,
                    Card_Id = card.card_id,
                    Flavor_Text = card.flavor_text,
                    Power = card.power,
                    Toughness = card.toughness,
                    Card_Rarity = (MTGRarity)Enum.Parse(typeof(MTGRarity), card.card_rarity),
                    Card_Layout = (MTGLayout)Enum.Parse(typeof(MTGLayout), card.card_layout),
                    Card_Type = card.card_type,
                    Card_Subtype = card.card_subtype,
                    Card_Text = card.card_text,
                    Multiverse_ID = card.multiverse_id,
                    Card_Colors = card.card_colors,
                    Card_Color_Identity = card.card_color_identity,
                    Card_Artist = card.card_artist,
                    Sets = card.sets
                }));
            }

            return model;
        }
    }
}