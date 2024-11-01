using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.BLL.Models.Dto.RatingDto;
using MovieApp.BLL.Services.Interfaces;

namespace MovieApp.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RatingController(IRatingService ratingService) : ControllerBase
{
    
    [HttpPost("add")]
    public async Task<IActionResult> AddRating([FromBody] RatingAddDto rating)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        rating.UserId = userId!;
        var result = await ratingService.AddRatingAsync(rating);
        return CreatedAtAction(nameof(AddRating), new { id = result.Id }, result);
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> UpdateRating([FromBody] RatingUpdateDto rating)
    {
        var result = await ratingService.UpdateRatingAsync(rating);
        return CreatedAtAction(nameof(AddRating), new { id = result.Id }, result);
    }
    
    [HttpGet("movie/{id}")]
    public async Task<IActionResult> GetRatingsByMovieId(int id, CancellationToken cancellationToken = default)
    {
        var ratings = await ratingService.GetRatingsByMovieIdAsync(id, cancellationToken);
        if (ratings == null)
        {
            return NotFound();
        }
        return Ok(ratings);
    }
}