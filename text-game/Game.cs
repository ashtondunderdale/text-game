namespace text_game;

internal class Game
{
    public static int x = 0;
    public static int y = 0;

    private static int locationMaxY = 2;
    private static int locationMinY = -2;
    private static int locationMaxX = 2;
    private static int locationMinX = -2;

    private static string location = "wasteland";

    public static void PlayGame(Character character)
    {
        bool playingGame = true;

        while (playingGame)
        {
            Console.Clear();
            DisplayPlayerInformation();            
        }
    }

    public static void DisplayPlayerInformation()
    {
        Console.Write($"Name:");
        Helpers.ColouredText($" {Program.character.Name}", ConsoleColor.Green);

        Console.Write($"\nLevel:");
        Helpers.ColouredText($" {Program.character.Level}", ConsoleColor.Green);

        Console.Write($"\nHealth:");
        Helpers.ColouredText($" {Program.character.Health}", ConsoleColor.Red);

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

    public static bool ValidateCommand(string input)
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
        else if (input == "i") 
        {
            DisplayInventory();
        }
        return true;
    }

    static void DisplayInventory() 
    {
        int itemIndex = 1;
        if (Program.character.Inventory.Count != 0)
        {
            foreach (var item in Program.character.Inventory) 
            {
                Console.WriteLine("\n\nInventory\n_________________");
                Console.WriteLine($"{itemIndex} | {item}");
            }
        }
        else 
        {
            Helpers.ColouredText("\nYour inventory is empty", ConsoleColor.Yellow);
        }
        Helpers.DisplayEnterPrompt();
    }
}
