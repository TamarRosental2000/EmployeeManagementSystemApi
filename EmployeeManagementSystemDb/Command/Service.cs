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
    public class Service
    {
        private readonly UnitOfWork _unitOfWork;

        public Service(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SaveOrUpdate<T>(T entity)
        {
            _unitOfWork.SaveOrUpdate(entity);
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
        public Project GetProject(int projectId)
        {
            return _unitOfWork.Get<Project>(projectId);
 
        }
        public Employee GetEmployee(int employeeId)
        {
            return _unitOfWork.Get<Employee>(employeeId);
        }
    }

}
