using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IInterviewRepository: IBaseRepository<Interview>
{
    Task<List<Interview>> GetAllInterview();
    Task<Interview> GetInterviewDetails(int id);
    
}