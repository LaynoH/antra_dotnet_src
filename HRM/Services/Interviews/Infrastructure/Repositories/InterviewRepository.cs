using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InterviewRepository : BaseRepository<Interview>, IInterviewRepository
{
    private InterviewDbContext _dbContext;
    public InterviewRepository(InterviewDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Interview>> GetAllInterview()
    {
        // with pagination
        var interview = await _dbContext.Interview.Skip(0).Take(10).ToListAsync();
        
        return interview;
    }

    public async Task<Interview> GetInterviewDetails(int id)
    {
        var interview = await _dbContext.Interview.FirstOrDefaultAsync(j => j.Id == id);
        return interview;
    }
}