using System;

namespace ConBox
{
    class Program
    {
        private static bool gameOn = true;
        static void Main(string[] args)
        {
            UIManager UIManager = new UIManager();

            // First frame, different color for debugging purposes

            while (gameOn)
            {
                // Temporary set cursor position fix
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 0);
                UIManager.Render();
            }
        }
    }
}
