using System;

namespace text_game;

internal class Game
{
    public static int x = 0;
    public static int y = 0;

    public static int locationMaxY = 2;
    public static int locationMinY = -2;
    public static int locationMaxX = 2;
    public static int locationMinX = -2;

    public static string location = "Laboratory";

    public static void PlayGame(Character character)
    {
        bool playingGame = true;



        while (playingGame)
        {
            location = "Wasteland";
            locationMaxY = 25; locationMinY = -25;
            locationMaxX = 25; locationMinX = -25;

            Console.Clear();
            DisplayPlayerInformation();

            string? input = Console.ReadLine();

            if (input != "w" && input != "a" && input != "s" && input != "d" && input != "i")
            {
                Helpers.DisplayError("Please enter a valid coordinate or command character.");
                Helpers.DisplayEnterPrompt();

                continue;
            }

            if (ValidateCommand(input))
            {
                if (input != "i")
                {
                    UpdateCoordinate(input);
                }
            };

            if (x == 2 && y == 2)
            {
                while (true)
                {
                    DisplayPlayerInformation();

                    Helpers.ColouredText("\n\nYou are back at the laboratory, do you enter? ( y / n )", ConsoleColor.Green);
                    Helpers.ColouredText("\n\nNote: this will replay the tutorial", ConsoleColor.Yellow);
                    input = Console.ReadLine();

                    if (input == "y")
                    {
                        Tutorial.tutorialMode = true;
                        Helpers.ColouredText("\nYou entered in the laboratory.", ConsoleColor.Yellow);
                        Helpers.DisplayEnterPrompt();
                        Tutorial.StartLaboratoryTutorial();
                        break;
                    }
                    else if (input == "n")
                    {
                        Helpers.ColouredText("\nYou did not enter the laboratory.", ConsoleColor.Yellow);
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

    public static void DisplayPlayerInformation()
    {
        Console.Write($"Name:");
        Helpers.ColouredText($" {Program.character.Name}", ConsoleColor.Green);

        Console.Write($"\nLevel:");
        Helpers.ColouredText($" {Program.character.Level}", ConsoleColor.Green);

        Console.Write($"\nHealth:");
        Helpers.ColouredText($" {Program.character.Health}", ConsoleColor.Red);

        Console.Write($"\n\nLocation: {location}\n");

        Console.WriteLine($"Coordinates: x {x}, y {y}\n" +
            $"\nMax x: {locationMaxX} Min x: {locationMinX}" +
            $"\nMax y: {locationMaxY} Min y: {locationMinY}" +
            $"\n__________________________");
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
