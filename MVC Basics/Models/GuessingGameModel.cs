using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Models
{
    public class GuessingGameModel
    {
	private Controller aController;
	private Random randomNumberGenerator;
	private int randomNumber;
	private int guessedNumber;
	private int guessesCount;

	private string message;
	private string startAgainMessage;
	private string numberOfTriesMessage;

	public string Message { get => message; }
	public string NumberOfTriesMessage { get => numberOfTriesMessage; }
	public string StartAgainMessage { get => startAgainMessage; }

	public int GuessedNumber { get => guessedNumber; }

	public GuessingGameModel(Controller aController)
	{
	    this.aController = aController;
	    randomNumberGenerator = new Random();
	    guessedNumber = 1;
	}

	public int StartGuessingProcess()
	{
	    randomNumber = randomNumberGenerator.Next(1, 101);
	    guessesCount = 0;

	    if (aController != null)
	    {
		aController.HttpContext.Session.SetInt32("RandomNumber", randomNumber);
		aController.HttpContext.Session.SetInt32("GuessesCount", guessesCount);
	    }

	    return randomNumber;
	}

	public void FetchDataFromSession()
	{
	    if (aController != null)
	    {
		randomNumber = aController.HttpContext.Session.GetInt32("RandomNumber") ?? 1;
		guessesCount = aController.HttpContext.Session.GetInt32("GuessesCount") ?? 0;
	    } else
	    {
		randomNumber = 1;
		guessesCount = 0;
	    }
	}

	public void GuessTheNumber(int guessedNumber)
	{
	    if (guessedNumber < 1 || guessedNumber > 100)
	    {
		message = $"Error! The guessed number ({guessedNumber}) is out of range (which is 1 - 100)!";
		return;
	    }

	    guessesCount++;
	    if (aController != null)
		aController.HttpContext.Session.SetInt32("GuessesCount", guessesCount);
	    numberOfTriesMessage = $"Number of tries: {guessesCount}";

	    if (guessedNumber == randomNumber)
	    {
		message = $"Congratulation! You guessed the number, {randomNumber}!";
		startAgainMessage = "Enter a number and click 'Submit' button to start another guessing game..";

		StartGuessingProcess();
		guessedNumber = 1;
	    } else
	    if (guessedNumber < randomNumber)
	    {
		message = $"Wrong! The number you guessed ({guessedNumber}) is too low! Try again..";
	    } else
	    if (guessedNumber > randomNumber)
	    {
		message = $"Wrong! The number you guessed ({guessedNumber}) is too high! Try again..";
	    }

	    this.guessedNumber = guessedNumber;
	}
    }
}
