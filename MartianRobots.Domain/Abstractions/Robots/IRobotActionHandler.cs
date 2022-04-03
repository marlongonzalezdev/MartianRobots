using MartianRobots.Domain.Abstractions.Maps;

namespace MartianRobots.Domain.Abstractions.Robots
{
    /// <summary>
    /// Represents a robot action handler contract.
    /// </summary>
    public interface IRobotActionHandler
    {
        /// <summary>
        /// Executes the robot action
        /// </summary>
        public void Execute(Robot robot, IPlanetMap map);
    }
}