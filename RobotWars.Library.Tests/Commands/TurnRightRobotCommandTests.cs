using Moq;
using RobotWars.Library.Commands;
using RobotWars.Library.Directions;

namespace RobotWars.Library.Tests.Commands
{
    public class TurnRightRobotCommandTests
    {
        [Test]
        public void Apply_ShouldCallTurnRightOnDirection()
        {
            var command = new TurnRightRobotCommand();
            var arenaMock = new Mock<IArena>();
            var position = new Position(3, 4);
            var initialDirection = new Mock<IDirectionState>();
            var newDirection = new Mock<IDirectionState>().Object;
            var penalties = 2;

            initialDirection.Setup(d => d.TurnRight()).Returns(newDirection);

            var initialState = new RobotState(position, initialDirection.Object, penalties);

            var result = command.Apply(initialState, arenaMock.Object);

            initialDirection.Verify(d => d.TurnRight(), Times.Once);

            Assert.That(result.Position, Is.EqualTo(position));
            Assert.That(result.Direction, Is.SameAs(newDirection));
            Assert.That(result.Penalties, Is.EqualTo(penalties));
        }
    }
}