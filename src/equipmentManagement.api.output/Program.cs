using Microsoft.EntityFrameworkCore;
using equipmentManagement.application.output.interfaces;
using equipmentManagement.infra.data.output;
using equipmentManagement.infra.data.output.repositories;
using equipmentManagement.Api.Output.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAndConfigureControllers();
//builder.Services.AddDbContext<ContextequipmentManagement>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ContextequipmentManagement")));

builder.Services.AddScoped<SqlFactory>();
builder.Services.AddScoped<IReadProductRepository, ProductRepository>();

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
