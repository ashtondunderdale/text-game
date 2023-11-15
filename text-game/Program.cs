namespace text_game;

internal class Program
{
    static void Main()
    {
        Game();
    }

    static void Game() 
    {
        GetCharacterDetails();
    }

    static void GetCharacterDetails() 
    {
        string name = GetValidName();
        string role = GetValidRole();

        int health; int attack; int defence;

        switch (role.ToLower())
        {
            case "knight":
                health = 5; attack = 3; defence = 3;
                CreateCharacter(name, role, health, attack, defence);
                break;

            case "ranger":
                health = 5; attack = 2; defence = 1;
                CreateCharacter(name, role, health, attack, defence);
                break;

            case "assassin":
                health = 5; attack = 5; defence = 0;
                CreateCharacter(name, role, health, attack, defence);
                break;
        }
    }

    static string GetValidName()
    {
        string? inputString;

        while (true)
        {
            Console.WriteLine("Enter a name for your character");
            inputString = Console.ReadLine();

            if (string.IsNullOrEmpty(inputString)) Console.WriteLine($"name cannot be blank.");
            else break;
        }
        return inputString;
    }

    static string GetValidRole() 
    {
        string? inputString;
        HashSet<string> validRoles = new() { "knight", "ranger", "assassin" };

        while (true)
        {
            Console.WriteLine("\nEnter a role for your character\n\n\tKnight\n\tRanger\n\tAssassin");
            inputString = Console.ReadLine();

            if (string.IsNullOrEmpty(inputString)) 
            { 
                Console.WriteLine($"role cannot be blank."); 
                continue;
            }

            if (!validRoles.Contains(inputString.ToLower()))
            {
                Console.WriteLine("Enter a valid role from above");
                continue;
            }


            else break;
        }
        return inputString;
    }

    static void CreateCharacter(string name, string role, int health, int attack, int defence) 
    {
        Character character = new(name, role, health, attack, defence);
        Console.WriteLine($"\nYour Character:\n\n\tName: {name}\n\tRole: {role}\n\n\tHealth {health}\n\tAttack: {attack}\n\tDefence: {defence}");
        Console.ReadKey();
    }
}