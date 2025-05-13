namespace RobotWars.Library.Directions
{
    public class DirectionEast : IDirectionState
    {
        public char Direction => 'E';

        public IDirectionState TurnLeft() => new DirectionNorth();
        public IDirectionState TurnRight() => new DirectionSouth();
        public bool CanMoveForward(Position position, IArena arena) => arena.IsInside(position.X + 1, position.Y);
        public Position MoveForward(Position position, IArena arena)
        {
            if (CanMoveForward(position, arena))
            {
                return new Position(position.X + 1, position.Y);
            }

            throw new InvalidOperationException("Cannot move forward in the current direction.");
        }
    }
}
