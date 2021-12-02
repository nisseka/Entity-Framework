using Entity_Framework.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Controllers
{
    public class DBController : Controller
    {
        public readonly DatabaseDbContext DBContext;

	public DBController(DatabaseDbContext context)
	{
	    DBContext = context;
	}

    }
}
