
namespace text_game;

internal class Helpers
{

    public static void DisplayError(string errorMessage)
    {
        DisplayColoured($"\n\t{errorMessage}", ConsoleColor.Red);
    }

    public static void DisplayEnterPrompt()
    {
        DisplayColoured("\n\n\tPress enter...", ConsoleColor.Yellow);
        Console.ReadKey(); Console.Clear();
    }

    public static void DisplayColoured(string text, ConsoleColor colour)
    {
        Console.ForegroundColor = colour;
        Console.Write(text); Console.ResetColor();
    }
}
