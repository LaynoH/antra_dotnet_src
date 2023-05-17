using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IInterviewService
{
    Task<List<InterviewResponseModel>> GetAllInterview();

    Task<InterviewRequestModel> GetInterviewDetails(int id);

    Task<int> AddInterview(InterviewRequestModel model);
    
    Task<List<InterviewResponseModel>> DeleteInterview(int id);
    
    Task<InterviewRequestModel> Updatenterview(int id);
}