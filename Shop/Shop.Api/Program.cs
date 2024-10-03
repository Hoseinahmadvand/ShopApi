using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Shop.Config;

var builder = WebApplication.CreateBuilder(args);
var services=builder.Services;
var connectionString = builder.Configuration.GetConnectionString("DefultConnection");
// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

ShopBootstraper.Configure(services,connectionString);
CommonBootstrapper.Init(services);

services.AddTransient<IFileService,FileService>();

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
