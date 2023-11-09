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

        public string ValidateEmployee(Employee employee)
        {
            if (employee == null)
            {
                return "Employee is Null";
            }
            if (string.IsNullOrEmpty(employee.FirstName))
            {
                return "FirstName is Null Or Empty";
            }
            return string.Empty;
        }
    }
}
