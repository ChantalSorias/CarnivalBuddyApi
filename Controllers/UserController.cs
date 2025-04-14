using AutoMapper;
using CarnivalBuddyApi.Dtos;
using CarnivalBuddyApi.Models;
using CarnivalBuddyApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarnivalBuddyApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            try
            {
                var users = await _userService.GetAll();
                return Ok(_mapper.Map<List<UserDto>>(users));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all users.");
                return StatusCode(500, "An error occurred while fetching users.");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            try
            {
                var user = await _userService.GetById(id);
                if (user == null)
                {
                    return NotFound("User was not found.");
                }

                var userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching user by ID: {id}");
                return StatusCode(500, "An error occurred while fetching the user.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<User>(userDto);

                var existingUser = await _userService.GetByEmail(user.Email);

                if (existingUser != null)
                {
                    return Ok(existingUser);
                }

                var newUser = await _userService.Create(user);
                return CreatedAtAction(nameof(Create), new { id = newUser.Id }, _mapper.Map<UserDto>(newUser));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user.");
                return StatusCode(500, "An error occurred while creating the user.");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existing = await _userService.GetById(id);
                if (existing == null)
                {
                    return NotFound("User was not found.");
                }

                var user = _mapper.Map<User>(userDto);
                await _userService.Update(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating user with ID {id}");
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var existing = await _userService.GetById(id);
                if (existing == null)
                {
                    return NotFound("User was not found.");
                }

                await _userService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting user with ID {id}");
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}