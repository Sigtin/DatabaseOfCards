using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Triskaidekaphobia_Cards.Models
{
    public class MTGCardListModel
    {
        public List<MTGCardModel> MTGCards { get; set; }

        public MTGCardListModel()
        {
            MTGCards = new List<MTGCardModel>();
        }
    }
}