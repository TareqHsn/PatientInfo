using Microsoft.AspNetCore.Mvc;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

namespace PatientInfo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientRepository;
        private readonly INCDDetailServices _ncdDetailRepository;
        private readonly IAllergyDetailServices _allergyDetailRepository;

        public PatientsController(IPatientService patientRepository, INCDDetailServices ncdDetailRepository, IAllergyDetailServices allergyDetailRepository)
        {
            _patientRepository = patientRepository;
            _ncdDetailRepository = ncdDetailRepository;
            _allergyDetailRepository = allergyDetailRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        //[HttpPost]
        //public async Task<ActionResult> CreatePatient(Patient patient)
        //{
        //    await _patientRepository.AddPatientAsync(patient);
        //    return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientId }, patient);
        //}
        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }

            await _patientRepository.AddPatientAsync(patient);

            return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientId }, patient);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, Patient patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest();
            }

            await _patientRepository.UpdatePatientAsync(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientRepository.DeletePatientAsync(id);
            return NoContent();
        }

        // NCD Details methods
        [HttpGet("{patientId}/ncdDetails")]
        public async Task<ActionResult<IEnumerable<NDC_Detail>>> GetNCDDetails(int patientId)
        {
            var ncdDetails = await _ncdDetailRepository.GetNCDDetailsByPatientIdAsync(patientId);
            return Ok(ncdDetails);
        }

        [HttpPost("{patientId}/ncdDetails")]
        public async Task<ActionResult> AddNCDDetail(int patientId, NDC_Detail ncdDetail)
        {
            if (patientId != ncdDetail.PatientId)
            {
                return BadRequest();
            }

            await _ncdDetailRepository.AddNCDDetailAsync(ncdDetail);
            return CreatedAtAction(nameof(GetNCDDetails), new { patientId = ncdDetail.PatientId }, ncdDetail);
        }

        [HttpDelete("ncdDetails/{id}")]
        public async Task<IActionResult> DeleteNCDDetail(int id)
        {
            await _ncdDetailRepository.DeleteNCDDetailAsync(id);
            return NoContent();
        }

        // Allergy Details methods
        [HttpGet("{patientId}/allergyDetails")]
        public async Task<ActionResult<IEnumerable<Allergy_Detail>>> GetAllergyDetails(int patientId)
        {
            var allergyDetails = await _allergyDetailRepository.GetAllergyDetailsByPatientIdAsync(patientId);
            return Ok(allergyDetails);
        }

        [HttpPost("{patientId}/allergyDetails")]
        public async Task<ActionResult> AddAllergyDetail(int patientId, Allergy_Detail allergyDetail)
        {
            if (patientId != allergyDetail.PatientId)
            {
                return BadRequest();
            }

            await _allergyDetailRepository.AddAllergyDetailAsync(allergyDetail);
            return CreatedAtAction(nameof(GetAllergyDetails), new { patientId = allergyDetail.PatientId }, allergyDetail);
        }

        [HttpDelete("allergyDetails/{id}")]
        public async Task<IActionResult> DeleteAllergyDetail(int id)
        {
            await _allergyDetailRepository.DeleteAllergyDetailAsync(id);
            return NoContent();
        }


    }
}
