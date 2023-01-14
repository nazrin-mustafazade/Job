using System;
using JobMVC.Models.Identity;

namespace JobMVC.Models
{
	public class Employee : AppUser
	{
		public Education Education {get; set;}
        public int EducationId {get; set;}

        public Location Location {get; set;}
        public int LocationId {get; set;}   

        public ICollection<EmployeeOrganization> EmployeeOrganizations { get; set; }


    }
}