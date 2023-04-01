using Unit.Interfaces;

namespace Unit
{
    public class Soldier : BaseUnit, IAttackableUnit
    {
        public override string name => "Soldier";
        public float attackRange { get; }
        public float attackRate { get; }
        public float moveSpeed { get; }

        public bool CanAttack()
        {
            throw new System.NotImplementedException();
        }

        public int Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}