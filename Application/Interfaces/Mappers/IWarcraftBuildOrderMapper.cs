using Application.Models;
using Domain.Entities;

namespace Application.Interfaces.Mappers
{
    public interface IWarcraftBuildOrderMapper : IMapper<WarcraftBuildOrder?, WarcraftBuildOrderDto?>
    {
    }
}
