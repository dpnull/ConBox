using System;
using System.Collections.Generic;
using System.Text;
using ConBox.Models;

namespace ConBox.Windows
{
    public class InventoryWindow : ConWindow
    {
        public InventoryWindow(int x, int y, int width, int height, BorderType border, string title = "Inventory", bool centered = false, bool visible = false)
            : base(title, border, centered, visible)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Border = border;
        }

        public void PrintItems(Player player)
        {
            ConsoleColor temp = ForegroundColor;
            int index = 0;
            int y = 0;
            for(int i = 0; i < player.Inventory.Count; i++)
            {
                index++;
                if(InputManager.Selection >= player.Inventory.Count) { InputManager.Selection = player.Inventory.Count - 1; }
                if(player.Inventory[InputManager.Selection] == player.Inventory[i]) { ForegroundColor = ConsoleColor.Blue; }
                else { ForegroundColor = temp; }

                string item = $"{index}) {player.Inventory[i].Name}";
                Print(0, y, item);
                y++;
            }
        }

    }
}
