using System.Security.Claims;
using CarnivalBuddyApi.Dtos;
using CarnivalBuddyApi.Models;
using CarnivalBuddyApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarnivalBuddyApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> LikeEntity([FromBody] LikeDto likeDto)
        {
            var loggedInUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (loggedInUserId == null)
            {
                return Forbid();
            }

            var success = await _likeService.Like(loggedInUserId, likeDto.EntityType, likeDto.EntityId);
            if (success)
            {
                return Ok("Liked!");
            }
            else
            {
                return BadRequest("Already liked.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> UnlikeEntity([FromBody] LikeDto likeDto)
        {
            var loggedInUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (loggedInUserId == null)
            {
                return Forbid();
            }

            var success = await _likeService.Unlike(loggedInUserId, likeDto.EntityType, likeDto.EntityId);
            if (success)
            {
                return Ok("Liked!");
            }
            else
            {
                return BadRequest("Already liked.");
            }
        }

        [HttpGet("{entityType}/{entityId}/is-liked")]
        public async Task<IActionResult> IsLiked(LikedEntityType entityType, string entityId)
        {
            var loggedInUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (loggedInUserId == null)
            {
                return Forbid();
            }

            var liked = await _likeService.IsLiked(loggedInUserId, entityType, entityId);
            return Ok(new { liked });
        }

        [HttpGet("{entityType}/{entityId}/count")]
        public async Task<IActionResult> GetLikesCount(LikedEntityType entityType, string entityId)
        {
            var count = await _likeService.GetLikesCount(entityType, entityId);
            return Ok(new { count });
        }

    }
}