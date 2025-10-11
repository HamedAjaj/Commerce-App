using ECommerce.Catalog.API.Dependency;
using ECommerce.Catalog.Infrastructure;
using ECommerce.Orders.API.Dependency;
using ECommerce.Orders.Infrastructure;
using ECommerce.SharedKernel.Dependencies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Modules
builder.Services.AddSharedKernelDependancies();
builder.Services.AddOrdersModule(builder.Configuration);
//builder.Services.AddInventoryModule(builder.Configuration);
builder.Services.AddCatalogModule(builder.Configuration);

var app = builder.Build();
 

// Run migrations for each DbContext  of every module
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var ordersDb = services.GetRequiredService<OrdersDbContext>();
    ordersDb.Database.Migrate();

    //var inventoryDb = services.GetRequiredService<InventoryDbContext>();
    //inventoryDb.Database.Migrate();

    var catalogDb = services.GetRequiredService<CatalogDbContext>();
    catalogDb.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

}
 
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
