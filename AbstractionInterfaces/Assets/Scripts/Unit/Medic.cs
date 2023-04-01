using Unit.Interfaces;

namespace Unit
{
    public class Medic : BaseUnit, IHealableUnit
    {
        public override string name => "Medic";

        public void Heal()
        {
            throw new System.NotImplementedException();
        }
    }
}