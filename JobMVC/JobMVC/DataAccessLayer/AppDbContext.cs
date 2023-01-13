using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobMVC.DataAccessLayer
{
	public class AppDbContext : IdentityDbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}
	}
}

