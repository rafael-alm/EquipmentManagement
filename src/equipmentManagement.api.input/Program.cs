using Microsoft.EntityFrameworkCore;
using equipmentManagement.api.input.Configurations;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.application.input.services.product;
using equipmentManagement.application.input.services.product.interfaces;
using equipmentManagement.application.input.services.supplier;
using equipmentManagement.application.input.services.supplier.interfaces;
using equipmentManagement.domain.aggregates.supplier;
using equipmentManagement.infra.data.input;
using equipmentManagement.infra.data.input.aggregates;
using equipmentManagement.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAndConfigureControllers();
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddDbContext<ContextequipmentManagement>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ContextequipmentManagement")));
builder.Services.AddScoped<IDbContext, UnitOfWork>();
builder.Services.AddScoped<ICreateSupplierService, CreateSupplierService>();
builder.Services.AddScoped<IModifySupplierService, ModifySupplierService>();
builder.Services.AddScoped<ISupplierAppRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ICreateProductService, CreateProductService>();
builder.Services.AddScoped<IModifyProductService, ModifyProductService>();
builder.Services.AddScoped<IProductAppRepository, ProductRepository>();
builder.Services.AddScoped<IInactivateProductService, InactivateProductService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    //replace DataContext with your Db Context name
    var dataContext = scope.ServiceProvider.GetRequiredService<ContextequipmentManagement>();
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
