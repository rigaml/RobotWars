using RobotWars.Library.Directions;

namespace RobotWars.Library.Tests.Directions
{
    public class DirectionStateFactoryTests
    {
        [TestCase("N")]
        [TestCase("n")]
        public void Create_WithDirectionN_ReturnsDirectionNorth(char directionChar)
        {
            var direction = DirectionStateFactory.Create(directionChar);

            Assert.That(direction, Is.InstanceOf<DirectionNorth>());
        }

        [TestCase("S")]
        [TestCase("s")]
        public void Create_WithDirectionS_ReturnsDirectionSouth(char directionChar)
        {
            var direction = DirectionStateFactory.Create(directionChar);

            Assert.That(direction, Is.InstanceOf<DirectionSouth>());
        }

        [TestCase("E")]
        [TestCase("e")]
        public void Create_WithDirectionE_ReturnsDirectionEast(char directionChar)
        {
            var direction = DirectionStateFactory.Create(directionChar);

            Assert.That(direction, Is.InstanceOf<DirectionEast>());
        }


        [TestCase("W")]
        [TestCase("w")]
        public void Create_WithDirectionW_ReturnsDirectionWest(char directionChar)
        {
            var direction = DirectionStateFactory.Create(directionChar);

            Assert.That(direction, Is.InstanceOf<DirectionWest>());
        }

        [Test]
        public void Create_WithInvalidDirection_ThrowsNotSupportedException()
        {
            var invalidDirection = 'X';

            var ex = Assert.Throws<NotImplementedException>(() => DirectionStateFactory.Create(invalidDirection));
        }
    }
}