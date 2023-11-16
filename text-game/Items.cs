namespace text_game;

internal class Weapon
{
    public string Name { get; set; }
    public virtual int AttackDamage { get; set; }
}

internal class MetalPipe : Weapon
{
    public override int AttackDamage { get; set; } = 3;
}

internal class Unequipped : Weapon
{
    public override int AttackDamage { get; set; } = 1;
}

