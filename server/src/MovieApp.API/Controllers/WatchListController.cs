using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.BLL.Models.Dto.WatchList;
using MovieApp.BLL.Services.Interfaces;

namespace MovieApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WatchListController(IWatchListService reviewService) : ControllerBase
{
    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddWatchList([FromBody] WatchListAddDto review, CancellationToken cancellationToken = default)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var result = await reviewService.AddWatchListAsync(review, userId!, cancellationToken);
        
        return CreatedAtAction(nameof(AddWatchList), new { id = result.Id }, result);
    }

    
    [Authorize]
    [HttpPost("delete/{id}")]
    public async Task<IActionResult> DeleteWatchListById(int id, CancellationToken cancellationToken = default)
    {
        var deleted = await reviewService.DeleteWatchListAsync(id, cancellationToken);
        if (deleted == false)
        {
            return NotFound();
        }
        return NoContent();
    }

}