using EmployeeManagementSystemApi.Controllers;
using EmployeeManagementSystemDb.Models;
using EmployeeManagementSystemDb.Request;

namespace EmployeeManagementSystemApi.Logic
{
    public class ValidateRequest
    {
        private readonly ILogger<EmployeeManagementController> _logger;
        public ValidateRequest(ILogger<EmployeeManagementController> logger)
        {
            _logger = logger;
        }

        public string ValidateEmployee(EmployeeRequest employee)
        {
            if (employee == null)
            {
                return "Employee is Null";
            }
            if (string.IsNullOrEmpty(employee.FirstName))
            {
                return "FirstName is Null Or Empty";
            }
            if (string.IsNullOrEmpty(employee.LastName))
            {
                return "LastName is Null Or Empty";
            }
            if (string.IsNullOrEmpty(employee.Department))
            {
                return "Department is Null Or Empty";
            }
            if (employee.HireDate == DateTime.MinValue)
            {
                return "HireDate is required";
            }
            if (employee.Salary<0)
            {
                return "Salary is required";
            }
            return string.Empty;
        }

        internal string ValidateId(int id)
        {
            if (id == null)
            {
                return "Employee is Null";
            }
            if (id<0)
            {
                return "EmployeeId is Invalid";
            }
            return string.Empty;
        }

        internal string ValidateProject(ProjectRequest projectRequest)
        {
            if (projectRequest.StartDate==DateTime.MinValue)
            {
                return "StartDate is required";
            }
            if (string.IsNullOrEmpty(projectRequest.ProjectName))
            {
                return "ProjectName is required";
            }
            return string.Empty;

        }
    }
}
