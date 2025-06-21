using Service;
using Repository;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<GetActiveMaterialsUseCase>();

builder.Services.AddDbContext<ERPContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnString")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
