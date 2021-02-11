using System;
using System.Collections.Generic;
using System.Text;
using ConBox.Models;
using ConBox.Factory;
using System.Linq;

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
            Player.AddItemToInventory(ItemFactory.CreateItem(2001));
            Player.AddItemToInventory(ItemFactory.CreateItem(2002));
            Player.CurrentWeapon = Player.Inventory.Where(i => i.Type == Item.ItemType.Weapon).FirstOrDefault();

            // New world and set default location
            CurrentWorld = worldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.GetLocation(0, 0);
        }

        public void TravelToXLocation(int x)
        {
            if (CurrentLocation != CurrentWorld.GetLocation(x, 0))
            {
                CurrentLocation = CurrentWorld.GetLocation(x, 0);
                UIManager.MessageWindow.Add($"Travelling to {CurrentWorld.GetLocation(x, 0).Name}...");
                UIManager.DeveloperWindow.Add($"[ {nameof(TravelToXLocation)} ] {nameof(CurrentWorld.GetLocation)} call with {nameof(x)}{x}, {nameof(CurrentLocation)} = ({CurrentLocation.X}, {CurrentLocation.Y})", Windows.QueueMessage.MessageType.Info);
            } else
            {
                UIManager.MessageWindow.Add($"You are already at this location!", Windows.QueueMessage.MessageType.Info);
            }
        }

        public void TestLog()
        {
            UIManager.MessageWindow.Add("This is a warning message!", Windows.QueueMessage.MessageType.Warning);
        }
    }
}
