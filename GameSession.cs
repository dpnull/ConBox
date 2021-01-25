using System;
using System.Collections.Generic;
using System.Text;
using ConBox.Models;
using ConBox.Factory;

namespace ConBox
{
    public class GameSession
    {
        public Location CurrentLocation { get; set; }
        public World CurrentWorld { get; set; }

        public static Bindings Bindings;
        public Player Player;

        public GameSession()
        {

            // Create factories
            BindingsFactory bindingsFactory = new BindingsFactory();
            WorldFactory worldFactory = new WorldFactory();

            // Instantiation using factories
            Bindings = bindingsFactory.CreateBindings();

            // New player
            Player = new Player("Dom", 100, 100, 0, 1, 20);

            // New world and set default location
            CurrentWorld = worldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.GetLocation(0, 0);
        }

        public void TravelToXLocation(int x)
        {
            CurrentLocation = CurrentWorld.GetLocation(x, 0);
        }
    }
}
