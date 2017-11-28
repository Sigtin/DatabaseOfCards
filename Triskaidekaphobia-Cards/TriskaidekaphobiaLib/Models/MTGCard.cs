using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriskaidekaphobiaLib.Models
{
    public class MTGCard
    {
        public string Name { get; set; }
        public double CMC { get; set; }
        public string MCINumber { get; set; }
        public string ManaCost { get; set; }
        public string Id { get; set; }
        public string Flavor { get; set; }
        //public int CardNumber { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Rarity { get; set; }
        public string Layout { get; set; }
        public List<string> Types { get; set; } = new List<string>();
        public List<string> Subtypes { get; set; } = new List<string>();
        public string Text { get; set; }
        public int MultiverseId { get; set; }
        public List<string> Colors { get; set; } = new List<string>();
        public List<string> ColorIdentity { get; set; } = new List<string>();
        public string Artist { get; set; }
        public List<string> Printings { get; set; }
    }
}
