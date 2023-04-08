using System.Collections;
using System.Collections.Generic;
using Unit.Enums;
using Unit.Interfaces;
using UnityEngine;

namespace Unit
{
    /// <summary>
    /// Each baseunit has some overrideable variable(s) and function(s).
    /// </summary>
    public abstract class AbstractUnit : MonoBehaviour, IUnit
    {
        public virtual Faction faction { get; set; }
        public virtual string name { get; }
        public virtual int health => 10;
        public virtual int power => 1;
        public virtual int level => 1;
        public virtual bool TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}