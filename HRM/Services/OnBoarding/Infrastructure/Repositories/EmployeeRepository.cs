using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    private EmployeeDbContext _dbContext;
    public EmployeeRepository(EmployeeDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Employee>> GetAllEmployees()
    {
        var employees = await _dbContext.Employees.ToListAsync();
        return employees;
    }

    public async Task<Employee> GetEmployeeById(int id)
    {
        var employee = await _dbContext.Employees.FirstOrDefaultAsync(j => j.Id == id);
        return employee;
    }
    
}