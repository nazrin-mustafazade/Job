using System;
using JobMVC.Models;
using JobMVC.Models.EmployerModels;
using JobMVC.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JobMVC.DataAccessLayer
{
	public class AppDbContext : IdentityDbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		private DbSet<AppUser> AppUsers => Set<AppUser>();
		public DbSet<Cv> Cvs { get; set; }
		public DbSet<Vacancy> Vacancies { get; set; }
		public DbSet<Applicant> Applicants { get; set; }
		

        public class YourDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseNpgsql("Server=localhost;Database=CourseWorkJob1;Uid=postgres;Password=Promises00;");

                return new AppDbContext(optionsBuilder.Options);
            }
        }
    }
}

