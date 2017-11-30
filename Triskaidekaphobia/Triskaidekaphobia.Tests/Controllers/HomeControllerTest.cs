using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triskaidekaphobia;
using Triskaidekaphobia.Controllers;
using TriskaidekaphobiaLib.Models;

namespace Triskaidekaphobia.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexTester()
        {
            HomeController home = new HomeController();

            ViewResult result = home.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AboutTester()
        {
            HomeController homeController = new HomeController();

            ViewResult result = homeController.About() as ViewResult;

            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void SearchTester()
        {
            HomeController homeController = new HomeController();

            ViewResult result = homeController.Search() as ViewResult;

            Assert.AreEqual("Your search page.", result.ViewBag.Message);

        }

        [TestMethod]
        public void SearchTest1()
        {
            HomeController homeController = new HomeController();

            //Come back to this when the method has been properly constructed.
        }

        [TestMethod]
        public void SearchResultTester()
        {
            HomeController homeController = new HomeController();

            MTGCardList cardListModel = new MTGCardList();
            var result = homeController.SearchResult(cardListModel) as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
