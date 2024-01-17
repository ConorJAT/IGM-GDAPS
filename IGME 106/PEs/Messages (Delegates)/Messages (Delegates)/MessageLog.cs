using System;
using System.Collections.Generic;
using System.Text;

namespace Messages__Delegates_
{
    class MessageLog
    {
        private List<string> messages;

        public MessageLog()
        {
            messages = new List<string>();
        }

        public void Save(string label, string message)
        {
            messages.Add(label + ":| " + message);
        }

        public void Print()
        {
            for (int i = 0; i < messages.Count; i++)
            {
                string[] toPrint = messages[i].Split('|');
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(toPrint[0]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(toPrint[1]);
            }
        }
    }
}
