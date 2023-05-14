using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastruction.Services;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;
        // constructor
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // return all the jobs so that candidates can apply to the jobs
            // call the job service
            
            // database
            // I/O bound => go to this URL and fetch me some data/image network, file download
            // database calls
            // CPU bound => loan calculation, large PI number, resizing processing
            
            var jobs  = await _jobService.GetAllJobs();
            return View(jobs);
        }

        // get the jobs detailed information
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // get job by id 
            var job = await _jobService.GetAllJobs();
            return View(job); 
        }

        // Authenticated and User should have for creating new job
        // HR/ Manager
        // show empty page
        [HttpGet]
        public IActionResult Create()
        {
            // take the information from the View and save to DB
            return View();
        }
        
        // saving the job information
        [HttpPost]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            // check if the data is valid, on the server 
            if (!ModelState.IsValid)
            {
                return View();
            }
            // save the data in database 
            // return to the index view
            await _jobService.AddJob(model);
            return RedirectToAction("Index");
        }
    }
}