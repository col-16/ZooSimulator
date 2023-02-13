using ZooSimulator.Abstractions;
using ZooSimulator.Enums;
using ZooSimulator.Models;

namespace ZooSimulator
{
    /// <summary>
    /// Base abstract Animal Creator factory class.
    /// </summary>
    public abstract class AnimalCreator : IAnimalCreator
    {
        protected IZooFeeder _zooFeeder;

        /// <summary>
        /// Base factory constructor.
        /// </summary>
        /// <param name="zooFeeder">An instance of a Zoo Feeder that will be assigned to the Animal.</param>
        protected AnimalCreator(IZooFeeder zooFeeder)
        {
            _zooFeeder = zooFeeder;
        }

        /// <summary>
        /// Base abstract factory method to be overridden by concrete factory.
        /// </summary>
        /// <param name="index">The index of the Animal.</param>
        /// <returns>A new Animal</returns>
        public abstract IAnimal FactoryMethod(int index);
    }

    /// <summary>
    /// Concrete factory for creating and initialising a new Monkey.
    /// </summary>
    public class MonkeyCreator : AnimalCreator
    {
        /// <summary>
        /// Monkey factory constructor.
        /// </summary>
        /// <param name="zooFeeder">An instance of a Zoo Feeder that will be assigned to the Monkey.</param>
        public MonkeyCreator(IZooFeeder zooFeeder) : base(zooFeeder) {}

        /// <summary>
        /// Monkey factory method that creates a new Monkey.
        /// </summary>
        /// <param name="index">The index of the specific Monkey.</param>
        /// <returns>A new Monkey</returns>
        public override IAnimal FactoryMethod(int index)
        {
            return new Monkey($"{AnimalType.Monkey}-{index}", _zooFeeder);
        }
    }

    /// <summary>
    /// Concrete factory for creating and initialising a new Giraffe.
    /// </summary>
    public class GiraffeCreator : AnimalCreator
    {
        /// <summary>
        /// Giraffe factory constructor.
        /// </summary>
        /// <param name="zooFeeder">An instance of a Zoo Feeder that will be assigned to the Giraffe.</param>
        public GiraffeCreator(IZooFeeder zooFeeder) : base(zooFeeder) {}

        /// <summary>
        /// Giraffe factory method that creates a new Giraffe.
        /// </summary>
        /// <param name="index">The index of the specific Giraffe.</param>
        /// <returns>A new Giraffe</returns>
        public override IAnimal FactoryMethod(int index)
        {
            return new Giraffe($"{AnimalType.Giraffe}-{index}", _zooFeeder);
        }
    }

    /// <summary>
    /// Concrete factory for creating and initialising a new Elephant.
    /// </summary>
    public class ElephantCreator : AnimalCreator
    {
        /// <summary>
        /// Elephant factory constructor.
        /// </summary>
        /// <param name="zooFeeder">An instance of a Zoo Feeder that will be assigned to the Elephant.</param>
        public ElephantCreator(IZooFeeder zooFeeder) : base(zooFeeder) {}

        /// <summary>
        /// Elephant factory method that creates a new Elephant.
        /// </summary>
        /// <param name="index">The index of the specific Elephant.</param>
        /// <returns>A new Elephant</returns>
        public override IAnimal FactoryMethod(int index)
        {
            return new Elephant($"{AnimalType.Elephant}-{index}", _zooFeeder);
        }
    }
}
