using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox.Models
{
    public class Player : Entity
    {
        public int Experience { get; set; }
        public int Level { get; set; }

        public Player(string name, int maxHealth, int health, int experience, int level, int gold) :
            base(name, maxHealth, health, gold)
        {
            Experience = experience;
            Level = level;

        }
    }
}
