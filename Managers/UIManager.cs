﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConBox.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics;

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
            InventoryWindow,
            MessageWindow,
            DeveloperWindow
        }
        public static FocusableWindows CurrentlyFocused;

        public static MessageWindow MessageWindow;

        public GameSession GameSession;
        public InputManager InputManager;
        public Parameters Parameters;

        // Instantiate windows
        public TravelWindow TravelWindow;
        public StatsWindow StatsWindow;
        public LocationWindow LocationWindow;
        public BindingsWindow BindingsWindow;
        public InventoryWindow InventoryWindow;
        public static DeveloperWindow DeveloperWindow;
        
        private bool _firstFrame = true;
        public UIManager()
        {
            Init();
        }

        public void Init()
        {
            GameSession = new GameSession();
            InputManager = new InputManager();
            Parameters = new Parameters();

            Parameters.WidthOrHeightChanged += UpdateSize;

            MessageWindow = new MessageWindow(Parameters.MessageX, Parameters.MessageY, Parameters.MessageWidth, Parameters.MessageHeight, ConWindow.BorderType.Double);

            BindingsWindow = new BindingsWindow(Parameters.BindingsX, Parameters.BindingsY, Parameters.BindingsWidth, Parameters.BindingsHeight, ConWindow.BorderType.Double);
            StatsWindow = new StatsWindow(Parameters.StatsX, Parameters.StatsY, Parameters.StatsWidth, Parameters.StatsHeight, ConWindow.BorderType.Double);
            LocationWindow = new LocationWindow(Parameters.LocationX, Parameters.LocationY, Parameters.LocationWidth, Parameters.LocationHeight, ConWindow.BorderType.Single);
            TravelWindow = new TravelWindow(Parameters.TravelX, Parameters.TravelY, Parameters.TravelWidth, Parameters.TravelHeight, ConWindow.BorderType.Double);
            InventoryWindow = new InventoryWindow(Parameters.InventoryX, Parameters.InventoryY, Parameters.InventoryWidth, Parameters.InventoryHeight, ConWindow.BorderType.Double);

            // dev
            DeveloperWindow = new DeveloperWindow(Parameters.DeveloperX, Parameters.DeveloperY, Parameters.DeveloperWidth, Parameters.DeveloperHeight, ConWindow.BorderType.Double, Parameters.DeveloperHeight - 2, "DEV CONSOLE", true, false);
            DeveloperWindow.Add("Developer window successfuly initialized.");

            CurrentlyFocused = FocusableWindows.MainWindow;
        }

        public void Render()
        {
            // Draw the first frame
            
            if(_firstFrame)
            {
                Draw();
                _firstFrame = false;
            }

            // Todo: Automatic buffer resizing

            ProcessKeyboard();

            Update();

            Draw();
        }

        public void Update()
        {
            Parameters.Recalculate();
        }

        public void ProcessKeyboard()
        {
            InputManager.ProcessInput(GameSession);
        }

        public void Draw()
        {
            Console.Clear();

            // Currently drawn globally
            // Temporary solution
            if(CurrentlyFocused != FocusableWindows.DeveloperWindow)
            {
                DrawBindings();
                DrawMessageLog();
            }


            // Drawn only based on the specified currently focused window state
            if (CurrentlyFocused == FocusableWindows.MainWindow) { DrawStats(); DrawLocation(); }
            else if (CurrentlyFocused == FocusableWindows.InventoryWindow) { DrawStats(); DrawInventory(); }
            else if (CurrentlyFocused == FocusableWindows.TravelWindow) { DrawStats(); DrawTravel(); }
            else if (CurrentlyFocused == FocusableWindows.DeveloperWindow) { DrawDevWindow(); }
        }

        public void DrawBindings()
        {          
            BindingsWindow.DrawBindings(GameSession.Bindings);
        }

        public void DrawMessageLog()
        {
            MessageWindow.Draw();
            MessageWindow.PrintLog();
        }

        public void DrawStats()
        {
            StatsWindow.Draw();
            StatsWindow.PrintStats(GameSession.Player);

        }

        public void DrawLocation()
        {
            LocationWindow.Draw();
            LocationWindow.PrintLocation(GameSession.CurrentLocation);
        }

        public void DrawInventory()
        {
            InventoryWindow.Draw();
            InventoryWindow.PrintItems(GameSession.Player);
        }

        public void DrawTravel()
        {
            TravelWindow.Draw();
            TravelWindow.PrintAvailableLocations(GameSession.CurrentWorld);

        }

        public void UpdateSize(object sender, EventArgs e)
        {

            BindingsWindow.Reposition(Parameters.BindingsX, Parameters.BindingsY);
            BindingsWindow.Resize(Parameters.BindingsWidth, Parameters.BindingsHeight);

            StatsWindow.Reposition(Parameters.StatsX, Parameters.StatsY);
            StatsWindow.Resize(Parameters.StatsWidth, Parameters.StatsHeight);

            LocationWindow.Reposition(Parameters.LocationX, Parameters.LocationY);
            LocationWindow.Resize(Parameters.LocationWidth, Parameters.LocationHeight);

            InventoryWindow.Reposition(Parameters.InventoryX, Parameters.InventoryY);
            InventoryWindow.Resize(Parameters.InventoryWidth, Parameters.InventoryHeight);

            TravelWindow.Reposition(Parameters.TravelX, Parameters.TravelY);
            TravelWindow.Resize(Parameters.TravelWidth, Parameters.TravelHeight);

            MessageWindow.Reposition(Parameters.MessageX, Parameters.MessageY);
            MessageWindow.Resize(Parameters.MessageWidth, Parameters.MessageHeight);
        }


        public void DrawDevWindow()
        {
            DeveloperWindow.Draw();
            DeveloperWindow.PrintLog();
        }
    }
}
