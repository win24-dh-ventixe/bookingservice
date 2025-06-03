namespace Presentation.Dtos;

public class BookingDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public Guid EventId { get; init; }
    public int Quantity { get; init; }
    public DateTime BookingDate { get; init; }
}
