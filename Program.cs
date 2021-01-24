using System;

namespace ConBox
{
    class Program
    {
        private static bool gameOn = true;
        static void Main(string[] args)
        {
            UIManager UIManager = new UIManager();

            while (gameOn)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                UIManager.Render();
            }
        }
    }
}
