﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Models
{
    public class PeopleViewModel
    {
	private Controller aController;
	private string searchFor;

	public readonly List<Person> People;
	public readonly List<Person> PeopleToDisplay;
	public readonly List<string> TableRowClasses;

	public string CookieString 
	{ 
	    get
	    {
		string cookieString = string.Empty;

		foreach (var person in People)
		{
		    cookieString += person.CookieString;
		}
		return cookieString;
	    }

	    set 
	    {
		if (value != null)
		{
		    string[] cookieLines = value.Split("\r\n",StringSplitOptions.RemoveEmptyEntries);

		    foreach (var line in cookieLines)
		    {
			Person person = new Person();
			person.CookieString = line;
			AddPerson(person, false);
		    }
		}
	    }
	}

	public string SearchFor { get => searchFor; set { searchFor = value; } }

	public bool CaseSensitiveSearch { get; set; }

	public PeopleViewModel(Controller aController)
	{
	    this.aController = aController;
	    People = new List<Person>();
	    PeopleToDisplay = new List<Person>();

	    TableRowClasses = new List<string>();
	    TableRowClasses.Add("tableRowOdd");
	    TableRowClasses.Add("tableRowEven");

	    CookieString = aController.Request.Cookies["people"];	// Add people from cookie
	}

	public void PrepareView()
	{
	    StringComparison compareType = CaseSensitiveSearch ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

	    PeopleToDisplay.Clear();

	    foreach (var person in People)
	    {
		if ( searchFor != null && searchFor.Length > 0)
		{
		    if (person.Name.IndexOf(searchFor, compareType) >= 0 || person.City.IndexOf(searchFor, compareType) >= 0)
		    {
			PeopleToDisplay.Add(person);
		    }
		} else	    // No filtering..
		    PeopleToDisplay.Add(person);
	    }
	}

	public Person AddPerson(string aName, string aCity, string aPhoneNumber)
	{
	    Person person = new Person(aName, aCity, aPhoneNumber);
	    AddPerson(person,true);

	    return person;
	}

	public void DeletePerson(int itemIndex)
	{
	    if (itemIndex >= 0 && itemIndex<People.Count)
	    {
		People.RemoveAt(itemIndex);
		WritePeopleCookie(CookieString);
	    }
	}

	public void WritePeopleCookie(string cookieString)
	{
	    CookieOptions option = new CookieOptions();
	    option.Expires = DateTime.Now.AddDays(10);
	    aController.Response.Cookies.Append("people", cookieString, option);
	}

	public Person AddPerson(CreatePersonViewModel personData)
	{
	    Person person = null;

	    if (aController.ModelState.IsValid)
	    {
		person = new Person(personData);

		AddPerson(person,true);
	    }

	    return person;
	}

	public int AddPerson(Person aPerson, bool UpdateDB)
	{
	    int itemIndex = People.Count;

	    aPerson.ID = itemIndex;
	    People.Add(aPerson);

	    if (UpdateDB)
	    {
		WritePeopleCookie(CookieString);
	    }
	    return  itemIndex;
	}
    }
}
