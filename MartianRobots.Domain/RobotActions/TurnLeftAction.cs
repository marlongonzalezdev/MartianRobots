using MartianRobots.Domain.Abstractions.Maps;
using MartianRobots.Domain.Abstractions.Robots;

namespace MartianRobots.Domain.RobotActions
{
    /// <summary>
    /// Changes robot orientation to the left.
    /// </summary>
    public sealed class TurnLeftAction : IRobotActionHandler
    {
        private static TurnLeftAction CurrentInstance { get; set; }

        /// <summary>
        /// Gets an instance.
        /// </summary>
        public static TurnLeftAction Instance => CurrentInstance ??= new TurnLeftAction();

        private TurnLeftAction()
        {
        }

        /// <summary>
        /// Executes the robot action
        /// </summary>
        public void Execute(Robot robot, IPlanetMap map)
        {
            robot.Orientation = map.TurnLeft(robot.Orientation);
            robot.Movements.Add(new PreviousMovement
            {
                Coordinates = robot.Coordinates,
                Orientation = robot.Orientation
            });
        }
    }
}