namespace text_game;

internal class Character
{
    public string name;
    public int health;
    public int level;
    public List<string> inventory;

    public Character(string name, int health, int level, List<string> inventory)
    {
        this.name = name;
        this.health = health;
        this.level = level;
        this.inventory = inventory;
    }
}
