using Microsoft.AspNetCore.Mvc;
using MovieApp.BLL.Services.Interfaces;

namespace MovieApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorsController(IActorService _actorService) : ControllerBase
{
    [HttpGet("movie/{movieId}")]
    public async Task<IActionResult> GetActorsByMovie(int movieId, CancellationToken cancellationToken = default)
    {
        var actors = await _actorService.GetActorsByMovieIdAsync(movieId, cancellationToken);
        if (actors == null)
        {
            return NotFound();
        }
        return Ok(actors);
    }
    
    [HttpGet("{id}/combined_credits")]
    public async Task<IActionResult> GetActorsCreditsById(int id, CancellationToken cancellationToken = default)
    {
        var actorCredits = await _actorService.GetActorCreditsByIdAsync(id, cancellationToken);
        if (actorCredits == null)
        {
            return NotFound();
        }
        return Ok(actorCredits);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetActorById(int id, CancellationToken cancellationToken = default)
    {
        var actor = await _actorService.GetActorByIdAsync(id, cancellationToken);
        if (actor == null)
        {
            return NotFound();
        }
        return Ok(actor);
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchActors([FromQuery] string query, [FromQuery] int page = 1, CancellationToken cancellationToken = default)
    {
        var actors = await _actorService.SearchActorsAsync(query, page, cancellationToken);
        return Ok(actors);
    }
    
}