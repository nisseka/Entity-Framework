using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Controllers
{
    public class HomeController : Controller
    {
	public IActionResult Index(string searchFor, bool caseSensitive)
	{
	    PeopleViewModel peopleViewModel = new PeopleViewModel(this);

	    peopleViewModel.SearchFor = searchFor;
	    peopleViewModel.CaseSensitiveSearch = caseSensitive;

	    peopleViewModel.PrepareView();

	    return View(peopleViewModel);
	}

	[HttpPost]
	public IActionResult AddPerson(CreatePersonViewModel personData)
	{
	    PeopleViewModel peopleViewModel = new PeopleViewModel(this);

	    peopleViewModel.AddPerson(personData);

	    return RedirectToAction("Index");
	}

	public IActionResult DeletePerson(int id)
	{
	    PeopleViewModel peopleViewModel = new PeopleViewModel(this);
	    peopleViewModel.DeletePerson(id);

	    return RedirectToAction("Index");
	}
    }
}
