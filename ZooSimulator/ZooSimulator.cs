using ZooSimulator.Abstractions;

namespace ZooSimulator
{
    /// <summary>
    /// The ZooSimulator class that is responsible for starting and running the simulator.
    /// </summary>
    public class ZooSimulator: IZooSimulator
    {
        private readonly IZoo _zoo;
        private readonly int _timeIntervalInSeconds;
        private DateTime _simulatedDateTime;

        /// <summary>
        /// Default constructor that sets the simulation interval and associates with a given instance of a Zoo.
        /// </summary>
        /// <param name="zoo">The instance of the Zoo to bind with.</param>
        /// <param name="timeIntervalInSeconds">The interval of the Zoo simulator.</param>
        /// <exception cref="ArgumentException">Thrown if no Zoo instance is specified.</exception>
        public ZooSimulator(IZoo zoo, int timeIntervalInSeconds = 20)
        {
            if (zoo is null)
            {
                throw new ArgumentException("Zoo cannot be null.", nameof(zoo));
            }

            _zoo = zoo;
            _timeIntervalInSeconds = timeIntervalInSeconds;
        }

        /// <summary>
        /// A function that effectively opens the Zoo by kicking off the simulator's timer
        /// </summary>
        /// <param name="startDateTime">The start date/time of the simulator.</param>
        public async void OpenZoo(DateTime startDateTime)
        {
            _simulatedDateTime = startDateTime;

            Console.WriteLine($"Simulated DateTime {_simulatedDateTime}");
            Console.WriteLine("Please press 'F' to Feed the animals.");

            _zoo.ListAnimalState();

            var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(_timeIntervalInSeconds));
            while (await periodicTimer.WaitForNextTickAsync())
            {
                Console.Clear();

                _simulatedDateTime = _simulatedDateTime.AddHours(1);
                _zoo?.ProcessSimulatorTick(_simulatedDateTime);
            }
        }

        /// <summary>
        /// A function that calls to the Zoo to feed the Animals.
        /// </summary>
        public void FeedAnimals()
        {
            _zoo.FeedAnimals(_simulatedDateTime);
        }
    }
}
