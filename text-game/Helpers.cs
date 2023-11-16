namespace text_game
{
    internal class Helpers
    {
        /// <summary>
        /// Displays an error message in red color.
        /// </summary>
        /// <param name="errorMessage">The error message to display.</param>
        public static void DisplayError(string errorMessage)
        {
            ColouredText($"\n\t{errorMessage}", ConsoleColor.Red);
        }

        /// <summary>
        /// Displays an enter prompt message in yellow color and waits for a key press.
        /// </summary>
        public static void DisplayEnterPrompt()
        {
            ColouredText("\n\n\tPress Enter...", ConsoleColor.Yellow);
            Console.ReadKey(); Console.Clear();
        }

        /// <summary>
        /// Displays coloured text with the specified color.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="colour">The color of the text.</param>
        public static void ColouredText(string text, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.Write($"{text}"); Console.ResetColor();
        }

        /// <summary>
        /// Displays coloured text with a specified colour and typing effect.
        /// </summary>
        /// <param name="text">The text to type.</param>
        /// <param name="color">The colour of the text.</param>
        /// <param name="typeSpeed">the speed to display characters</param>
        public static void TypeColouredText(string text, ConsoleColor color, int sleepDuration)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(sleepDuration);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
