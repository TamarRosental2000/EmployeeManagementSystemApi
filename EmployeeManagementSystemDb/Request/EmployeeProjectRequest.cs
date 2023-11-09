using System;
using System.Collections.Generic;

namespace EmployeeManagementSystemDb.Request;

public partial class EmployeeProjectRequest
{
    public int EmployeeId { get; set; }

    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    //public virtual EmployeeRequest Employee { get; set; } = null!;
    //public virtual ProjectRequest Project { get; set; } = null!;
}
