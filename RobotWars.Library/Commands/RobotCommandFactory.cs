namespace RobotWars.Library.Commands
{
    /// <summary>
    /// Factory class for creating robot commands based on the instruction character.
    /// </summary>
    public static class RobotCommandFactory
    {
        public static IRobotCommand Create(char instruction)
        {
            return char.ToUpper(instruction) switch
            {
                'M' => new MoveForwardRobotCommand(),
                'L' => new TurnLeftRobotCommand(),
                'R' => new TurnRightRobotCommand(),
                _ => throw new NotSupportedException($"Invalid instruction: {instruction}")
            };
        }
    }
}