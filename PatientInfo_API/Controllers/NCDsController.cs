using Microsoft.AspNetCore.Mvc;
using PatientInfo_API.Services;

namespace PatientInfo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NDCsController : ControllerBase
    {
        private readonly INCDCServices _ndcsService;
        

        public NDCsController(INCDCServices nCDCServices)
        {
            _ndcsService = nCDCServices;
           
        }
        [HttpGet]
        public async Task<IActionResult> getDetails()
        {
            try
            {
                return new OkObjectResult(_ndcsService.GetAllNcd());
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}

