namespace RobotWars.Library.Directions
{
    public class DirectionSouth : IDirectionState
    {
        public char Direction => 'S';

        public IDirectionState TurnLeft() => new DirectionEast();
        public IDirectionState TurnRight() => new DirectionWest();
        public bool CanMoveForward(Position position, IArena arena) => arena.IsInside(position.X, position.Y - 1);
        public Position MoveForward(Position position, IArena arena)
        {
            if (CanMoveForward(position, arena))
            {
                return new Position(position.X, position.Y - 1);
            }

            throw new InvalidOperationException("Cannot move forward in the current direction.");
        }
    }
}
