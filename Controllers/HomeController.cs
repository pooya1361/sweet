using Microsoft.AspNetCore.Mvc;
using sweet.Models;
using Sweet.Services;
using System.Diagnostics;
using System.Xml.Linq;

namespace sweet.Controllers
{
	public class HomeController : Controller
	{
		private ICustomerService _customerService;

		public HomeController(ICustomerService customerService)
		{
			this._customerService = customerService;
		}

		private void loadData()
		{
			var customers = _customerService.GetCustomers();
			var countries = _customerService.GetCountries();

			customers = customers.Select(c =>
			{
				c.countryName = countries.Find(cnt => cnt.id == c.countryId)?.name; return c;
			}).ToList();
			ViewBag.Customers = customers;
			ViewBag.Countries = countries;
		}

		public IActionResult Index()
		{
			loadData();

			return View();
		}

		[HttpPost]
		public ActionResult AddCustomer(newCustomerModel model)
		{
			if (ModelState.IsValid)
			{
				if (_customerService.AddCustomer(model.name, model.countryId))
				{
					loadData();
				}

			}
			return RedirectToAction("Index", model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
