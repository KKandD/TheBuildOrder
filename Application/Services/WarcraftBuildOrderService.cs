using Application.Interfaces.Mappers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;

namespace Application.Services
{
    public class WarcraftBuildOrderService : IWarcraftBuildOrderService
    {
        private readonly IWarcraftBuildOrderRepository _warcraftBuildOrderRepository;
        private readonly IMapper<WarcraftBuildOrder, WarcraftBuildOrderDto> _mapper;

        public WarcraftBuildOrderService(IWarcraftBuildOrderRepository buildOrderRepository, IMapper<WarcraftBuildOrder, WarcraftBuildOrderDto> mapper)
        {
            _warcraftBuildOrderRepository = buildOrderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WarcraftBuildOrderDto>> GetWarcraftBuildOrders()
        {
            var buildOrders = await _warcraftBuildOrderRepository.GetAll();

            return buildOrders.Select(_mapper.MapToDto).ToList();
        }

        public async Task<WarcraftBuildOrderDto> GetWarcraftBuildOrderById(int id)
        {
            var buildOrder = await _warcraftBuildOrderRepository.GetById(id);

            return _mapper.MapToDto(buildOrder);
        }

        public async Task<WarcraftBuildOrderDto> AddWarcraftBuildOrder(WarcraftBuildOrderDto dto)
        {
            var createdBuildOrder = await _warcraftBuildOrderRepository.Add(_mapper.MapToEntity(dto));

            return _mapper.MapToDto(createdBuildOrder);
        }

        public async Task<WarcraftBuildOrderDto> UpdateWarcraftBuildOrder(WarcraftBuildOrderDto dto)
        {
            var updatedBuildOrder = await _warcraftBuildOrderRepository.Update(_mapper.MapToEntity(dto));

            return _mapper.MapToDto(updatedBuildOrder);
        }

        public async Task DeleteWarcraftBuildOrder(WarcraftBuildOrderDto dto)
        {
            await _warcraftBuildOrderRepository.Remove(_mapper.MapToEntity(dto));
        }
    }
}
