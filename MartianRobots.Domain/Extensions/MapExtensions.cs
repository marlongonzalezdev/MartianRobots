using MartianRobots.Domain.Abstractions.Maps;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Maps;

namespace MartianRobots.Domain.Extensions
{
    /// <summary>
    /// Map extension methods.
    /// </summary>
    public static class MapExtensions
    {
        /// <summary>
        /// Returns lost landmarks from a mao.
        /// </summary>
        public static IDictionary<Coordinates, IEnumerable<LostLandmark>> GetLostLandmarks(this IPlanetMap map)
        {
            return map.GetLostPositions()
                .Where(p => p.Value.OfType<LostLandmark>().Any())
                .ToDictionary(p => p.Key, p => p.Value.OfType<LostLandmark>());
        }
    }
}