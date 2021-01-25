using System;
using System.Collections.Generic;
using System.Text;
using ConBox.Models;

namespace ConBox.Factory
{
    public class WorldFactory
    {
        // Instiantiates and returns a new world object
        public World CreateWorld()
        {
            // Instantiate and return new world
            World world = new World();

            // Create locations
            world.AddLocation(0, 0, "Home", "Your dirty dwelling.");
            world.AddLocation(1, 0, "Village", "A seemingly abandoned village.");
            world.AddLocation(1, 1, "Old Blacksmith", "An elderly blacksmith. Shaky but can do his job.");
            world.AddLocation(1, 2, "Market", "An old lady works here selling all sorts of items. But useless.");

            world.AddLocation(2, 0, "Forest", "Thick forest with lively ecosystem.");

            return world;
        }
    }
}
