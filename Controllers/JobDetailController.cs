using Azure.Core.Serialization;
using HandOffApiCli.Data.Entities;
using HandOffApiCli.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HandOffApiCli.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobDetailController : ControllerBase
    {
        private readonly IJobDetailService _jobDetailService;

        public JobDetailController(IJobDetailService jobDetailService)
        {
            _jobDetailService = jobDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobDetail>>> GetAllJobDetails()
        {
            return Ok( await _jobDetailService.GetAllJobDetails());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobDetail>> GetSingleJobDetail(int id)
        {
            var jobDetail = await _jobDetailService.GetSingleJobDetail(id);
            if (jobDetail is null)
                return NotFound("The JobDetail your trying retrieve does not exist");
            return Ok(await _jobDetailService.GetSingleJobDetail(id));

        }

        [HttpPost]
        public async Task<ActionResult<JobDetail>> AddJobDetail(JobDetail jobDetail) 
        {
            return Ok(await _jobDetailService.AddJobDetail(jobDetail));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<JobDetail>>> DeleteJobDetail(int id)
        {
            var result = await _jobDetailService.DeleteJobDetail(id);
            if (result.IsNullOrEmpty())
                return NotFound("The JobDetail is not found");
            return Ok(result);
        }
    }
}
