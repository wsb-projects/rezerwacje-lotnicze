using System.Text.Json.Serialization;
using rezerwacje_lotnicze.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddSwaggerServices();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddFlightBookingDbContext(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.RegisterSeeders();
builder.Services.AddCorsPolicy(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();
    await app.SeedDatabase();
}

app.UseHttpsRedirection();
app.UseCorsPolicy();
app.MapIdentityRoutes();
app.MapControllers();

app.Run();