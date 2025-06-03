using System.ComponentModel.DataAnnotations;

namespace Presentation.Dtos;

public class CreateBookingDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public Guid EventId { get; set; }

    [Range(1, 10)]
    public int Quantity { get; set; } = 1;
}