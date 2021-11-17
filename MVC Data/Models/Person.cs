using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Models
{
    public class Person
    {
	public string Name { get; set; }
	public string PhoneNumber { get; set; }
	public string City { get; set; }

	public int ID { get; set; }

	public string CookieString 
	{ 
	    get { return $"{Name},{PhoneNumber},{City}\r\n"; } 
	    set
	    {
		string[] cookieParameters = value.Split(',');
		if (cookieParameters.Length > 0)
		{
		    Name = cookieParameters[0];
		}
		if (cookieParameters.Length > 1)
		{
		    PhoneNumber = cookieParameters[1];
		}
		if (cookieParameters.Length > 2)
		{
		    City = cookieParameters[2];
		}
	    }
	}

	public Person()
	{
	    Name = string.Empty;
	    PhoneNumber = string.Empty;
	    City = string.Empty;
	}

	public Person(CreatePersonViewModel personData)
	{
	    Name = personData.Name;
	    PhoneNumber = personData.PhoneNumber;
	    City = personData.City;
	}

	public Person(string aName, string aCity, string aPhoneNumber)
	{
	    Name = aName;
	    City = aCity;
	    PhoneNumber = aPhoneNumber;
	}
    }
}
