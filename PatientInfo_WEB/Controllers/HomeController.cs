using Microsoft.AspNetCore.Mvc;
using PatientInfo_WEB.Models;
using PatientInfo_WEB.Services;
namespace PatientInfo_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPatientInformationService _patientInformationService;

        public HomeController(ILogger<HomeController> logger,IPatientInformationService patientInformationService)
        {
            _logger = logger;
            _patientInformationService = patientInformationService;
        }

        public IActionResult Index()
        {
            try
            {
                var obj = LoadData();

                return View(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PatientInformationView LoadData()
        {
            var obj = new PatientInformationView();
            
            var Diseases = _patientInformationService.getAllDiseases().Result.ToList();
            var allergies = _patientInformationService.getAllAllergies().Result.ToList();
            var ncds = _patientInformationService.getAllNCDs().Result.ToList();

            var patientDetails = _patientInformationService.getAllPatientDetails().Result.ToList();

            obj.Allergies = allergies;
            obj.DiseaseInformations = Diseases;
            obj.NCDs = ncds;
            obj.PatientDetails = patientDetails;
            return obj;
        }
        [HttpPost]
        public IActionResult Index(PatientInformationView patientInformation)
        {
            try
            {
                var s = _patientInformationService.postPatientInformation(patientInformation);

                var obj = LoadData();

                return View(obj);
            }
            catch (Exception)
            {

                throw;
            }

        }

       
    }
}