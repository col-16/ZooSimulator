using ZooSimulator.Abstractions;

namespace ZooSimulator.Models
{
    /// <summary>
    /// An Animal Pen which contanins Animals
    /// </summary>
    public class AnimalPen : IAnimalPen
    {
        /// <summary>
        /// The Animals that are contained wihtin the Animal Pen.
        /// </summary>
        private readonly List<IAnimal> _animals;

        /// <summary>
        /// Default AnimalPen constructor.
        /// </summary>
        public AnimalPen()
        {
            _animals = new List<IAnimal>();
        }

        /// <summary>
        /// Adds a list of animals to the existing Animals to the pen.
        /// </summary>
        /// <param name="animals">The list of Animals to be added.</param>
        public void AddAnimals(List<IAnimal> animals)
        {
            _animals.AddRange(animals);
        }

        /// <summary>
        /// Returns the current collection of Animals in the pen
        /// </summary>
        /// <returns>A list of Animals that are currently in the Animal Pen.</returns>
        public List<IAnimal> GetAnimals()
        {
            return _animals;
        }
    }
}
