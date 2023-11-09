using System;
using System.Collections.Generic;

namespace EmployeeManagementSystemDb.Request;

public partial class EmployeeRequest
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Department { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public decimal Salary { get; set; }

    //public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
}
