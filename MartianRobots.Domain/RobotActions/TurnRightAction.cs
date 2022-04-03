using MartianRobots.Domain.Abstractions.Maps;
using MartianRobots.Domain.Abstractions.Robots;

namespace MartianRobots.Domain.RobotActions
{
    /// <summary>
    /// Changes robot orientation to the right.
    /// </summary>
    public sealed class TurnRightAction : IRobotActionHandler
    {
        private static TurnRightAction CurrentInstance { get; set; }

        /// <summary>
        /// Gets an instance.
        /// </summary>
        public static TurnRightAction Instance => CurrentInstance ??= new TurnRightAction();

        private TurnRightAction()
        {
        }

        public void Execute(Robot robot, IPlanetMap map)
        {
            robot.Orientation = map.TurnRight(robot.Orientation);
            robot.Movements.Add(new PreviousMovement
            {
                Coordinates = robot.Coordinates,
                Orientation = robot.Orientation
            });
        }
    }
}