using HandOffApiCli.Data.Entities;
using HandOffApiCli.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HandOffApiCli.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetAllPatients() => Ok(await _patientService.GetAllPatients());

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetSinglePatient(int id)
        {
            var patient = await _patientService.GetSinglePatient(id);
            if (patient is null)
                return NotFound("The patient your trying retrieve does not exist");
            return Ok(await _patientService.GetSinglePatient(id));
        }
        [HttpGet("{patientId}")]
        public async Task<ActionResult<Employee>> GetPatientPrimaryDoctor(int patientId)
        {
            var employee = await _patientService.GetPatientPrimaryDoctor(patientId);
            if (employee is null)
                return NotFound("The employee does not have a doctor");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> AddPatient(Patient patient)
        {
            return Ok(await _patientService.AddPatient(patient));
        }

        [HttpPut]
        public async Task<ActionResult<List<Patient>>> UpdatePatient(int id, Patient request)
        {
            var result = await _patientService.UpdatePatient(id, request);
            if (result.IsNullOrEmpty())
                return NotFound("The patient your trying to update does not exist.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Patient>>> DeletePatient(int id)
        {
            var result = await _patientService.DeletePatient(id);
            if (result.IsNullOrEmpty())
                return NotFound("The Patient is not found");
            return Ok(result);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<Patient?>> AddJobDetailToPatient(int id, int employeeId)
        {
            var result = await _patientService.AddPrimaryDoctorToPatient(id, employeeId);
            if (result is null)
                return NotFound("The Patient is not found");
            return Ok(result);
        }
    }
}
