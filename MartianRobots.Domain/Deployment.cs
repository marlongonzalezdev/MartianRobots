using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Enums;

namespace MartianRobots.Domain
{
    public class Deployment
    {
        public Coordinates Coordinates { get; set; } = new();
        public Orientation Orientation { get; set; }
        public string Instructions { get; set; } = string.Empty;
    }
}
