using Application.Models;

namespace Application.Interfaces.Services
{
    public interface IWarcraftBuildOrderService
    {
        Task<IEnumerable<WarcraftBuildOrderDto>?> GetWarcraftBuildOrders();
        Task<WarcraftBuildOrderDto?> GetWarcraftBuildOrderById(int id);
        Task<WarcraftBuildOrderDto?> AddWarcraftBuildOrder(WarcraftBuildOrderDto dto);
        Task<WarcraftBuildOrderDto?> UpdateWarcraftBuildOrder(WarcraftBuildOrderDto dto);
        Task DeleteWarcraftBuildOrder(WarcraftBuildOrderDto dto);
    }
}
