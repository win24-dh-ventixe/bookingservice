using Presentation.Dtos;
using Presentation.Models;

namespace Presentation.Factories;

public class BookingFactory
{
    public static BookingEntity FromDto(CreateBookingDto dto)
    {
        return new BookingEntity
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            EventId = dto.EventId,
            Quantity = dto.Quantity
        };
    }

    public static BookingDto ToDto(BookingEntity entity)
    {
        return new BookingDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            EventId = entity.EventId,
            Quantity = entity.Quantity,
            BookingDate = entity.BookingDate
        };
    }
}