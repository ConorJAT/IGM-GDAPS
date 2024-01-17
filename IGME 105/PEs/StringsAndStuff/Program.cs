using System;

namespace StringsAndStuff { 
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello! Please enter your name: ");
            String username = Console.ReadLine();

            Console.WriteLine($"\nYour name in all caps is {username.ToUpper()}");
            Console.WriteLine($"The first letter of your name is {username[0]}");
            Console.WriteLine($"The last letter of your name is {username[username.Length - 1]}");
            Console.WriteLine($"The length of your name is {username.Length} characters long");
            username = username.Replace('a', '@'); username = username.Replace('A', '@');
            username = username.Replace('s', '$'); username = username.Replace('S', '$');
            Console.WriteLine($"Your new name is now {username}\n\n");



            Console.Write("Please enter the price of an item: ");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine($"\nYour entered price is ${price:#.##}");
            Console.WriteLine($"With an 8% tax, your new total is ${(price * 1.08):#.##}");
            int dollarOnly = (int)(price * 1.08);
            Console.WriteLine($"The dollar portion of your price is {dollarOnly}");
            Console.WriteLine($"The cents portion of your price is 0{((price * 1.08) - dollarOnly):#.##}\n\n");



            Console.WriteLine("Time to compare two numbers!");
            Console.Write("Please enter your first number: ");
            double number1 = double.Parse(Console.ReadLine());
            Console.Write("Please enter your second number: ");
            double number2 = double.Parse(Console.ReadLine());
            Console.WriteLine($"\nThe higher number between the two you entered is {Math.Max(number1, number2)}\n\n");


            Console.Write("Now enter a 3 word sentence: ");
            String sentence = Console.ReadLine();
            int firstSpace = sentence.IndexOf(' ');
            int lastSpace = sentence.LastIndexOf(' ');
            String middleWord = sentence.Substring(firstSpace + 1, (lastSpace - firstSpace) - 1);
            Console.WriteLine($"\nThe middle word of your sentence is \"{middleWord}\"");


        }
    }
}