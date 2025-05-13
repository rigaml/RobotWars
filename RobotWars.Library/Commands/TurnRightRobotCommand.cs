namespace RobotWars.Library.Commands
{
    /// <summary>
    /// Command to turn the robot right.
    /// </summary>
    public class TurnRightRobotCommand : IRobotCommand
    {
        public RobotState Apply(RobotState robotState, IArena arena)
        {
            return new RobotState(robotState.Position, robotState.Direction.TurnRight(), robotState.Penalties);
        }
    }
}
