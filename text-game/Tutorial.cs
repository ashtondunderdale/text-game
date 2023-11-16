namespace text_game;

internal class Tutorial
{
    private static Character character;
    private static int x = 0;
    private static int y = 0;
    private static string location = "laboratory";

    private static int locationMaxY = 2;
    private static int locationMinY = -2;
    private static int locationMaxX = 2;
    private static int locationMinX = -2;


    static void Main() => Starter();

    static void Starter()
    {
        GetName();
        DisplayIntro();
        PlayTutorial();

        Game.PlayGame();
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
        Thread.Sleep(1000);
        Helpers.DisplayEnterPrompt();
    }

    static void PlayTutorial()
    {
        while (true)
        {
            DisplayPlayerInformation();

            Helpers.ColouredText("\n\nYou decide to look around the laboratory.", ConsoleColor.Yellow);
            Helpers.ColouredText("\n\nTry typing \'w\' to move up by 1 on \'y\'\n", ConsoleColor.White);

            string? input = Console.ReadLine();

            if (input != "w")
            {
                Helpers.DisplayError("Please enter \'w\'.");
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
                "\n\t'w' (up)     = y + 1" +
                "\n\t'a' (left)   = x - 1" +
                "\n\t's' (down)   = y - 1" +
                "\n\t'd' (right)  = x + 1");

            string? input = Console.ReadLine();

            if (input != "w" && input != "a" && input != "s" && input != "d")
            {
                Helpers.DisplayError("Please enter a valid coordinate character.");
                Helpers.DisplayEnterPrompt();

                continue;
            }
            UpdateCoordinate(input);
            break;
        }

        DisplayPlayerInformation();
        Console.Write("\n\nHere you can see your location has updated again.\nTry exploring the rest of the laboratory.");
        Helpers.DisplayEnterPrompt();

        bool tutorialMode = true;

        while (tutorialMode) 
        {
            DisplayPlayerInformation();

            string? input = Console.ReadLine();

            if (input != "w" && input != "a" && input != "s" && input != "d")
            {
                Helpers.DisplayError("Please enter a valid coordinate character.");
                Helpers.DisplayEnterPrompt();

                continue;
            }

            if (ValidateCoordinate(input))
            {
                UpdateCoordinate(input);
            };

            if (x == 0 && y == 0)
            {
                DisplayPlayerInformation();

                Helpers.ColouredText("\n\nYou are back where you woke up.", ConsoleColor.Yellow);
                Helpers.DisplayEnterPrompt();
            }

            if (x == 2 && y == 2) 
            {
                while (true)
                {
                    DisplayPlayerInformation();

                    Helpers.ColouredText("\n\nYou have found an exit.\nDo you leave the laboratory? ( y / n )", ConsoleColor.Green);
                    input = Console.ReadLine();

                    if (input == "y") 
                    {
                        tutorialMode = false;
                        break;
                    }
                    else if (input == "n")
                    {
                        Helpers.ColouredText("\nYou stay in the laboratory.", ConsoleColor.Yellow);
                        Helpers.DisplayEnterPrompt();
                        break;
                    }
                    else
                    {
                        Helpers.DisplayError("Enter a valid option ( y / n )");
                        Helpers.DisplayEnterPrompt();
                    }
                }
            }
        }
    }

    static void DisplayPlayerInformation()
    {
        Console.Write($"Name:");
        Helpers.ColouredText($" {character.name}", ConsoleColor.Green);

        Console.Write($"\nHealth:");
        Helpers.ColouredText($" {character.health}", ConsoleColor.Red);

        Console.Write($"\n\nLocation: {location}\n");

        Console.WriteLine($"Coordinates: x {x}, y {y}\n__________________________");
    }

    static void UpdateCoordinate(string coordinate)
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

    static bool ValidateCoordinate(string input) 
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