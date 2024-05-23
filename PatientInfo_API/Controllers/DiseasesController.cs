using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

namespace PatientInfo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseInfoServices _services;


        public DiseasesController(IDiseaseInfoServices services)
        {
            _services = services;

        }

        [HttpGet]
        public async Task<IActionResult> getDetails()
        {
            return new OkObjectResult(_services.GetAllDiseaseInformations());
        }
    }
}



