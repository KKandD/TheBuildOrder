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

            group.MapPut("/", UpdateWarcraftBuildOrder)
                 .WithName("UpdateWarcraftBuildOrder");

            group.MapDelete("/{id:int}", DeleteWarcraftBuildOrder)
                 .WithName("DeleteWarcraftBuildOrder");

            return group;
        }

        public static async Task<Results<Ok<IEnumerable<WarcraftBuildOrderDto>>, InternalServerError>> GetWarcraftBuildOrders(IWarcraftBuildOrderService buildOrderService)
        {
            var buildOrders = await buildOrderService.GetWarcraftBuildOrders();

            return buildOrders is not null ? TypedResults.Ok(buildOrders) : TypedResults.InternalServerError();
        }

        public static async Task<Results<Ok<WarcraftBuildOrderDto>, NotFound, BadRequest>> GetWarcraftBuildOrderById(IWarcraftBuildOrderService buildOrderService, int id)
        {
            if (id is 0)
                return TypedResults.BadRequest();

            var buildOrder = await buildOrderService.GetWarcraftBuildOrderById(id);
            return buildOrder is not null ? TypedResults.Ok(buildOrder) : TypedResults.NotFound();
        }

        public static async Task<Results<Created, BadRequest>> CreateWarcraftBuildOrder(IWarcraftBuildOrderService buildOrderService, [FromBody]WarcraftBuildOrderDto dto)
        {
            if (dto is null)
                return TypedResults.BadRequest();

            var createdBuildOrder = await buildOrderService.AddWarcraftBuildOrder(dto);

            if (createdBuildOrder is null)
                return TypedResults.BadRequest();

            return TypedResults.Created($"/api/buildOrders/{createdBuildOrder.Id}");
        }

        public static async Task<Results<CreatedAtRoute, BadRequest>> UpdateWarcraftBuildOrder(IWarcraftBuildOrderService buildOrderService, [FromBody]WarcraftBuildOrderDto dto)
        {
            if(dto is null)
                return TypedResults.BadRequest();

            var updatedBuildOrder = await buildOrderService.UpdateWarcraftBuildOrder(dto);

            if (updatedBuildOrder is null)
                return TypedResults.BadRequest();

            return TypedResults.CreatedAtRoute(routeName: $"/api/BuildOrders/{updatedBuildOrder.Id}");
        }

        public static async Task<Results<Ok, BadRequest>> DeleteWarcraftBuildOrder(IWarcraftBuildOrderService buildOrderService, [FromBody]WarcraftBuildOrderDto dto)
        {
            await buildOrderService.DeleteWarcraftBuildOrder(dto);

            return TypedResults.Ok();
        }
    }

}
