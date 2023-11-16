using System.ComponentModel.DataAnnotations;

namespace text_game;

internal class Program
{
    static void Main() => Game();

    static void Game() 
    {
        GetName();
        DisplayIntro();
        Tutorial();
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

            break;
        }
    }

    static void DisplayIntro() 
    { 
        Console.Clear();

        Thread.Sleep(2000);
        Helpers.TypeColouredText("The year is 27707.", ConsoleColor.White, 100);

        Thread.Sleep(1500);
        Helpers.TypeColouredText("\nYou woke up a few seconds ago.", ConsoleColor.White, 50);

        Thread.Sleep(2000);
        Helpers.TypeColouredText("\nYou cant remember much.", ConsoleColor.White, 80);

        Thread.Sleep(2000);
        Helpers.TypeColouredText("\n\nYou seem to be in a laboratory...", ConsoleColor.White, 50);
    }

    static void Tutorial() 
    { 
    
    }
}