using System;
namespace JobMVC.Models
{
	public class OrganizationTitle
	{
		public int Id { get; set; }

		public int OrganizationId { get; set; }
		public Organization Organization { get; set; }

		public int TitleId { get; set; }
		public Title Title { get; set; }
	}
}

