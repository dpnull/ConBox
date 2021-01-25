using System;
using System.Collections.Generic;
using System.Text;
using ConBox.Models;

namespace ConBox.Windows
{
    public class LocationWindow : ConWindow
    {
        public LocationWindow(int x, int y, int width, int height, BorderType border, string title = "Location", bool centered = false, bool visible = false)
            : base(title, border, centered, visible)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Border = border;
        }

        public void PrintLocation(Location location)
        {
            Print(0, 0, $"-- {location.Name} --", true, ConsoleColor.Blue);
            Print(0, 1, location.Description, true, ConsoleColor.Yellow);
        }
    }
}
