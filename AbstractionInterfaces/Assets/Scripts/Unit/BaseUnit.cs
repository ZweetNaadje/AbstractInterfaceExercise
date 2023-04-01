using System.Collections;
using System.Collections.Generic;
using Unit.Interfaces;
using UnityEngine;

namespace Unit
{
    public abstract class BaseUnit : MonoBehaviour, IUnit
    {
        public virtual string name { get; }
        public virtual int health => 10;
        public virtual int power => 1;
        public virtual int level => 1;
    }
}