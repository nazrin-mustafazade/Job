using System;
namespace JobMVC.Models
{
	public class Title
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string? Description { get; set; }

        //

        public ICollection<OrganizationTitle> OrganizationTitles { get; set; }

    }
}

