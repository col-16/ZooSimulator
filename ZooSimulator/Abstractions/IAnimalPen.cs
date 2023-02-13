namespace ZooSimulator.Abstractions
{
    /// <summary>
    /// Animal Pen interface
    /// </summary>
    public interface IAnimalPen
    {
        /// <summary>
        /// Adds a list of animals to the existing Animals to the pen.
        /// </summary>
        /// <param name="animals">The list of Animals to be added.</param>
        void AddAnimals(List<IAnimal> animals);

        /// <summary>
        /// Returns the current collection of Animals in the pen
        /// </summary>
        /// <returns>A list of Animals that are currently in the Animal Pen.</returns>
        List<IAnimal> GetAnimals();
    }
}
