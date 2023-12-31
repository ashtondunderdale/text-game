﻿using System;

namespace text_game;

internal class Tutorial
{
    public static bool tutorialMode = true;
    public static bool foundTutorialWeapon = false;

    public static void PlayTutorial()
    {
        CreateCharacter();
        //DisplayIntro();
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

            Program.character = new Character(name, 10, 1, inventory, 0);
            Program.character.EquipWeapon(new Unequipped());
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
        Random random = new Random();
        double encounterChance = 0.4;

        Game.locationMaxY = 2; Game.locationMinY = -2;
        Game.locationMaxX = 2; Game.locationMinX = -2;
        Game.x = 0; Game.y = 0;
        Game.location = "Laboratory";

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

        while (tutorialMode)
        {
            Game.DisplayPlayerInformation();

            string? input = Console.ReadLine();

            if (input != "w" && input != "a" && input != "s" && input != "d" && input != "i")
            {
                Helpers.DisplayError("Please enter a valid coordinate or command character.");
                Helpers.DisplayEnterPrompt();

                continue;
            }

            if (Game.ValidateCommand(input))
            {
                if (input != "i")
                {
                    Game.UpdateCoordinate(input);

                    if (random.NextDouble() <= encounterChance)
                    {
                        Game.DisplayPlayerInformation();
                        RandomEncounter();
                    }
                }
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

        void RandomEncounter()
        {
            double randomEncounterType = random.NextDouble();

            if (randomEncounterType > 0.5)
            {
                MutantRat mutantRat = new();
                Helpers.ColouredText($"\n\nA {mutantRat.Name} suddenly attacks you!", ConsoleColor.Red);

                while (mutantRat.IsAlive() && Program.character.IsAlive())
                {
                    Helpers.DisplayEnterPrompt();
                    Game.DisplayPlayerInformation();
                    Helpers.ColouredText("\n\nChoose your action\n\n", ConsoleColor.Yellow);
                    Console.WriteLine("\t1. Attack");
                    Console.WriteLine("\t2. Flee");

                    string? choice = Console.ReadLine();
                    int ratDamage = mutantRat.Attack();

                    switch (choice)
                    {
                        case "1":
                            int playerDamage = Program.character.Attack();
                            mutantRat.TakeDamage(playerDamage);

                            Helpers.ColouredText($"\nYou dealt {playerDamage} damage to the {mutantRat.Name}!", ConsoleColor.Yellow);
                            Helpers.DisplayEnterPrompt();
                            break;

                        case "2":
                            double fleeChance = random.NextDouble();

                            if (fleeChance > 0.5)
                            {
                                Helpers.ColouredText($"\nYou chose to flee from the {mutantRat.Name}.", ConsoleColor.Yellow);
                                Helpers.DisplayEnterPrompt();
                            }
                            else 
                            {
                                Helpers.ColouredText($"\nYou chose to flee from the {mutantRat.Name}", ConsoleColor.Yellow);
                                Helpers.ColouredText($"\n\nThe rat scratched you as you were trying to escape!\n", ConsoleColor.Red);
                                Helpers.ColouredText($"The {mutantRat.Name} dealt {ratDamage} damage to you!\n", ConsoleColor.Red);
                                Program.character.TakeDamage(ratDamage);
                                Helpers.DisplayEnterPrompt();
                            }
                            return;

                        default:
                            Helpers.DisplayError("Invalid choice. Please enter 1 to attack or 2 to flee.");
                            continue;
                    }

                    if (!mutantRat.IsAlive())
                    {
                        Game.DisplayPlayerInformation();
                        Helpers.ColouredText($"\n\n\tYou defeated the {mutantRat.Name}!", ConsoleColor.Green);
                        Program.character.Experience += mutantRat.ExperienceOnDeath;
                        break; 
                    }

                    Program.character.TakeDamage(ratDamage);
                    Game.DisplayPlayerInformation();

                    Helpers.ColouredText($"\n\nThe {mutantRat.Name} dealt {ratDamage} damage to you!\n", ConsoleColor.Red);

                    Helpers.ColouredText($"\n\tYour Health: {Program.character.Health}\n\t{mutantRat.Name}'s Health: {mutantRat.Health}", ConsoleColor.Yellow);

                    if (!Program.character.IsAlive())
                    {
                        Helpers.ColouredText($"\n\nThe {mutantRat.Name} defeated you. Game over.", ConsoleColor.Red);
                        Helpers.DisplayEnterPrompt();
                        GameOver();
                        return;
                    }
                }

                Helpers.DisplayEnterPrompt();
            }

            else if (randomEncounterType < 0.2 && foundTutorialWeapon == false)
            {
                Helpers.ColouredText("\n\nYou find a metal pipe on the floor!\n", ConsoleColor.Green);
                Helpers.ColouredText("It has been automatically equipped.", ConsoleColor.Yellow);

                Weapon metalPipe = new MetalPipe();
                Program.character.EquipWeapon(new MetalPipe());
                Program.character.Inventory.Add(metalPipe.Name);

                foundTutorialWeapon = true;

                Helpers.DisplayEnterPrompt();
            }
            Console.Clear();
        }

        static void GameOver()
        {
            Environment.Exit(0);
        }
    }
}