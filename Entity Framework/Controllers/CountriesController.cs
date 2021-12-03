using Entity_Framework.Data;
using Entity_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Controllers
{
    public class CountriesController : DBController
    {
	public CountriesController(DatabaseDbContext context) : base(context)
	{
	}

	public IActionResult Index()
	{
	    CountriesViewModel countyViewModel = new CountriesViewModel(this, DBContext);

	    return View(countyViewModel);
	}

	[HttpPost]
	public IActionResult AddCountry(CreateCountryViewModel countryData)
	{
	    CountriesViewModel countyViewModel = new CountriesViewModel(this, DBContext);

	    countyViewModel.AddCountry(countryData);

	    return RedirectToAction("Index");
	}

	public IActionResult DeleteCountry(int id)
	{
	    CountriesViewModel countyViewModel = new CountriesViewModel(this, DBContext);
	    countyViewModel.RemoveCountryFromDB(id);

	    return RedirectToAction("Index");
	}
    }
}
