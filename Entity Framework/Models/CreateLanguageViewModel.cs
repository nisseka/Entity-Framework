using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class CreateLanguageViewModel
    {
	[DataType(DataType.Text)]
	[Display(Name = "Name:")]
	[Required(ErrorMessage = "A name is required")]
	public string Name { get; set; }

	public CreateLanguageViewModel()
	{
	    Name = string.Empty;
	}
    }
}
