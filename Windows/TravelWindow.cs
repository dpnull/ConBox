using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConBox.Models;

namespace ConBox.Windows
{
    public class TravelWindow : ConWindow
    {
        public TravelWindow(int x, int y, int width, int height, BorderType border, string title = "Travel", bool centered = false, bool visible = false)
            : base(title, border, centered, visible)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Border = border;
        }

        public void PrintAvailableLocations(World world)
        {
            ConsoleColor temp = ForegroundColor;
            int index = 0;
            int y = 0;
            List<Location> filteredList = world.locations.Where(x => x.Y == 0).ToList();  

            for (int i = 0; i < filteredList.Count; i++)
            {
                index++;
                if(InputManager.Selection >= filteredList.Count) { InputManager.Selection = filteredList.Count - 1; } // Set selection index to the non-array count of filtered list to avoid out of bounds.
                if(filteredList[InputManager.Selection] == filteredList[i]) { ForegroundColor = ConsoleColor.Blue; } // Highlight currently selected location.
                else { ForegroundColor = temp; }

                string item = $"{index}) {filteredList[i].Name}";
                Print(0, y, item);
                y++; 
            }
            ForegroundColor = temp;
        }

    }
}
