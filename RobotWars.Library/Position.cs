namespace RobotWars.Library
{
    /// <summary>
    /// Defines the robot's coordinates. 
    /// </summary>
    /// <param name="x">Robot `x` coordinate.</param>
    /// <param name="y">Robot `y` coordinate.</param>
    public class Position(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
    }
}
