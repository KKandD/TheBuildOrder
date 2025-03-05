using Domain.Enums;

namespace Domain.Entities
{
    public class StarcraftBuildOrder : BuildOrder
    {
        public StarcraftRaces Race { get; set; }
    }
}
