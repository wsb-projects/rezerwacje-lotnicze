using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rezerwacje_lotnicze.Domain.Entities.Flights;
using rezerwacje_lotnicze.Domain.Entities.Tickets;
using rezerwacje_lotnicze.Domain.Entities.User;

namespace rezerwacje_lotnicze.Infrastructure;

public class FlightBookingDbContext : IdentityDbContext<IdentityUser>
{
    public FlightBookingDbContext(DbContextOptions<FlightBookingDbContext> options) : base(options)
    {
    }

    public DbSet<BaseTicket> Tickets { get; set; }
    public DbSet<BaseFlight> Flights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BaseTicket>()
            .HasDiscriminator<TicketType>("TicketType")
            .HasValue<PassengerTicket>(TicketType.PassengerTicket)
            .HasValue<CargoTicket>(TicketType.CargoTicket);

        modelBuilder.Entity<BaseFlight>()
            .HasDiscriminator<FlightType>("FlightType")
            .HasValue<PassengerFlight>(FlightType.PassengerFlight)
            .HasValue<CargoFlight>(FlightType.CargoFlight);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Tickets)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);
    }
}