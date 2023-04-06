using Masterchef.Service;
using System;
using MasterChef.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "masterChef.api", Version = "v1" });
});

builder.Services.Configure<RouteOptions>(o => o.LowercaseUrls = true);

builder.Services.AddCors(
    options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RecipeContext>(opt => opt.UseInMemoryDatabase("recipeContext"));
builder.Services.AddTransient<IRecipeService, RecipeService>();

builder.Services.AddApiVersioning();
builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "masterChef.api v1"));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();