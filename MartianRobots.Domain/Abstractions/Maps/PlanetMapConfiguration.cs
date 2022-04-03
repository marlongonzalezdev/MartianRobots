﻿using MartianRobots.Domain.Entities;

namespace MartianRobots.Domain.Abstractions.Maps
{
    /// <summary>
    /// Planet map configuration parameters.
    /// </summary>
    public class PlanetMapConfiguration
    {
        /// <summary>
        /// Origin coordinates of the map.
        /// </summary>
        public Coordinates Origin { get; init; }

        /// <summary>
        /// Total height of the map.
        /// </summary>
        public int Height { get; init; }

        /// <summary>
        /// Total width of the map.
        /// </summary>
        public int Width { get; init; }
    }
}