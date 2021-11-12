using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Controllers
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

	public IActionResult GuessingGame()
	{
	    GuessingGameModel guessingGameModel = new GuessingGameModel(this);

	    guessingGameModel.StartGuessingProcess();

	    return View(guessingGameModel);
	}

	[HttpPost]
	public IActionResult GuessingGame(int guessedNumber)
	{
	    GuessingGameModel guessingGameModel = new GuessingGameModel(this);

	    guessingGameModel.FetchDataFromSession();
	    guessingGameModel.GuessTheNumber(guessedNumber);

	    return View(guessingGameModel);
	}
    }
}
