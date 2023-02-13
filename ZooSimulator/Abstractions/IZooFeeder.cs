namespace ZooSimulator.Abstractions
{
    /// <summary>
    /// The Zoo Feeder interface that represents a Zoo Feeder
    /// </summary>
    public interface IZooFeeder
    {
        /// <summary>
        /// Returns the current 'feed' value.
        /// </summary>
        public int GetCurrentGroupFeedValue { get; }

        /// <summary>
        /// Updates the current 'feed' value.
        /// </summary>
        public void UpdateFeedValue();
    }
}
