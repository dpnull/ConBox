using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox
{
    public class BindingsFactory
    {
        /// <summary>
        /// Bindings factory to create a list of bindings for Bindings object
        /// </summary>
        /// <returns></returns>
        public Bindings CreateBindings()
        {
            Bindings bindings = new Bindings();

            // Note: There is an existing duplication of the exit keybind, but doing so allows for manual arrangement of keybinds
            // without the need of sorting it with algorithm. This allows for much more intuitive order of actions
            // to be displayed on the UI

            // Main
            bindings.AddBinding("travel", 't', "Travel", false, UIManager.FocusableWindows.MainWindow);
            bindings.AddBinding("inventory", 'i', "Inventory", false, UIManager.FocusableWindows.MainWindow);

            // Travel
            bindings.AddBinding("exit", 'x', "Exit", false, UIManager.FocusableWindows.TravelWindow);

            // Inventory
            bindings.AddBinding("weapons", 'w', "Weapons", false, UIManager.FocusableWindows.InventoryWindow);
            bindings.AddBinding("misc", 'm', "Miscellaneous", false, UIManager.FocusableWindows.InventoryWindow);
            bindings.AddBinding("exit", 'x', "Exit", false, UIManager.FocusableWindows.InventoryWindow);

            return bindings;
        }
    }
}
