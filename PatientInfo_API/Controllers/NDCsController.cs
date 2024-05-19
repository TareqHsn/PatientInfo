using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInfo_API.Models;
using PatientInfo_API.Models.DTOs;
using PatientInfo_API.Services;

namespace PatientInfo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NDCsController : ControllerBase
    {
        private readonly INDCServices _ndcsService;
        private readonly IMapper _mapper;

        public NDCsController(INDCServices ndcsService, IMapper mapper)
        {
            _ndcsService = ndcsService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NDC>>> GetAllergies()
        {
            var list = await _ndcsService.GetNDCList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NDC>> GetSingleNDC(int id)
        {
            var single = await _ndcsService.GetSingleNDC(id);
            if (single == null) return NotFound();
            return Ok(single);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNDC(int id, NDC NDC)
        {
            if (id != NDC.NDCId) return BadRequest();
            await _ndcsService.UpdateNDC(id, NDC);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<NDC>> AddNDC(NDCDTO allergies)
        {
            var single = _mapper.Map<NDC>(allergies);
            await _ndcsService.SaveNDC(single);
            return CreatedAtAction("GetSingleNDC", new { id = single.NDCId }, single);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _ndcsService.DeleteNDC(id);

            if (!success)
                return NotFound();

            return Ok();
        }
    }
}
