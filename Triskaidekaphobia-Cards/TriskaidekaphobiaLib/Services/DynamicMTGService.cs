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
                var cardList = query.OrderBy(x => x.card_name).ToList();
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
