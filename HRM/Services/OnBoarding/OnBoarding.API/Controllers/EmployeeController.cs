using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
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
            return NotFound(new { error = "No Employees found, please try later." });
        }

        return Ok(employees);
    }
        
    [Route("{id:int}", Name = "GetEmployeeDetails")]
    [HttpGet]
    public async Task<IActionResult> GetEmployeeDetails(int id)
    {
        var employees = await _employeeService.GetEmployeeById(id);
        if (employees==null)
        {
            return NotFound(new { error = "No Employee found for this id" });
        }

        return Ok(employees);
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
        return CreatedAtAction("GetEmployeeDetails", new { controller = "Employee", 
            id = employee}, "Employee Created");
    }
    
    [Route("delete")]
    [HttpDelete]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _employeeService.DeleteEmployee(id);
        if (employee == null)
        {
            return NotFound(new { error = "No Employee found for this id, can't delete" });
        }
        return Ok(employee);
    }
    
}