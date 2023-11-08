namespace EmployeeManagementSystemDb.Models;

public partial class Employee
{
    public virtual int EmployeeId { get; set; }

    public virtual string FirstName { get; set; } = null!;

    public virtual  string LastName { get; set; } = null!;
            
    public virtual  string Department { get; set; } = null!;
            
    public virtual  DateTime HireDate { get; set; }
            
    public virtual decimal Salary { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
