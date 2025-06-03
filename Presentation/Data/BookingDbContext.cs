using Microsoft.EntityFrameworkCore;
using Presentation.Models;

namespace Presentation.Data;

public class BookingDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<BookingEntity> Bookings { get; set; }
}