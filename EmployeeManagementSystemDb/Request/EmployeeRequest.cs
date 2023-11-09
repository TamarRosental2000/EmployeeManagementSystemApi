using System;
using System.Collections.Generic;

namespace EmployeeManagementSystemDb.Request;

public partial class EmployeeRequest
{

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Department { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public decimal Salary { get; set; }

 }
