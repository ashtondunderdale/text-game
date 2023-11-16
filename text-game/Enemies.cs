namespace text_game;

internal class MutantRat
{
    public string Name = "Mutant Rat";
    public int Health = 3;
    public int AttackDamage = 1;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
        }
    }

    public int Attack()
    {
        return AttackDamage;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}
