using Moq;
using NUnit.Framework;
using ZooSimulator.Abstractions;

namespace ZooSimulator.UnitTests
{
    public class ZooSimulatorTests
    {
        ZooSimulator _zooSimulator;
        Mock<IZoo> _mockZoo;


        // A small set of simple tests, demonstrating how we can mock our injected dependencies for the purpose of testing ...


        [SetUp]
        public void SetUpZooSimulatorTest() 
        {
            _mockZoo = new Mock<IZoo>();
            _zooSimulator = new ZooSimulator(_mockZoo.Object);
        }

        [Test]
        public void Should_OpenZoo()
        {
            // Arrange
            var startDateTime = DateTime.Now;

            // Act
            _zooSimulator.OpenZoo(startDateTime);

            // Assert
            _mockZoo.Verify(m => m.ListAnimalState(), Times.Once);
        }

        [Test]
        public void Should_FeedAnimals()
        {
            // Arrange


            // Act
            _zooSimulator.FeedAnimals();

            // Assert
            _mockZoo.Verify(m => m.FeedAnimals(It.IsAny<DateTime>()), Times.Once);
        }
    }
}
