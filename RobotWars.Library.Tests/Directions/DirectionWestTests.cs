using Moq;
using RobotWars.Library.Directions;

namespace RobotWars.Library.Tests.Directions
{
    public class DirectionWestTests
    {
        private DirectionWest _direction;

        [SetUp]
        public void Setup()
        {
            _direction = new DirectionWest();
        }

        [Test]
        public void Direction_ShouldReturnW()
        {
            char result = _direction.Direction;

            Assert.That(result, Is.EqualTo('W'));
        }

        [Test]
        public void TurnLeft_ShouldReturnDirectionSouth()
        {
            var result = _direction.TurnLeft();

            Assert.That(result, Is.InstanceOf<DirectionSouth>());
        }

        [Test]
        public void TurnRight_ShouldReturnDirectionNorth()
        {
            var result = _direction.TurnRight();

            Assert.That(result, Is.InstanceOf<DirectionNorth>());
        }

        [Test]
        public void CanMoveForward_WhenFinalPositionIsWithinArena_ShouldReturnTrue()
        {
            var position = new Position(1, 3);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(0, 3)).Returns(true);

            var result = _direction.CanMoveForward(position, arenaMock.Object);

            arenaMock.Verify(a => a.IsInside(0, 3), Times.Once);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanMoveForward_WhenFinalPositionIsOutsideArena_ShouldReturnFalse()
        {
            var position = new Position(0, 3);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(-1, 3)).Returns(false);

            var result = _direction.CanMoveForward(position, arenaMock.Object);

            arenaMock.Verify(a => a.IsInside(-1, 3), Times.Once);
            Assert.That(result, Is.False);
        }

        [Test]
        public void MoveForward_WhenMovementIsPossible_ShouldReturnNewPositionWithXDecrementedBy1()
        {
            var position = new Position(1, 3);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(0, 3)).Returns(true);

            var result = _direction.MoveForward(position, arenaMock.Object);

            arenaMock.Verify(a => a.IsInside(0, 3), Times.Once);

            Assert.That(result.X, Is.EqualTo(0));
            Assert.That(result.Y, Is.EqualTo(3));
            Assert.That(result, Is.Not.SameAs(position));
        }

        [Test]
        public void MoveForward_WhenMovementIsNotPossible_ShouldThrowInvalidOperationException()
        {
            var position = new Position(0, 3);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(3, 3)).Returns(false);

            var ex = Assert.Throws<InvalidOperationException>(() =>
                _direction.MoveForward(position, arenaMock.Object));
        }
    }
}