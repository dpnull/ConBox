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
            MessageWindow
        }
        public static FocusableWindows CurrentlyFocused;


        public GameSession GameSession;
        public InputManager InputManager;
        public Parameters Parameters;

        // Instantiate windows
        public TravelWindow TravelWindow;
        public StatsWindow StatsWindow;
        public LocationWindow LocationWindow;
        public BindingsWindow BindingsWindow;
        public InventoryWindow InventoryWindow;
        public MessageWindow MessageWindow;
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

            BindingsWindow = new BindingsWindow(Parameters.BindingsX, Parameters.BindingsY, Parameters.BindingsWidth, Parameters.BindingsHeight, ConWindow.BorderType.Double);
            MessageWindow = new MessageWindow(Parameters.MessageX, Parameters.MessageY, Parameters.MessageWidth, Parameters.MessageHeight, ConWindow.BorderType.Double);
            StatsWindow = new StatsWindow(Parameters.StatsX, Parameters.StatsY, Parameters.StatsWidth, Parameters.StatsHeight, ConWindow.BorderType.Double);
            LocationWindow = new LocationWindow(Parameters.LocationX, Parameters.LocationY, Parameters.LocationWidth, Parameters.LocationHeight, ConWindow.BorderType.Single);
            TravelWindow = new TravelWindow(Parameters.TravelX, Parameters.TravelY, Parameters.TravelWidth, Parameters.TravelHeight, ConWindow.BorderType.Double);
            InventoryWindow = new InventoryWindow(Parameters.InventoryX, Parameters.InventoryY, Parameters.InventoryWidth, Parameters.InventoryHeight, ConWindow.BorderType.Double);

            CurrentlyFocused = FocusableWindows.MainWindow;           
        }

        public void Render()
        {
            
            Console.Clear();

            // Todo: Automatic buffer resizing

            WindowManager();

            ProcessKeyboard();

            Parameters.Recalculate();
        }

        public void ProcessKeyboard()
        {
            InputManager.ProcessInput();
        }

        public void WindowManager()
        {
            // Currently drawn globally
            DrawBindings();
            DrawMessageLog();

            // Drawn only based on the specified currently focused window state
            if (CurrentlyFocused == FocusableWindows.MainWindow) { DrawStats(); DrawLocation(); }
            if (CurrentlyFocused == FocusableWindows.InventoryWindow) { DrawStats(); DrawInventory(); }
            if (CurrentlyFocused == FocusableWindows.TravelWindow) { DrawStats(); DrawTravel(); }
        }

        public void DrawBindings()
        {
            BindingsWindow.DrawBindings(GameSession.Bindings);
        }

        public void DrawMessageLog()
        {
            MessageWindow.Draw();
        }

        public void DrawStats()
        {
            StatsWindow.Draw();
            StatsWindow.PrintStats(GameSession.Player);

        }

        public void DrawLocation()
        {
            LocationWindow.Draw();
        }

        public void DrawInventory()
        {
            InventoryWindow.Draw();
        }

        public void DrawTravel()
        {
            TravelWindow.Draw();
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
    }
}
