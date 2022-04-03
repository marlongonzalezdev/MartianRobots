using MartianRobots.Domain.Abstractions.Maps;
using MartianRobots.Domain.Abstractions.Robots;
using MartianRobots.Domain.Extensions;
using MartianRobots.Domain.Maps;

namespace MartianRobots.Domain.RobotActions
{
    /// <summary>
    /// Moves a robot forward from current position.
    /// </summary>
    public sealed class MoveForwardAction : IRobotActionHandler
    {
        private static MoveForwardAction CurrentInstance { get; set; }

        /// <summary>
        /// Gets an instance.
        /// </summary>
        public static MoveForwardAction Instance => CurrentInstance ??= new MoveForwardAction();

        private MoveForwardAction()
        {
        }
        
        public void Execute(Robot robot, IPlanetMap map)
        {
            var nextCoords = map.GetNextCoordinates(robot.Coordinates, robot.Orientation);

            var lostLandmarks = map.GetLostLandmarks();
            var nextIsLost = lostLandmarks.TryGetValue(robot.Coordinates, out var marks)
                && marks.Any(m => m.LostRecordedCoords == robot.Coordinates && m.Orientation == robot.Orientation);

            if (nextIsLost) return;

            if (map.IsOutOfBounds(nextCoords))
            {
                robot.IsLost = true;
                map.AddLostPosition(robot.Coordinates, new LostLandmark(robot.Coordinates, robot.Orientation));
            }
            else
            {
                robot.Coordinates = nextCoords;
                robot.Movements.Add(new PreviousMovement
                {
                    Coordinates = nextCoords,
                    Orientation = robot.Orientation
                });
            }
        }
    }
}