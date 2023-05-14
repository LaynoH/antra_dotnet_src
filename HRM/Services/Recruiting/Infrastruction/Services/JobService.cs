using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastruction.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }
    public async Task<List<JobResponseModel>> GetAllJobs()
    {
        var jobs = await _jobRepository.GetAllJobs();
        var jobResponseModel = new List<JobResponseModel>();
        foreach (var job in jobs)
        {
            jobResponseModel.Add(new JobResponseModel
            {
                Id = job.Id, Description = job.Description, Ttile = job.Title, StartDate = job.StartDate.GetValueOrDefault(), NumberOfPositions = job.NumberOfPositions
            });

        }

        return jobResponseModel;

        // have some dummy data
        // get the data from repositories and send the model info to the controller
        /*var jobs = new List<JobResponseModel>()
        {
            new (){Id = 1, Ttile = ".NET Developer", Description = "Need to be good with C# and EF core and .NET"},
            new (){Id = 2, Ttile = "Full Stack .NET Developer", Description = "Need to be good with Typescript "},
            new JobResponseModel{Id = 3, Ttile = "Java Developer", Description = "Need to be good with Java"},
            new JobResponseModel{Id = 4, Ttile = "JavaScript Developer", Description = "Need to be good with JavaScript"}
        };
        return jobs;
        */
    }

    public async Task<JobRequestModel> GetJobById(int id)
    {
        var job = await _jobRepository.GetJobById(id);
        if (job==null)
        {
            return null;
        }
        var jobResponseModel = new JobRequestModel
        {
            Id = job.Id, Ttile = job.Title, StartDate = job.StartDate.GetValueOrDefault( ), Description = job.Description
        };
        return jobResponseModel;
    }

    public async Task<int> AddJob(JobRequestModel model)
    {
        // call the repository that will use EF core to save the data
        var jobEntity = new Job { Title = model.Ttile, StartDate = model.StartDate, Description = model.Description, CreatedOn = DateTime.UtcNow, NumberOfPositions = model.NumberOfPositions, JobStatusLookUpId = 1};
        var job = await _jobRepository.AddAsync(jobEntity);
        return job.Id;
    }
}