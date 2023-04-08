namespace Unit.Interfaces
{
    /// <summary>
    /// Whatever unit implements this interface, is a unit which can heal other units.
    /// </summary>
    public interface IHealableUnit
    {
        public void Heal();
    }
}