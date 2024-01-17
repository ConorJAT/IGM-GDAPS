using System;

namespace Refactoring
{
    class Program
    {
        // Conor Race
        // Class: IGME 105.01
        // Purpose: Acts as a functioning calculator w/ limited capabilities.

        public static int PrintMenuAndGetChoice()
        {
            int choice;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please select an option you'd like to perform:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1.) Whole Number\t2.) Multiplication\t3.) Exponentiation");
            Console.WriteLine("4.) Sine\t\t5.) Cosine\t\t6.) Clear Window");
            Console.WriteLine("7.) Close Program");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Your Choice: ");
            Console.ForegroundColor = ConsoleColor.White;
            choice = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Gray;
            return choice;
        }

        public static int GetUserInt(String prompt)
        {
            int enteredInt;
            Console.Write(prompt);
            enteredInt = int.Parse(Console.ReadLine());
            return enteredInt;
        }

        public static double GetUserDouble(String prompt)
        {
            double enteredDouble;
            Console.Write(prompt);
            enteredDouble = double.Parse(Console.ReadLine());
            return enteredDouble;
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to this Handy Dandy Calculator Program!\n");
            int userChoice = 0;
            while (userChoice != 7) 
            {
                userChoice = PrintMenuAndGetChoice();

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("\n\nWhole Number");
                        double doubleCut = GetUserDouble("Please enter in a decimal number: ");
                        int wholeNum = (int)doubleCut;
                        Console.WriteLine($"The whole number is: {wholeNum}\n\n");
                        break;

                    case 2:
                        Console.WriteLine("\n\nMultiplication");
                        int firstNum = GetUserInt("Please enter in a number: ");
                        int secondNum = GetUserInt("Please enter in another number: ");
                        Console.WriteLine($"The product of {firstNum} * {secondNum} is: {firstNum * secondNum}\n\n");
                        break;

                    case 3:
                        Console.WriteLine("\n\nExponentiation");
                        int baseNum = GetUserInt("Please enter in a base number: ");
                        int powerNum = GetUserInt("Raised to the power of: ");
                        Console.WriteLine($"The final result of {baseNum}^{powerNum} is: {Math.Pow(baseNum, powerNum)}\n\n"); 
                        break;

                    case 4:
                        Console.WriteLine("\n\nSine");
                        double radians = GetUserDouble("Please enter in an angle in radians form: ");
                        Console.WriteLine($"The sin of {radians} is: {Math.Sin(radians)}\n\n");
                        break;

                    case 5:
                        Console.WriteLine("\n\nCosine");
                        double radi = GetUserDouble("Please enter in an angle in radians form: ");
                        Console.WriteLine($"The cosine of {radi} is: {Math.Cos(radi)}\n\n");
                        break;

                    case 6:
                        Console.Clear();
                        break;

                    case 7:
                        Console.WriteLine("\n\nHave a nice day! :)");
                        break;

                    default:
                        Console.WriteLine("\n\nInvalid Option! Please Try Again!");
                        break;
                }
            }
        }
    }
}