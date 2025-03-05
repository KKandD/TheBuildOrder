using Application.Interfaces.Services;
using Application.Models;
using Presentation.Infrastructure;

namespace Presentation.Endpoints
{
    public class BuildOrders : EndpointGroupBase
    {

        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .RequireAuthorization()
                .MapGet(GetBuildOrders)
                .MapGet(GetBuildOrderById, "{id}");
                //.MapPost(CreateTodoItem)
                //.MapPut(UpdateTodoItem, "{id}")
                //.MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
                //.MapDelete(DeleteBuildOrder, "{id}");
        }

        public async Task<IEnumerable<BuildOrderDto>> GetBuildOrders(IBuildOrderService buildOrderService)
        {
            var buildOrders = await buildOrderService.GetBuildOrders();

            return buildOrders;
        }
        
        public async Task<BuildOrderDto> GetBuildOrderById(IBuildOrderService buildOrderService, int id)
        {
            var buildOrder = await buildOrderService.GetById(id);

            return buildOrder;
        }
    }
}
