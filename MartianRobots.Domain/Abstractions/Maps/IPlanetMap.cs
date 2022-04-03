using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Enums;

namespace MartianRobots.Domain.Abstractions.Maps
{
    /// <summary>
    /// Represents a planet map contract which defines how displacement, orientation changes and limits are handled.
    /// </summary>
    public interface IPlanetMap
    {
        /// <summary>
        /// Configures the planet map.
        /// </summary>
        public void Configure(PlanetMapConfiguration configuration);

        /// <summary>
        /// Adds a lost position.
        /// </summary>
        public void AddLostPosition(Coordinates coordinates, Landmark landmark);

        /// <summary>
        /// Retrieves the planet landmarks.
        /// </summary>
        public IDictionary<Coordinates, IEnumerable<Landmark>> GetLostPositions();

        /// <summary>
        /// Calculates the next coordinates increment from current position and orientation.
        /// </summary>
        public Coordinates GetNextCoordinates(Coordinates coordinates, Orientation orientation);

        /// <summary>
        /// Calculates next orientation 90º to left.
        /// </summary>
        public Orientation TurnLeft(Orientation orientation);

        /// <summary>
        /// Calculates next orientation 90º to right.
        /// </summary>
        public Orientation TurnRight(Orientation orientation);

        /// <summary>
        /// Returns if given coordinates are out of bounds.
        /// </summary>
        public bool IsOutOfBounds(Coordinates coordinates);
    }
}