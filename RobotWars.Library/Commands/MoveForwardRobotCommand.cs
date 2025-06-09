namespace RobotWars.Library.Commands
{

    /// <summary>
    /// Command to move the robot forward in the direction it is facing.
    /// </summary>
    public class MoveForwardRobotCommand : IRobotCommand
    {
        /// <summary>
        /// Applies the move forward command to the robot state if possible otherwise increases the penalty value.
        /// </summary>
        /// <param name="robotState">Current robot state.</param>
        /// <param name="arena">Arena where robot is navigating.</param>
        /// <returns>Robot's state.</returns>
        public RobotState Apply(RobotState robotState, IArena arena)
        {
            if (robotState.Direction.CanMoveForward(robotState.Position, arena))
            { 
                var newPosition = robotState.Direction.MoveForward(robotState.Position, arena);
                return new RobotState(newPosition, robotState.Direction, robotState.Penalties);
            }
            else
            {
                return new RobotState(robotState.Position, robotState.Direction, robotState.Penalties + 1);
            }
        }
    }
}
