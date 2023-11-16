using text_game;

internal class Program
{
    public static Character character;

    static void Main()
    {
        Tutorial.PlayTutorial();
        Game.PlayGame(character);
    }
}
