﻿using System.Text;
using MartianRobots.Application;

namespace MartianRobots.Services.Extensions
{
    /// <summary>
    /// Orientation extension methods.
    /// </summary>
    public static class MissionControlExtensions
    {
        /// <summary>
        /// Gets a status report for the deployed robots.
        /// </summary>
        public static string GetStatusReport(this MissionControl control)
        {
            var builder = new StringBuilder();
            foreach (var robot in control.Robots)
            {
                builder
                    .Append(robot.Coordinates.X)
                    .Append(' ')
                    .Append(robot.Coordinates.Y)
                    .Append(' ').Append((string?)robot.Orientation.GetKeyCode());

                //var troubles = robot.Troubles.Select(t => t.GetTroubleCode());
                //if (troubles.Any())
                //{
                //    builder.Append(' ');
                //    builder.AppendJoin(' ', troubles);
                //}
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}