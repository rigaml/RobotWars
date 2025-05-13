using Moq;
using RobotWars.Library.Commands;
using RobotWars.Library.Directions;

namespace RobotWars.Library.Tests.Commands
{
    public class RobotStateTests
    {
        [Test]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            var position = new Position(3, 4);
            var direction = new DirectionNorth();
            var penalties = 2;

            var robotState = new RobotState(position, direction, penalties);

            Assert.That(robotState.Position, Is.SameAs(position));
            Assert.That(robotState.Direction, Is.SameAs(direction));
            Assert.That(robotState.Penalties, Is.EqualTo(penalties));
        }


        [Test]
        public void GetState_ReturnsCorrectTuple()
        {
            var x = 3;
            var y = 4;
            var position = new Position(x, y);
            var directionChar = 'E';
            var directionMock = Mock.Of<IDirectionState>(d => d.Direction == directionChar);
            var penalties = 2;

            var robotState = new RobotState(position, directionMock, penalties);

            var stateTuple = robotState.GetState();

            Assert.That(stateTuple.x, Is.EqualTo(x));
            Assert.That(stateTuple.y, Is.EqualTo(y));
            Assert.That(stateTuple.direction, Is.EqualTo(directionChar));
            Assert.That(stateTuple.penalties, Is.EqualTo(penalties));
        }
    }
}