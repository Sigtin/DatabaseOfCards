using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Triskaidekaphobia.Controllers
{
    public class DeckBuilderController : Controller
    {
        // GET: DeckBuilder
        public ActionResult Index()
        {
            return View();
        }
    }
}