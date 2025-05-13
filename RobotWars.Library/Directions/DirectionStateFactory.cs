namespace RobotWars.Library.Directions
{
    /// <summary>
    /// Factory class to create direction states.
    /// Decisions about what to do depending on the direction are centralized in this class and not scattered accross the codebase.
    /// </summary>
    public static class DirectionStateFactory
    {
        public static IDirectionState Create(char direction)
        {
            return char.ToUpper(direction) switch
            {
                'N' => new DirectionNorth(),
                'S' => new DirectionSouth(),
                'E' => new DirectionEast(),
                'W' => new DirectionWest(),
                _ => throw new NotSupportedException($"Invalid direction: {direction}")
            };
        }
    }
}
