using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var dockerConnectionString = Environment.GetEnvironmentVariable("MSSQLConnectionString");

builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(dockerConnectionString));

//builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(builder.Configuration.
//    GetConnectionString("EmployeeDbConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

//var angularURL = Environment.GetEnvironmentVariable("angularURL");

//app.UseCors(policy => 
//{ 
//    policy.WithOrigins(angularURL).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
//});
app.UseCors(policy =>
{
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.MapControllers();

app.Run();