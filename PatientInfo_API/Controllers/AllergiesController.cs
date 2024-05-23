using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

namespace PatientInfo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergiesServices _allergiesService;


        public AllergiesController(IAllergiesServices allergiesService )
        {
            _allergiesService = allergiesService;

        }
        [HttpGet]
        public async Task<IActionResult> GetDetails()
        {
            return new OkObjectResult(_allergiesService.getAllAllergies());
        }
    }
}

