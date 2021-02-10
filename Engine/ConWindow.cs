using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ConBox.Windows;

namespace ConBox
{
    public class ConWindow
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } 
        public int Height { get; set; }
        public string Title { get; set; }
        public BorderType Border { get; set; }
        public bool Centered { get; set; }
        public bool Visible { get; set; }
        public ConsoleColor BorderColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor TitleColor { get; set; }
        public bool IsDirty { get; set; }

        /// <summary>
        /// Available border types for the window
        /// </summary>
        public enum BorderType
        {
            Single,
            Double,
            Bold,
            Checker
        }

        /// <summary>
        /// Instantiate a new Console Window.
        /// </summary>
        /// <param name="x">The x parameter.</param>
        /// <param name="y">The y parameter.</param>
        /// <param name="width">The width parameter.</param>
        /// <param name="height">The height parameter.</param>
        /// <param name="title">The window title.</param>
        /// <param name="border">The border type.</param>
        /// <param name="centered">Center the title.</param>
        /// <param name="visible">Set the window visible.</param>
        /// <param name="borderColor">The border color.</param>
        /// <param name="backgroundColor">The background color.</param>
        /// <param name="foregroundColor">The foreground color.</param>
        public ConWindow(int x, int y, int width, int height, string title, BorderType border, bool centered, bool visible, ConsoleColor borderColor, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Title = title;
            Border = border;
            Centered = centered;
            Visible = visible;
            BorderColor = borderColor;
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
            TitleColor = borderColor;
            IsDirty = false;
        }

        /// <summary>
        /// Instantiate a new Console Window with default border, foreground, and background colors.
        /// </summary>
        /// <param name="x">The x parameter.</param>
        /// <param name="y">The y parameter.</param>
        /// <param name="width">The width parameter.</param>
        /// <param name="height">The height parameter.</param>
        /// <param name="title">The window title.</param>
        /// <param name="border">The border type.</param>
        /// <param name="centered">Center the title.</param>
        /// <param name="visible">Set the window visible.</param>
        public ConWindow(int x, int y, int width, int height, string title, BorderType border, bool centered, bool visible)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Title = title;
            Border = Border;
            Centered = centered;
            Visible = visible;
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
            BorderColor = ConsoleColor.White;
            TitleColor = BorderColor;
            IsDirty = false;
        }

        /// <summary>
        /// Instantiate a new Console Window.
        /// </summary>
        /// <param name="title">The window title.</param>
        /// <param name="border">The border type.</param>
        /// <param name="centered">Center the title.</param>
        /// <param name="visible">Set the window visible.</param>
        /// <param name="borderColor">The border color.</param>
        /// <param name="backgroundColor">The background color.</param>
        /// <param name="foregroundColor">The foreground color.</param>
        public ConWindow(string title, BorderType border, bool centered, bool visible, ConsoleColor borderColor, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Title = title;
            Border = border;
            Centered = centered;
            Visible = visible;
            BorderColor = borderColor;
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
            TitleColor = borderColor;
            IsDirty = false;
        }

        /// <summary>
        /// Instantiate a new Console Window with default border, foreground, and background colors.
        /// </summary>
        /// <param name="title">The window title.</param>
        /// <param name="border">The border type.</param>
        /// <param name="centered">Center the title.</param>
        /// <param name="visible">Set the window visible.</param>
        public ConWindow(string title, BorderType border, bool centered, bool visible)
        {
            Title = title;
            Border = border;
            Centered = centered;
            Visible = visible;
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
            BorderColor = ConsoleColor.White;
            TitleColor = BorderColor;
            IsDirty = false;
        }

        public void Clear()
        {
            int x = X;
            int y = Y;
            StringBuilder whiteSpace = new StringBuilder();
            whiteSpace.Append(' ', Width);
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(whiteSpace);
                y++;
            }

        }

        public void ChangeIsDirty(bool value)
        {
            IsDirty = value;
        }


        /// <summary>
        /// Change the background color of the window.
        /// </summary>
        public void DrawBackground()
        {
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(X, Y);
            for(int x = 0; x < Width; x++)
            {
                for(int y = 0; y < Height; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Print a message to the console window on the specified parameters.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="message">The message to be displayed.</param>
        /// 
        public void Print(int x, int y, string message)
        {

            Console.SetCursorPosition(X + x + 1, Y + y + 1);
            Console.ForegroundColor = ForegroundColor;
            Console.Write(message);
        }

        /// <summary>
        /// Print a message to the console window on the specified parameters.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="centered">Center message along the width of the window.</param>
        public void Print(int x, int y, string message, bool centered)
        {
            if (!centered)
            {
                Console.SetCursorPosition(X + x + 1, Y + y + 1);
            } else
            {
                Console.SetCursorPosition((X + x + 1) + Width / 2 - (message.Length) / 2, (Y + y + 1));
            }
            Console.ForegroundColor = ForegroundColor;
            Console.Write(message);
        }

        /// <summary>
        /// Print a message to the console window on the specified parameters using the provided foreground color.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="foregroundColor">The foreground color to be used for the message.</param>
        public void Print(int x, int y, string message, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.SetCursorPosition(X + x + 1, Y + y + 1);
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Print a message to the console window on the specified parameters.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="centered">Center message along the width of the window.</param>
        /// <param name="foregroundColor">The foreground color to be used for the message.</param>
        public void Print(int x, int y, string message, bool centered, ConsoleColor foregroundColor)
        {
            if (!centered)
            {
                Console.SetCursorPosition(X + x + 1, Y + y + 1);
            }
            else
            {
                Console.SetCursorPosition((X + x + 1) + Width / 2 - (message.Length) / 2, (Y + y + 1));
            }
            Console.ForegroundColor = foregroundColor;
            Console.Write(message);
            Console.ForegroundColor = ForegroundColor;
        }

        /// <summary>
        /// Print a message to the console window on the specified parameters using the provided foreground and background color.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="foregroundColor">The foreground color to be used for the message.</param>
        /// <param name="backgroundColor">The background color to be used for the message.</param>
        public void Print(int x, int y, string message, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.SetCursorPosition(X + x + 1, Y + y + 1);
            Console.Write(message);
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
        }

        /// <summary>
        /// Print a message to the console window on the specified parameters.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="centered">Center message along the width of the window.</param>
        /// <param name="foregroundColor">The foreground color to be used for the message.</param>
        /// <param name="backgroundColor">The background color to be used for the message.</param>
        public void Print(int x, int y, string message, bool centered, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            if (!centered)
            {
                Console.SetCursorPosition(X + x + 1, Y + y + 1);
            }
            else
            {
                Console.SetCursorPosition((X + x + 1) + Width / 2 - (message.Length) / 2, (Y + y + 1));
            }
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(message);
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
        }

        /// <summary>
        /// Currently obsolete.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="message"></param>
        public void SlowPrint(int x, int y, string message)
        {
            Console.SetCursorPosition(X + x + 1, Y + y + 1);
            Random RNG = new Random(message.GetHashCode());
            int delay = 1; // = 5 + RNG.Next(10);
            for (int i = 0; i < message.Length; i++)
            {
                Thread.Sleep(delay);
                Console.Write(message[i]);
            }
        }

        /// <summary>
        /// Make the window visible.
        /// </summary>
        public void MakeVisible()
        {
            Visible = true;
        }

        /// <summary>
        /// Make the window hidden.
        /// </summary>
        public void MakeHidden()
        {
            Visible = false;
        }

        /// <summary>
        /// Check if the window is visible.
        /// </summary>
        /// <returns></returns>
        public bool IsVisible()
        {
            return Visible;
        }

        /// <summary>
        /// Automatically set the window to be hidden or visible based on the provided condition.
        /// </summary>
        /// <param name="condition">Condition for visibility of the window.</param>
        public void AutoVisible(bool condition)
        {
            if (condition)
            {
                MakeVisible();
            }
            else
            {
                MakeHidden();
            }
        }

        /// <summary>
        /// Currently obsolete.
        /// </summary>
        /// <param name="defaultSrc"></param>
        public void MakeHiddenDefaultSrc(ConWindow defaultSrc)
        {
            Visible = false;
            
        }

        /// <summary>
        /// Currently obsolete.
        /// </summary>
        /// <param name="srcConsole"></param>
        /// <param name="srcX"></param>
        /// <param name="srcY"></param>
        /// <param name="srcWidth"></param>
        /// <param name="srcHeight"></param>
        /// <param name="newConsole"></param>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        public void Connect(ConWindow srcConsole, int srcX, int srcY, int srcWidth, int srcHeight, ConWindow newConsole, int newX, int newY)
        {
            if (srcConsole == null)
            {
                throw new ArgumentException("srcConsole is null");
            }
            if (newConsole == null)
            {
                throw new ArgumentException("newConsole is null");
            }
            if (srcWidth <= 0)
            {
                throw new ArgumentException("srcConsole Width must be greater than 0");
            }
            if (srcHeight <= 0)
            {
                throw new ArgumentException("srcConsole height must be greater than 0");
            }

            for (int iy = 0; iy < srcHeight; iy++)
            {
                for (int ix = 0; ix < srcWidth; ix++)
                {
                    if (ix + newX >= 0 && iy + newY >= 0 && ix + newX < newConsole.Width && iy + newY < newConsole.Height
                        && ix + srcX >= 0 && iy + srcY >= 0 && ix + srcX < srcConsole.Width && iy + srcY < srcConsole.Height)
                    {
                        newConsole.X = ix + newX;
                        newConsole.Y = iy + newY;

                        newConsole.X = srcConsole.X + ix + srcX;
                        newConsole.Y = srcConsole.Y + iy + srcY;
                    }
                }
            }

        }

        /// <summary>
        /// Resize the width and the height of the window.
        /// </summary>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        public void Resize(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentException("Width must be greater than 0");
            }
            if (height <= 0)
            {
                throw new ArgumentException("Height must be greater than 0");
            }

            Width = width;
            Height = height;

        }

        /// <summary>
        /// Reposition the console window on the x and y axis.
        /// </summary>
        /// <param name="x">The new x coordinate.</param>
        /// <param name="y">The new y coordinate.</param>
        public void Reposition(int x, int y)
        {
            if (x < 0)
            {
                throw new ArgumentException("X must be greater than -1");
            }
            if (y < 0)
            {
                throw new ArgumentException("Y must be greater than -1");
            }

            X = x;
            Y = y;

        }

        /// <summary>
        /// Relocate the window.
        /// </summary>
        /// <param name="x">The new x coordinate.</param>
        /// <param name="y">The new y coordinate.</param>
        public void Location(int x, int y)
        {
            if (X <= 0)
            {
                throw new ArgumentException("X must be greater than 0");
            }
            if (Y <= 0)
            {
                throw new ArgumentException("Y must be greater than 0");
            }

            X = x;
            Y = y;
        }

        /// <summary>
        /// Draw the window border.
        /// </summary>
        /// <returns></returns>
        public int Draw()
        {

            int result = 0;
            int x = X;
            int y = Y;
            char h = '─';
            char v = '│';
            char tl = '┌';
            char bl = '└';
            char tr = '┐';
            char br = '┘';
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = BorderColor;

            if (Border == BorderType.Single)
            {
                h = '─';
                v = '│';
                tl = '┌';
                bl = '└';
                tr = '┐';
                br = '┘';
            }
            else if (Border == BorderType.Double)
            {
                h = '═';
                v = '║';
                tl = '╔';
                bl = '╚';
                tr = '╗';
                br = '╝';
            }
            else if (Border == BorderType.Bold)
            {
                h = '█';
                v = '█';
                tl = '█';
                bl = '█';
                tr = '█';
                br = '█';
            }
            else if (Border == BorderType.Checker)
            {
                h = '▓';
                v = '▓';
                tl = '▓';
                bl = '▓';
                tr = '▓';
                br = '▓';
            }

            //Top
            for (x = X; x < (X + Width); x++)
            {
                try
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(h);
                }
                catch { result = -1; }
            }
            //Bottom
            y = Y + Height - 1;
            for (x = X; x < (X + Width); x++)
            {
                try
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(h);
                }
                catch { result = -1; }
            }
            //Left
            x = X;
            for (y = Y; y < (Y + Height); y++)
            {
                try
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(v);
                }
                catch { result = -1; }
            }
            //Right
            x = X + Width - 1;
            for (y = Y; y < (Y + Height - 1); y++)
            {
                try
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(v);
                }
                catch { result = -1; }
            }

            try
            {
                //Bottom-Left
                Console.SetCursorPosition(X, Y + Height - 1);
                Console.Write(bl);
                //Bottom-Right
                Console.SetCursorPosition(X + Width - 1, Y + Height - 1);
                Console.Write(br);
                //Top-Right
                Console.SetCursorPosition(X + Width - 1, Y);
                Console.Write(tr);
                //Top-Left
                Console.SetCursorPosition(X, Y);
                Console.Write(tl);
            }
            catch { result = -1; }

            Console.ForegroundColor = TitleColor;
            if (Centered)
            {
                Console.SetCursorPosition((X + Width / 2) - (Title.Length / 2), Y);
                Console.Write(Title);
            }
            else
            {
                Console.SetCursorPosition(X + 1, Y);
                Console.Write(Title);
            }
            Console.ForegroundColor = ForegroundColor;

            return result;
        }
    }
}

