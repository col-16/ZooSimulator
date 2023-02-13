using ZooSimulator.Models;

namespace ZooSimulator
{
    public static class Program
    {
        /// <summary>
        /// Our main entry point ...
        /// </summary>
        /// <param name="args">command line arguments.</param>
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Zoo Simulator.");
            Console.WriteLine("Please press 'O' to Open the Zoo and 'F' to Feed the animals.");

            try
            {
                var animalPen = new AnimalPen();
                var zoo = new Zoo(animalPen);
                var animalMultiplier = 5;
                zoo.AddAnimals(animalMultiplier);

                var zooSimulator = new ZooSimulator(zoo, 3);
                
                ConsoleKeyInfo keyinfo;
                
                do
                {
                    keyinfo = Console.ReadKey(true);
                    if (keyinfo.Key == ConsoleKey.O)
                    {
                        Console.Clear();
                        zooSimulator.OpenZoo(DateTime.Now);
                    }
                    if (keyinfo.Key == ConsoleKey.F)
                    {
                        Console.Clear();
                        zooSimulator.FeedAnimals();
                    }
                }
                while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}