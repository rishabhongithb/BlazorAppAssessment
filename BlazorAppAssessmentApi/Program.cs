using BlazorAppAssessmentApi.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Define a CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorAppAssessmentPloicy", policy =>
    {
        policy.WithOrigins("https://localhost:7055") // frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("BlazorAppAssessmentPloicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
