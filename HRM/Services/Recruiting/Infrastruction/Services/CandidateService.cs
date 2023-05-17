using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastruction.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;
    public CandidateService(ICandidateRepository candidateRepository)
    {
        _candidateRepository = candidateRepository;
    }
    
    public async Task<List<CandidateResponseModel>> GetAllCandidates()
    {
        var candidates = await _candidateRepository.GetAllAsync();
        var candidateResponseModel = new List<CandidateResponseModel>();
        foreach (var candidate in candidates)
        {
            candidateResponseModel.Add(new CandidateResponseModel()
            {
                Id = candidate.Id, FirstName = candidate.FirstName, LastName = candidate.LastName, MiddleName = candidate.MiddleName,
                Email = candidate.Email, ResumeURL = candidate.ResumeURL, CreatedOn = candidate.CreatedOn
            });

        }

        return candidateResponseModel;
    }
    public async Task<CandidateRequestModel> GetCandidateById(int id)
    {
        var candidate = await _candidateRepository.GetCandidateById(id);
        if (candidate==null)
        {
            return null;
        }
        var candidateResponseModel = new CandidateRequestModel
        {
            Id = candidate.Id, FirstName = candidate.FirstName, LastName = candidate.LastName, MiddleName = candidate.MiddleName,
            Email = candidate.Email, ResumeURL = candidate.ResumeURL, CreatedOn = candidate.CreatedOn
        };
        return candidateResponseModel;
    }

    public async Task<int> AddCandidate(CandidateRequestModel model, int jobId)
    {
        var candidateEntity = new Candidate { FirstName = model.FirstName, LastName = model.LastName, MiddleName = model.MiddleName,
            Email = model.Email, ResumeURL = model.ResumeURL, CreatedOn = model.CreatedOn
        };
        
        var submissionEntity = new Submission
        {
            JobId = jobId, CandidateId = model.Id, SubmittedOn = DateTime.UtcNow
        };
        var candidate = await _candidateRepository.AddAsync(candidateEntity);
        await _candidateRepository.AddSubmission(submissionEntity);
        
        return candidate.Id;
    }
    
    public async Task<CandidateRequestModel> UpdateResume(int id, string ResumeURL)
    {
        var candidate = await _candidateRepository.UpdateResume(id, ResumeURL);
        if (candidate==null)
        {
            return null;
        }
        var candidateResponseModel = new CandidateRequestModel
        {
            Id = candidate.Id, FirstName = candidate.FirstName, LastName = candidate.LastName, MiddleName = candidate.MiddleName,
            Email = candidate.Email, ResumeURL = candidate.ResumeURL, CreatedOn = candidate.CreatedOn
        };
        return candidateResponseModel;
    }
}