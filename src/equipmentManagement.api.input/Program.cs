using equipmentManagement.api.input.Configurations;
using equipmentManagement.Api.Configurations;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.application.input.services.company;
using equipmentManagement.application.input.services.company.interfaces;
using equipmentManagement.infra.data.input;
using equipmentManagement.infra.data.input.aggregates;
using equipmentManagement.infra.data.input.autoMapper;
using inspecao.administrActive.dominio.modelos.empresa.repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddAndConfigureControllers();
builder.Services.AddAutoMapperConfiguration();

builder.Services.AddDbContext<ContextEquipmentManagement>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ContextEquipmentManagement")));
builder.Services.AddScoped<IDbContext, UnitOfWork>();
builder.Services.AddScoped<ICreateCompanyService, CreateCompanyService>();
builder.Services.AddScoped<IModifyCompanyService, ModifyCompanyService>();
builder.Services.AddScoped<ICompanyWriteRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyReadRepository, CompanyRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    //replace DataContext with your Db Context name
    var dataContext = scope.ServiceProvider.GetRequiredService<ContextEquipmentManagement>();
    dataContext.Database.Migrate();
}

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
