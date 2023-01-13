using System;
namespace JobMVC.Models
{
	public class OrganizationSkill
	{
		public int Id { get; set; }

		public int OrganizationId { get; set; }
		public Organization Organization { get; set; }

		public int SkillId { get; set; }
		public Skill Skill { get; set; }

	}
}

