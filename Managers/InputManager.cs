using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox
{
    public class InputManager
    {
        public static ConsoleKeyInfo Input;
        public static int Selection = 1;
    
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

            // URGENT TODO: Work out why pressing non-char letters automatically opens up the first window from the first if. Until then, up/down is + / -
            while (true)
            {
                Input = Console.ReadKey(true);

                // Globally available inputs
                ArrowSelection(UIManager.FocusableWindows.TravelWindow);
                ArrowSelection(UIManager.FocusableWindows.InventoryWindow);

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

                // Test message log
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
            if (Input.KeyChar == GameSession.Bindings.GetKeybind(sid, UIManager.CurrentlyFocused))
            {
                return true;
            }

            return false;
        }

        public bool IsKeyPressed(ConsoleKey key)
        {
            if (Input.Key == key)
            {
                return true;
            }

            return false;
        }

        public bool IsKeyPressed(ConsoleKey key, UIManager.FocusableWindows type)
        {
            if (Input.Key == key && UIManager.CurrentlyFocused == type)
            {
                return true;
            }

            return false;
        }

        public void ArrowSelection(UIManager.FocusableWindows type)
        {
            if (UIManager.CurrentlyFocused == type)
            {
                if (IsKeyPressed(ConsoleKey.UpArrow))
                {
                    if (Selection > 0)
                    {
                        Selection--;
                    }
                }
                if (IsKeyPressed(ConsoleKey.DownArrow))
                {
                    Selection++;
                }
            }
        }
    }
}
