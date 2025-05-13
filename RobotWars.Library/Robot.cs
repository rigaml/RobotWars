using RobotWars.Library.Commands;
using RobotWars.Library.Directions;

namespace RobotWars.Library
{
    /// <summary>
    /// Represents a robot in the war arena.
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Robot"/> class.
        /// The robot is initialized with a area, position and direction.
        /// </summary>
        /// <param name="arena">Arena where robot should navitate.</param>
        /// <param name="initialPosition">Robot initial position.</param>
        /// <param name="initialDirection">Robot initial direction.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Robot(IArena arena, Position initialPosition, IDirectionState initialDirection)
        {
            if (!arena.IsInside(initialPosition.X, initialPosition.Y))
                throw new ArgumentOutOfRangeException(nameof(initialPosition), "Position is outside the arena.");

            _arena = arena;
            _robotState = new RobotState(initialPosition, initialDirection, 0);
        }

        private IArena _arena;
        private RobotState _robotState;

        /// <summary>
        /// Processes a single instruction for the robot.
        /// </summary>
        /// <param name="instruction">The instruction to process. According to the task specification, "1.Only a single instruction can be sent at once", 
        /// so only one character is processed.</param>
        /// <returns>A tuple containing the robot's position (X and Y), direction, and penalties incurred since created.</returns>
        /// <exception cref="NotSupportedException">Thrown when the instruction is not supported.</exception>
        public (int x, int y, char direction, int penalties) Process(char instruction)
        {
            var robotCommand= RobotCommandFactory.Create(instruction);
            _robotState= robotCommand.Apply(_robotState, _arena);
            return _robotState.GetState();
        }
    }
}
