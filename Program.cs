using Microsoft.AspNetCore.Identity;
using rezerwacje_lotnicze.Infrastructure;
using rezerwacje_lotnicze.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<FlightBookingDbContext>()
    .AddApiEndpoints();

builder.Services.AddFlightBookingDbContext(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.Services.ApplyMigrations();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<IdentityUser>();

app.Run();