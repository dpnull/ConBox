using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConBox.Windows;

namespace ConBox
{
    public class UIManager
    {
        public enum FocusableWindows
        {
            MainWindow,
            TravelWindow,
            StatsWindow,
            LocationWindow,
            BindingsWindow,
            InventoryWindow
        }
        public static FocusableWindows CurrentlyFocused;

        public int ConsoleWidth { get; set; }
        public int ConsoleHeight { get; set; }

        public GameSession GameSession;
        public InputManager InputManager;

        // Instantiate windows
        public TravelWindow TravelWindow;
        public StatsWindow StatsWindow;
        public LocationWindow LocationWindow;
        public BindingsWindow BindingsWindow;
        public InventoryWindow InventoryWindow;
        public UIManager()
        {
            ConsoleWidth = Console.WindowWidth;
            ConsoleHeight = Console.WindowHeight;
        }

        public void Init()
        {
            GameSession = new GameSession();
            InputManager = new InputManager();
            BindingsWindow = new BindingsWindow(ConsoleWidth - 20, 0, 20, ConsoleHeight, ConWindow.BorderType.Double);
            StatsWindow = new StatsWindow(0, 0, ConsoleWidth - BindingsWindow.Width, 3, ConWindow.BorderType.Double);
            LocationWindow = new LocationWindow(0, StatsWindow.Height, ConsoleWidth - BindingsWindow.Width, 4, ConWindow.BorderType.Single);
            TravelWindow = new TravelWindow(0, 0, ConsoleWidth, 5, ConWindow.BorderType.Double);
            InventoryWindow = new InventoryWindow(0, StatsWindow.Height, ConsoleWidth - BindingsWindow.Width, 10, ConWindow.BorderType.Double);

            CurrentlyFocused = FocusableWindows.MainWindow;

            StatsWindow.BackgroundColor = ConsoleColor.Red;
            
        }

        public void Render()
        {
            Console.Clear();

            DrawBindings();

            WindowManager();

            ProcessKeyboard();

        }

        public void ProcessKeyboard()
        {
            InputManager.ProcessInput();
        }

        public void WindowManager()
        {
            if(CurrentlyFocused == FocusableWindows.MainWindow) { DrawStats(); DrawLocation(); }
            if(CurrentlyFocused == FocusableWindows.InventoryWindow) { DrawStats(); DrawInventory(); }

        }

        public void DrawBindings()
        {
            BindingsWindow.DrawBindings(GameSession.Bindings);
        }

        public void DrawStats()
        {
            StatsWindow.Draw();

        }

        public void DrawLocation()
        {
            LocationWindow.Draw();
        }

        public void DrawInventory()
        {
            InventoryWindow.Draw();
        }
    }
}
