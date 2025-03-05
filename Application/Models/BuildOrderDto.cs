using Application.Models.Common;
using Domain.Enums;

namespace Application.Models
{
    public class BuildOrderDto : BaseDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Goal { get; set; }
        public BuildOrderGame Game { get; set; }
        public IEnumerable<string> Steps { get; set; } = Array.Empty<string>();
        public IEnumerable<string> Tags { get; set; } = Array.Empty<string>();
    }
}
