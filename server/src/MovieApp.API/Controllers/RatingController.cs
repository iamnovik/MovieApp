using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.BLL.Models.Dto.RatingDto;
using MovieApp.BLL.Services.Interfaces;

namespace MovieApp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RatingController(IRatingService ratingService) : ControllerBase
{
    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddRating([FromBody] RatingAddDto rating, CancellationToken cancellationToken = default)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var result = await ratingService.AddRatingAsync(rating, userId!, cancellationToken);
        
        return CreatedAtAction(nameof(AddRating), new { id = result.Id }, result);
    }
    
    [Authorize]
    [HttpPost("update")]
    public async Task<IActionResult> UpdateRating([FromBody] RatingUpdateDto rating, CancellationToken cancellationToken = default)
    {
        var result = await ratingService.UpdateRatingAsync(rating, cancellationToken);
        
        return Ok( result);
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