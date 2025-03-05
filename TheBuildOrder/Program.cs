using Application;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TheBuildOrder;
using TheBuildOrder.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var cos = builder.Configuration.GetConnectionString("TheBuildOrderDb");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("TheBuildOrderDb")));

builder.AddInfrastructureServices();

builder.AddApplicationServices();

builder.AddWebServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("The Build Order API");
    });
}

app.Map("/", () => Results.Redirect("/scalar/v1"));

app.MapGroup("/api/warcraftBuildOrders").MapWarcraftBuildOrderEndpoints();

app.UseHttpsRedirection();

app.Run();