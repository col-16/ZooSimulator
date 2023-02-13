namespace ZooSimulator.Abstractions
{
    /// <summary>
    /// Zoo Interface
    /// </summary>
    public interface IZoo
    {
        /// <summary>
        /// Initialises the Zoo Pen's Animal collection, assigning Zoo Feeders to each animal group.
        /// </summary>
        /// <param name="animalMultiplier">The number of animals to create for each type.</param>
        public void AddAnimals(int animalMultiplier);

        /// <summary>
        /// Iterates through and 'feeds' all the Animals within the Zoo's Pen.
        /// </summary>
        /// <param name="simulatedDateTime">The current simulation date/time.</param>
        public void FeedAnimals(DateTime simulatedDateTime);

        /// <summary>
        /// Used to perform a simulation iteration for a given tick.
        /// </summary>
        /// <param name="simulatedDateTime">The current simulation date/time.</param>
        public void ProcessSimulatorTick(DateTime simulatedDateTime);

        /// <summary>
        /// Outputs the current state of all the Animals within the Zoo's Pen.
        /// </summary>
        public void ListAnimalState();

        /// <summary>
        /// Outputs the current state of all the Animals in the list of animals passed in.
        /// </summary>
        /// <param name="animals">The list of animals to print the state of.</param>
        public void ListAnimalState(List<IAnimal> animals);
    }
}
