using System;
using JobMVC.Models;
using JobMVC.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobMVC.DataAccessLayer
{
	public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		private DbSet<AppUser> AppUsers => Set<AppUser>();
		public DbSet<Cv> Cvs { get; set; }
	}
}

