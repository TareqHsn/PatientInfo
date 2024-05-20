using Microsoft.AspNetCore.Mvc;
using PatientInfo_API.Models;
using PatientInfo_API.Services;
using PatientInformationsAPI.Model;

namespace PatientInfo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientRepository;
       

        public PatientsController(IPatientService patientRepository)
        {
            _patientRepository = patientRepository;
           
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails()
        {
            return new OkObjectResult(_patientRepository.PatientInformationDetails());
        }
        [HttpPost("postPatientInformation")]
        public async Task<IActionResult> postPatientInformation(PatientInformationView patientInformation)
        {
            var res = await _patientRepository.PostPatientInformationDetails(patientInformation);
            return Ok();
        }
    }
}










