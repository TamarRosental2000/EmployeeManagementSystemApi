namespace EmployeeManagementSystemDb.Models;

public partial class Project
{
    public virtual int ProjectId { get; set; }

    public virtual string ProjectName { get; set; } = null!;

    public virtual string? Description { get; set; }

    public virtual DateTime StartDate { get; set; }

    public virtual DateTime? EndDate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
