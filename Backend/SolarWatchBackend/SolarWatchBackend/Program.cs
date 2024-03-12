
using SolarWatchBackend.Service;
using SolarWatchBackend.Services;

var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, "secrets.env");
DotEnv.Load(dotenv);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IJsonProcessor, JsonProcessor>();
builder.Services.AddTransient<ISunSetRiseProvider, SunSetRiseProvider>();
builder.Services.AddTransient<ICityProvider, CityProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();