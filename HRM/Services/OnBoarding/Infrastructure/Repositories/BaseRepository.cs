using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly EmployeeDbContext _dbContext;

    public BaseRepository(EmployeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null)
    {
        throw new NotImplementedException();
    }

    public async Task<T> AddAsync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Employee>> DeleteAsync(int id)
    {
        var employee = await _dbContext.Employees.FirstOrDefaultAsync(j => j.Id == id);
        if (employee != null)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            var employees = await _dbContext.Employees.ToListAsync();
            return employees;
        }
        return null;
    }
}