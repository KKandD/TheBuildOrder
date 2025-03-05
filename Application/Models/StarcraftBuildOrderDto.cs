using Domain.Enums;

namespace Application.Models
{
    public class StarcraftBuildOrderDto : BuildOrderDto
    {
        public StarcraftRaces Race { get; set; }
    }
}
