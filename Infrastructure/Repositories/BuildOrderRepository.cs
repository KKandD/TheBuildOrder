using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BuildOrderRepository : IWarcraftBuildOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BuildOrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WarcraftBuildOrder> Add(WarcraftBuildOrder entity)
        {
            await _dbContext.Set<WarcraftBuildOrder>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<WarcraftBuildOrder>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<WarcraftBuildOrder>().ToListAsync(cancellationToken);
        }

        public async Task<WarcraftBuildOrder> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<WarcraftBuildOrder>().FindAsync(id, cancellationToken);
        }

        public async Task Remove(WarcraftBuildOrder entity)
        {
            _dbContext.Set<WarcraftBuildOrder>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<WarcraftBuildOrder> Update(WarcraftBuildOrder entity)
        {
            _dbContext.Set<WarcraftBuildOrder>().Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
