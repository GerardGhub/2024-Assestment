using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skubss.WebAPI.Data;
using Skubss.WebAPI.DTOs;
using Skubss.WebAPI.Models;

namespace Skubss.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// get the employee based on id param
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>



        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
        {
            var employees = await _db.Employees.FindAsync(id);

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }


        /// <summary>
        /// Adding new employee
        /// </summary>
        /// <param name="addEmployee"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> AddEmployees(EmployeeRegistrationDto addEmployee)
        {
            var employee = new Employee()
            {
                FirstName = addEmployee.FirstName,
                LastName = addEmployee.LastName,
                DateOfBirth = addEmployee.DateOfBirth
            };


            var checkEmployeeInfo = await _db.Employees.Where(temp => temp.FirstName == addEmployee.FirstName
            && temp.LastName == addEmployee.LastName && temp.DateOfBirth == addEmployee.DateOfBirth).ToListAsync();


            if (checkEmployeeInfo.Count > 0)
            {
                return BadRequest(new { message = "Employee already exist!" });
            }

            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return Ok(employee);

        }


        /// <summary>
        /// Getting all the employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _db.Employees.ToListAsync());
        }

        /// <summary>
        /// Update the Information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateEmployeeDetails"></param>
        /// <returns></returns>

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, EmployeeRegistrationDto updateEmployeeDetails)
        {
            var employee = await _db.Employees.FindAsync(id);

            if (employee != null)
            {
                employee.FirstName = updateEmployeeDetails.FirstName;
                employee.LastName = updateEmployeeDetails.LastName;
                employee.DateOfBirth = updateEmployeeDetails.DateOfBirth;

                await _db.SaveChangesAsync();

                return Ok(employee);
            }
            return NotFound();

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _db.Employees.FindAsync(id);
            if (employee != null)
            {
                _db.Remove(employee);
                await _db.SaveChangesAsync();
                return Ok(employee);
            }
            return NotFound();
        }






    }
}
