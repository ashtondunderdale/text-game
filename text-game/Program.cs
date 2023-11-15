namespace text_game;

internal class Program
{
    static void Main()
    {
        Game();
    }

    static void Game() 
    {
        CreateCharacter();
    }

    static void CreateCharacter() 
    {
        string name = GetValidString("Enter a name for your character", "name");
        string role = GetValidRole();

        switch (role) 
        {
            case "knight":
                break;

            case "assassin":
                break;

            case "ranger":
                break;

            case "mage":
                break;

            default:
                break;
        }

        Character character = new(name, role, 1, 1, 1);
    }

    static string GetValidString(string message, string subject)
    {
        string? inputString;

        while (true)
        {
            Console.WriteLine(message);
            inputString = Console.ReadLine();

            if (string.IsNullOrEmpty(inputString)) Console.WriteLine($"{subject} cannot be blank.");
            else break;
        }
        return inputString;
    }

    static string GetValidRole() 
    {
        string? inputString;

        while (true)
        {
            Console.WriteLine("Enter a role for your character\n\n1 | Knight\n2 | Ranger\n3 | Mage\n4 | Assassion");
            inputString = Console.ReadLine();

            if (string.IsNullOrEmpty(inputString)) 
            { 
                Console.WriteLine($"role cannot be blank."); 
                continue;
            }

            if (inputString != "1" && inputString != "2" && inputString != "3" && inputString != "4")
            {
                Console.WriteLine($"role must be one of the above.");
                continue;
            }

            else break;
        }
        return inputString;
    }
}