using RobotWars.Library.Commands;

namespace RobotWars.Library.Tests.Commands
{
    public class RobotCommandFactoryTests
    {
        [TestCase('M')]
        [TestCase('m')]
        public void Create_WithInstructionM_ReturnsMoveForwardCommand(char instruction)
        {
            var command = RobotCommandFactory.Create(instruction);

            Assert.That(command, Is.InstanceOf<MoveForwardRobotCommand>());
        }

        [TestCase('L')]
        [TestCase('l')]
        public void Create_WithInstructionL_ReturnsTurnLeftCommand(char instruction)
        {
            var command = RobotCommandFactory.Create(instruction);

            Assert.That(command, Is.InstanceOf<TurnLeftRobotCommand>());
        }
        [TestCase('R')]
        [TestCase('r')]
        public void Create_WithInstructionR_ReturnsTurnRightCommand(char instruction)
        {
            var command = RobotCommandFactory.Create(instruction);

            Assert.That(command, Is.InstanceOf<TurnRightRobotCommand>());
        }

        [Test]
        public void Create_WithInstructionInvalid_ThrowsNotSupportedException()
        {
            var invalidInstruction = 'X';

            var ex = Assert.Throws<NotSupportedException>(() => RobotCommandFactory.Create(invalidInstruction));
        }
    }
}