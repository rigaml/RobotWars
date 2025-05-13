using Moq;
using RobotWars.Library.Directions;

namespace RobotWars.Library.Tests.Directions
{
    public class DirectionSouthTests
    {
        private DirectionSouth _direction;

        [SetUp]
        public void Setup()
        {
            _direction = new DirectionSouth();
        }

        [Test]
        public void Direction_ShouldReturnS()
        {
            char result = _direction.Direction;

            Assert.That(result, Is.EqualTo('S'));
        }

        [Test]
        public void TurnLeft_ShouldReturnDirectionEast()
        {
            var result = _direction.TurnLeft();

            Assert.That(result, Is.InstanceOf<DirectionEast>());
        }

        [Test]
        public void TurnRight_ShouldReturnDirectionWest()
        {
            var result = _direction.TurnRight();

            Assert.That(result, Is.InstanceOf<DirectionWest>());
        }

        [Test]
        public void CanMoveForward_WhenFinalPositionIsWithinArena_ShouldReturnTrue()
        {
            var position = new Position(2, 1);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(2, 0)).Returns(true);

            var result = _direction.CanMoveForward(position, arenaMock.Object);

            arenaMock.Verify(a => a.IsInside(2, 0), Times.Once);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanMoveForward_WhenFinalPositionIsOutsideArena_ShouldReturnFalse()
        {
            var position = new Position(2, 0);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(2, -1)).Returns(false);

            var result = _direction.CanMoveForward(position, arenaMock.Object);

            arenaMock.Verify(a => a.IsInside(2, -1), Times.Once);
            Assert.That(result, Is.False);
        }

        [Test]
        public void MoveForward_WhenMovementIsPossible_ShouldReturnNewPositionWithYDecreasedBy1()
        {
            var position = new Position(2, 3);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(2, 2)).Returns(true);

            var result = _direction.MoveForward(position, arenaMock.Object);

            arenaMock.Verify(a => a.IsInside(2, 2), Times.Once);

            Assert.That(result.X, Is.EqualTo(2));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result, Is.Not.SameAs(position));
        }

        [Test]
        public void MoveForward_WhenMovementIsNotPossible_ShouldThrowInvalidOperationException()
        {
            var position = new Position(2, 0);
            var arenaMock = new Mock<IArena>();
            arenaMock.Setup(a => a.IsInside(3, 3)).Returns(false);

            var ex = Assert.Throws<InvalidOperationException>(() =>
                _direction.MoveForward(position, arenaMock.Object));
        }
    }
}