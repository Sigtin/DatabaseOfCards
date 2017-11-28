using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triskaidekaphobia_Cards;
using System.Web.Mvc;
using Triskaidekaphobia_Cards.Controllers;
using Triskaidekaphobia_Cards.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
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

            Assert.AreEqual("Your application description page.", result);
        }

        [TestMethod]
        public void SearchTester()
        {
            HomeController homeController = new HomeController();

            ViewResult result = homeController.Search() as ViewResult;

            Assert.AreEqual("Your Search Page.", result);

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

            MTGCardListModel cardListModel = new MTGCardListModel();
            var result = homeController.SearchResult(cardListModel) as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}

