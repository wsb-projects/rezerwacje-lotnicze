using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Application.Services;
using rezerwacje_lotnicze.Domain.Entities.User;
using rezerwacje_lotnicze.Infrastructure;
using rezerwacje_lotnicze.Infrastructure.Extensions;
using rezerwacje_lotnicze.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FlightBookingDbContext>()
    .AddApiEndpoints();

builder.Services.AddFlightBookingDbContext(builder.Configuration);


builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<UserSeeder>();
builder.Services.AddScoped<FlightSeeder>();

var app = builder.Build();

app.Services.ApplyMigrations();
app.SeedDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapIdentityApi<User>();

app.Run();
