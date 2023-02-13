namespace ZooSimulator.Abstractions
{
    /// <summary>
    /// The ZooSimulator class that is responsible for starting and running the simulator.
    /// </summary>
    public interface IZooSimulator
    {
        /// <summary>
        /// A function that effectively opens the Zoo by kicking off the simulator's timer
        /// </summary>
        /// <param name="startDateTime">The start date/time of the simulator.</param>
        public void OpenZoo(DateTime startDateTime);

        /// <summary>
        /// A function that calls to the Zoo to feed the Animals.
        /// </summary>
        public void FeedAnimals();
    }
}
