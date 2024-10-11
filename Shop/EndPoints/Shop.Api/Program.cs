using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Common.Application;
using Shop.Config;

namespace Shop.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var services = builder.Services;
        var connectionString = builder.Configuration.GetConnectionString("DefultConnection");

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        ShopBootstraper.Configure(services, connectionString);

        CommonBootstrapper.Init(builder.Services);

        services.AddTransient<IFileService, FileService>();

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
    }
}
