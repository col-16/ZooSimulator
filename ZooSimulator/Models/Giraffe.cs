using ZooSimulator.Abstractions;

namespace ZooSimulator.Models
{
    /// <summary>
    /// A Giraffe class that derives from the base Animal class.
    /// </summary>
    public class Giraffe : Animal
    {
        /// <summary>
        /// Returns the point at which below the amimal is considered dead (overridden).
        /// </summary>
        public override float DeathThreshold => 50.0f;

        /// <summary>
        /// Initialises a new instance of a Giraffe.
        /// </summary>
        /// <param name="name">The name of the Animal.</param>
        /// <param name="zooFeeder">The Zoo feeder that will be assigned to the animal.</param>
        public Giraffe(string name, IZooFeeder zooFeeder) : base(name, zooFeeder) {}
    }
}
