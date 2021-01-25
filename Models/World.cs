using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox.Models
{
    public class World
    {
        // Store created locations
        // TODO: Make locations private
        public List<Location> locations = new List<Location>();

        public void AddLocation(int x, int y, string name, string description)
        {
            Location location = new Location();
            location.X = x;
            location.Y = y;
            location.Name = name;
            location.Description = description;

            // Add newly created location into locations list
            locations.Add(location);
        }

        public Location GetLocation(int x, int y)
        {
            foreach (Location location in locations)
            {
                if (location.X == x && location.Y == y)
                {
                    return location;
                }
            }


            return null;
        }


        public void PrintGuiLocations(int x, int y)
        {
            int index = 0;
            for (int i = 0; i < locations.Count; i++)
            {
                if (locations[i].Y == 0)
                {
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("{0}) {1}", index += 1, locations[i].Name);
                }
            }
        }

        public void TravelToLocation(string input, World world)
        {

            for (int i = 0; i < locations.Count; i++)
            {
                if (Int32.Parse(input) == locations[i].X)
                {
                    world.GetLocation(locations[i].X, locations[i].Y);
                }
            }
        }

        // Getter for location count
        // Possible improvement ?
        public int GetLocationCount()
        {
            int count = 0;
            for (int i = 0; i < locations.Count; i++)
            {
                count++;
            }
            return count;
        }
    }
}