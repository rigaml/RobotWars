namespace RobotWars.Library.Tests
{
    public class ArenaTests
    {
        private const int DefaultTestWidth = 10;
        private const int DefaultTestHeight = 20;

        private Arena _defaultTestArena;

        [SetUp]
        public void Setup()
        {
            // Create a fresh Arena instance for each test method
            _defaultTestArena = new Arena(DefaultTestWidth, DefaultTestHeight);
        }

        [TestCase(-1, 1, "width")]
        [TestCase(0, 1, "width")]
        [TestCase(1, 0, "height")]
        [TestCase(1, -1, "height")]
        public void Constructor_WhenValuesNotGreaterThanZero_ThrowsArgumentOutOfRangeException(int width, int height, string expectedParameter)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Arena(width, height));

            Assert.That(ex.ParamName, Is.EqualTo(expectedParameter));
        }

        public void Constructor_WhenValuesGreaterThanZero_CreatesArena()
        {
            int width = 10;
            int height = 20;

            Arena arena = new Arena(width, height);

            Assert.That(arena, Is.Not.Null);
            Assert.That(arena.Width, Is.EqualTo(width));
            Assert.That(arena.Height, Is.EqualTo(height));
        }

        [TestCase(0, 0, true)]
        [TestCase(DefaultTestWidth - 1, DefaultTestHeight - 1, true)]
        [TestCase(DefaultTestWidth / 2, DefaultTestHeight / 2, true)]
        [TestCase(-1, DefaultTestHeight - 1, false)]
        [TestCase(DefaultTestWidth - 1, -1, false)]
        public void IsInside_WhenCoordinates_ReturnsExpectedValue(int x, int y, bool expectedValue)
        {
            bool result = _defaultTestArena.IsInside(x, y);

            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}
