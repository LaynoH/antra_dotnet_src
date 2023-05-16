using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
        // attribute routing
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        // add references for applicationcore and infra project
        // copy all the DI registrations including Dbcontext into API project program.cs
        // copy the connection string from MVC appSetting to API appSetting

        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobs();
            if (!jobs.Any())
            {
                return NotFound(new { error = "No open jobs found, please try later." });
            }

            return Ok(jobs);
        }
        
        [Route("{id:int}", Name = "GetJobDetails")]
        [HttpGet]
        public async Task<IActionResult> GetJobDetails(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job==null)
            {
                return NotFound(new { error = "No job found for this id" });
            }

            return Ok(job);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var job = await _jobService.AddJob(model);
            return CreatedAtAction("GetJobDetails", new { controller = "Jobs", id = job, JobCreated = "Job Created" });
        }
    }
}
