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
                TriskaidekaphobiaLib.Models.MTGCardList MTGlist = new TriskaidekaphobiaLib.Models.MTGCardList();
                //MTGlist = service.ReturnCardList();
                return RedirectToAction("SearchResult", MTGlist);
            }
            else
            {
                return View();
            }
        }

        public ActionResult SearchResult(TriskaidekaphobiaLib.Models.MTGCardList MTGlist)
        {
            MTGlist = mtgService.GetAllMagicCards();
            return View(MTGlist);
        }
    }
}