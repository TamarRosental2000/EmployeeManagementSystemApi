using EmployeeManagementSystemDb.Models;
using EmployeeManagementSystemDb.Utils;
using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDb.Command
{
    public class EmployeeService
    {
        private readonly UnitOfWork _unitOfWork;

        public EmployeeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SaveOrUpdateEmployee(Employee employee)
        {
            _unitOfWork.SaveOrUpdate(employee);
            _unitOfWork.Commit();
        }

        public void DeleteEmployee(int employeeId)
        {
            var itemToDelete = _unitOfWork.Get<Employee>(employeeId);
            if (itemToDelete != null)
            {
                _unitOfWork.Delete(itemToDelete);
                _unitOfWork.Commit();
            }
        }
    }

}
