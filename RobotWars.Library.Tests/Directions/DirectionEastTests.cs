using Moq;
using RobotWars.Library.Directions;

namespace RobotWars.Library.Tests.Directions
{
    public class DirectionEastTests
    {
        private DirectionEast _direction;

        [SetUp]
        public void Setup()
        {
            _direction = new DirectionEast();
        }

        [Test]
        public void Direction_ShouldReturnE()
        {
            char result = _direction.Direction;

            Assert.That(result, Is.EqualTo('E'));
        }

        [Test]
        public void TurnLeft_ShouldReturnDirectionNorth()
        {
            var result = _direction.TurnLeft();

            Assert.That(result, Is.InstanceOf<DirectionNorth>());
        }

        [Test]
        public void TurnRight_ShouldReturnDirectionSouth()
        {
            var result = _direction.TurnRight();

            Assert.That(result, Is.InstanceOf<DirectionSouth>());
        }

        [Test]
        public void CanMoveForward_WhenFinalPositionIsWithinArena_ShouldReturnTrue()
        {
            var position = new Position(2, 3);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(3, 3)).Returns(true);

            var result = _direction.CanMoveForward(position, arenaMock.Object);

            Assert.That(result, Is.True);
            arenaMock.Verify(a => a.IsInside(3, 3), Times.Once);
        }

        [Test]
        public void CanMoveForward_WhenFinalPositionIsOutsideArena_ShouldReturnFalse()
        {
            var position = new Position(2, 3);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(3, 3)).Returns(false);

            var result = _direction.CanMoveForward(position, arenaMock.Object);

            Assert.That(result, Is.False);
            arenaMock.Verify(a => a.IsInside(3, 3), Times.Once);
        }

        [Test]
        public void MoveForward_WhenMovementIsPossible_ShouldReturnNewPositionWithXIncrementedBy1()
        {
            var position = new Position(2, 3);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(3, 3)).Returns(true);

            var result = _direction.MoveForward(position, arenaMock.Object);

            arenaMock.Verify(a => a.IsInside(3, 3), Times.Once);

            Assert.That(result.X, Is.EqualTo(3));
            Assert.That(result.Y, Is.EqualTo(3));
            Assert.That(result, Is.Not.SameAs(position));
        }

        [Test]
        public void MoveForward_WhenMovementIsNotPossible_ShouldThrowInvalidOperationException()
        {
            var position = new Position(2, 3);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(3, 3)).Returns(false);

            var ex = Assert.Throws<InvalidOperationException>(() =>
                _direction.MoveForward(position, arenaMock.Object));
        }
    }
}