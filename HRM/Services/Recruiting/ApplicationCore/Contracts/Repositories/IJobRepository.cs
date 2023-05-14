using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface IJobRepository : IBaseRepository<Job>
	{
		Task<List<Job>> GetAllJobs();
		Task<Job> GetJobById(int id);
	}
}

