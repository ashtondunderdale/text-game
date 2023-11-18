namespace text_game
{
    internal class Weapon
    {
        public string Name { get; set; }
        public Weapon(string name)
        {
            Name = name;
        }

        public virtual int AttackDamage { get; set; }
    }

    internal class MetalPipe : Weapon
    {
        public MetalPipe() : base("Metal Pipe") 
        {
            AttackDamage = 3;
        }
    }

    internal class Unequipped : Weapon
    {
        public Unequipped() : base("Unequipped") 
        {
            AttackDamage = 1;
        }
    }
}
