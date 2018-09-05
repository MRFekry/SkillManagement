using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace SkillManagement.WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        #region Propertirs
        ISQLEmployeeService _sqlEmployeeService;
        #endregion

        #region Constructors
        public EmployeeController()
        {

        }
        public EmployeeController(ISQLEmployeeService sqlEmployeeService)
        {
            _sqlEmployeeService = sqlEmployeeService;
        }
        #endregion

        #region APIs
        // GET: Get all employees
        [Route("Employees")]
        [HttpGet]
        public IEnumerable<SQLEmployee> Get()
        {
            return _sqlEmployeeService.GetAllEmployees();
        }

        // GET: Get employee by id
        [Route("Employee/{Id}")]
        [HttpGet]
        public SQLEmployee Get(long Id)
        {
            return _sqlEmployeeService.GetEmployeeById(Id);
        }

        // POST: Add new employee
        [Route("Employees")]
        [HttpPost]
        public long Post([FromBody]SQLEmployee employee)
        {
            return _sqlEmployeeService.AddEmployee(employee);
        }

        // PUT: Update existing employee
        [Route("Employee/{employee}")]
        [HttpPut]
        public void Put([FromBody]SQLEmployee employee)
        {
            _sqlEmployeeService.UpdateEmployee(employee);
        }

        // DELETE: Delete existing employee
        [Route("Employee/{employee}")]
        [HttpDelete]
        public void Delete([FromBody]SQLEmployee employee)
        {
            _sqlEmployeeService.DeleteEmployee(employee);
        }
        #endregion
    }
}
