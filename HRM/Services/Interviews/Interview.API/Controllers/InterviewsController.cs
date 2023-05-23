using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewService _interviewService;
        
            public InterviewsController(IInterviewService interviewService)
            {
                _interviewService = interviewService;
            }
            [Route("")]
            [HttpGet]
            //[Authorize]
            public async Task<IActionResult> GetAllInterview()
            {
                // if role = admin, get all
                // if role  = manager, get only manager's interviews
                // read the header using HttpContext
                // JWT token
                // Authorization Header, bearer "      "
                // decode JWT to C# object
                /*if (this.HttpContext.User.Identity.IsAuthenticated)
                {
                    // go to database, and get the values
                }*/
                var interviews = new List<string>(new[] {"abc, xyz, dddd"});

                return Ok(interviews);

                /* //basic function
                var interview = await _interviewService.GetAllInterview();
                if (!interview.Any())
                {
                    return NotFound(new { error = "No Employees found, please try later." });
                }
        
                return Ok(interview);
                */
            }
                
            [Route("{id:int}", Name = "GetInterviewDetails")]
            [HttpGet]
            public async Task<IActionResult> GetInterviewDetails(int id)
            {
                var interview = await _interviewService.GetInterviewDetails(id);
                if (interview==null)
                {
                    return NotFound(new { error = "No Employee found for this id" });
                }
        
                return Ok(interview);
            }
        
            [Route("create")]
            [HttpPost]
            public async Task<IActionResult> Create(InterviewRequestModel model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
        
                var interview = await _interviewService.AddInterview(model);
                return CreatedAtAction("GetInterviewDetails", new { controller = "Interviews", 
                    id = interview}, "Interview Created");
            }
            
            [Route("delete")]
            [HttpDelete]
            public async Task<IActionResult> DeleteInterview(int id)
            {
                var interview = await _interviewService.DeleteInterview(id);
                if (interview == null)
                {
                    return NotFound(new { error = "No Employee found for this id, can't delete" });
                }
                return Ok(interview);
            }
            
            [Route("update")]
            [HttpPut]
            public async Task<IActionResult> Updatenterview(int id)
            {
                var interview = await _interviewService.Updatenterview(id);
                if (interview==null)
                {
                    return NotFound(new { error = "No Employee found for this id" });
                }
        
                return Ok(interview);
            }
    }
}
