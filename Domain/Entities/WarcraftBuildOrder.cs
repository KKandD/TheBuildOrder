using Domain.Enums;

namespace Domain.Entities
{
    public class WarcraftBuildOrder : BuildOrder
    {
        public WarcraftRaces Race { get; set; }
    }
}
