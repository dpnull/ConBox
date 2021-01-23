using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ConBox.Windows
{
    public class Parameters
    {
        public bool IsFullscreen = false;

        public event EventHandler WidthOrHeightChanged;

        private int _consoleWidth = Console.WindowWidth;
        private int _consoleHeight = Console.WindowHeight;

        public int ConsoleWidth
        {
            get { return _consoleWidth; }
            set
            {
                if (WidthOrHeightChanged != null)
                {
                    _consoleWidth = value;
                    WidthOrHeightChanged(this, null);
                }
            }
        }
        public int ConsoleHeight
        {
            get { return _consoleHeight; }
            set
            {
                if (WidthOrHeightChanged != null)
                {
                    _consoleHeight = value;
                    WidthOrHeightChanged(this, null);
                }
            }
        }

        public int BindingsX;
        public int BindingsY;
        public int BindingsWidth;
        public int BindingsHeight;

        public int StatsX;
        public int StatsY;
        public int StatsWidth;
        public int StatsHeight;

        public int LocationX;
        public int LocationY;
        public int LocationWidth;
        public int LocationHeight;

        public int TravelX;
        public int TravelY;
        public int TravelWidth;
        public int TravelHeight;

        public int InventoryX;
        public int InventoryY;
        public int InventoryWidth;
        public int InventoryHeight;

        public Parameters()
        {
            Recalculate();
        }

        public void Recalculate()
        {
            ConsoleWidth = Console.WindowWidth;
            ConsoleHeight = Console.WindowHeight;

            BindingsX = ConsoleWidth - 20;
            BindingsY = 0;
            BindingsWidth = 20;
            BindingsHeight = ConsoleHeight;

            StatsX = 0;
            StatsY = 0;
            StatsWidth = ConsoleWidth - BindingsWidth;
            StatsHeight = 3;

            LocationX = 0;
            LocationY = StatsHeight;
            LocationWidth = ConsoleWidth - BindingsWidth;
            LocationHeight = 4;

            TravelX = 0;
            TravelY = StatsY;
            TravelWidth = ConsoleWidth - BindingsWidth;
            TravelHeight = 8;

            InventoryX = 0;
            InventoryY = StatsY;
            InventoryWidth = ConsoleWidth - BindingsWidth;
            InventoryHeight = 8;
        }

    }
}
