using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastruction.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastruction.Repositories
{
	public class JobRepository: BaseRepository<Job>, IJobRepository
	{
		private RecruitingDbContext _dbContext;
		public JobRepository(RecruitingDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		
		public async Task<List<Job>> GetAllJobs()
		{
			// go to the database and get the data
			// EF core with LINQ
			var jobs = await _dbContext.Jobs.ToListAsync();
			return jobs;
			//throw new NotImplementedException();
		}

		public async Task<Job> GetJobById(int id)
		{
			var job = await _dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == id);
			return job;
		}
	}
}

