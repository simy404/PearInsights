using Microsoft.AspNet.Identity.Owin;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {

        private readonly Entities _entitiesDbContext;

		public HomeController() 
        {
			_entitiesDbContext = new Entities();
		}

        [AllowAnonymous]
        public ActionResult Index()
        {
            var CorouselList =  _entitiesDbContext.Corousels.ToList();
			return View(CorouselList);
        }
        
        [Authorize(Roles = "Admin" )]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        [Authorize()]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Example()
        {
            return View();

        }

		[Authorize()]
		public ActionResult FruitProductionDistribution()
        {
            var FruitProduction = _entitiesDbContext.Pearproductions.ToList();
            return View(FruitProduction);
        }

		[Authorize()]
		public ActionResult CitiesProducingPears()
		{
			var CitiesProducingPears = _entitiesDbContext.CitiesProducingPears.ToList();
			return View(CitiesProducingPears);
		}

		[Authorize()]
		public ActionResult PearTypes()
		{
			var PearTypes = _entitiesDbContext.PearTypes.ToList();
			return View(PearTypes);
		}

        [Authorize(Roles = "Admin")]
        public ActionResult EditDatas()
        {
            return View();
        }

	}
}