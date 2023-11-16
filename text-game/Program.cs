namespace text_game;

internal class Program
{
    private static Character character;
    private static int x = 0;
    private static int y = 0;
    static void Main() => Starter();

    static void Starter()
    {
        GetName();
        //DisplayIntro();
        Tutorial();

        Game();
    }

    static void GetName()
    {
        while (true)
        {
            Console.WriteLine("What will you be called?");
            string? name = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                Helpers.DisplayError("Your name must contain characters.");
                Helpers.DisplayEnterPrompt();

                continue;
            }

            name = name.Trim();
            Console.Write($"\n\tYour name: ");
            Helpers.ColouredText($"{name}", ConsoleColor.Green);
            Helpers.DisplayEnterPrompt();

            character = new Character(name, 10);
            break;
        }
    }

    static void DisplayIntro()
    {
        Console.Clear();
        Thread.Sleep(2000);

        string[] introLines =
        {
        "The year is 27707.",
        "\nYou woke up a few seconds ago.",
        "\nYou can't remember much.",
        "\n\nYou seem to be in a laboratory..."
        };

        int[] sleepDurations = { 100, 50, 80, 50 };

        for (int i = 0; i < introLines.Length; i++)
        {
            Helpers.TypeColouredText(introLines[i], ConsoleColor.White, sleepDurations[i]);
            Thread.Sleep(i == introLines.Length - 1 ? 0 : 1500);
        }
    }

    static void Tutorial()
    {
        while (true)
        {
            DisplayPlayerInformation();

            Helpers.ColouredText("\n\nYou decide to look around the room.", ConsoleColor.White);
            Helpers.ColouredText("\n\nTry typing \'u\' to move up by 1 on \'y\'\n", ConsoleColor.White);

            string? input = Console.ReadLine();

            if (input != "u")
            {
                Helpers.DisplayError("Please enter \'u\'.");
                Helpers.DisplayEnterPrompt();

                continue;
            }
            UpdateCoordinate(input);
            break;
        }



        while (true)
        {
            DisplayPlayerInformation();
            Console.WriteLine("\n\nThis means you switched the tile your character is currently on.\nYou will encounter various things on each tile.\n\n");

            Console.WriteLine("Try moving to another tile:\n" +
                "\n\t'u' (up)     = y + 1" +
                "\n\t'd' (down)   = y - 1" +
                "\n\t'l' (left)   = x - 1" +
                "\n\t'r' (right)  = x + 1");

            string? input = Console.ReadLine();

            if (input != "u" && input != "d" && input != "l" && input != "r")
            {
                Helpers.DisplayError("Please enter a valid coordinate character.");
                Helpers.DisplayEnterPrompt();

                continue;
            }
            UpdateCoordinate(input);
            break;
        }

        DisplayPlayerInformation();
        Console.WriteLine("\n\nHere you can see your location has updated again.\nTry exploring the rest of the laboratory.");
        Helpers.DisplayEnterPrompt();
    }
    static void DisplayPlayerInformation()
    {
        Console.Write($"Name:");
        Helpers.ColouredText($" {character.name}", ConsoleColor.Green);

        Console.Write($"\nHealth:");
        Helpers.ColouredText($" {character.health}", ConsoleColor.Red);

        Console.WriteLine($"\n\nCurrent Location: x {x}, y {y}\n__________________________");
    }

    static void UpdateCoordinate(string coordinate)
    {
        switch (coordinate)
        {
            case "u":
                y += 1;
                Helpers.ColouredText($"\nYou moved from y {y - 1} to y {y}", ConsoleColor.Yellow);
                break;

            case "d":
                y -= 1;
                Helpers.ColouredText($"\nYou moved from y {y + 1} to y {y}", ConsoleColor.Yellow);
                break;

            case "l":
                x -= 1;
                Helpers.ColouredText($"\nYou moved from x {x + 1} to x {x}", ConsoleColor.Yellow);
                break;

            case "r":
                x += 1;
                Helpers.ColouredText($"\nYou moved from x {x - 1} to x {x}", ConsoleColor.Yellow);
                break;
        }
        Helpers.DisplayEnterPrompt();
    }

    static void Game()
    {

    }
}