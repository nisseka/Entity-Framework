using Entity_Framework.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class PeopleViewModel
    {
	private Controller aController;
	private readonly DatabaseDbContext DBContext;
	private string searchFor;

	public List<DBPerson> People;
	public List<MenuLink> MenuLinks;

	public readonly List<Person> PeopleToDisplay;
	public readonly List<string> TableRowClasses;


	public string SearchFor { get => searchFor; set { searchFor = value; } }

	public bool CaseSensitiveSearch { get; set; }

	public PeopleViewModel(Controller aController, DatabaseDbContext dbContext)
	{
	    this.aController = aController;
	    DBContext = dbContext;

	    PeopleToDisplay = new List<Person>();

	    TableRowClasses = new List<string>();
	    TableRowClasses.Add("tableRowOdd");
	    TableRowClasses.Add("tableRowEven");

	    ReadDB();
	}

	public void ReadDB()
	{
	    People = DBContext.People.ToList();
	    MenuLinks = DBContext.MenuLinks.ToList();
	}

	public void PrepareView()
	{
	    int peopleToDisplayIndex = 0;
	    bool addPerson = false;

	    StringComparison compareType = CaseSensitiveSearch ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

	    PeopleToDisplay.Clear();

	    foreach (var person in People)
	    {
		if (searchFor != null && searchFor.Length > 0)
		{
		    if (person.Name.Contains(searchFor, compareType) || person.City.Contains(searchFor, compareType))
		    {
			addPerson = true;
		    } else
			addPerson = false;
		} else        // No filtering..
		    addPerson = true;

		if (addPerson)
		{
		    Person personInPeopleToDisplayList = new Person(person);	    // Create a copy of person
		    personInPeopleToDisplayList.ItemIndex = peopleToDisplayIndex;   // Assign an ItemIndex (which is its index in the PeopleToDisplay list)

		    PeopleToDisplay.Add(personInPeopleToDisplayList);
		    peopleToDisplayIndex++;
		}
	    }
	}

	public bool DeletePerson(int itemIndex)
	{
	    bool success = false;
	    if (itemIndex >= 0 && itemIndex<People.Count)
	    {
		success = RemovePersonFromDB(People[itemIndex].ID);
	    }
	    return success;
	}

	public bool DeletePersonByID(int aPersonID)
	{
	    return RemovePersonFromDB(aPersonID);
	}

	public DBPerson AddPerson(CreatePersonViewModel personData)
	{
	    DBPerson person = null;

	    if (aController.ModelState.IsValid)
	    {
		person = new DBPerson(personData);

		AddPersonToDB(person);
	    }

	    return person;
	}

	public bool RemovePersonFromDB(int ID)
	{
	    bool success = false;

	    DBPerson dBPerson = DBContext.People.Find(ID);
	    if (dBPerson!=null)
	    {
		People.Remove(dBPerson);
		DBContext.People.Remove(dBPerson);
		DBContext.SaveChanges();
		success = true;
	    }
	    return success;
	}

	public int AddPersonToDB(DBPerson aPerson)
	{
	    aPerson.ID = 0;				    // Set ID to 0 to allow addition to database

	    DBContext.People.Add(aPerson);
	    DBContext.SaveChanges();
	    return  DBContext.People.Count();
	}

	public DBPerson FindPersonByID(int aPersonID)
	{
	    DBPerson person = null;

	    foreach (var item in People)
	    {
		if (item.ID == aPersonID)
		{
		    person = item;
		    break;
		}
	    }
	    return person;
	}
    }
}
