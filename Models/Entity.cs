using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox.Models
{
    public abstract class Entity
    {
        private string _name;
        private int _maxHealth;
        private int _health;
        private int _gold;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int MaxHealth
        {
            get { return _maxHealth; }
            private set { _maxHealth = value; }
        }
        public int Health
        {
            get { return _health; }
            private set { _health = value; }
        }
        public int Gold
        {
            get { return _gold; }
            private set { _gold = value; }
        }

        public bool IsDead => Health <= 0;


        protected Entity(string name, int maxHealth, int health, int gold)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = health;
            Gold = gold;
        }

        public void TakeDamage(int d)
        {
            Health -= d;

            if (IsDead)
            {
                Health = 0;
            }

        }

        public void Heal(int h)
        {
            Health += h;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        public void SetHealth(int h)
        {
            Health = h;
        }

        public void AddGold(int g)
        {
            Gold += g;
        }

        public void RemoveGold(int g)
        {
            Gold -= g;
        }
    }
}
