using rezerwacje_lotnicze.Domain.Entities.Flights;

namespace rezerwacje_lotnicze.Infrastructure.Seeders
{
    public class FlightSeeder
    {
        private readonly FlightBookingDbContext _dbContext;

        public FlightSeeder(FlightBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            if (!_dbContext.Flights.Any())
            {
                var passengerFlight1 = new PassengerFlight
                {
                    DepartureLocation = "New York",
                    ArrivalLocation = "London",
                    DepartureDate = new DateTime(2025, 5, 1, 14, 0, 0).ToUniversalTime(),
                    ArrivalDate = new DateTime(2025, 5, 1, 22, 0, 0).ToUniversalTime(),
                    SeatsCapacity = 200,
                    SeatPrice = 500
                };

                var passengerFlight2 = new PassengerFlight
                {
                    DepartureLocation = "Los Angeles",
                    ArrivalLocation = "Tokyo",
                    DepartureDate = new DateTime(2025, 6, 1, 15, 30, 0).ToUniversalTime(),
                    ArrivalDate = new DateTime(2025, 6, 2, 5, 30, 0).ToUniversalTime(),
                    SeatsCapacity = 180,
                    SeatPrice = 450
                };

                var cargoFlight1 = new CargoFlight
                {
                    DepartureLocation = "Shanghai",
                    ArrivalLocation = "Chicago",
                    DepartureDate = new DateTime(2025, 7, 1, 10, 0, 0).ToUniversalTime(),
                    ArrivalDate = new DateTime(2025, 7, 1, 18, 0, 0).ToUniversalTime(),
                    CargoWeight = 10000,
                    CargoVolume = 500
                };

                var cargoFlight2 = new CargoFlight
                {
                    DepartureLocation = "Dubai",
                    ArrivalLocation = "Frankfurt",
                    DepartureDate = new DateTime(2025, 8, 1, 8, 0, 0).ToUniversalTime(),
                    ArrivalDate = new DateTime(2025, 8, 1, 16, 0, 0).ToUniversalTime(),
                    CargoWeight = 12000,
                    CargoVolume = 600
                };

                _dbContext.Flights.AddRange(passengerFlight1, passengerFlight2, cargoFlight1, cargoFlight2);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
