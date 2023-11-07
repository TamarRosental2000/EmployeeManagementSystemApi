using System;
using System.Collections.Generic;

namespace EmployeeManagementSystemApi.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Department { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public decimal Salary { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
