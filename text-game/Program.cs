using System.ComponentModel.DataAnnotations;

namespace text_game;

internal class Program
{
    static void Main() => Game();

    static void Game() 
    {
        GetCharacter();
    }

    static void GetCharacter() 
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

            Console.Write($"\n\tYour name: ");
            Helpers.DisplayColoured($"{name}\n\n", ConsoleColor.Green);
            break;
        }
    }
}