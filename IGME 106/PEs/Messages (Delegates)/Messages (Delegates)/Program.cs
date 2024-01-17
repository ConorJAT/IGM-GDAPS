using System;

namespace Messages__Delegates_
{

    delegate void MessageDelegate(string label, string message);

    class Program
    {
        static void Main(string[] args)
        {
            MessageLog myLog = new MessageLog();
            Dice myDie = new Dice();
            MessageDelegate newMessage = myLog.Save;
            myDie.RolledATwenty += newMessage;

            Console.WriteLine("Welcome to the 20-Sided Die Roller!\n");
            for (int i = 1; i < 101; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Roll {i}: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(myDie.Roll());

            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPrinting Message Log:");
            myLog.Print();
        }
    }
}
