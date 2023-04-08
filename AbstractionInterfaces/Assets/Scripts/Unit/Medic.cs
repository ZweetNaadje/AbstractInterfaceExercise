using Unit.Interfaces;
using UnityEngine;

namespace Unit
{
    public class Medic : AbstractUnit, IHealableUnit, IMovable
    {
        public override string name => "Medic";

        public void Heal()
        {
            throw new System.NotImplementedException();
        }

        public void Move(Vector3 moveTowards)
        {
            throw new System.NotImplementedException();
        }
    }
}