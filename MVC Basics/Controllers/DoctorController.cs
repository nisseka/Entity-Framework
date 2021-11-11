using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Controllers
{
    public class DoctorController : Controller
    {
	public IActionResult Index()
	{
	    HumanTemperatureModel temperatureModel = new HumanTemperatureModel();

	    return View(temperatureModel);
	}

	[HttpPost]
	public IActionResult Index(string temperature,string temperatureScale)
	{
	    HumanTemperatureModel temperatureModel = new HumanTemperatureModel(temperature, temperatureScale);

	    return View(temperatureModel);
	}
    }
}
