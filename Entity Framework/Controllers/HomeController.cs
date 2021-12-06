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

	public IActionResult PersonDetails(int id)
	{
	    PeopleViewModel peopleViewModel = new PeopleViewModel(this, DBContext);

	    peopleViewModel.PrepareView();

	    Person person = peopleViewModel.FindPersonByID(id);

	    return View(person);
	}

	[HttpPost]
	public IActionResult AddPerson(CreatePersonViewModel personData)
	{
	    PeopleViewModel peopleViewModel = new PeopleViewModel(this, DBContext);

	    peopleViewModel.AddPerson(personData);

	    return RedirectToAction("Index");
	}

	[HttpPost]
	public IActionResult UpdatePerson(UpdatePersonViewModel personData)
	{
	    PeopleViewModel peopleViewModel = new PeopleViewModel(this, DBContext);

	    peopleViewModel.UpdatePerson(personData);

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
