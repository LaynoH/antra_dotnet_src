using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IEmployeeRepository: IBaseRepository<Employee>
{
    Task<List<Employee>> GetAllEmployees();
    Task<Employee> GetEmployeeById(int id);

    Task<Employee> AsInterviewer(int id);
}