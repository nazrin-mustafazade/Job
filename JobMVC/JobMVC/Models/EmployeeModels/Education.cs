using System;
namespace JobMVC.Models
{
	public class Education
	{
		public int Id { get; set; }
		public DateTime DateEarned { get; set; }
		public string Title { get; set; } = null!;
		public string Type { get; set; } = null!;
		public string Institution { get; set; } = null!;
		public string? Description { get; set; }

	}
}

