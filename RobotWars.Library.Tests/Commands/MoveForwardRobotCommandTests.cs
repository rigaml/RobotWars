using Moq;
using RobotWars.Library.Commands;
using RobotWars.Library.Directions;

namespace RobotWars.Library.Tests.Commands
{
    public class MoveForwardRobotCommandTests
    {
        private MoveForwardRobotCommand _command;
        private Mock<IArena> _arenaMock;

        [SetUp]
        public void Setup()
        {
            _command = new MoveForwardRobotCommand();
            _arenaMock = new Mock<IArena>();
        }

        [Test]
        public void Apply_WhenMovementIsPossible_ShouldMoveRobotForward()
        {
            var initialPosition = new Position(2, 3);
            var newPosition = new Position(2, 4);
            var direction = Mock.Of<IDirectionState>();
            var penalties = 0;

            var initialState = new RobotState(initialPosition, direction, penalties);

            Mock.Get(direction)
                .Setup(d => d.CanMoveForward(initialPosition, _arenaMock.Object))
                .Returns(true);

            Mock.Get(direction)
                .Setup(d => d.MoveForward(initialPosition, _arenaMock.Object))
                .Returns(newPosition);

            var result = _command.Apply(initialState, _arenaMock.Object);

            Assert.That(result.Position, Is.EqualTo(newPosition));
            Assert.That(result.Direction, Is.SameAs(direction));
            Assert.That(result.Penalties, Is.EqualTo(penalties));

            Mock.Get(direction).Verify(d => d.CanMoveForward(initialPosition, _arenaMock.Object), Times.Once);
            Mock.Get(direction).Verify(d => d.MoveForward(initialPosition, _arenaMock.Object), Times.Once);
        }

        [Test]
        public void Apply_WhenMovementIsNotPossible_ShouldIncreasePenalty()
        {
            var position = new Position(2, 3);
            var direction = Mock.Of<IDirectionState>();
            var initialPenalties = 1;

            var initialState = new RobotState(position, direction, initialPenalties);

            Mock.Get(direction)
                .Setup(d => d.CanMoveForward(position, _arenaMock.Object))
                .Returns(false);

            var result = _command.Apply(initialState, _arenaMock.Object);

            Assert.That(result.Position, Is.EqualTo(position));
            Assert.That(result.Direction, Is.SameAs(direction));
            Assert.That(result.Penalties, Is.EqualTo(initialPenalties + 1));

            Mock.Get(direction).Verify(d => d.CanMoveForward(position, _arenaMock.Object), Times.Once);
            Mock.Get(direction).Verify(d => d.MoveForward(It.IsAny<Position>(), It.IsAny<IArena>()), Times.Never);
        }
    }
}