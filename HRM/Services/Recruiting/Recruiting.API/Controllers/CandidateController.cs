using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }
       
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var candidate = await _candidateService.GetAllCandidates();
            if (!candidate.Any())
            {
                return NotFound(new { error = "No open jobs found, please try later." });
            }

            return Ok(candidate);
        }
        
        [Route("{id:int}", Name = "GetCandidateDetails")]
        [HttpGet]
        public async Task<IActionResult> GetCandidateDetails(int id)
        {
            var candidate = await _candidateService.GetCandidateById(id);
            if (candidate==null)
            {
                return NotFound(new { errorMessage = "No job found for this id" });
            }

            return Ok(candidate);
        }
        
        // int id is job id
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(CandidateRequestModel model, int jobId)
        {
            var candidate = await _candidateService.AddCandidate(model, jobId);
            return CreatedAtAction("GetCandidateDetails", new { controller = "Candidate", 
                id = candidate}, "Candidate Created");
        }
        
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateResume(int id, string ResumeUrl)
        {
            var candidate = await _candidateService.UpdateResume(id, ResumeUrl);
            if (candidate==null)
            {
                return NotFound(new { error = "No Employee found for this id" });
            }

            return Ok(candidate);
        
        }
    }
}
