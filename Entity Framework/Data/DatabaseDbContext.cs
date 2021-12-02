using Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Data
{
    public class DatabaseDbContext : DbContext
    {
	public DbSet<DBPerson> People { get; set; }
	public DbSet<MenuLink> MenuLinks { get; set; }


	public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
	    modelBuilder.Entity<DBPerson>().HasData(new DBPerson { ID = 1, Name = "Niklas", City="Lidköping",PhoneNumber="0510-28826" });
	    modelBuilder.Entity<DBPerson>().HasData(new DBPerson { ID = 2, Name = "Per", City = "Skövde", PhoneNumber = "0500-85855" });
	    modelBuilder.Entity<DBPerson>().HasData(new DBPerson { ID = 3, Name = "Otto", City = "Skara", PhoneNumber = "0511-32448" });

	    modelBuilder.Entity<MenuLink>().HasData(new MenuLink { Name="AJAX", Title= "AJAX Mode", LinkURL= "/AJAX/Index" });
	}
    }
}
