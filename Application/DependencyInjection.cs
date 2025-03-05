using Application.Interfaces.Mappers;
using Application.Interfaces.Services;
using Application.Mappings;
using Application.Models;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            //builder.Services.AddScoped<IBuildOrderMapper, BuildOrderMapper>();
            builder.Services.AddScoped<IMapper<WarcraftBuildOrder, WarcraftBuildOrderDto>, WarcraftBuildOrderMapper>();

            builder.Services.AddScoped<IWarcraftBuildOrderService, WarcraftBuildOrderService>();
        }
    }
}
