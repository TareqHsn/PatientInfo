using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientInfo_API.Models.DTOs;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

namespace PatientInfo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseInfoServices _services;
        private readonly IMapper _mapper;

        public DiseasesController(IDiseaseInfoServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiseaseInfo>>> GetAllergies()
        {
            var list = await _services.GetDiseaseInfoList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DiseaseInfo>> GetSingleDiseaseInfo(int id)
        {
            var single = await _services.GetSingleDiseaseInfo(id);
            if (single == null) return NotFound();
            return Ok(single);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiseaseInfo(int id, DiseaseInfo DiseaseInfo)
        {
            if (id != DiseaseInfo.DiseaseInfoId) return BadRequest();
            await _services.UpdateDiseaseInfo(id, DiseaseInfo);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<DiseaseInfo>> AddDiseaseInfo(DiseaseInfoDTO allergies)
        {
            var single = _mapper.Map<DiseaseInfo>(allergies);
            await _services.SaveDiseaseInfo(single);
            return CreatedAtAction("GetSingleDiseaseInfo", new { id = single.DiseaseInfoId }, single);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _services.DeleteDiseaseInfo(id);

            if (!success)
                return NotFound();

            return Ok();
        }
    }
}
