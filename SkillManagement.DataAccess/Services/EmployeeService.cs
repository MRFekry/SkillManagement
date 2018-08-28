using System.Collections.Generic;
using SkillManagement.DataAccess.Entities;
using SkillManagement.DataAccess.Interfaces;

namespace SkillManagement.DataAccess.Services
{
    public class EmployeeService : IEmployeeService
    {
        IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddEmployee(Employee employee)
        {
            return _unitOfWork.EmployeeRepository.Add(employee);
            //_unitOfWork.Complete();
        }

        public void DeleteEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Delete(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _unitOfWork.EmployeeRepository.GetAll();
        }

        public Employee GetEmployeeById(long Id)
        {
            return _unitOfWork.EmployeeRepository.Get(Id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
        }
    }
}
