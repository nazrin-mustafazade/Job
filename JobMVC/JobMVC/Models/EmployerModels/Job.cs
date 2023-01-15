using System;
namespace JobMVC.Models.EmployerModels
{
	public class Job
	{
		public int Id { get; set; }
		public int Code { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public DateTime DatePublished { get; set; }
		public int NumberOfVacancies { get; set; }


	}
}

