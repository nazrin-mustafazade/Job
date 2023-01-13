using System;
namespace JobMVC.Models
{
	public class Skill
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Area { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
        //

        public ICollection<OrganizationSkill> OrganizationSkills { get; set; }

    }
}

