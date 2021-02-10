using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConBox.Windows
{
    public class BindingsWindow : ConWindow
    {
        public BindingsWindow(int x, int y, int width, int height, BorderType border, string title = "Bindings", bool centered = false, bool visible = false)
            : base(title, border, centered, visible)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Border = border;
            IsDirty = false;
        }

        // Show bindings based on the parameters passed
        public void FilterBindings(Bindings bindings, UIManager.FocusableWindows type)
        {
            int y = Y;
            // Create a filtered list that only contains the passed enumerator
            List<Bindings> filteredBindings = bindings._bindings.Where(b => b.Type == type).ToList();
            for (int i = 0; i < filteredBindings.Count(); i++)
            {
                if (filteredBindings[i].Type == type)
                {
                    Print(0, y, filteredBindings[i].PrintBinding());
                }

                y++;

            }
        }

        public void DrawBindings(Bindings bindings)
        {
            Draw();

            if (UIManager.CurrentlyFocused == UIManager.FocusableWindows.MainWindow)
            {
                FilterBindings(bindings, UIManager.FocusableWindows.MainWindow);
                bindings.AutoShow(UIManager.FocusableWindows.MainWindow);
            }
            if (UIManager.CurrentlyFocused == UIManager.FocusableWindows.TravelWindow)
            {
                FilterBindings(bindings, UIManager.FocusableWindows.TravelWindow);
                bindings.AutoShow(UIManager.FocusableWindows.TravelWindow);
            }
            if(UIManager.CurrentlyFocused == UIManager.FocusableWindows.InventoryWindow)
            {
                FilterBindings(bindings, UIManager.FocusableWindows.InventoryWindow);
                bindings.AutoShow(UIManager.FocusableWindows.InventoryWindow);
            }
        }

    }
}
