namespace Unit.Interfaces
{
    public interface IAttackableUnit
    {
        public float attackRange { get; }
        public float attackRate { get; }
        public float moveSpeed { get; }

        public bool CanAttack();

        public int Attack();
    }
}