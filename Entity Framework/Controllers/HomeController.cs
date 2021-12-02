using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework.Data;

namespace Entity_Framework.Controllers
{
    public class HomeController : DBController
    {
	public HomeController(DatabaseDbContext context) : base(context)
	{
	}

	public IActionResult Index(string searchFor, bool caseSensitive)
	{
	    PeopleViewModel peopleViewModel = new PeopleViewModel(this,DBContext);

	    peopleViewModel.SearchFor = searchFor;
	    peopleViewModel.CaseSensitiveSearch = caseSensitive;

	    peopleViewModel.PrepareView();

	    return View(peopleViewModel);
	}

	[HttpPost]
	public IActionResult AddPerson(CreatePersonViewModel personData)
	{
	    PeopleViewModel peopleViewModel = new PeopleViewModel(this, DBContext);

	    peopleViewModel.AddPerson(personData);

	    return RedirectToAction("Index");
	}

	public IActionResult DeletePerson(int id)
	{
	    PeopleViewModel peopleViewModel = new PeopleViewModel(this, DBContext);
	    peopleViewModel.DeletePersonByID(id);

	    return RedirectToAction("Index");
	}
    }
}
