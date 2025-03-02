using Domain.Entities;

namespace Presentation.Endpoints
{
    public class BuildOrders : EndpointGroupBase
    {

        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .RequireAuthorization()
                .MapGet(GetBuildOrders)
                .MapGet(GetBuildOrderById, "{id}")
                .MapPost(CreateTodoItem)
                .MapPut(UpdateTodoItem, "{id}")
                .MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
                .MapDelete(DeleteBuildOrder, "{id}");
        }

        public async Task<IEnumerable<BuildOrder>> GetBuildOrders(I sender)
        {
            var result = await sender.Send(query);

            return TypedResults.Ok(result);
        }
        
        public async Task<BuildOrder> GetBuildOrderById(ISender sender, [AsParameters] GetTodoItemsWithPaginationQuery query)
        {
            var result = await sender.Send(query);

            return TypedResults.Ok(result);
        }
    }
}
