namespace RobotWars.Library.Directions
{
    public class DirectionWest : IDirectionState
    {
        public char Direction => 'W';

        public IDirectionState TurnLeft() => new DirectionSouth();
        public IDirectionState TurnRight() => new DirectionNorth();
        public bool CanMoveForward(Position position, IArena arena) => arena.IsInside(position.X - 1, position.Y);
        public Position MoveForward(Position position, IArena arena)
        {
            if (CanMoveForward(position, arena))
            {
                return new Position(position.X - 1, position.Y);
            }

            throw new InvalidOperationException("Cannot move forward in the current direction.");
        }
    }
}
