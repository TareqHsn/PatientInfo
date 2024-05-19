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
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergiesServices _allergiesService;
        private readonly IMapper _mapper;

        public AllergiesController(IAllergiesServices allergiesService, IMapper mapper)
        {
            _allergiesService = allergiesService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allergy>>> GetAllergies()
        {
            var list = await _allergiesService.GetAllergyList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Allergy>> GetSingleAllergy(int id)
        {
            var single = await _allergiesService.GetSingleAllergy(id);
            if (single == null) return NotFound();
            return Ok(single);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllergy(int id, Allergy allergy)
        {
            if (id != allergy.AllergyId) return BadRequest();
            await _allergiesService.UpdateAllergy(id, allergy);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<Allergy>> AddAllergy(AllergiesDTO allergies)
        {
            var single = _mapper.Map<Allergy>(allergies);
            await _allergiesService.SaveAllergy(single);
            return CreatedAtAction("GetSingleAllergy", new { id = single.AllergyId }, single);
        }    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _allergiesService.DeleteAllergy(id);

            if (!success)
                return NotFound();

            return Ok();
        }
    }
}
