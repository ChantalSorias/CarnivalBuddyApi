using AutoMapper;
using CarnivalBuddyApi.Dtos;
using CarnivalBuddyApi.Models;
using CarnivalBuddyApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarnivalBuddyApi.Controllers
{
    [ApiController]
    [Route("api/carnivals")]
    public class CarnivalController : ControllerBase
    {
        private readonly ICarnivalService _carnivalService;
        private readonly ILogger<CarnivalController> _logger;
        private readonly IMapper _mapper;

        public CarnivalController(ICarnivalService carnivalService, ILogger<CarnivalController> logger, IMapper mapper)
        {
            _carnivalService = carnivalService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarnivalDto>>> GetAll()
        {
            try
            {
                var carnivals = await _carnivalService.GetAll();
                return Ok(_mapper.Map<List<CarnivalDto>>(carnivals));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all carnivals.");
                return StatusCode(500, "An error occurred while fetching carnivals.");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Carnival>> GetById(string id)
        {
            try
            {
                var carnival = await _carnivalService.GetById(id);
                if (carnival == null)
                {
                    return NotFound("Carnival was not found.");
                }

                var carnivalDto = _mapper.Map<CarnivalDto>(carnival);
                return Ok(carnivalDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching carnival by ID: {id}");
                return StatusCode(500, "An error occurred while fetching the carnival.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CarnivalDto carnivalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var carnival = _mapper.Map<Carnival>(carnivalDto);
                var newCarnival = await _carnivalService.Create(carnival);
                return CreatedAtAction(nameof(Create), new { id = newCarnival.Id }, _mapper.Map<CarnivalDto>(newCarnival));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating carnival.");
                return StatusCode(500, "An error occurred while creating the carnival.");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] CarnivalDto carnivalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existing = await _carnivalService.GetById(id);
                if (existing == null)
                {
                    return NotFound("Carnival was not found.");
                }

                var carnival = _mapper.Map<Carnival>(carnivalDto);
                await _carnivalService.Update(carnival);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating carnival with ID {id}");
                return StatusCode(500, "An error occurred while updating the carnival.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var existing = await _carnivalService.GetById(id);
                if (existing == null)
                {
                    return NotFound("Carnival was not found.");
                }

                await _carnivalService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting carnival with ID {id}");
                return StatusCode(500, "An error occurred while deleting the carnival.");
            }
        }
    }
}