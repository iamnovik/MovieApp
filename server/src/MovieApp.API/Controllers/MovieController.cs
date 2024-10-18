using Microsoft.AspNetCore.Mvc;
using MovieApp.BLL.Services.Interfaces;

namespace MovieApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController(IMovieService _movieService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUpcomingMovies([FromQuery] int page, CancellationToken cancellationToken = default)
    {
        var movies = await _movieService.GetUpcomingMoviesAsync(page,cancellationToken);
        return Ok(movies);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieById(int id, CancellationToken cancellationToken = default)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }
    
    [HttpGet("search")]
    public async Task<IActionResult> SearchMovies([FromQuery] string query, [FromQuery] int page = 1, CancellationToken cancellationToken = default)
    {
        var movies = await _movieService.SearchMoviesAsync(query, page);
        return Ok(movies);
    }   
}