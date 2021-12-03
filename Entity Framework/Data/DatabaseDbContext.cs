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
	public DbSet<City> Cities { get; set; }
	public DbSet<Country> Countries { get; set; }

	public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
	    modelBuilder.Entity<DBPerson>()
		.HasOne(person => person.City)
		.WithMany(city => city.People)
		.HasForeignKey(person => person.CityId);

	    modelBuilder.Entity<City>()
		.HasOne(city => city.Country)
		.WithMany(country => country.Cities)
		.HasForeignKey(city => city.CountryId);

	    modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Sverige", CountryCode="SE" });

	    modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Lidköping", CountryId = 1 });
	    modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "Skövde", CountryId = 1 });
	    modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "Skara", CountryId = 1 });

	    modelBuilder.Entity<DBPerson>().HasData(new DBPerson { ID = 1, Name = "Niklas", CityId=1, PhoneNumber="0510-28826" });
	    modelBuilder.Entity<DBPerson>().HasData(new DBPerson { ID = 2, Name = "Per", CityId = 2, PhoneNumber = "0500-85855" });
	    modelBuilder.Entity<DBPerson>().HasData(new DBPerson { ID = 3, Name = "Otto", CityId = 3, PhoneNumber = "0511-32448" });

	    modelBuilder.Entity<MenuLink>().HasData(new MenuLink { Name = "AJAX", Title= "AJAX Mode", LinkURL= "/AJAX/" });
	    modelBuilder.Entity<MenuLink>().HasData(new MenuLink { Name = "Cities", Title = "Cities", LinkURL = "/Cities/" });
	    modelBuilder.Entity<MenuLink>().HasData(new MenuLink { Name = "Countries", Title = "Countries", LinkURL = "/Countries/" });
	    modelBuilder.Entity<MenuLink>().HasData(new MenuLink { Name = "People", Title = "People", LinkURL = "/Home/" });
	}
    }
}
