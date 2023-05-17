using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface ICandidateService
	{
		Task<List<CandidateResponseModel>> GetAllCandidates();
		Task<CandidateRequestModel> GetCandidateById(int id);

		Task<int> AddCandidate(CandidateRequestModel model, int id);
		
		Task<CandidateRequestModel> UpdateResume(int id, string ResumeURL);
	}
}

