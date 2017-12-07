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
            using (var db = new TCGEntities())
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
                    Rarity = card.card_rarity,
                    Layout = card.card_layout,
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

        public MTGCardList GetAllMagicCardsByTerm(string q)
        {
            MTGCardList model = new MTGCardList();
            using (var db = new TCGEntities())
            {
                var query = db.MTG_Card.Select(x => x);
                var cardList = query.ToList();
                foreach(var card in cardList)
                {
                    MTGCard newMTGCard = new MTGCard();
                    newMTGCard.Name = card.card_name;
                    newMTGCard.CMC = (double)card.cmc;
                    newMTGCard.MCINumber = card.mci_number;
                    newMTGCard.ManaCost = card.mana_cost;
                    newMTGCard.Id = card.card_id;
                    newMTGCard.Flavor = card.flavor_text;
                    newMTGCard.Power = card.power;
                    newMTGCard.Toughness = card.toughness;
                    newMTGCard.Rarity = card.card_rarity;
                    newMTGCard.Layout = card.card_layout;
                    newMTGCard.Types = card.card_type.Split(' ').ToList();
                    newMTGCard.Subtypes = card.card_subtype.Split(' ').ToList();
                    newMTGCard.Text = card.card_text;
                    newMTGCard.MultiverseId = (int)card.multiverse_id;
                    newMTGCard.Colors = card.card_colors.Split(' ').ToList();
                    newMTGCard.ColorIdentity = card.card_color_identity.Split(' ').ToList();
                    newMTGCard.Artist = card.card_artist;
                    newMTGCard.Printings = card.sets.Split(' ').ToList();
                    newMTGCard.Image = "";
                    if(newMTGCard.Flavor == null)
                    {
                        newMTGCard.Flavor = "";
                    }
                    if (newMTGCard.Subtypes == null)
                    {
                        newMTGCard.Subtypes[0] = "";
                    }
                    if (newMTGCard.Text == null)
                    {
                        newMTGCard.Text = "";
                    }

                    if (newMTGCard.Artist.Contains(q) || newMTGCard.Flavor.Contains(q) || newMTGCard.Name.Contains(q) || newMTGCard.Subtypes.Contains(q) || newMTGCard.Text.Contains(q) || newMTGCard.Types.Contains(q))
                    {
                        model.Cards.Add(newMTGCard);
                    }
                }
            }
            return model;
        }
    }
}
