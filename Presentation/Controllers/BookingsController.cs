using Microsoft.AspNetCore.Mvc;
using Presentation.Dtos;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(IBookingService bookingService) : ControllerBase
{
    private readonly IBookingService _bookingService = bookingService;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBookingDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _bookingService.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var bookings = await _bookingService.GetAllAsync();
        return Ok(bookings);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var booking = await _bookingService.GetByIdAsync(id);
        if (booking is null) return NotFound();
        return Ok(booking);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _bookingService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
