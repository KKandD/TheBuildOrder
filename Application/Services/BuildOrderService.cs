using Application.Interfaces.Services;
using Application.Models;

namespace Application.Services
{
    public class BuildOrderService : IBuildOrderService
    {

        public BuildOrderService()
        {
            
        }

        public Task<IEnumerable<BuildOrderDto>> GetBuildOrders(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BuildOrderDto> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
