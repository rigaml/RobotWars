namespace RobotWars.Library.Directions
{
    public interface IDirectionState
    {
        char Direction { get; }

        IDirectionState TurnLeft();

        IDirectionState TurnRight();

        bool CanMoveForward(Position position, IArena arena);

        Position MoveForward(Position position, IArena arena);
    }
}
