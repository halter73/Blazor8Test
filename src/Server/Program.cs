using BlazorApp;
using BlazorApp.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddWebAssemblyComponents()
    .AddServerComponents();

builder.Services.AddDbContext<BlazorMovieContext>(c => c.UseInMemoryDatabase("db"));

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

app.MapRazorComponents<App>()
    .AddWebAssemblyRenderMode()
    .AddServerRenderMode();

app.Run();
