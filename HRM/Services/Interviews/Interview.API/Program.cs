using System.Text;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IInterviewService, InterviewService>();
builder.Services.AddScoped<IInterviewRepository, InterviewRepository>();

//var dockerConnectionString = Environment.GetEnvironmentVariable("MSSQLConnectionString");

//builder.Services.AddDbContext<InterviewDbContext>(options => options.UseSqlServer(dockerConnectionString));
builder.Services.AddDbContext<InterviewDbContext>(options => options.UseSqlServer(builder.Configuration.
    GetConnectionString("InterviewDbConnection")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        { 
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "HRM",
            ValidAudience = "HRM Users",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

var angularURL = Environment.GetEnvironmentVariable("angularURL");

app.UseCors(policy => 
{ 
    policy.WithOrigins(angularURL).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
});

app.MapControllers();

app.Run();