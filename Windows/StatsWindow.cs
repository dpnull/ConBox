﻿using System;
using System.Collections.Generic;
using System.Text;
using ConBox.Models;

namespace ConBox.Windows
{
    public class StatsWindow : ConWindow
    {
        public StatsWindow(int x, int y, int width, int height, BorderType border, string title = "Stats", bool centered = false, bool visible = false)
            : base(title, border, centered, visible)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Border = border;
        }

        public void PrintStats(Player player)
        {
            string stats =
                $"HP: {player.Health} | " +
                $"GLD: {player.Gold} | " +
                $"LV: {player.Level} | " +
                $"XP: {player.Experience} | " +
                $"WPN: {player.CurrentWeapon.Name}";

            Print(1, 0, stats);
        }
    }
}
