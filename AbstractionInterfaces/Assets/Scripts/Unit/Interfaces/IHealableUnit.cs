namespace Unit.Interfaces
{
    /// <summary>
    /// Whatever unit implements this interface, is a unit which can heal other units.
    /// </summary>
    public interface IHealableUnit
    {
        /// <summary>
        /// This method will heal the selected target (ally).
        /// </summary>
        public void Heal();
    }
}