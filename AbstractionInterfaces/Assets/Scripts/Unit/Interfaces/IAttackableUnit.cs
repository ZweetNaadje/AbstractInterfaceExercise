namespace Unit.Interfaces
{
    /// <summary>
    /// Whatever unit implements this interface, is a unit what can attack other units.
    /// </summary>
    public interface IAttackableUnit
    {
        /// <summary>
        /// This property determines the attack range of the unit.
        /// </summary>
        public float attackRange { get; }
        
        /// <summary>
        /// This property determines the attack rate of the unit
        /// </summary>
        public float attackRate { get; }
        
        /// <summary>
        /// This property determines the movement speed of the unit.
        /// </summary>
        public float moveSpeed { get; }

        /// <summary>
        /// This method will check whether you selected a valid target.
        /// </summary>
        /// <param name="target">Target is the selected target by the player</param>
        /// <returns></returns>
        public bool ValidTarget(IUnit target);

        /// <summary>
        /// This method will set a new target for the AI.
        /// </summary>
        /// <param name="target">Target is the selected target by the player</param>
        public void SetTarget(IUnit target);
    }
}