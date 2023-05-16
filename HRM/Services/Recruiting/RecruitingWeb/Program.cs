using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastruction.Data;
using Infrastruction.Repositories;
using Infrastruction.Services;
using Microsoft.EntityFrameworkCore;
using RecruitingWeb.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// this is the line we injected 
builder.Services.AddScoped<IJobService, JobService>();
// inject our connectionstrings into DbContext
builder.Services.AddDbContext<RecruitingDbContext>(options => options.UseSqlServer(builder.Configuration.
    GetConnectionString("RecruitingDbConnection")));
builder.Services.AddScoped<IJobRepository, JobRepository>();
// ninject and autofrac

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Home/DevException");
}
*/
app.UseRecruitingMiddleware();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

