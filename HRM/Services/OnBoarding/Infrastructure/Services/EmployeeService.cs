using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task<List<EmployeeResponseModel>> GetAllEmployees()
    {
        var employees = await _employeeRepository.GetAllEmployees();
        var employeeResponseModel = new List<EmployeeResponseModel>();
        foreach (var employee in employees)
        {
            employeeResponseModel.Add(new EmployeeResponseModel
            {
                Id = employee.Id, Address = employee.Address, EmployeeStatusId = employee.EmployeeStatusId, 
                FirstName = employee.FirstName, LastName = employee.LastName, SSN = employee.SSN
            });

        }
        return employeeResponseModel;
    }

    public async Task<EmployeeRequestModel> GetEmployeeById(int id)
    {
        var employee = await _employeeRepository.GetEmployeeById(id);
        if (employee==null)
        {
            return null;
        }
        var employeeResponseModel = new EmployeeRequestModel
        {
            Id = employee.Id, Address = employee.Address, EmployeeStatusId = employee.EmployeeStatusId, 
            FirstName = employee.FirstName, LastName = employee.LastName, SSN = employee.SSN
        };
        return employeeResponseModel;
    }

    public async Task<int> AddEmployee(EmployeeRequestModel model)
    {
        var employeeEntity = new Employee {Address = model.Address, EmployeeStatusId = model.EmployeeStatusId, 
            FirstName = model.FirstName, LastName = model.LastName, SSN = model.SSN};
        var employee = await _employeeRepository.AddAsync(employeeEntity);
        return employee.Id;
    }

    public async Task<List<EmployeeResponseModel>> DeleteEmployee(int id)
    {
        var employeeDel = await _employeeRepository.DeleteAsync(id);
        var employees = await _employeeRepository.GetAllEmployees();
        var employeeResponseModel = new List<EmployeeResponseModel>();
        foreach (var employee in employees)
        {
            employeeResponseModel.Add(new EmployeeResponseModel
            {
                Id = employee.Id, Address = employee.Address, EmployeeStatusId = employee.EmployeeStatusId, 
                FirstName = employee.FirstName, LastName = employee.LastName, SSN = employee.SSN
            });

        }
        return employeeResponseModel;
    }

    public async Task<EmployeeRequestModel> AsInterviewer(int id)
    {
        var employee = await _employeeRepository.AsInterviewer(id);
        if (employee==null)
        {
            return null;
        }
        var employeeResponseModel = new EmployeeRequestModel
        {
            Id = employee.Id, Address = employee.Address, EmployeeStatusId = employee.EmployeeStatusId, 
            FirstName = employee.FirstName, LastName = employee.LastName, SSN = employee.SSN
        };
        return employeeResponseModel;
    }
}