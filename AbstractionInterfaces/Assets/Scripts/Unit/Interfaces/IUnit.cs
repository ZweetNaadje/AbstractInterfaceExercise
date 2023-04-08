using Unit.Enums;
using UnityEngine;

namespace Unit.Interfaces
{
    /// <summary>
    /// Everything which implements this interface is a unit.
    /// Underwater, at the bare minimum, all units NEED to have the properties
    /// (public variables are properties) which are written down here.
    /// </summary>
    public interface IUnit
    {
        //How to create factions for easy assigning? ENUMS!
        public Faction faction { get; set; }
        public Transform transform { get; }
        public string name { get; } 
        public int health { get; }
        public int power { get; }
        public int level { get; }

        public bool TakeDamage(int damage);
    }
}