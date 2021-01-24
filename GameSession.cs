using System;
using System.Collections.Generic;
using System.Text;
using ConBox.Models;

namespace ConBox
{
    public class GameSession
    {
        public static Bindings Bindings;
        public Player Player;

        public GameSession()
        {

            // Create factories
            BindingsFactory bindingsFactory = new BindingsFactory();

            // Instantiation using factories
            Bindings = bindingsFactory.CreateBindings();

            Player = new Player("Dom", 100, 100, 0, 1, 20);
            
        }
    }
}
