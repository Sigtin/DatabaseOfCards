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
        [HttpPost]
        public ActionResult BasicSearchResult(string q)
        {
            return RedirectToAction("SearchResult", "Home", new { q = q });
        }
        public ActionResult SearchResult(string q)
        {
            TriskaidekaphobiaLib.Models.MTGCardList MTGlist = new TriskaidekaphobiaLib.Models.MTGCardList();
            if (!String.IsNullOrEmpty(q))
            {
                MTGlist = mtgService.GetAllMagicCardsByTerm(q);
            }
            else
            {
                MTGlist = mtgService.GetAllMagicCards();
            }

            return View(MTGlist);
        }

        [HttpPost]
        public ActionResult SearchResult(string Name = "", string SetCode = "", string LessGreaterEqual = null, int? CMC = null, int? MCINumber = null, string FlavorText = null, string Power = null, string Toughness = null, string Rarity = null, string Layout = null, string Type = null, string Subtype = null, string Text = null, string Color = null, string ColorIdentity = null, string Artist = null)
        {
            return View();
        }
    }
}