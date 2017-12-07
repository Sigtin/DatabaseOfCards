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
                var query2 = db.MTG_Card.Select(x => x).Where(x => x.card_artist.Contains(q) || x.flavor_text.Contains(q) || x.card_name.Contains(q) || x.card_subtype.Contains(q) || x.card_text.Contains(q) || x.card_type.Contains(q));
                var cardList = query2.ToList();
                foreach (var card in cardList)
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
                    if (newMTGCard.Flavor == null)
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
                    
                    model.Cards.Add(newMTGCard);
                }
            }
            return model;
        }
        public MTGCardList AdvancedSearch(string Name = "", string SetCode = "", string LessGreaterEqual = null, int? CMC = null, string FlavorText = null, string Power = null, string Toughness = null, string Rarity = "", string Layout = "", string Type = "", string Subtype = "", string Text = null, string Color = "", string ColorIdentity = "", string Artist = "")
        {
            MTGCardList model = new MTGCardList();
            using (var db = new TCGEntities())
            {
                var query = db.MTG_Card.Select(x => x);

                if (CMC != null)
                {
                    if(LessGreaterEqual == "=")
                    {
                        if (FlavorText != null && FlavorText != "")
                        {
                            if (Power != null && Power != "" || Toughness != null && Toughness != "")
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc == CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.card_text.Contains(Text)).Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc == CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                            else
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc == CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.card_text.Contains(Text)).Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc == CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                        }
                        else
                        {
                            if (Power != null && Power != "" || Toughness != null && Toughness != "")
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc == CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.card_text.Contains(Text))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc == CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                            else
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc == CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.card_text.Contains(Text))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc == CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                        }
                    }
                    else if(LessGreaterEqual == ">")
                    {
                        if (FlavorText != null && FlavorText != "")
                        {
                            if (Power != null && Power != "" || Toughness != null && Toughness != "")
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc > CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.card_text.Contains(Text)).Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc > CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                            else
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc > CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.card_text.Contains(Text)).Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc > CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                        }
                        else
                        {
                            if (Power != null && Power != "" || Toughness != null && Toughness != "")
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc > CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.card_text.Contains(Text))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc > CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                            else
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc > CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.card_text.Contains(Text))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc > CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (FlavorText != null && FlavorText != "")
                        {
                            if (Power != null && Power != "" || Toughness != null && Toughness != "")
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc < CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.card_text.Contains(Text)).Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc < CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                            else
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc < CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.card_text.Contains(Text)).Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc < CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.flavor_text.Contains(FlavorText))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                        }
                        else
                        {
                            if (Power != null && Power != "" || Toughness != null && Toughness != "")
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc < CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.card_text.Contains(Text))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc < CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                            else
                            {
                                if (Text != null && Text != "")
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc < CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.card_text.Contains(Text))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                                else
                                {
                                    query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                       .Where(x => x.cmc < CMC)
                                                       .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                       //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                       .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                       .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                       .Where(x => x.card_artist.Contains(Artist));
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (FlavorText != null && FlavorText != "")
                    {
                        if (Power != null && Power != "" || Toughness != null && Toughness != "")
                        {
                            if (Text != null && Text != "")
                            {
                                query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                   .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                   //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                   .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                   .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                   .Where(x => x.card_text.Contains(Text)).Where(x => x.flavor_text.Contains(FlavorText))
                                                   .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                   .Where(x => x.card_artist.Contains(Artist));
                            }
                            else
                            {
                                query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                   .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                   //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                   .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                   .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                   .Where(x => x.flavor_text.Contains(FlavorText))
                                                   .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                   .Where(x => x.card_artist.Contains(Artist));
                            }
                        }
                        else
                        {
                            if (Text != null && Text != "")
                            {
                                query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                   .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                   //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                   .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                   .Where(x => x.card_text.Contains(Text)).Where(x => x.flavor_text.Contains(FlavorText))
                                                   .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                   .Where(x => x.card_artist.Contains(Artist));
                            }
                            else
                            {
                                query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                   .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                   //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                   .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                   .Where(x => x.flavor_text.Contains(FlavorText))
                                                   .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                   .Where(x => x.card_artist.Contains(Artist));
                            }
                        }
                    }
                    else
                    {
                        if (Power != null && Power != "" || Toughness != null && Toughness != "")
                        {
                            if (Text != null && Text != "")
                            {
                                query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                   .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                   //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                   .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                   .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                   .Where(x => x.card_text.Contains(Text))
                                                   .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                   .Where(x => x.card_artist.Contains(Artist));
                            }
                            else
                            {
                                query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                   .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                   //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                   .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                   .Where(x => x.power.Contains(Power)).Where(x => x.toughness.Contains(Toughness))
                                                   .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                   .Where(x => x.card_artist.Contains(Artist));
                            }
                        }
                        else
                        {
                            if (Text != null && Text != "")
                            {
                                query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                   .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                   //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                   .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                   .Where(x => x.card_text.Contains(Text))
                                                   .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                   .Where(x => x.card_artist.Contains(Artist));
                            }
                            else
                            {
                                query = db.MTG_Card.Select(x => x).Where(x => x.card_name.Contains(Name)).Where(x => x.sets.Contains(SetCode))
                                                   .Where(x => x.card_rarity.Contains(Rarity)).Where(x => x.card_layout.Contains(Layout))
                                                   //vv       THIS   IS   BUSTED       vv  vv               THIS   TOO              vv
                                                   .Where(x => x.card_type.Contains(Type)).Where(x => x.card_subtype.Contains(Subtype))
                                                   .Where(x => x.card_colors.Contains(Color)).Where(x => x.card_color_identity.Contains(ColorIdentity))
                                                   .Where(x => x.card_artist.Contains(Artist));
                            }
                        }
                    }
                }
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
    }
}
