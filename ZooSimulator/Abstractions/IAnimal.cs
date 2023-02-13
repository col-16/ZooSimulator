namespace ZooSimulator.Abstractions
{
    /// <summary>
    /// Animal interface.
    /// </summary>
    public interface IAnimal
    {
        /// <summary>
        /// Feeds the animal according to default rules, resulting in an increase in health (overridable).
        /// </summary>
        public void Feed();

        /// <summary>
        /// 'Decays' the animal's health according to default rules (overridable).
        /// </summary>
        /// <param name="healthDecayPercent">The percentage of which the animal's health will be reduced.</param>
        /// <param name="simulatedDateTime">The current simulator date/time (optional).</param>
        public void Decay(float healthDecayPercent, DateTime simulatedDateTime);

        /// <summary>
        /// Gets the current state of the animal.
        /// </summary>
        /// <returns>A string that explains the current health state of the animal.</returns>
        public string GetState();
    }
}
