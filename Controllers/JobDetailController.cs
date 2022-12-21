using Azure.Core.Serialization;
using HandOffApiCli.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandOffApiCli.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobDetailController : Controller
    {
        public List<JobDetail> jobs = new List<JobDetail>()
        {
            new JobDetail
            {
                JobDetailId= 1,
                JobDescription= "Nurse"
            },
            new JobDetail
            {
                JobDetailId= 2,
                JobDescription = "Doctor"
            }
        };

        [HttpGet]
        public List<JobDetail> GetAllJobDetails()
        {
            return jobs;
        }
    }
}
