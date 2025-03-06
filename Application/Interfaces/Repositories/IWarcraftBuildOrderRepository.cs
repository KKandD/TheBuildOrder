using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IWarcraftBuildOrderRepository
    {
        Task<WarcraftBuildOrder> Add(WarcraftBuildOrder entity);
        Task<WarcraftBuildOrder> Update(WarcraftBuildOrder entity);
        Task Remove(WarcraftBuildOrder entity);
        Task<WarcraftBuildOrder?> GetById(int id, CancellationToken cancellationToken = default);
        Task<List<WarcraftBuildOrder>> GetAll(CancellationToken cancellationToken = default);
    }
}
