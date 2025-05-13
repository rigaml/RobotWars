using RobotWars.Library.Directions;

namespace RobotWars.Library.Commands
{
    /// <summary>
    /// Represents the state of a robot.
    /// </summary>
    public class RobotState
    {
        public RobotState(Position position, IDirectionState direction, int penalties)
        {
            Position = position;
            Direction = direction;
            Penalties = penalties;
        }
        public Position Position { get; }
        public IDirectionState Direction { get; }
        public int Penalties { get; }

        public (int x, int y, char direction, int penalties) GetState()
        {
            return (Position.X, Position.Y, Direction.Direction, Penalties);
        }
    }
}
