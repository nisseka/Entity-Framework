using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Test.Controllers
{
    public class HomeController : Controller
    {
	public IActionResult Index()
	{
	    return View();
	}

	public IActionResult About()
	{
	    return View();
	}

	public IActionResult Projects()
	{
	    return View();
	}

	public IActionResult Contact()
	{
	    return View();
	}
    }
}
