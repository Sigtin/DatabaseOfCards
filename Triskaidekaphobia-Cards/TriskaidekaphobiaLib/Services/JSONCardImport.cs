using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriskaidekaphobiaLib.Models;
using MTGDAL;

namespace TriskaidekaphobiaLib.Services
{
    public class JSONCardImport
    {
        public void JSONImport()
        { 
            List<MTGSet> sets;
            using (StreamReader r = new StreamReader("./AllSets-x.json"))
            {
                string json = r.ReadToEnd();
                sets = JsonConvert.DeserializeObject<List<MTGSet>>(json);
            }
            using (var db = new TCGEntities2())
            {
                foreach (MTGSet set in sets)
                {
                    foreach (MTGCard card in set.cards)
                    {
                        string colorString = "";
                        foreach(string color in card.Colors)
                        {
                            colorString += $"{color} ";
                        }
                        string colorIdentityString = "";
                        foreach (string color in card.ColorIdentity)
                        {
                            colorIdentityString += $"{color} ";
                        }
                        string typeString = "";
                        foreach(string type in card.Types)
                        {
                            typeString += $"{type} ";
                        }
                        string subTypeString = "";
                        foreach(string subType in card.Subtypes)
                        {
                            subTypeString += $"{subType} ";
                        }
                        string printingsString = "";
                        foreach(string printing in card.Printings)
                        {
                            printingsString += $"{printing} ";
                        }
                        var newMTGCard = new MTG_Card()
                        {
                            card_artist = card.Artist,
                            card_colors = colorString,
                            card_color_identity = colorIdentityString,
                            card_id = card.Id,
                            card_layout = card.Layout,
                            card_name = card.Name,
                            card_rarity = card.Rarity,
                            card_subtype = subTypeString,
                            card_text = card.Text,
                            card_type = typeString,
                            cmc = (decimal)card.CMC,
                            flavor_text = card.Flavor,
                            mana_cost = card.ManaCost,
                            mci_number = card.MCINumber,
                            multiverse_id = card.MultiverseId,
                            power = card.Power,
                            toughness = card.Toughness,
                            sets = printingsString
                        };
                        db.MTG_Card.Add(newMTGCard);
                        db.SaveChanges();
                        //Console.WriteLine($"{card.Name} {card.ManaCost}");
                        //Console.WriteLine($"CMC: {card.CMC}");
                        //string colorIdentity = "Color Identity: ";
                        //foreach (string color in card.Colors)
                        //{
                        //    colorIdentity += $"{color} ";
                        //}
                        //Console.WriteLine(colorIdentity);
                        //Console.WriteLine(card.Text);
                        //Console.WriteLine(card.Flavor);
                        //Console.WriteLine($"{card.Power}/{card.Toughness}");
                        //Console.WriteLine($"Artist: {card.Artist}");
                        //Console.WriteLine($"Rarity: {card.Rarity}");
                        //Console.WriteLine("-----");
                    }
                }
            }
        }
    }
}
