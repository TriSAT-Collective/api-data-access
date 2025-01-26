using api_data_access;
using api_data_access.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Configuration.AddConfiguration(
    new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("config.json", false, true)
        .AddEnvironmentVariables()
        .AddCommandLine(args)
        .Build()
);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));

builder.Services.AddSingleton<SmartMeterService>();
builder.Services.AddSingleton<WeatherService>();

var app = builder.Build();

app.UsePathBase(app.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>()?.Api.PathBase);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();