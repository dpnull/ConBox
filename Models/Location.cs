﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox.Models
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location()
        {
            X = 0;
            Y = 0;
            Name = "Home";
            Description = "This is your house.";
        }
    }
}