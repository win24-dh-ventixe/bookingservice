using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Models;
using Presentation.Services;

var builder = WebApplication.CreateBuilder(args);

// Register core services (controllers, database, business logic)
builder.Services.AddControllers();


builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookingService, BookingService>();

// Enable Swagger for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();


// Seed one sample event if database is empty (used for testing/demo)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BookingDbContext>();

    if (!context.Bookings.Any())
    {
        context.Bookings.Add(new BookingEntity
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "mock@example.com",
            EventId = Guid.NewGuid(),
            Quantity = 3
        });

        context.SaveChanges();
    }
}

app.Run();