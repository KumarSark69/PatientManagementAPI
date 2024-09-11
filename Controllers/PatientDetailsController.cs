
using Microsoft.AspNetCore.Mvc;
using PatientManagementApi.Models;
using PatientManagementApi.Services;


namespace PatientManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientDetailsController : ControllerBase
    {
        private readonly IPatientDetailService _patientDetailService;

        public PatientDetailsController(IPatientDetailService patientDetailService)
        {
            _patientDetailService = patientDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDetail>>> GetPatientDetails()
        {
            var patientDetails = await _patientDetailService.GetAllPatientDetailsAsync();
            return Ok(patientDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDetail>> GetPatientDetail(int id)
        {
            var patientDetail = await _patientDetailService.GetPatientDetailByIdAsync(id);
            if (patientDetail == null)
            {
                return NotFound();
            }
            return Ok(patientDetail);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<PatientDetail>>> GetPatientDetailsByPatientId(int patientId)
        {
            var patientDetails = await _patientDetailService.GetPatientDetailsByPatientIdAsync(patientId);
            return Ok(patientDetails);
        }

        [HttpPost]
        public async Task<ActionResult<PatientDetail>> PostPatientDetail(PatientDetail patientDetail)
        {
            var createdPatientDetail = await _patientDetailService.AddPatientDetailAsync(patientDetail);
            return CreatedAtAction(nameof(GetPatientDetail), new { id = createdPatientDetail.DetailID }, createdPatientDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientDetail(int id, PatientDetail patientDetail)
        {
            if (id != patientDetail.DetailID)
            {
                return BadRequest();
            }
            await _patientDetailService.UpdatePatientDetailAsync(patientDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientDetail(int id)
        {
            await _patientDetailService.DeletePatientDetailAsync(id);
            return NoContent();
        }
    }
}