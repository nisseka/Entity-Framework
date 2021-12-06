using Entity_Framework.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class DBModel
    {
	protected Controller aController;
	protected readonly DatabaseDbContext DBContext;

	public List<DBPerson> People;
	public List<MenuLink> MenuLinks;
	public List<City> Cities;
	public List<Country> Countries;
	public List<Language> Languages;
	public List<PersonLanguage> PersonLanguages;

	public readonly List<string> TableRowClasses;

	public DBModel(Controller aController, DatabaseDbContext dbContext)
	{
	    this.aController = aController;
	    DBContext = dbContext;

	    TableRowClasses = new List<string>();
	    TableRowClasses.Add("tableRowOdd");
	    TableRowClasses.Add("tableRowEven");

	    ReadDB();
	}

	public void ReadDB()
	{
	    People = DBContext.People.ToList();
	    MenuLinks = DBContext.MenuLinks.ToList();
	    Cities = DBContext.Cities.ToList();
	    Countries = DBContext.Countries.ToList();
	    Languages = DBContext.Languages.ToList();
	    PersonLanguages = DBContext.PersonLanguages.ToList();

	    aController.ViewBag.Cities = Cities;                // Make city list available for partial view 'AddPerson'
	    aController.ViewBag.Languages = Languages;          // Make language list available for partial view 'AddPerson'
	    aController.ViewBag.Countries = Countries;          // Make country list available for partial view 'AddCity'
	    aController.ViewBag.MenuLinks = MenuLinks;          // Make menu links available for the layout page
	}

	public bool RemovePersonFromDB(int ID)
	{
	    bool success = false;

	    DBPerson dBPerson = DBContext.People.Find(ID);
	    if (dBPerson != null)
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
	    aPerson.ID = 0;                                 // Set ID to 0 to allow addition to database

	    DBContext.People.Add(aPerson);
	    DBContext.SaveChanges();
	    return DBContext.People.Count();
	}

	public virtual void PrepareView()
	{

	}
    }
}
