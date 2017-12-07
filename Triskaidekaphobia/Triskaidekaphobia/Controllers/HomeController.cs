using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Triskaidekaphobia.Models;
using TriskaidekaphobiaLib.Services;
using TriskaidekaphobiaLib.Models;

namespace Triskaidekaphobia.Controllers
{
    public class HomeController : Controller
    {
        DynamicMTGService mtgService = new DynamicMTGService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            ViewBag.Message = "Your search page.";

            return View();
        }

        [HttpPost]
        public ActionResult Search(string cardList)
        {
            if (ModelState.IsValid)
            {
                TriskaidekaphobiaLib.Models.MTGCardList MTGlist = mtgService.GetAllMagicCards();
                return RedirectToAction("SearchResult", MTGlist);
            }
            else
            {
                return View();
            }
        }

        public ActionResult SearchResult(TriskaidekaphobiaLib.Models.MTGCardList MTGlist)
        {
            return View(MTGlist);
        }

        [HttpPost]
        public ActionResult SearchResult(string Name = "", string SetCode = "", string LessGreaterEqual = null, int? CMC = null, string FlavorText = null, string Power = null, string Toughness = null, string Rarity = "", string Layout = "", string Type = "", string Subtype = "", string Text = null, string Color = "", string ColorIdentity = "", string Artist = "")
        {
            TriskaidekaphobiaLib.Models.MTGCardList cardList = new TriskaidekaphobiaLib.Models.MTGCardList();
            cardList = mtgService.AdvancedSearch(Name, SetCode, LessGreaterEqual, CMC, FlavorText, Power, Toughness, Rarity, Layout, Type, Subtype, Text, Color, ColorIdentity, Artist);
            return View(cardList);
        }
    }
}