using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface IJobService
	{
		Task<List<JobResponseModel>> GetAllJobs();

		Task<JobRequestModel> GetJobById(int id);

		Task<int> AddJob(JobRequestModel model);
	}
}

