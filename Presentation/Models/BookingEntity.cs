using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class BookingEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid EventId { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public int Quantity { get; set; } = 1;

    public DateTime BookingDate { get; set; } = DateTime.UtcNow;
}