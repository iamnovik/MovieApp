using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.BLL.Models.Dto.ReviewDto;
using MovieApp.BLL.Services.Interfaces;

namespace MovieApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController(IReviewService reviewService) : ControllerBase
{
    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddReview([FromBody] ReviewAddDto review, CancellationToken cancellationToken = default)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var result = await reviewService.AddReviewAsync(review, userId!, cancellationToken);
        
        return CreatedAtAction(nameof(AddReview), new { id = result.Id }, result);
    }
    
    [Authorize]
    [HttpPost("update")]
    public async Task<IActionResult> UpdateReview([FromBody] ReviewUpdateDto review, CancellationToken cancellationToken = default)
    {
        var result = await reviewService.UpdateReviewAsync(review, cancellationToken);
        
        return Ok(result);
    }
    
    [HttpGet("movie/{id}")]
    public async Task<IActionResult> GetReviewsByMovieId(int id, CancellationToken cancellationToken = default)
    {
        var reviews = await reviewService.GetReviewsByMovieIdAsync(id, cancellationToken);
        if (reviews == null)
        {
            return NotFound();
        }
        return Ok(reviews);
    }
    
    [Authorize]
    [HttpPost("delete/{id}")]
    public async Task<IActionResult> DeleteReviewById(int id, CancellationToken cancellationToken = default)
    {
        var deleted = await reviewService.DeleteReviewAsync(id, cancellationToken);
        if (deleted == false)
        {
            return NotFound();
        }
        return NoContent();
    }
}