using System;
namespace JobMVC.Models
{
	public class Organization
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public string Name { get; set; } = null!;
		public string Type { get; set; } = null!;
		public int Size { get; set; }
		public string? Industry { get; set; }
		public string? Detail { get; set; }

		//

		public ICollection<OrganizationTitle> OrganizationTitles { get; set; }
		public ICollection<OrganizationSkill> OrganizationSkills { get; set; }

	}
}

