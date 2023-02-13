using Moq;
using NUnit.Framework;
using ZooSimulator.Abstractions;

namespace ZooSimulator.UnitTests
{
    public class ZooTests
    {
        Zoo _zoo;
        Mock<IAnimal> _mockAnimal;
        Mock<IAnimalPen> _mockAnimalPen;


        // A small set of simple tests, demonstrating how we can mock our injected dependencies for the purpose of testing ...


        [SetUp]
        public void SetUpZooTest()
        {
            _mockAnimal= new Mock<IAnimal>();
            _mockAnimalPen = new Mock<IAnimalPen>();
            _zoo = new Zoo(_mockAnimalPen.Object);
        }

        [Test]
        public void Should_AddAnimalsToZooPen()
        {
            // Arrange
            int numberOfAnimals = 1;

            // Act
            _zoo.AddAnimals(numberOfAnimals);

            // Assert
            _mockAnimalPen.Verify(m => m.AddAnimals(It.IsAny<List<IAnimal>>()), Times.Once);
        }

        [Test]
        public void Should_FeedAnimalsToZooPen()
        {
            // Arrange
            var startDateTime = DateTime.Now;
            _mockAnimalPen.Setup(ap => ap.GetAnimals()).Returns(new List<IAnimal> { _mockAnimal.Object });

            // Act
            _zoo.FeedAnimals(startDateTime);

            // Assert
            _mockAnimal.Verify(a => a.Feed(), Times.Once);
        }
    }
}
