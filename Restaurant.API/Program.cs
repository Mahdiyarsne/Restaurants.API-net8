using Restaurants.Infrastucture.Extensions;
using Restaurants.Application.Extensions;
using Restaurants.Infrastucture.Seeders;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
 
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseSerilog((context, configuration) =>

 configuration
 .ReadFrom.Configuration(context.Configuration)
);

var app = builder.Build();

var scoope = app.Services.CreateScope();
var seeder = scoope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();
// Configure the HTTP request pipeline.

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
