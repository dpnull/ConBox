using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox
{
    public class InputManager
    {
        public static ConsoleKeyInfo Input;

        public InputManager()
        {

        }

        /// <summary>
        /// Process all input.
        /// </summary>
        public void ProcessInput()
        {
            Input = Console.ReadKey(true);

            if (IsKeyPressed("travel"))
            {
                UIManager.CurrentlyFocused = UIManager.FocusableWindows.TravelWindow;
            }

            if (IsKeyPressed("inventory"))
            {
                UIManager.CurrentlyFocused = UIManager.FocusableWindows.InventoryWindow;
            }

            // Close currently focused window
            // Temporary fix
            if (IsKeyPressed("exit"))
            {
                UIManager.CurrentlyFocused = UIManager.FocusableWindows.MainWindow;

                // Set Currently Focused as global
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
    }
}
