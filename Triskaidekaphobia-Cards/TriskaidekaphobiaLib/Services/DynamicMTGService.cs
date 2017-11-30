using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTGDAL;
using TriskaidekaphobiaLib.Models;

namespace TriskaidekaphobiaLib.Services
{
    public class DynamicMTGService
    {
        public MTGCardList GetAllMagicCards()
        {
            MTGCardList model = new MTGCardList();
            using (var db = new TCGEntities3())
            {
                var query = db.MTG_Card.Select(x => x);
                var cardList = query.ToList();
                cardList.ForEach(card => model.Cards.Add(new MTGCard()
                {
                    Name = card.card_name,
                    CMC = (double)card.cmc,
                    MCINumber = card.mci_number,
                    ManaCost = card.mana_cost,
                    Id = card.card_id,
                    Flavor = card.flavor_text,
                    Power = card.power,
                    Toughness = card.toughness,
                    Rarity = (MTGRarity)Enum.Parse(typeof(MTGRarity), card.card_rarity),
                    Layout = (MTGLayout)Enum.Parse(typeof(MTGLayout), card.card_layout),
                    Types = card.card_type.Split(' ').ToList(),
                    Subtypes = card.card_subtype.Split(' ').ToList(),
                    Text = card.card_text,
                    MultiverseId = (int)card.multiverse_id,
                    Colors = card.card_colors.Split(' ').ToList(),
                    ColorIdentity = card.card_color_identity.Split(' ').ToList(),
                    Artist = card.card_artist,
                    Printings = card.sets.Split(' ').ToList(),
                    Image = ""
                }));
            }
            return model;
        }
    }
}
