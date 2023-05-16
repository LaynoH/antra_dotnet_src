using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IEmployeeService
{
    Task<List<EmployeeResponseModel>> GetAllEmployees();

    Task<EmployeeRequestModel> GetEmployeeById(int id);

    Task<int> AddEmployee(EmployeeRequestModel model);
    
    Task<List<EmployeeResponseModel>> DeleteEmployee(int id);
    
    Task<EmployeeRequestModel> AsInterviewer(int id);
}