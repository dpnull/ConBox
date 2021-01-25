using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox.Windows
{
    public class QueueMessage
    {
        public enum MessageType
        {
            Info,
            Warning
        }

        public string Text { get; set; }
        public MessageType Type { get; set; }

        public QueueMessage(string message, MessageType type)
        {
            Text = message;
            Type = type;
        }
    }

    public class MessageWindow : ConWindow
    {
        public ConsoleColor InfoForegroundColor;
        public ConsoleColor WarningForegroundColor;
        public ConsoleColor InfoBackgroundColor;
        public ConsoleColor WarningBackgroundColor;

        public MessageWindow(int x, int y, int width, int height, BorderType border, string title = "Message Log", bool centered = false, bool visible = false)
            : base(title, border, centered, visible)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Border = border;

            InfoForegroundColor = ForegroundColor;
            InfoBackgroundColor = BackgroundColor;
            WarningForegroundColor = ForegroundColor;
            WarningBackgroundColor = ConsoleColor.DarkYellow;
        }

        public void SetMessageColors(ConsoleColor infoForeground, ConsoleColor infoBackground, ConsoleColor warningForeground, ConsoleColor warningBackground)
        {
            InfoForegroundColor = infoForeground;
            InfoBackgroundColor = infoBackground;
            WarningForegroundColor = warningForeground;
            WarningBackgroundColor = warningBackground;
        }


        private readonly Queue<QueueMessage> _lines = new Queue<QueueMessage>();

        // Define the maximum number of lines to store
        private static readonly int _maxLines = 6;

        // Use a Queue to keep track of the lines of text
        // The first line added to the log will also be the first removed

        /// <summary>
        /// Add a message to the log with default message type as info.
        /// </summary>
        /// <param name="message">The message string.</param>
        public void Add(string message)
        {
            _lines.Enqueue(new QueueMessage(message, QueueMessage.MessageType.Info));

            // When exceeding the maximum number of lines remove the oldest one.
            if (_lines.Count > _maxLines)
            {
                _lines.Dequeue();
            }
        }

        /// <summary>
        /// Add a message to the log with custom message type
        /// </summary>
        /// <param name="message">The message string.</param>
        public void Add(string message, QueueMessage.MessageType type)
        {
            _lines.Enqueue(new QueueMessage(message, type));

            // When exceeding the maximum number of lines remove the oldest one.
            if (_lines.Count > _maxLines)
            {
                _lines.Dequeue();
            }
        }

        // Draw each line of the MessageLog queue to the console
        public void PrintLog()
        {
            int x = 0;
            int y = 0;

            QueueMessage[] messages = _lines.ToArray();
            for (int i = 0; i < messages.Length; i++)
            {
                if(messages[i].Type == QueueMessage.MessageType.Warning)
                {
                    Print(x, y, messages[i].Text, WarningForegroundColor, WarningBackgroundColor);
                }
                else if (messages[i].Type == QueueMessage.MessageType.Info)
                {
                    Print(x, y, messages[i].Text, InfoForegroundColor, InfoBackgroundColor);
                }
                
                y++;
            }
        }

        public void PrintInfo()
        {

        }
    }
}

