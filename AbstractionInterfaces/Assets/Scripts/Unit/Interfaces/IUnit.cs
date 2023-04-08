using Unit.Enums;
using UnityEngine;

namespace Unit.Interfaces
{
    /// <summary>
    /// Everything which implements this interface is a unit.
    /// Underwater, at the bare minimum, all units NEED to have the properties
    /// (public variables are properties) which are written in this interface.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// This property determines the faction of the unit.
        /// </summary>
        public Faction faction { get; }
        
        /// <summary>
        /// This property determines the position of the unit.
        /// </summary>
        public Transform transform { get; }
        
        /// <summary>
        /// This property determines name of the unit.
        /// </summary>
        public string name { get; }
        
        /// <summary>
        /// This property determines the health of the unit.
        /// </summary>
        public int health { get; }
        
        /// <summary>
        /// This property determines the power of the unit. (This is a damage modifier)
        /// </summary>
        public int power { get; }
        
        /// <summary>
        /// This property determines the level of the unit. (This is a damage modifier)
        /// </summary>
        public int level { get; }

        /// <summary>
        /// This method will cause a unit to take damage with the damage value represented by an int.
        /// </summary>
        /// <param name="damage">Damage is the value of the damage being done to the receiver</param>
        /// <returns></returns>
        public bool TakeDamage(int damage);
    }
}