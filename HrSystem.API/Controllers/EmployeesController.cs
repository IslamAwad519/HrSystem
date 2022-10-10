using BussinessLogic.Repositories;
using HrSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employee> repository;

        public EmployeesController(IRepository<Employee> _repository)
        {
            this.repository = _repository;
        }

        // GET
        [HttpGet]
        public IActionResult GetEmployees()
        {
            List<Employee> employees;
            try
            {
                employees = repository.GetAll().ToList();
            }
            catch
            {
                return BadRequest();
            }

            return Ok(employees);
        }

        // GET:
        [HttpGet("{id}")]
        public IActionResult GetEmployeByID(int id)
        {
            Employee employee;
            try
            {
                employee = repository.Get(x => x.Id == id);

                if (employee == null)
                    return NotFound("Employee doesn't exist");
            }
            catch
            {
                return BadRequest();
            }

            return Ok(employee);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult PutEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (employee.Id == 0)
                return BadRequest("Employee Id Must Contains a value");

            try
            {
                repository.Update(employee);
                repository.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok("Successfully Updated");
        }

        // POST
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else if (repository.IsExists(x => x.Id == employee.Id))
                return BadRequest("Employee with the same id exits");

            try
            {
                repository.Add(employee);
                repository.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                Employee employee = repository.Get(x => x.Id == id);

                if (employee == null)
                    return NotFound("Employee you want to delete doesn't exist");

                repository.Delete(id);
                repository.SaveChanges();
            }
            catch
            {
                return NotFound();
            }

            return Ok("Employee Deleted Successfully");
        }
    }
}
