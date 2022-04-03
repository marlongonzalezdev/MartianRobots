using MartianRobots.Domain.Abstractions.Maps;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Enums;

namespace MartianRobots.Domain.Maps
{
    /// <summary>
    /// A landmark representing last traces of a lost robot.
    /// </summary>
    public record LostLandmark(Coordinates LostRecordedCoords, Orientation Orientation) : Landmark
    {
        public Coordinates LostRecordedCoords { get; } = LostRecordedCoords;
        public Orientation Orientation { get; } = Orientation;
    }
}