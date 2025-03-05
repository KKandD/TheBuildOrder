using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class BuildOrder : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Goal { get; set; }
        public BuildOrderGame Game { get; set; }
        public IEnumerable<string> Steps { get; set; } = Array.Empty<string>();
        public IEnumerable<string> Tags { get; set; } = Array.Empty<string>();
    }
}
