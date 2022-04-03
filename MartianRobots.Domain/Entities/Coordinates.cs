namespace MartianRobots.Domain.Entities
{
    /// <summary>
    /// Multidimensional space coordinates.
    /// </summary>
    public struct Coordinates : IEquatable<Coordinates>
    {
        /// <summary>
        /// Max allowed coordinate in any axis.
        /// </summary>
        private const int Max = 50;

        /// <summary>
        /// Coordinates representing 0,0
        /// </summary>
        public static Coordinates Zero => new(0, 0);

        /// <summary>
        /// X coordinate.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Creates an instance.
        /// </summary>
        public Coordinates(int x, int y)
        {
            ThrowIfOverLimit(x);
            ThrowIfOverLimit(y);
            X = x;
            Y = y;
        }

        private static void ThrowIfOverLimit(int coordinate)
        {
            if (coordinate > Max) throw new ArgumentException($"Coordinate cannot be more than {Max}.");
        }

        /// <summary>
        /// Sum operator.
        /// </summary>
        public static Coordinates operator +(Coordinates a, Coordinates b) => new(a.X + b.X, a.Y + b.Y);

        /// <summary>
        /// Equals operator.
        /// </summary>
        public static bool operator ==(Coordinates a, Coordinates b) => a.Equals(b);

        /// <summary>
        /// Not equals operator.
        /// </summary>
        public static bool operator !=(Coordinates a, Coordinates b) => !a.Equals(b);

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="instance">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="instance" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(Coordinates instance)
        {
            return X.Equals(instance.X)
                && Y.Equals(instance.Y);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        public override int GetHashCode()
        {
            return X.GetHashCode()
                    ^ Y.GetHashCode();
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Coordinates instance)
                return Equals(instance);
            else
                return false;
        }
    }
}