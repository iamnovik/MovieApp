using Microsoft.AspNetCore.Mvc;
using MovieApp.BLL.Services.Interfaces;

namespace MovieApp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ImagesController(IImageService imageService) : ControllerBase
{
    [HttpGet("movie/{movieId}")]
    public async Task<IActionResult> GetPostersByMovie(int movieId, CancellationToken cancellationToken = default)
    {
        var posters = await imageService.GetPostersByMovieIdAsync(movieId);
        if (posters == null)
        {
            return NotFound();
        }
        return Ok(posters);
    }
}