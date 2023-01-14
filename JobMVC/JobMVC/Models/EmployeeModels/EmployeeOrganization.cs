using System;
using JobMVC.Models;
public class EmployeeOrganization
{
    //
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public int OrganizationId { get; set; }
    public Organization Organization { get; set; }
}