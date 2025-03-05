using Application.Interfaces.Services;
using Application.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TheBuildOrder.Endpoints
{
    public static class WarcraftBuildOrders
    {
        public static RouteGroupBuilder MapWarcraftBuildOrderEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetWarcraftBuildOrders)
                 .WithName("GetAllWarcraftBuildOrders");

            group.MapGet("/{id:int}", GetWarcraftBuildOrderById)
                 .WithName("GetWarcraftBuildOrderById");

            group.MapPost("/", CreateWarcraftBuildOrder)
                 .WithName("CreateWarcraftBuildOrder");

            group.MapPut("/{id:int}", UpdateWarcraftBuildOrder)
                 .WithName("UpdateWarcraftBuildOrder");

            group.MapDelete("/{id:int}", DeleteWarcraftBuildOrder)
                 .WithName("DeleteWarcraftBuildOrder");

            return group;
        }

        public static async Task<Ok<IEnumerable<WarcraftBuildOrderDto>>> GetWarcraftBuildOrders(IWarcraftBuildOrderService buildOrderService)
        {
            var buildOrders = await buildOrderService.GetWarcraftBuildOrders();
            return TypedResults.Ok(buildOrders);
        }

        public static async Task<Results<Ok<WarcraftBuildOrderDto>, NotFound, BadRequest>> GetWarcraftBuildOrderById(IWarcraftBuildOrderService buildOrderService, int id)
        {
            if (id is 0)
                return TypedResults.BadRequest();

            var buildOrder = await buildOrderService.GetWarcraftBuildOrderById(id);
            return buildOrder is not null ? TypedResults.Ok(buildOrder) : TypedResults.NotFound();
        }

        public static async Task<Results<Created<WarcraftBuildOrderDto>, BadRequest>> CreateWarcraftBuildOrder(IWarcraftBuildOrderService buildOrderService, [FromBody]WarcraftBuildOrderDto dto)
        {
            if (dto is null)
                return TypedResults.BadRequest();

            var createdBuildOrder = await buildOrderService.AddWarcraftBuildOrder(dto);

            if (createdBuildOrder is null)
                return TypedResults.BadRequest();

            return TypedResults.Created($"/api/BuildOrders/{createdBuildOrder.Id}", createdBuildOrder);
        }

        public static async Task<BuildOrderDto> UpdateWarcraftBuildOrder(IWarcraftBuildOrderService buildOrderService, int id, WarcraftBuildOrderDto dto)
        {
            throw new NotImplementedException();
        }

        public static async Task<BuildOrderDto> DeleteWarcraftBuildOrder(IWarcraftBuildOrderService buildOrderService, int id)
        {
            throw new NotImplementedException();
        }
    }

}
