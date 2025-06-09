using RobotWars.Library.Directions;

namespace RobotWars.Library.Tests
{
    public class RobotTests
    {
        private const char _defaultDirection = 'N';

        private Arena _defaultTestArena;
        private Position _defaultTestPosition;
        private IDirectionState _defaultTestDirectionState;

        [SetUp]
        public void Setup()
        {
            _defaultTestArena = new Arena(5, 5);
            _defaultTestPosition = new Position(0, 0);
            _defaultTestDirectionState = DirectionStateFactory.Create(_defaultDirection);
        }

        [Test]
        public void Constructor_WhenPositionOutsideArena_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                new Robot(_defaultTestArena, new Position(-1, 0), _defaultTestDirectionState));
        }

        [TestCase("")]
        [TestCase(' ')]
        [TestCase('*')]
        public void Move_WhenInstructionInvalid_ThrowsArgumentException(char instruction)
        {
            var robot = new Robot(_defaultTestArena, _defaultTestPosition, _defaultTestDirectionState);

            var result= robot.Process(instruction);

            Assert.That(result.x, Is.EqualTo(_defaultTestPosition.X));
            Assert.That(result.y, Is.EqualTo(_defaultTestPosition.Y));
            Assert.That(result.direction, Is.EqualTo(_defaultDirection));
            Assert.That(result.penalties, Is.EqualTo(0));
        }

        [Test]
        public void Move_WhenInstructionValidLowerCase_ShouldPerformActionAndReturnRobotState()
        {
            var robot = new Robot(_defaultTestArena, _defaultTestPosition, _defaultTestDirectionState);

            var instructionLowerCase = 'r';
            var (positionX, positionY, direction, penalties) = robot.Process(instructionLowerCase);

            Assert.That(positionX, Is.EqualTo(_defaultTestPosition.X));
            Assert.That(positionY, Is.EqualTo(_defaultTestPosition.Y));
            Assert.That(direction, Is.EqualTo('E'));
            Assert.That(penalties, Is.EqualTo(0));
        }

        [TestCase('L', 'W')]
        [TestCase('R', 'E')]
        public void Move_WhenInstructionIsTurn_ReturnsSamePositionAndPenaltyButRotated(
            char instructionCode, 
            char expectedDirection)
        {
            var robot = new Robot(_defaultTestArena, _defaultTestPosition, _defaultTestDirectionState);

            var (positionX, positionY, direction, penalties) = robot.Process(instructionCode);

            Assert.That(positionX, Is.EqualTo(_defaultTestPosition.X));
            Assert.That(positionY, Is.EqualTo(_defaultTestPosition.Y));
            Assert.That(direction, Is.EqualTo(expectedDirection));
            Assert.That(penalties, Is.EqualTo(0));
        }

        [TestCase(0, 0, 'N', 0, 1)]
        [TestCase(4, 4, 'S', 4, 3)]
        [TestCase(2, 2, 'W', 1, 2)]
        [TestCase(1, 3, 'E', 2, 3)]
        public void Move_WhenMoveInstructionNotNearBorder_ReturnsExpectedPositionAndZeroPenalties(
            int initialX,
            int initialY,
            char initialDirection,
            int expectedX,
            int expectedY)
        {
            var initialPosition = new Position(initialX, initialY);
            var initialDirectionState = DirectionStateFactory.Create(initialDirection);

            var robot = new Robot(_defaultTestArena, initialPosition, initialDirectionState);

            var (positionX, positionY, direction, penalties) = robot.Process('M');

            Assert.That(positionX, Is.EqualTo(expectedX));
            Assert.That(positionY, Is.EqualTo(expectedY));
            Assert.That(direction, Is.EqualTo(initialDirection));
            Assert.That(penalties, Is.EqualTo(0));
        }

        [TestCase(3, 4, 'N')]
        [TestCase(3, 0, 'S')]
        [TestCase(0, 3, 'W')]
        [TestCase(4, 3, 'E')]
        public void Move_WhenMoveInstructionOnTheBorder_ReturnsSamePositionAndIncreasedPenalties(
            int initialX,
            int initialY,
            char initialDirection)
        {
            var initialPosition = new Position(initialX, initialY);
            var initialDirectionState = DirectionStateFactory.Create(initialDirection);

            var robot = new Robot(_defaultTestArena, initialPosition, initialDirectionState);

            var (positionX, positionY, direction, penalties) = robot.Process('M');

            Assert.That(positionX, Is.EqualTo(initialX));
            Assert.That(positionY, Is.EqualTo(initialY));
            Assert.That(direction, Is.EqualTo(initialDirection));
            Assert.That(penalties, Is.EqualTo(1));
        }

        [TestCase(0, 2, 'E', "MLMRMMMRMMRR", 4, 1, 'N', 0)]
        [TestCase(4, 4, 'S', "LMLLMMLMMMRMM", 0, 1, 'W', 1)]
        [TestCase(2, 2, 'W', "MLMLMLMRMRMRMRM", 2, 2, 'N', 0)]
        [TestCase(1, 3, 'N', "MMLMMLMMMMM", 0, 0, 'S', 3)]
        public void Move_WhenMultipleInstructions_ReturnsExpectedPositionAndPenalties(
            int initialX,
            int initialY,
            char initialDirection,
            string instructions,
            int expectedX,
            int expectedY,
            char expectedDirection,
            int expectedPenalties)
        {
            var initialPosition = new Position(initialX, initialY);
            var initialDirectionState = DirectionStateFactory.Create(initialDirection);

            var robot = new Robot(_defaultTestArena, initialPosition, initialDirectionState);

            int positionX = initialX;
            int positionY = initialY;
            int direction = initialDirection;
            int penalties = 0;

            foreach (var instruction in instructions)
            {
                (positionX, positionY, direction, penalties) = robot.Process(instruction);
            }

            Assert.That(positionX, Is.EqualTo(expectedX));
            Assert.That(positionY, Is.EqualTo(expectedY));
            Assert.That(direction, Is.EqualTo(expectedDirection));
            Assert.That(penalties, Is.EqualTo(expectedPenalties));
        }
    }
}