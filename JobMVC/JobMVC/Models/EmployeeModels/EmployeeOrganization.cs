using System;
using JobMVC.Models;
using JobMVC.Models.Identity;

public class EmployeeOrganization
{
    //
    public int EmployeeId { get; set; }
    public AppUser Employee { get; set; }

    public int OrganizationId { get; set; }
    public Organization Organization { get; set; }
}