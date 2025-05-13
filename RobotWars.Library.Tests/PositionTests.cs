namespace RobotWars.Library.Tests
{
    public class PositionTests
    {
        [TestCase(1, 2)]
        [TestCase(3, 4)]
        [TestCase(5, 6)]
        [TestCase(7, 8)]
        public void Constructor_WithValidDirectionChar_CreatesPosition(int x, int y)
        {
            Position position = new Position(x, y);

            Assert.That(position, Is.Not.Null);
            Assert.That(position.X, Is.EqualTo(x));
            Assert.That(position.Y, Is.EqualTo(y));
        }
    }
}
