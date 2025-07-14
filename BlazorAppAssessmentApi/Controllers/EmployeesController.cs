using BlazorAppAssessmentApi.Data;
using BlazorAppAssessmentApi.SQLOperatiion;
using BlazorAppAssessmentLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public EmployeesController(ApplicationDBContext context)
        {
            _context = context;
        }


        //I can use the repository pattern as well but we have 2 method so
        //i choose this
        private EmployeesSQL sqlInstance { get; set; }
        public EmployeesSQL _sqlInstance
        {
            get
            {
                if (sqlInstance == null)
                    sqlInstance = new EmployeesSQL(_context);
                return sqlInstance;
            }
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                var employees = _sqlInstance.GetAllEmployees();
                if(employees != null)
                    return employees.ToList();
                else
                    return new List<Employee>();
            }
            catch (Exception ex)
            {
                throw ;
            }         
        }

        [HttpPost]  
        public ActionResult PostEmployee(Employee employee)
        {
            var isCreated = _sqlInstance.CreateEmployee(employee);
            if(isCreated)
            {
                return CreatedAtAction("GetEmployee", new { id = employee.UID }, employee);
            }
            return BadRequest();
        }
    }
}
