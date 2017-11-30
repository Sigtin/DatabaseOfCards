using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Triskaidekaphobia.Models
{
    public class MTGCardList
    {
        public List<MTGCardModel> MTGCards { get; set; }

        public MTGCardList()
        {
            MTGCards = new List<MTGCardModel>();
        }
    }
}