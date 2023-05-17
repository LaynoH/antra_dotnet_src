using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly InterviewDbContext _dbContext;

    public BaseRepository(InterviewDbContext dbContext)
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

    public async Task<Interview> UpdateAsync(int id)
    {
        var interview = await _dbContext.Interview.FirstOrDefaultAsync(j => j.Id == id);
        if (interview!= null)
        {
            interview.InterviewTypeId = 3;
            
            await _dbContext.SaveChangesAsync();
            return interview;
        }

        return null;
    }

    public async Task<List<Interview>> DeleteAsync(int id)
    {
        var interview = await _dbContext.Interview.FirstOrDefaultAsync(j => j.Id == id);
        if (interview != null)
        {
            _dbContext.Interview.Remove(interview);
            await _dbContext.SaveChangesAsync();
            var interviews = await _dbContext.Interview.ToListAsync();
            return interviews;
        }
        return null;
    }
}