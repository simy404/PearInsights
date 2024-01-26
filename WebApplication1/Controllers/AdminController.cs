using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly Entities _entitiesDbContext;

		public AdminController()
		{
			_entitiesDbContext = new Entities();
		}
		// GET: Admin
		#region FruitProductionDistribution
		public ActionResult FruitProductionDistribution()
		{
			var FruitProduction = _entitiesDbContext.Pearproductions.ToList();
			return View(FruitProduction);
		}

		[HttpPost]
		public ActionResult DeleteFruitProductionDistribution(int id)
		{
			var FruitProductionEntity = _entitiesDbContext.Pearproductions.Find(id);

			if (FruitProductionEntity != null)
			{
				_entitiesDbContext.Pearproductions.Remove(FruitProductionEntity);

				_entitiesDbContext.SaveChanges();
			}

			return Redirect("FruitProductionDistribution");
		}

		public ActionResult EditFruitProductionDistribution(int id)
		{
			var FruitProductionEntity = _entitiesDbContext.Pearproductions.Find(id);

			if (FruitProductionEntity != null)
			{
				//todo will be use AutoMapper for type casting
				PearproductionsViewModel FruitProductionviewModel = new PearproductionsViewModel()
				{
					id = FruitProductionEntity.id,
					country_name = FruitProductionEntity.country_name,
					production_2018 = FruitProductionEntity.production_2018,
					production_2019 = FruitProductionEntity.production_2019,
					production_2020 = FruitProductionEntity.production_2020,

				};
				return View(FruitProductionviewModel);
			}

			return Redirect("/Admin/FruitProductionDistribution");

		}

		[HttpPost]
		public ActionResult EditFruitProductionDistribution(PearproductionsViewModel pearproductionsView)
		{
			if (ModelState.IsValid)
			{
				Pearproduction pearproductionEntity = _entitiesDbContext.Pearproductions.Find(pearproductionsView.id);

				//todo will be use AutoMapper for type casting
				pearproductionEntity.country_name = pearproductionsView.country_name;
				pearproductionEntity.production_2018 = pearproductionsView.production_2018;
				pearproductionEntity.production_2019 = pearproductionsView.production_2019;
				pearproductionEntity.production_2020 = pearproductionsView.production_2020;

				_entitiesDbContext.SaveChanges();


				return Redirect("/Admin/FruitProductionDistribution");
			}

			return View(pearproductionsView.id);
		}


		public ActionResult AddFruitProductionDistribution()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddFruitProductionDistribution(PearproductionsViewModel pearproductionsView)
		{
			if (ModelState.IsValid)
			{
				//todo will be use AutoMapper for type casting
				Pearproduction FruitProductionviewModel = new Pearproduction()
				{
					country_name = pearproductionsView.country_name,
					production_2018 = pearproductionsView.production_2018,
					production_2019 = pearproductionsView.production_2019,
					production_2020 = pearproductionsView.production_2020,

				};

				_entitiesDbContext.Pearproductions.Add(FruitProductionviewModel);

				_entitiesDbContext.SaveChanges();
				return Redirect("/Admin/FruitProductionDistribution");
			}

			return View();
		}

		#endregion

		#region CitiesProducingPears
		public ActionResult CitiesProducingPears()
		{
			var CitiesProducingPears = _entitiesDbContext.CitiesProducingPears.ToList();
			return View(CitiesProducingPears);
		}

		public ActionResult EditCitiesProducingPears(int id)
		{
			var CitiesProducingPearsEntity = _entitiesDbContext.CitiesProducingPears.Find(id);

			if (CitiesProducingPearsEntity != null)
			{
				//todo will be use AutoMapper for type casting
				CitiesProducingPearsViewModel CitiesProducingPearsviewModel = new CitiesProducingPearsViewModel()
				{
					Id = CitiesProducingPearsEntity.Id,
					City = CitiesProducingPearsEntity.City

				};
				return View(CitiesProducingPearsviewModel);
			}

			return Redirect("/Admin/CitiesProducingPears");

		}

		[HttpPost]
		public ActionResult EditCitiesProducingPears(CitiesProducingPearsViewModel CitiesProducingPearsView)
		{
			if (ModelState.IsValid)
			{
				CitiesProducingPear CitiesProducingPearsEntity = _entitiesDbContext.CitiesProducingPears.Find(CitiesProducingPearsView.Id);

				//todo will be use AutoMapper for type casting
				CitiesProducingPearsEntity.City = CitiesProducingPearsView.City;
				_entitiesDbContext.SaveChanges();


				return Redirect("/Admin/CitiesProducingPears");
			}

			return View(CitiesProducingPearsView.Id);
		}

		[HttpPost]
		public ActionResult DeleteCitiesProducingPears(int id)
		{
			var CitiesProducingPearsEntity = _entitiesDbContext.CitiesProducingPears.Find(id);

			if (CitiesProducingPearsEntity != null)
			{
				_entitiesDbContext.CitiesProducingPears.Remove(CitiesProducingPearsEntity);

				_entitiesDbContext.SaveChanges();
			}

			return Redirect("CitiesProducingPears");
		}

		public ActionResult AddCitiesProducingPears()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddCitiesProducingPears(CitiesProducingPearsViewModel citiesProducingPearsView)
		{
			if (ModelState.IsValid)
			{
				//todo will be use AutoMapper for type casting
				CitiesProducingPear citiesProducingPear = new CitiesProducingPear()
				{
					City = citiesProducingPearsView.City

				};

				_entitiesDbContext.CitiesProducingPears.Add(citiesProducingPear);

				_entitiesDbContext.SaveChanges();
				return Redirect("/Admin/CitiesProducingPears");
			}

			return View();
		}

		#endregion

		#region PearTypes
		public ActionResult PearTypes()
		{
			var PearTypes = _entitiesDbContext.PearTypes.ToList();
			return View(PearTypes);
		}

		[HttpPost]
		public ActionResult DeletePearTypes(int id)
		{
			var PearTypeEntity = _entitiesDbContext.PearTypes.Find(id);

			if (PearTypeEntity != null)
			{
				_entitiesDbContext.PearTypes.Remove(PearTypeEntity);

				_entitiesDbContext.SaveChanges();
			}

			return Redirect("PearTypes");
		}

		public ActionResult EditPearTypes(int id)
		{
			var PearTypeEntity = _entitiesDbContext.PearTypes.Find(id);

			if (PearTypeEntity != null)
			{
				//todo will be use AutoMapper for type casting
				PearTypeViewModel PearTypeviewModel = new PearTypeViewModel()
				{
					Type = PearTypeEntity.Type,

				};
				return View(PearTypeviewModel);
			}

			return Redirect("/Admin/PearTypes");

		}

		[HttpPost]
		public ActionResult EditPearTypes(PearTypeViewModel pearTypeView)
		{
			if (ModelState.IsValid)
			{
				PearType pearTypeEntity = _entitiesDbContext.PearTypes.Find(pearTypeView.Id);

				//todo will be use AutoMapper for type casting
				pearTypeEntity.Type = pearTypeView.Type;

				_entitiesDbContext.SaveChanges();


				return Redirect("/Admin/PearTypes");
			}

			return View(pearTypeView.Id);
		}

		public ActionResult AddPearTypes()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddPearTypes(PearTypeViewModel pearTypeViewModel)
		{
			if (ModelState.IsValid)
			{
				//todo will be use AutoMapper for type casting
				PearType pearTypeview = new PearType()
				{
					Type = pearTypeViewModel.Type
				};

				_entitiesDbContext.PearTypes.Add(pearTypeview);

				_entitiesDbContext.SaveChanges();
				return Redirect("/Admin/PearTypes");
			}

			return View();
		}
		#endregion
	}

}