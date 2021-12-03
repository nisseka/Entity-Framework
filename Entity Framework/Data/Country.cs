using Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Data
{
    [Table("Countries")]
    public class Country
    {
	[Key]
	public int Id { get; set; }

	[Required]
	[MaxLength(60, ErrorMessage = "Country name is too long")]
	public string Name { get; set; }

	[Required]
	[MaxLength(2,ErrorMessage = "Contry Code is max 2 characters")]
	public string CountryCode { get; set; }

	public List<City> Cities { get; set; }

	public Country()
	{

	}

	public Country(CreateCountryViewModel countryData)
	{
	    Name = countryData.Name;
	    CountryCode = countryData.CountryCode.ToUpper();
	}
    }
}
