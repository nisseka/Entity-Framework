using Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Data
{
    [Table("People")]
    public class DBPerson
    {
	[Key]
	public int ID { get; set; }

	[Required]
	public string Name { get; set; }

	public string PhoneNumber { get; set; }
	
	public City City { get; set; }
	public int CityId { get; set; }

	public DBPerson()
	{

	}

	public DBPerson(CreatePersonViewModel personData)
	{
	    Name = personData.Name;
	    PhoneNumber = personData.PhoneNumber;
	    CityId = personData.CityId;
	}

	public DBPerson(Person source)
	{
	    Name = source.Name;
	    PhoneNumber = source.PhoneNumber;
//	    City = source.City;
	    ID = source.ID;
	}
    }

}
