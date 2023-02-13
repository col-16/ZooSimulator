using ZooSimulator.Abstractions;

namespace ZooSimulator
{
    /// <summary>
    /// The Zoo Feeder class that represents a Zoo Feeder
    /// </summary>
    public class ZooFeeder : IZooFeeder
    {
        private const int _feedMinPercent = 10;
        private const int _feedMaxPercent = 25;
        private readonly Random _randomGenerator = new Random();
        private int _currentRandomNumber = 0;

        /// <summary>
        /// Returns the current 'feed' value.
        /// </summary>
        public int GetCurrentGroupFeedValue { get { return _currentRandomNumber; } }

        /// <summary>
        /// Constructor that allows an apotional initial 'feed' value to be set.
        /// </summary>
        /// <param name="initalValue">Optional initial feed value.</param>
        public ZooFeeder(int initalValue = default)
        {
            _currentRandomNumber = initalValue;
        }

        /// <summary>
        /// Updates the current 'feed' value.
        /// </summary>
        public void UpdateFeedValue()
        {
             _currentRandomNumber = _randomGenerator.Next(_feedMinPercent, _feedMaxPercent);
        }
    }
}
