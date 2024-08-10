using KFHService.Data;
using KFHService.Infrastructure;
using KFHService.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((ctx, lc) =>
            lc.WriteTo.File(ctx.Configuration.GetValue<string>(key: "logFilePath"),
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true,
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
           .ReadFrom.Configuration(ctx.Configuration));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7183/") });



builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
