namespace RobotWars.Library
{
    /// <summary>
    /// Interface encapsulating the robots' battle arena.
    /// </summary>
    public interface IArena
    {
        int Width { get; }
        int Height { get; }
        bool IsInside(int x, int y);
    }
}
