using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Models
{
    public class CreatePersonViewModel
    {
	[Display(Name="Name:")]
	[Required]
	public string Name { get; set; }

	[Display(Name = "Phone Number:")]
	public string PhoneNumber { get; set; }

	[Display(Name = "City:")]
	public string City { get; set; }

	public CreatePersonViewModel()
	{
	    Name = string.Empty;
	    PhoneNumber = string.Empty;
	    City = string.Empty;
	}
    }
}
