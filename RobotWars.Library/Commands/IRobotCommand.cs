namespace RobotWars.Library.Commands
{
    public interface IRobotCommand
    {
        RobotState Apply(RobotState robotState, IArena arena);
    }
}
