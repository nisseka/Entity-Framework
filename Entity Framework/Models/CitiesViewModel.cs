using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework.Data;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework.Models
{
    public class CitiesViewModel : DBModel
    {
	public CitiesViewModel(Controller aController, DatabaseDbContext dbContext) : base(aController, dbContext)
	{

	}

	public City AddCity(CreateCityViewModel cityData)
	{
	    City city = null;

	    if (aController.ModelState.IsValid)
	    {
		city = new City(cityData);

		AddCityToDB(city);
	    }

	    return city;
	}
	public int AddCityToDB(City aCity)
	{
	    aCity.Id = 0;                                 // Set ID to 0 to allow addition to database

	    DBContext.Cities.Add(aCity);
	    DBContext.SaveChanges();
	    return DBContext.Cities.Count();
	}

	public bool RemoveCityFromDB(int ID)
	{
	    bool success = false;

	    City city = DBContext.Cities.Find(ID);
	    if (city != null)
	    {
		Cities.Remove(city);
		DBContext.Cities.Remove(city);
		DBContext.SaveChanges();
		success = true;
	    }
	    return success;
	}

    }
}
