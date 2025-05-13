namespace RobotWars.Library
{
    /// <summary>
    /// Encapsulates the robots' battle arena as a rectangle.
    /// </summary>
    public class Arena : IArena
    {
        /// <summary>
        /// Creates a new arena with the given size.
        /// </summary>
        /// <param name="width">Width of the arena.</param>
        /// <param name="height">Height of the arena.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Arena(int width, int height)
        {
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), $"`{nameof(width)}` must be greater than zero.");
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), $"`{nameof(height)}` must be greater than zero.");

            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }

        /// <summary>
        /// Checks if the given coordinates are inside the arena.
        /// </summary>
        /// <param name="x">Coordinate value in the horizontal axis.</param>
        /// <param name="y">Coordinate value in the vertical axis.</param>
        /// <returns>True if coordinates are inside the Arena defined rectangle.</returns>
        public bool IsInside(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}
