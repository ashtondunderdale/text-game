namespace text_game;

internal class Character
{
    public string name;
    public string role;

    public int health;
    public int attack;
    public int defence;

    public Character(string name, string role, int health, int attack, int defence)
    {
        this.name = name;
        this.role = role;
        this.health = health;
        this.attack = attack;
        this.defence = defence;
    }
}
