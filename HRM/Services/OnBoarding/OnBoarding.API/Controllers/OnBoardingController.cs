using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnBoarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnBoardingController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public OnBoardingController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            if (!employees.Any())
            {
                return NotFound(new { error = "No open jobs found, please try later." });
            }

            return Ok(employees);
        }
        
        [Route("{id:int}", Name = "GetEmployeeDetails")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails(int id)
        {
            var job = await _employeeService.GetEmployeeById(id);
            if (job==null)
            {
                return NotFound(new { error = "No job found for this id" });
            }

            return Ok(job);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var employee = await _employeeService.AddEmployee(model);
            return CreatedAtAction("GetEmployeeDetails", new { controller = "Employees", id = employee, EmployeeCreated = "Employee Created" });
        }
    }
}
