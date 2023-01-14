using System;
namespace JobMVC.Models
{
	public class Location
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string City { get; set; } = null!;
		public string State { get; set; } = null!;
		public string Country { get; set; } = null!;


    }
}

