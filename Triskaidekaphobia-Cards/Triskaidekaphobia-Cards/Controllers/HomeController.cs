using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Triskaidekaphobia_Cards.Models;
using Triskaidekaphobia_Cards.Services;
using TriskaidekaphobiaLib;
namespace Triskaidekaphobia_Cards.Controllers
{
    public class HomeController : Controller
    {
        MTGCardService mtgService = new MTGCardService();
        TriskaidekaphobiaLib.Services.JSONCardImport import = new TriskaidekaphobiaLib.Services.JSONCardImport();

        public ActionResult Index()
        {
            import.JSONImport();
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
        public ActionResult Search(string cardList)
        {
            if (ModelState.IsValid)
            {
                MTGCardListModel MTGlist = new MTGCardListModel();
                //MTGlist = service.ReturnCardList();
                return RedirectToAction("Result", MTGlist);
            }
            else
            {
                return View();
            }
        }

        public ActionResult SearchResult(MTGCardListModel MTGlist)
        {
            MTGlist = mtgService.GetAllMTGCards();
            return View(MTGlist);
        }
    }
}