using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox.Models
{
    public class Location
    {
        private int _x;
        private int _y;

        public event EventHandler DidLocationChange;
        public int X
        {
            get { return _x; }
            set
            {
                if(value != _x)
                {
                    _x = value;
                    DidLocationChange?.Invoke(this, null);
                }

            }
        }
        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
            }
        }
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