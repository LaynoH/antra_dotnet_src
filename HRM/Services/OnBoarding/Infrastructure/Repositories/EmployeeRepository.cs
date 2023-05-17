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
        // with pagination
        var employees = await _dbContext.Employees.Skip(0).Take(10).ToListAsync();
        
        return employees;
    }

    public async Task<Employee> GetEmployeeById(int id)
    {
        var employee = await _dbContext.Employees.FirstOrDefaultAsync(j => j.Id == id);
        return employee;
    }

    public async Task<Employee> AsInterviewer(int id)
    {
        var employee = await _dbContext.Employees.FirstOrDefaultAsync(j => j.Id == id);
        if (employee!= null)
        {
            employee.EmployeeStatusId = 3;
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        return null;
    }
}