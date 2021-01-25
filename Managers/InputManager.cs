using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox
{
    public class InputManager
    {
        public static ConsoleKeyInfo Input;
        public static int Selection = 0;

        public InputManager()
        {

        }

        /// <summary>
        /// Process all input.
        /// </summary>
        public void ProcessInput(GameSession gameSession)
        {
            // Temporary solution for resetting selection index.
            // Index should automatically revert itself depending on where it is called from.
            while (true)
            {
                Input = Console.ReadKey(true);

                // Globally available inputs
                ArrowSelection();

                if (IsKeyPressed("travel"))
                {
                    UIManager.CurrentlyFocused = UIManager.FocusableWindows.TravelWindow;
                    break;
                }

                if (IsKeyPressed("inventory"))
                {
                    UIManager.CurrentlyFocused = UIManager.FocusableWindows.InventoryWindow;
                    break;
                }

                // Close currently focused window
                // Temporary fix
                if (IsKeyPressed("exit"))
                {
                    UIManager.CurrentlyFocused = UIManager.FocusableWindows.MainWindow;
                    break;

                    // Set Currently Focused as global
                }

                // Travel window specific bindings
                if(IsKeyPressed(ConsoleKey.Enter, UIManager.FocusableWindows.TravelWindow))
                {
                    gameSession.TravelToXLocation(Selection);
                    UIManager.CurrentlyFocused = UIManager.FocusableWindows.MainWindow;
                    break;
                }

                if(IsKeyPressed(ConsoleKey.F, UIManager.FocusableWindows.MainWindow))
                {
                    gameSession.TestLog();
                    break;
                }
            }


        }

        /// <summary>
        /// Check if key is pressed.
        /// </summary>
        /// <param name="sid">String parameter of the binding.</param>
        /// <returns></returns>
        public bool IsKeyPressed(string sid)
        {
            if (Input.KeyChar == GameSession.Bindings.GetKeybind(sid))
            {
                return true;
            }

            return false;
        }

        public bool IsKeyPressed(ConsoleKey key, UIManager.FocusableWindows windowType)
        {
            if(Input.Key == key && UIManager.CurrentlyFocused == windowType)
            {
                return true;
            }

            return false;
        }

        public void ArrowSelection()
        {
            if (IsKeyPressed(ConsoleKey.UpArrow, UIManager.FocusableWindows.TravelWindow))
            {
                if(Selection > 0)
                {
                    Selection--;
                }
            }
            if (IsKeyPressed(ConsoleKey.DownArrow, UIManager.FocusableWindows.TravelWindow))
            {
                Selection++;
            }
        }
    }
}
