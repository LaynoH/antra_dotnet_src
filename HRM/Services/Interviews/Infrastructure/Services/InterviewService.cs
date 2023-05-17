using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class InterviewService : IInterviewService
{
    private readonly IInterviewRepository _interviewRepository;
    public InterviewService(IInterviewRepository employeeRepository)
    {
        _interviewRepository = employeeRepository;
    }
    public async Task<List<InterviewResponseModel>> GetAllInterview()
    {
        var interviews = await _interviewRepository.GetAllInterview();
        var interviewResponseModel = new List<InterviewResponseModel>();
        foreach (var interview in interviews)
        {
            interviewResponseModel.Add(new InterviewResponseModel
            {
                Id = interview.Id, BeginTime = interview.BeginTime, CandidateEmail = interview.CandidateEmail,
                CandidateFirstName = interview.CandidateFirstName, CandidateIdentityId = interview.CandidateIdentityId,
                CandidateLastName = interview.CandidateLastName, EndTime = interview.EndTime, Feedback = interview.Feedback,
                InterviewerId = interview.InterviewerId, InterviewTypeId = interview.InterviewTypeId, Passed = interview.Passed,
                Rating = interview.Rating, SubmissionId = interview.SubmissionId
            });

        }
        return interviewResponseModel;
    }

    public async Task<InterviewRequestModel> GetInterviewDetails(int id)
    {
        var interview = await _interviewRepository.GetInterviewDetails(id);
        if (interview==null)
        {
            return null;
        }
        var interviewResponseModel = new InterviewRequestModel
        {
            Id = interview.Id, BeginTime = interview.BeginTime, CandidateEmail = interview.CandidateEmail,
            CandidateFirstName = interview.CandidateFirstName, CandidateIdentityId = interview.CandidateIdentityId,
            CandidateLastName = interview.CandidateLastName, EndTime = interview.EndTime, Feedback = interview.Feedback,
            InterviewerId = interview.InterviewerId, InterviewTypeId = interview.InterviewTypeId, Passed = interview.Passed,
            Rating = interview.Rating, SubmissionId = interview.SubmissionId
        };
        return interviewResponseModel;
    }

    public async Task<int> AddInterview(InterviewRequestModel model)
    {
        var interviewEntity = new Interview {Id = model.Id, BeginTime = model.BeginTime, CandidateEmail = model.CandidateEmail,
            CandidateFirstName = model.CandidateFirstName, CandidateIdentityId = model.CandidateIdentityId,
            CandidateLastName = model.CandidateLastName, EndTime = model.EndTime, Feedback = model.Feedback,
            InterviewerId = model.InterviewerId, InterviewTypeId = model.InterviewTypeId, Passed = model.Passed,
            Rating = model.Rating, SubmissionId = model.SubmissionId};
        var employee = await _interviewRepository.AddAsync(interviewEntity);
        return employee.Id;
    }

    public async Task<List<InterviewResponseModel>> DeleteInterview(int id)
    {
        var interviewDel = await _interviewRepository.DeleteAsync(id);
        var interviews = await _interviewRepository.GetAllInterview();
        var interviewResponseModel = new List<InterviewResponseModel>();
        foreach (var interview in interviews)
        {
            interviewResponseModel.Add(new InterviewResponseModel
            {
                Id = interview.Id, BeginTime = interview.BeginTime, CandidateEmail = interview.CandidateEmail,
                CandidateFirstName = interview.CandidateFirstName, CandidateIdentityId = interview.CandidateIdentityId,
                CandidateLastName = interview.CandidateLastName, EndTime = interview.EndTime, Feedback = interview.Feedback,
                InterviewerId = interview.InterviewerId, InterviewTypeId = interview.InterviewTypeId, Passed = interview.Passed,
                Rating = interview.Rating, SubmissionId = interview.SubmissionId
            });

        }
        return interviewResponseModel;
    }

    public Task<InterviewRequestModel> Updatenterview(int id)
    {
        throw new NotImplementedException();
    }
}