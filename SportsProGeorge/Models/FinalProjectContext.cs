using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Diagnostics.Metrics;


namespace SportsProGeorge.Models
{
    public class FinalProjectContext : IdentityDbContext<User>
    {

		public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options)
		{ }

		public DbSet<Product> Products { get; set; } = null!;
		public DbSet<Technician> Technicians { get; set; } = null!;
		public DbSet<Customer> Customers { get; set; } = null!;
		public DbSet<Incident> Incidents { get; set; } = null!;
		public DbSet<Country> Countries { get; set; } = null!;


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>().HasData(
	new Product { ProductID = 1, Name = "Tournament Master 1.0", Code = "TRNY10", Price = 4.99M, ReleaseDate = DateTime.Now },
	new Product { ProductID = 2, Name = "League Scheduler 1.0", Code = "LEAG10", Price = 4.99M, ReleaseDate = DateTime.Now },
	new Product { ProductID = 3, Name = "League Scheduler Deluxe 1.0", Code = "LEAGD10", Price = 7.99M, ReleaseDate = DateTime.Now },
	new Product { ProductID = 4, Name = "Draft Manager 1.0", Code = "DRAFT10", Price = 4.99M, ReleaseDate = DateTime.Now },
	new Product { ProductID = 5, Name = "Team Manager 1.0", Code = "TEAM10", Price = 4.99M, ReleaseDate = DateTime.Now },
	new Product { ProductID = 6, Name = "Tournament Master 2.0", Code = "TRNY20", Price = 5.99M, ReleaseDate = DateTime.Now },
	new Product { ProductID = 7, Name = "Draft Manager 2.0", Code = "DRAFT20", Price = 5.99M, ReleaseDate = DateTime.Now }

	);

			modelBuilder.Entity<Technician>().HasData(
				new Technician { TechnicianID = -1, Name = "Select A Technician", Email = "unassigned", PhoneNumber = "unassigned" },
				new Technician { TechnicianID = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", PhoneNumber = "800-555-0443" },
				new Technician { TechnicianID = 2, Name = "Andrew Wilson", Email = "awilson@sportsprosoftware.com", PhoneNumber = "800-555-0449" },
				new Technician { TechnicianID = 3, Name = "Gina Fiori", Email = "gfiori@sportsprosoftware.com", PhoneNumber = "800-555-0459" },
				new Technician { TechnicianID = 4, Name = "Gunter Wendt", Email = "gunter@sportsprosoftware.com", PhoneNumber = "800-555-0400" },
				new Technician { TechnicianID = 5, Name = "Jason Lee", Email = "jason@sportsprosoftware.com", PhoneNumber = "800-555-0444" }
			);

			modelBuilder.Entity<Customer>().HasData(
				new Customer { CustomerID = 1, Name = "Kaitlyn Anthoni", Email = "kanthoni@pge.com", City = "San Francisco", ZipCode = 123456, CountryId = 1, PhoneNumber = "123-456-7890", State = "California", Address = "123 Main Street" },
				new Customer { CustomerID = 2, Name = "Ania Irvin", Email = "ania@mma.nidc.com", City = "Washington", ZipCode = 123457, CountryId = 1, PhoneNumber = "132-456-7899", State = "D.C.", Address = "321 Pine Street" },
				new Customer { CustomerID = 3, Name = "Anton Mauro", Email = "amauro@yahoo.org", City = "Sacramento", ZipCode = 654321, CountryId = 1, PhoneNumber = "111-222-3333", State = "California", Address = "456 Swag Avenue" },
				new Customer { CustomerID = 4, Name = "John Cena", Email = "johncena@gmail.com", City = "Mexico City", ZipCode = 333222, CountryId = 2, PhoneNumber = "555-666-7777", State = "Mexico City", Address = "333 Party Lane" }

				);

			modelBuilder.Entity<Incident>().HasData(
				new Incident { IncidentID = 1, Title = "Could Not Install", Description = "Install does not work", CustomerID = 4, ProductID = 1, TechnicianID = 1, DateOpened = DateTime.Now },
				new Incident { IncidentID = 2, Title = "Could Not Install", Description = "Install does not work", CustomerID = 2, ProductID = 2, TechnicianID = 2, DateOpened = DateTime.Now },
				new Incident { IncidentID = 3, Title = "Crashes", Description = "Crashes on start", CustomerID = 1, ProductID = 1, TechnicianID = 3, DateOpened = DateTime.Now },
				new Incident { IncidentID = 4, Title = "Crashes", Description = "Crashes on start", CustomerID = 3, ProductID = 3, TechnicianID = 4, DateOpened = DateTime.Now }

				);

			modelBuilder.Entity<Country>().HasData(
	new Country { CountryId = 1, Name = "United States" },
	new Country { CountryId = 2, Name = "Canada" },
	new Country { CountryId = 3, Name = "Mexico" }
	);

		}

	}
}
