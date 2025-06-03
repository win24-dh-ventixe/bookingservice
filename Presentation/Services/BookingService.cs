using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Dtos;
using Presentation.Factories;

namespace Presentation.Services;

public class BookingService(BookingDbContext context) : IBookingService
{
    private readonly BookingDbContext _context = context;

    public async Task<BookingDto> CreateAsync(CreateBookingDto dto)
    {
        var entity = BookingFactory.FromDto(dto);
        _context.Bookings.Add(entity);
        await _context.SaveChangesAsync();
        return BookingFactory.ToDto(entity);
    }

    public async Task<IEnumerable<BookingDto>> GetAllAsync()
    {
        var bookings = await _context.Bookings.ToListAsync();
        var dtoList = bookings.Select(BookingFactory.ToDto).ToList();
        return dtoList;
    }

    public async Task<BookingDto?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Bookings.FindAsync(id);
        return entity is null ? null : BookingFactory.ToDto(entity);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Bookings.FindAsync(id);
        if (entity is null) return false;

        _context.Bookings.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
