using BussinessLogic.Repositories;
using HrSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IRepository<Department> repository;

        public DepartmentsController(IRepository<Department> _repository)
        {
            this.repository = _repository;
        }

        // GET
        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            List<Department> departments;
            try
            {
                departments = repository.GetAll().ToList();
            }
            catch
            {
                return BadRequest();
            }

            return Ok(departments);
        }

        // GET:
        [HttpGet("{id}")]
        public IActionResult GetDepartmentByID(int id)
        {
            Department department;
            try
            {
                department = repository.Get(x => x.Id == id);

                if (department == null)
                    return NotFound("department doesn't exist");
            }
            catch
            {
                return BadRequest();
            }

            return Ok(department);
        }
        // POST
        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else if (repository.IsExists(x => x.Id == department.Id))
                return BadRequest("department with the same id exits");

            try
            {
                repository.Add(department);
                repository.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Created("GetDepartmentByID", department);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult PutDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (department.Id == 0)
                return BadRequest("department Id Must Contains a value");

            try
            {
                repository.Update(department);
                repository.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok("Successfully Updated");
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                Department department = repository.Get(x => x.Id == id);

                if (department == null)
                    return NotFound("Department you want to delete doesn't exist");

                repository.Delete(id);
                repository.SaveChanges();
            }
            catch
            {
                return NotFound();
            }

            return Ok("Department Deleted Successfully");
        }
    }
}
