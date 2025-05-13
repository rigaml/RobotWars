namespace RobotWars.Library.Commands
{
    /// <summary>
    /// Command to turn the robot left.
    /// </summary>
    public class TurnLeftRobotCommand : IRobotCommand
    {
        public RobotState Apply(RobotState robotState, IArena arena)
        {
            return new RobotState(robotState.Position, robotState.Direction.TurnLeft(), robotState.Penalties);
        }
    }
}
