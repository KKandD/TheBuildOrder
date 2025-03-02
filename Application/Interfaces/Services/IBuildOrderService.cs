using Application.Models;

namespace Application.Interfaces.Services
{
    public interface IBuildOrderService
    {
        Task<IEnumerable<BuildOrderDto>> GetBuildOrders(int id);
        Task<BuildOrderDto> GetById(int id);
    }
}
