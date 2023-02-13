using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using ZooSimulator.Models;

namespace ZooSimulator.UnitTests
{
    public class AnimalTests
    {

        // Only tests the happy-path and is intended as a flavour of how we can test the domain logic ...


        [Test]
        public void UpdateMonkey_Healthy()
        {
            // Arrange
            var name = "John";
            var monkey = new Monkey(name, new ZooFeeder());

            // Act
            monkey.Decay(50);

            // Assert
            using (new AssertionScope())
            {
                var state = monkey.GetState();

                Assert.IsNotNull(state);
                state.Should().Be($"{name} is Alive (health=50%)");
            }
        }

        [Test]
        public void UpdateMonkey_Dead()
        {
            // Arrange
            var name = "Dave";
            var monkey = new Monkey(name, new ZooFeeder());

            // Act
            monkey.Decay(71);

            // Assert
            using (new AssertionScope())
            {
                var state = monkey.GetState();

                Assert.IsNotNull(state);
                state.Should().Be($"{name} is Dead (health=0%)");
            }
        }

        [Test]
        public void UpdateGiraffe_Healthy()
        {
            // Arrange
            var name = "Susan";
            var giraffe = new Giraffe(name, new ZooFeeder());

            // Act
            giraffe.Decay(50);

            // Assert
            using (new AssertionScope())
            {
                var state = giraffe.GetState();

                Assert.IsNotNull(state);
                state.Should().Be($"{name} is Alive (health=50%)");
            }
        }

        [Test]
        public void UpdateGiraffe_Dead()
        {
            // Arrange
            var name = "Mike";
            var giraffe = new Giraffe(name, new ZooFeeder());

            // Act
            giraffe.Decay(51);

            // Assert
            using (new AssertionScope())
            {
                var state = giraffe.GetState();

                Assert.IsNotNull(state);
                state.Should().Be($"{name} is Dead (health=0%)");
            }
        }

        [Test]
        public void UpdateElephant_Healthy()
        {
            // Arrange
            var name = "Nelly";
            var elephant = new Elephant(name, new ZooFeeder());
            var originalDecayEvent = DateTime.Now.AddHours(1);

            // Act
            elephant.Decay(20, originalDecayEvent);

            // Assert
            using (new AssertionScope())
            {
                var state = elephant.GetState();

                Assert.IsNotNull(state);
                state.Should().Be($"{name} is Alive (health=80%)");
            }
        }

        [Test]
        public void UpdateElephant_CannotWalk()
        {
            // Arrange
            var name = "Pete";
            var elephant = new Elephant(name, new ZooFeeder());
            var originalDecayEvent = DateTime.Now.AddHours(1);

            // Act
            elephant.Decay(35, originalDecayEvent);

            // Assert
            using (new AssertionScope())
            {
                var state = elephant.GetState();

                Assert.IsNotNull(state);
                state.Should().Be($"{name} is Immobile (health=65%)");
            }
        }

        [Test]
        public void UpdateElephant_CannotWalkAndIsFedWithinAnHour()
        {
            // Arrange
            var name = "Pete";
            var elephant = new Elephant(name, new ZooFeeder(35));
            var originalDecayEvent = DateTime.Now.AddHours(1);

            // Act
            elephant.Decay(35, originalDecayEvent);
            elephant.Feed();

            // Assert
            using (new AssertionScope())
            {
                var state = elephant.GetState();

                Assert.IsNotNull(state);
                state.Should().Be($"{name} is Alive (health=100%)");
            }
        }

        [Test]
        public void UpdateElephant_CannotWalkAndIsFedOutsideAnHour()
        {
            // Arrange
            var name = "Sandra";
            var elephant = new Elephant(name, new ZooFeeder(60));
            var originalDecayEvent = DateTime.Now.AddHours(1);
            var secondDecayEvent = originalDecayEvent.AddMinutes(61);

            // Act
            elephant.Decay(40, originalDecayEvent);
            elephant.Decay(20, secondDecayEvent);
            elephant.Feed();

            // Assert
            using (new AssertionScope())
            {
                var state = elephant.GetState();

                Assert.IsNotNull(state);
                state.Should().Be($"{name} is Dead (health=0%)");
            }
        }

        [Test]
        public void UpdateElephant_Dead()
        {
            // Arrange
            var name = "Sandra";
            var elephant = new Elephant(name, new ZooFeeder());
            var originalDecayEvent = DateTime.Now.AddHours(1);
            var secondDecayEvent = originalDecayEvent.AddMinutes(61);

            // Act
            elephant.Decay(35, originalDecayEvent);
            elephant.Decay(35, secondDecayEvent);

            // Assert
            using (new AssertionScope())
            {
                var state = elephant.GetState();

                Assert.IsNotNull(state);
                state.Should().Be($"{name} is Dead (health=0%)");
            }
        }
    }
}
