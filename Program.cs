using System.Text.Json.Serialization;
using rezerwacje_lotnicze.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddSwaggerServices();
builder.Services.AddIdentityServices();
builder.Services.AddFlightBookingDbContext(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.RegisterSeeders();
builder.Services.AddCorsPolicy();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUI();
    await app.SeedDatabase();
}

app.UseHttpsRedirection();
app.UseCorsPolicy();
app.MapIdentityRoutes();
app.MapControllers();

app.Run();