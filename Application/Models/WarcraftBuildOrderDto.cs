using Domain.Enums;

namespace Application.Models
{
    public class WarcraftBuildOrderDto : BuildOrderDto
    {
        public WarcraftRaces Race { get; set; }
    }
}
