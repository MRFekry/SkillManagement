using SkillManagement.DataAccess.Entities;
using SkillManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkillManagement.WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        #region Propertirs
        IEmployeeService _employeeService;
        #endregion

        #region Constructors
        public EmployeeController()
        {

        }
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region APIs
        // GET: Get all employees
        [Route("Employees")]
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeService.GetAllEmployees();
        }

        // GET: Get employee by id
        [Route("Employee/{Id}")]
        [HttpGet]
        public Employee Get(long Id)
        {
            return _employeeService.GetEmployeeById(Id);
        }

        // POST: Add new employee
        [Route("Employees")]
        [HttpPost]
        public int Post([FromBody]Employee employee)
        {
            return _employeeService.AddEmployee(employee);
        }

        // PUT: Update existing employee
        [Route("Employee/{employee}")]
        [HttpPut]
        public void Put(int id, [FromBody]Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
        }

        // DELETE: Delete existing employee
        [Route("Employee/{employee}")]
        [HttpDelete]
        public void Delete([FromBody]Employee employee)
        {
            _employeeService.DeleteEmployee(employee);
        }
        #endregion
    }
}
