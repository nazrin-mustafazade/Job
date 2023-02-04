using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using JobMVC.Models;
using JobMVC.Models.EmployerModels;

namespace JobMVC.Models.Identity
{
	public class AppUser : IdentityUser
	{
		public AppUser()
		{
			this.Applicants = new HashSet<Applicant>();
		}
		public string FirstName { get; set; } 
		public string LastName { get; set; } 
		public string FullName { get { return FirstName + " " + LastName; } }
		public string Address { get; set; } 
		public string City { get; set; }
		public string State { get; set; } 
		public string? Zip { get; set; }
		public string Country { get; set; } 
		
		//EMPLOYER
		public string? Company { get; set; }
		public int EmployerSize { get; set; }
		public DateTime EstablishDate { get; set; }
		public string Category { get; set; }
		
		
		public string ImageUrl { get; set; }
		[NotMapped]
		public IFormFile ProfileImage { get; set; }
		
		public string? Title { get; set; }
		public string? Department { get; set; }
		public string? Notes { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public DateTime LastLogin { get; set; }
		public bool IsAdmin { get; set; }
		public bool IsEmployer { get; set; }
		
		public Cv Cv { get; set; }
		public virtual ICollection<Applicant> Applicants { get; set; }
		
	}
}

