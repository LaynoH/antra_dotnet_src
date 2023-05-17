using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastruction.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastruction.Repositories;

public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
{
    private RecruitingDbContext _dbContext;
    public CandidateRepository(RecruitingDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Candidate> UpdateResume(int id, string ResumeURL)
    {
        var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(j => j.Id == id);
        candidate.ResumeURL = ResumeURL;
        
        return candidate;
    }
    public async Task<Candidate> GetCandidateById(int id)
    {
        var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(j => j.Id == id);
        return candidate;
    }
    
    public async Task<Submission> AddSubmission(Submission submission)
    {
        _dbContext.Submissions.Add(submission);
        await _dbContext.SaveChangesAsync();
        return submission;
    }

}