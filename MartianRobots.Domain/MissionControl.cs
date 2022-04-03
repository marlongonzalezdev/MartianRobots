﻿using MartianRobots.Domain.Abstractions.Maps;
using MartianRobots.Domain.Abstractions.Robots;

namespace MartianRobots.Domain
{
    /// <summary>
    /// An interplanetary mission control command interface.
    /// </summary>
    public class MissionControl
    {
        private IPlanetMap Map { get; set; }

        private readonly List<Robot> DeployedRobots = new();

        public Robot CurrentRobot { get; set; }

        /// <summary>
        /// Collection of robots deployed to the map.
        /// </summary>
        public IReadOnlyCollection<Robot> Robots => DeployedRobots.AsReadOnly();

        /// <summary>
        /// Creates an instance.
        /// </summary>
        public void MapPlanet(IPlanetMap map)
        {
            Map = map;
        }

        /// <summary>
        /// Deploys a robot on planet surface and sets it as current controlled robot.
        /// </summary>
        /// <param name="robot"></param>
        public void DeployRobot(Robot robot)
        {
            DeployedRobots.Add(robot);
            CurrentRobot = robot;
        }

        /// <summary>
        /// Commands the current robot to perform actions.
        /// </summary>
        /// <param name="action"></param>
        public void CommandRobot(IRobotActionHandler action)
        {
            if (CurrentRobot is null)
            {
                throw new InvalidOperationException("There is no robot deployed yet.");
            }

            action.Execute(CurrentRobot, Map);
        }
    }
}