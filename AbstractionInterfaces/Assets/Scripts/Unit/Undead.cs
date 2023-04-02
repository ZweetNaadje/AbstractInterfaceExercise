using Unit.Enums;

namespace Unit
{
    public class Undead : Soldier
    {
        public override string name => "Skeleton";
        public override int power => 4;
        public override int level => 3;
    }
}