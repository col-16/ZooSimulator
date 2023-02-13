using ZooSimulator.Abstractions;
using ZooSimulator.Enums;
using ZooSimulator.Models;

namespace ZooSimulator
{
    /// <summary>
    /// The Zoo class which extends on the IZoo interfece.
    /// </summary>
    public class Zoo : IZoo
    {
        private const int _healthDecayMinPercent = 0;
        private const int _healthDecayMaxPercent = 20;
        private readonly Random _randomGenerator = new Random();

        /// <summary>
        /// The Zoo Feeders to be assigned to Animal groups.
        /// </summary>
        private readonly Dictionary<string, IZooFeeder> _zooFeeders;

        /// <summary>
        /// The Animal pen in which the Zoo animals are added to that are contained wihtin the Zoo.
        /// </summary>
        private readonly IAnimalPen _animalPen;

        /// <summary>
        /// Default Zoo constructor that initialises the Zoo's Animals and Zoo Feeders.
        /// </summary>
        /// <param name="animalPen">An instance of the Zoo's animal pen.</param>
        public Zoo(IAnimalPen animalPen)
        {
            if (animalPen is null)
            {
                throw new ArgumentException("Zoo cannot be created without an AnimalPen.", nameof(animalPen));
            }

            _animalPen = animalPen;

            _zooFeeders = new Dictionary<string, IZooFeeder>()
            {
                { AnimalType.Monkey.ToString(), new ZooFeeder() },
                { AnimalType.Giraffe.ToString(), new ZooFeeder() },
                { AnimalType.Elephant.ToString(), new ZooFeeder() },
            };
        }

        /// <summary>
        /// Initialises the Zoo Pen's Animal collection, assigning Zoo Feeders to each animal group.
        /// </summary>
        /// <param name="animalMultiplier">The number of animals to create for each type.</param>
        public void AddAnimals(int animalMultiplier)
        {
            var animals = new List<IAnimal>();
            var animalCreators = new List<IAnimalCreator>
            {
                new MonkeyCreator(_zooFeeders[AnimalType.Monkey.ToString()]),
                new GiraffeCreator(_zooFeeders[AnimalType.Giraffe.ToString()]),
                new ElephantCreator(_zooFeeders[AnimalType.Elephant.ToString()])
            };

            foreach (var i in Enumerable.Range(1, animalMultiplier))
            {
                foreach (var animalCreator in animalCreators)
                {
                    var animal = animalCreator.FactoryMethod(i);
                    animals.Add(animal);
                }
            }

            _animalPen.AddAnimals(animals?.OrderBy(x => (x as Animal)?.GetName).ToList() ?? new List<IAnimal>());
        }

        /// <summary>
        /// Iterates through and 'feeds' all the Animals within the Zoo's Pen.
        /// </summary>
        /// <param name="simulatedDateTime">The current simulation date/time.</param>
        public void FeedAnimals(DateTime simulatedDateTime)
        {
            var animals = _animalPen.GetAnimals();

            if (animals is null || !animals.Any())
            {
                Console.WriteLine("There are no animals to feed");
                return;
            }

            foreach (var zooFeeder in _zooFeeders)
            {
                zooFeeder.Value.UpdateFeedValue();
            }

            Console.WriteLine($"Simulated DateTime {simulatedDateTime}");
            Console.WriteLine("Please press 'F' to Feed the animals.");
            Console.WriteLine($"Feeding the Elephants {_zooFeeders[AnimalType.Elephant.ToString()].GetCurrentGroupFeedValue}%");
            Console.WriteLine($"Feeding the Giraffes {_zooFeeders[AnimalType.Giraffe.ToString()].GetCurrentGroupFeedValue}%");
            Console.WriteLine($"Feeding the Monkeys {_zooFeeders[AnimalType.Monkey.ToString()].GetCurrentGroupFeedValue}%");

            animals.ForEach(a => a.Feed());

            ListAnimalState(animals);
        }

        /// <summary>
        /// Used to perform a simulation iteration for a given tick.
        /// </summary>
        /// <param name="simulatedDateTime">The current simulation date/time.</param>
        public void ProcessSimulatorTick(DateTime simulatedDateTime)
        {
            var animals = _animalPen.GetAnimals();

            if (animals is null || !animals.Any())
            {
                Console.WriteLine("There are no animals in the zoo");
                return;
            }

            var healthDecayPercent = _randomGenerator.Next(_healthDecayMinPercent, _healthDecayMaxPercent);

            Console.WriteLine($"Simulated DateTime {simulatedDateTime}");
            Console.WriteLine("Please press 'F' to Feed the animals.");
            Console.WriteLine($"Each animal's health has deteriorated by {healthDecayPercent}%");

            animals.ForEach(a => a.Decay(healthDecayPercent, simulatedDateTime));

            ListAnimalState(animals);
        }

        /// <summary>
        /// Outputs the current state of all the Animals within the Zoo's Pen.
        /// </summary>
        public void ListAnimalState()
        {
            var animals = _animalPen.GetAnimals();
            ListAnimalState(animals);
        }

        /// <summary>
        /// Outputs the current state of all the Animals in the list of animals passed in.
        /// </summary>
        /// <param name="animals">The list of animals to print the state of.</param>
        public void ListAnimalState(List<IAnimal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetState());
            }
        }
    }
}
