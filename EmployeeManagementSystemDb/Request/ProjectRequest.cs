using System;
using System.Collections.Generic;

namespace EmployeeManagementSystemDb.Request;

public partial class ProjectRequest
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

   // public virtual ICollection<EmployeeProjectRequest> EmployeeProjects { get; set; } = new List<EmployeeProjectRequest>();
}
