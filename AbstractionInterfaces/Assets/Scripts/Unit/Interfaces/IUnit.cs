namespace Unit.Interfaces
{
    public interface IUnit
    {
        public string name { get; } 
        public int health { get; }
        public int power { get; }
        public int level { get; }
    }
}