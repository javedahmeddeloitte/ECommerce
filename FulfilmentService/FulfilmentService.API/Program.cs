
using FulfilmentService.Business;
using FulfilmentService.Repository;
using FulfilmentService.Repository.DBModels;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositoryLayer(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<FulfilmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FulfillmentDBConnection"))
);
builder.Services.AddBusinessLayer();

var app = builder.Build();
//app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
