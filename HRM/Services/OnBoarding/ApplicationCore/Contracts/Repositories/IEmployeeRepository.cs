using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IEmployeeRepository: IBaseRepository<Employee>
{
    Task<List<Employee>> GetAllEmployees();
    Task<Employee> GetEmployeeById(int id);
}