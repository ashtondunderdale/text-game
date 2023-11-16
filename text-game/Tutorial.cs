namespace text_game;

internal class Tutorial
{
    public static void PlayTutorial() 
    {
        CreateCharacter();
        DisplayIntro();
        StartLaboratoryTutorial();
    }

    static void CreateCharacter()
    {
        List<string> inventory = new();    

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

            Program.character = new Character(name, 10, 1, inventory);
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

    public static void StartLaboratoryTutorial()
    {
        while (true)
        {
            Game.DisplayPlayerInformation();

            Helpers.ColouredText("\n\nYou decide to look around the laboratory.", ConsoleColor.Yellow);
            Helpers.ColouredText("\n\nTry typing \'w\' to move up by 1 on \'y\'\n", ConsoleColor.White);

            string? input = Console.ReadLine();

            if (input != "w")
            {
                Helpers.DisplayError("Please enter \'w\'.");
                Helpers.DisplayEnterPrompt();

                continue;
            }
            Game.UpdateCoordinate(input);
            break;
        }

        while (true)
        {
            Game.DisplayPlayerInformation();
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
            Game.UpdateCoordinate(input);
            break;
        }

        Game.DisplayPlayerInformation();
        Console.Write("\n\nHere you can see your location has updated again.\nTry exploring the rest of the laboratory.");
        Helpers.DisplayEnterPrompt();

        bool tutorialMode = true;

        while (tutorialMode) 
        {
            Game.DisplayPlayerInformation();

            string? input = Console.ReadLine();

            if (input != "w" && input != "a" && input != "s" && input != "d")
            {
                Helpers.DisplayError("Please enter a valid coordinate character.");
                Helpers.DisplayEnterPrompt();

                continue;
            }

            if (Game.ValidateCoordinate(input))
            {
                Game.UpdateCoordinate(input);
            };

            if (Game.x == 0 && Game.y == 0)
            {
                Game.DisplayPlayerInformation();

                Helpers.ColouredText("\n\nYou are back where you woke up.", ConsoleColor.Yellow);
                Helpers.DisplayEnterPrompt();
            }

            if (Game.x == 2 && Game.y == 2) 
            {
                while (true)
                {
                    Game.DisplayPlayerInformation();

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
}