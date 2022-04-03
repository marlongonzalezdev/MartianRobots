using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Enums;

namespace MartianRobots.Domain
{
    public class PreviousMovement
    {
        public Coordinates Coordinates { get; set; }
        public Orientation Orientation { get; set; }
    }
}
