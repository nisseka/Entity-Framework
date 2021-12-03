using Entity_Framework.Data;
using Entity_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Controllers
{
    public class CitiesController : DBController
    {
	public CitiesController(DatabaseDbContext context) : base(context)
	{

	}

	public IActionResult Index()
	{
	    CitiesViewModel citiesViewModel = new CitiesViewModel(this, DBContext);


	    return View(citiesViewModel);
	}

	[HttpPost]
	public IActionResult AddCity(CreateCityViewModel cityData)
	{
	    CitiesViewModel citiesViewModel = new CitiesViewModel(this, DBContext);

	    citiesViewModel.AddCity(cityData);

	    return RedirectToAction("Index");
	}

	public IActionResult DeleteCity(int id)
	{
	    CitiesViewModel citiesViewModel = new CitiesViewModel(this, DBContext);
	    citiesViewModel.RemoveCityFromDB(id);

	    return RedirectToAction("Index");
	}

    }
}
