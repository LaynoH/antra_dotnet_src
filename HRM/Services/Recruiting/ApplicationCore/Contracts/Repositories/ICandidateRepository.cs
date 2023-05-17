using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface ICandidateRepository : IBaseRepository<Candidate>
	{
		//Task<List<Candidate>> GetAllCandidates();
		Task<Candidate> UpdateResume(int id, string ResumeURL);
		Task<Candidate> GetCandidateById(int id);

		Task<Submission> AddSubmission(Submission submission);
	}
}

