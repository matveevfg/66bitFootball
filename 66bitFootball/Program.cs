using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _66bitFootball.Data;
using _66bitFootball.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<_66bitFootballContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("_66bitFootballContext") ?? throw new InvalidOperationException("Connection string '_66bitFootballContext' not found.")));

builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<TeamService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
