using Application.Interfaces.Mappers;
using Application.Models;
using Domain.Entities;

namespace Application.Mappings
{
    public class WarcraftBuildOrderMapper : IWarcraftBuildOrderMapper
    {
        public WarcraftBuildOrderDto? MapToDto(WarcraftBuildOrder? entity)
        {
            if (entity is null)
                return default;

            return new WarcraftBuildOrderDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Goal = entity.Goal,
                Game = entity.Game,
                Race = entity.Race,
                Tags = entity.Tags
            };
        }

        public WarcraftBuildOrder? MapToEntity(WarcraftBuildOrderDto? dto)
        {
            if (dto is null)
                return default;

            return new WarcraftBuildOrder
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Goal = dto.Goal,
                Game = dto.Game,
                Race = dto.Race,
                Tags = dto.Tags
            };
        }
    }
}
