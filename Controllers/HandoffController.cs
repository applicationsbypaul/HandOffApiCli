using HandOffApiCli.Data.Entities;
using HandOffApiCli.Services;
using Microsoft.AspNetCore.Mvc;

namespace HandOffApiCli.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HandoffController : ControllerBase
    {
        private readonly IHandoffService _handoffService;

        public HandoffController(IHandoffService handoffService)
        {
            _handoffService = handoffService;   
        }

        [HttpGet]
        public async Task<ActionResult<List<Handoff?>>> GetAllHandoffs() => Ok(await _handoffService.GetAllHandoffs());

        [HttpPost]
        public async Task<ActionResult<Handoff?>> AddHandoff(Handoff handoff) => Ok(await _handoffService.AddHandoff(handoff));

        [HttpGet("{id}")]
        public async Task<ActionResult<Handoff?>> GetSingleHandoff(int id) => Ok(await _handoffService.GetSingleHandoff(id));

        [HttpPut]
        public async Task<ActionResult<List<Handoff>>> UpdateHandoff(int id, Handoff request)
        {
            return Ok(await _handoffService.UpdateHandoff(id, request));
        }
    }
}
