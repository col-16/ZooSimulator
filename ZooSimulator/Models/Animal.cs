using ZooSimulator.Abstractions;
using ZooSimulator.Enums;

namespace ZooSimulator.Models
{
    /// <summary>
    /// Base abstract Animal class that extends the IAnimal interface.
    /// </summary>
    public abstract class Animal : IAnimal
    {
        protected const int percentMax = 100;
        protected const int percentMin = 0;
        protected readonly string _name;
        protected readonly IZooFeeder _zooFeeder;
        protected float _healthPercent = 100;
        protected HealthState _healthState;

        /// <summary>
        /// Returns the point at which below the amimal is considered dead (overridable).
        /// </summary>
        public virtual float DeathThreshold { get; }
        
        /// <summary>
        /// Returns the name of the Animal.
        /// </summary>
        public string GetName { get { return _name; } }
        
        /// <summary>
        /// Returns the current state of the animal.
        /// </summary>
        public HealthState GetCurrentState { get { return _healthState; } }
        
        /// <summary>
        /// Returns the current health of the animal as a percentage.
        /// </summary>
        public float GetCurrentHealthPercent { get { return _healthPercent; } }

        /// <summary>
        /// Initialises a new instance of an Animal.
        /// </summary>
        /// <param name="name">The name of the Animal.</param>
        /// <param name="zooFeeder">The Zoo feeder that will be assigned to the animal.</param>
        /// <exception cref="ArgumentException">Thrown when the Animal's name is not specified.</exception>
        protected internal Animal(string name, IZooFeeder zooFeeder)
        {
            if(String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Animal's name cannot be null or empty.", nameof(name));
            }

            _name = name;
            _healthState = HealthState.Alive;
            _zooFeeder = zooFeeder;
        }

        /// <summary>
        /// Feeds the animal according to default rules, resulting in an increase in health (overridable).
        /// </summary>
        public virtual void Feed()
        {
            if (_healthState == HealthState.Dead)
            {
                return;
            }

            _healthPercent = Math.Min(_healthPercent + _zooFeeder.GetCurrentGroupFeedValue, percentMax);
        }

        /// <summary>
        /// 'Decays' the animal's health according to default rules (overridable).
        /// </summary>
        /// <param name="healthDecayPercent">The percentage of which the animal's health will be reduced.</param>
        /// <param name="simulatedDateTime">The current simulator date/time (optional).</param>
        public virtual void Decay(float healthDecayPercent, DateTime simulatedDateTime = default)
        {
            if (_healthState == HealthState.Dead)
            {
                return;
            }

            _healthPercent = Math.Max(_healthPercent - healthDecayPercent, percentMin);

            if (_healthPercent < DeathThreshold)
            {
                _healthState = HealthState.Dead;
                _healthPercent = 0;
            }
        }

        /// <summary>
        /// Gets the current state of the animal.
        /// </summary>
        /// <returns>A string that explains the current health state of the animal.</returns>
        public string GetState()
        {
            switch (_healthState)
            {
                case HealthState.Alive:
                    return $"{_name} is {HealthState.Alive} (health={_healthPercent}%)";
                case HealthState.Immobile:
                    return $"{_name} is {HealthState.Immobile} (health={_healthPercent}%)";
                case HealthState.Dead:
                    return $"{_name} is {HealthState.Dead} (health={_healthPercent}%)";
                default:
                    return $"{_name} is in an unknown state";
            }
        }
    }
}
