using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox.Windows
{
    public class MessageWindow : ConWindow
    {
        public MessageWindow(int x, int y, int width, int height, BorderType border, string title = "Message Log", bool centered = false, bool visible = false)
            : base(title, border, centered, visible)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Border = border;
        }
    }
}
