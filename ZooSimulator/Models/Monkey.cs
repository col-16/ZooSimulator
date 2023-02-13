using ZooSimulator.Abstractions;

namespace ZooSimulator.Models
{
    /// <summary>
    /// A Monkey class that derives from the base Animal class.
    /// </summary>
    public class Monkey : Animal
    {
        /// <summary>
        /// Returns the point at which below the amimal is considered dead (overridden).
        /// </summary>
        public override float DeathThreshold => 30.0f;

        /// <summary>
        /// Initialises a new instance of a Monkey.
        /// </summary>
        /// <param name="name">The name of the Animal.</param>
        /// <param name="zooFeeder">The Zoo feeder that will be assigned to the animal.</param>
        public Monkey(string name, IZooFeeder zooFeeder) : base(name, zooFeeder) {}
    }
}
