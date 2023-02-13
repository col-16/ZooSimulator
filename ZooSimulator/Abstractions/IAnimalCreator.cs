namespace ZooSimulator.Abstractions
{
    /// Base Animal Creator factory interface.
    public interface IAnimalCreator
    {
        /// <summary>
        /// Base abstract factory method.
        /// </summary>
        /// <param name="index">The index of the Animal.</param>
        /// <returns>A new Animal.</returns>
        public abstract IAnimal FactoryMethod(int index);
    }
}
