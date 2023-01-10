using HandOffApiCli.Data.Entities;
using HandOffApiCli.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices;

namespace HandOffApiCli.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Visit>>> GetAllVisits() => Ok(await _visitService.GetAllVisits());

        [HttpGet("{id}")]
        public async Task<ActionResult<Visit>> GetSingleVisit(int id)
        {
            var result = await _visitService.GetSingleVisit(id);
            if (result is null)
                return NotFound("The Visit is not found");
            return Ok(result);
        }

        [HttpPost("{patientId}/AddVisitToPatient")]
        public async Task<ActionResult<Patient?>> AddVisit(int patientId, Visit visit)
        {
            var result = await _visitService.AddVisit(patientId, visit);
            if (result is null)
                return NotFound("The Patient is not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Visit>>> DeleteVisit(int id)
        {
            var result = await _visitService.DeleteVisit(id);
            if (result.IsNullOrEmpty())
                return NotFound("The Visit is not found");
            return Ok(result);
        }
    }
}
