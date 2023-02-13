using ZooSimulator.Abstractions;
using ZooSimulator.Enums;

namespace ZooSimulator.Models
{
    /// <summary>
    /// An Elephant class that derives from the base Animal class.
    /// </summary>
    public class Elephant : Animal
    {
        private DateTime _negativeHealthEventTimestamp;
        private float _walkThreshold = 70.0f;

        /// <summary>
        /// Initialises a new instance of an Elephant.
        /// </summary>
        /// <param name="name">The name of the Animal.</param>
        /// <param name="zooFeeder">The Zoo feeder that will be assigned to the animal.</param>
        public Elephant(string name, IZooFeeder zooFeeder) : base(name, zooFeeder) {}

        /// <summary>
        /// Feeds the Elephant according to specific rules, resulting in an increase in health (overridden).
        /// </summary>
        public override void Feed()
        {
            if (_healthState == HealthState.Dead)
            {
                return;
            }

            _healthPercent = Math.Min(_healthPercent + _zooFeeder.GetCurrentGroupFeedValue, percentMax);

            if (_healthState == HealthState.Immobile && _healthPercent >= _walkThreshold)
            {
                _healthState = HealthState.Alive;
                _negativeHealthEventTimestamp = default;
            }
        }

        /// <summary>
        /// 'Decays' the Elephant's health according to specific rules (overridden).
        /// </summary>
        /// <param name="value"></param>
        /// <param name="simulatedDateTime"></param>
        public override void Decay(float value, DateTime simulatedDateTime)
        {
            var eventDifferenceInHours = (simulatedDateTime - _negativeHealthEventTimestamp).TotalHours;

            if (_healthState == HealthState.Immobile && eventDifferenceInHours >= 1)
            {
                _healthState = HealthState.Dead;
                _healthPercent = 0;
                return;
            }

            if (_healthState == HealthState.Dead)
            {
                return;
            }

            _healthPercent = Math.Max(_healthPercent - value, percentMin);

            if (_healthPercent < _walkThreshold && _healthState != HealthState.Dead)
            {
                _healthState = HealthState.Immobile;
                _negativeHealthEventTimestamp = simulatedDateTime;
            }
        }
    }
}
