using Presentation.Dtos;

namespace Presentation.Services
{
    public interface IBookingService
    {
        Task<BookingDto> CreateAsync(CreateBookingDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<BookingDto>> GetAllAsync();
        Task<BookingDto?> GetByIdAsync(Guid id);
    }
}