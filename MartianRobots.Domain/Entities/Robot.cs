using System.Text.Json.Serialization;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Enums;

namespace MartianRobots.Domain
{
    /// <summary>
    /// Planetary robot.
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// Current coordinates.
        /// </summary>
        [JsonIgnore]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// Current orientation.
        /// </summary>
        [JsonIgnore]
        public Orientation Orientation { get; set; }

        public List<PreviousMovement> Movements { get; set; } = new();

        public bool IsLost { get; set; }

        /// <summary>
        /// Creates an instance.
        /// </summary>
        public Robot(Coordinates coordinates, Orientation orientation)
        {
            Coordinates = coordinates;
            Orientation = orientation;
            Movements.Add(new PreviousMovement
            {
                Coordinates = coordinates,
                Orientation = Orientation
            });
        }
    }
}