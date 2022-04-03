using MartianRobots.Domain.Abstractions.Maps;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Enums;

namespace MartianRobots.Domain.Maps
{
    public class RectangleMap : IPlanetMap
    {
        /// <summary>
        /// Origin coordinates.
        /// </summary>
        public Coordinates Origin { get; private set; }

        /// <summary>
        /// Top right coordinates.
        /// </summary>
        public Coordinates TopRight { get; private set; }

        private readonly IDictionary<Coordinates, List<Landmark>> LostPositions = new Dictionary<Coordinates, List<Landmark>>();
        private bool Configured { get; set; }

        /// <summary>
        /// Configures the current map.
        /// </summary>
        public void Configure(PlanetMapConfiguration configuration)
        {
            TopRight = new Coordinates(configuration.Width, configuration.Height);
            Origin = configuration.Origin;
            Configured = true;
        }

        /// <summary>
        /// Adds a landmark to the map
        /// </summary>
        public void AddLostPosition(Coordinates coordinates, Landmark landmark)
        {
            if (!LostPositions.ContainsKey(coordinates))
            {
                LostPositions.Add(coordinates, new List<Landmark>());
            }
            LostPositions[coordinates].Add(landmark);
        }

        /// <summary>
        /// Gets map landmarks.
        /// </summary>
        public IDictionary<Coordinates, IEnumerable<Landmark>> GetLostPositions() => LostPositions.ToDictionary(l => l.Key, l => l.Value.AsEnumerable());

        /// <summary>
        /// Calculates the next coordinates increment from current position and orientation.
        /// </summary>
        public Coordinates GetNextCoordinates(Coordinates coordinates, Orientation orientation)
        {
            ThrowIfNotConfigured();

           const int chunkAdvances = 1;

            var xAmmount = orientation is Orientation.East or Orientation.West ? chunkAdvances : 0;
            var yAmmount = orientation is Orientation.North or Orientation.South ? chunkAdvances : 0;

            if (orientation == Orientation.South)
                yAmmount *= -1;

            if (orientation == Orientation.West)
                xAmmount *= -1;

            return coordinates + new Coordinates(xAmmount, yAmmount);
        }

        /// <summary>
        /// Returns if given coordinates are out of bounds.
        /// </summary>
        public bool IsOutOfBounds(Coordinates coordinates)
        {
            ThrowIfNotConfigured();
            if (coordinates.X < Origin.X || coordinates.X > TopRight.X) return true;
            if (coordinates.Y < Origin.Y || coordinates.Y > TopRight.Y) return true;
            return false;
        }

        /// <summary>
        /// Calculates next orientation 90º to left.
        /// </summary>
        public Orientation TurnLeft(Orientation orientation) => Turn(orientation, -1);

        /// <summary>
        /// Calculates next orientation 90º to right.
        /// </summary>
        public Orientation TurnRight(Orientation orientation) => Turn(orientation, 1);

        private Orientation Turn(Orientation orientation, int times)
        {
            ThrowIfNotConfigured();

            var min = (int)Enum.GetValues(typeof(Orientation)).Cast<Orientation>().Min();
            var max = (int)Enum.GetValues(typeof(Orientation)).Cast<Orientation>().Max();

            var next = (int)orientation + times;
            if (next > max) next = min;
            if (next < min) next = max;

            return (Orientation)next;
        }

        private void ThrowIfNotConfigured()
        {
            if (!Configured)
            {
                throw new InvalidOperationException("Map is not configured yet.");
            }
        }
    }
}