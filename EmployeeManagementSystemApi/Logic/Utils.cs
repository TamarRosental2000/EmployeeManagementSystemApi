using EmployeeManagementSystemDb.Models;
using EmployeeManagementSystemDb.Request;

namespace EmployeeManagementSystemApi.Logic
{
    public class Utils
    {
        internal Employee BuildEmployee(EmployeeRequest employee)
        {
            return new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                HireDate = employee.HireDate,
                Salary = employee.Salary,
                Department = employee.Department,
                //Projects = new List<Project>()
            };
        }

        internal object BuildProject(ProjectRequest projectRequest)
        {
            return new Project()
            {
                Description = projectRequest.Description,
                ProjectName = projectRequest.ProjectName,
                StartDate = projectRequest.StartDate,
                EndDate = projectRequest.EndDate,
            };
        }
    }
}
