namespace Unit.Interfaces
{
    /// <summary>
    /// Whatever unit implements this interface, is a unit what can attack other units.
    /// </summary>
    public interface IAttackableUnit
    {
        public float attackRange { get; }
        public float attackRate { get; }
        public float moveSpeed { get; }

        public bool ValidTarget(IUnit target);

        public void SetTarget(IUnit target);
    }
}