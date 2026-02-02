using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Load ocelot.json
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Add Ocelot
builder.Services.AddOcelot();

var app = builder.Build();

// Health endpoint (must be before Ocelot)
app.MapGet("/health", () => Results.Ok("API Gateway is running"));

// IMPORTANT: Ocelot must be LAST
await app.UseOcelot();

app.Run();
