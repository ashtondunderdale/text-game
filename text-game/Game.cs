namespace text_game;

internal class Game
{
    public static int x = 0;
    public static int y = 0;

    private static int locationMaxY = 2;
    private static int locationMinY = -2;
    private static int locationMaxX = 2;
    private static int locationMinX = -2;

    private static string location = "laboratory";

    public static void PlayGame(Character character)
    {
        bool playingGame = true;

        while (playingGame) 
        { 
        
        }
    }

    public static void DisplayPlayerInformation()
    {
        Console.Write($"Name:");
        Helpers.ColouredText($" {Program.character.name}", ConsoleColor.Green);

        Console.Write($"\nHealth:");
        Helpers.ColouredText($" {Program.character.health}", ConsoleColor.Red);

        Console.Write($"\n\nLocation: {location}\n");

        Console.WriteLine($"Coordinates: x {x}, y {y}\n__________________________");
    }

    public static void UpdateCoordinate(string coordinate)
    {
        switch (coordinate)
        {
            case "w":
                y += 1;
                Helpers.ColouredText($"\nYou moved from y {y - 1} to y {y}", ConsoleColor.Yellow);
                break;

            case "s":
                y -= 1;
                Helpers.ColouredText($"\nYou moved from y {y + 1} to y {y}", ConsoleColor.Yellow);
                break;

            case "a":
                x -= 1;
                Helpers.ColouredText($"\nYou moved from x {x + 1} to x {x}", ConsoleColor.Yellow);
                break;

            case "d":
                x += 1;
                Helpers.ColouredText($"\nYou moved from x {x - 1} to x {x}", ConsoleColor.Yellow);
                break;
        }
        Helpers.DisplayEnterPrompt();
    }

    public static bool ValidateCoordinate(string input)
    {
        if (input == "w")
        {
            if (y + 1 > locationMaxY)
            {
                Helpers.DisplayError($"Cannot move that way. Out of bounds for {location}");
                Helpers.DisplayEnterPrompt();
                return false;
            }
        }
        else if (input == "s")
        {
            if (y - 1 < locationMinY)
            {
                Helpers.DisplayError($"Cannot move that way. Out of bounds for {location}");
                Helpers.DisplayEnterPrompt();
                return false;
            }
        }
        else if (input == "a")
        {
            if (x - 1 < locationMinX)
            {
                Helpers.DisplayError($"Cannot move that way. Out of bounds for {location}");
                Helpers.DisplayEnterPrompt();
                return false;
            }
        }
        else if (input == "d")
        {
            if (x + 1 > locationMaxX)
            {
                Helpers.DisplayError($"Cannot move that way. Out of bounds for {location}");
                Helpers.DisplayEnterPrompt();
                return false;
            }
        }
        return true;
    }
}
