using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conor Race
            // Class: IGME 105.01
            // Purpose: Acts as a functioning calculator w/ limited capabilities.
            Console.WriteLine("Welcome to this Handy Dandy Calculator Program!\n");
            int userChoice = 0;
            while (userChoice != 7) // While loop used to loop the calculator selection until user closes
                                    // the program, which is done by selecting the 7th option.
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Please select an option you'd like to perform:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1.) Whole Number\t2.) Multiplication\t3.) Exponentiation");
                Console.WriteLine("4.) Sine\t\t5.) Cosine\t\t6.) Clear Window");
                Console.WriteLine("7.) Close Program");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Your Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                userChoice = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Gray;

                switch (userChoice) //Switch statement used to for every scenario the user may have selected, even a number greater than 7
                {
                    case 1:
                        Console.WriteLine("\n\nWhole Number");
                        Console.Write("Please enter in a decimal number: ");
                        double doubleCut = double.Parse(Console.ReadLine());
                        int wholeNum = (int)doubleCut; // Casting the double to an int, generating a single whole number.
                        Console.WriteLine($"The whole number is: {wholeNum}\n\n");
                        break;

                    case 2:
                        Console.WriteLine("\n\nMultiplication");
                        Console.Write("Please enter in a number: ");
                        int firstNum = int.Parse(Console.ReadLine());
                        Console.Write("Please enter in another number: ");
                        int secondNum = int.Parse(Console.ReadLine());
                        Console.WriteLine($"The product of {firstNum} * {secondNum} is: {firstNum * secondNum}\n\n");
                        break;

                    case 3:
                        Console.WriteLine("\n\nExponentiation");
                        Console.Write("Please enter in a base number: ");
                        int baseNum = int.Parse(Console.ReadLine());
                        Console.Write("Raised to the power of: ");
                        int powerNum = int.Parse(Console.ReadLine());
                        Console.WriteLine($"The final result of {baseNum}^{powerNum} is: {Math.Pow(baseNum, powerNum)}\n\n"); // Chose exponent for my Math choice.
                        break;

                    case 4:
                        Console.WriteLine("\n\nSine");
                        Console.Write("Please enter in an angle in radians form: ");
                        double radians = double.Parse(Console.ReadLine());
                        Console.WriteLine($"The sin of {radians} is: {Math.Sin(radians)}\n\n");
                        break;

                    case 5:
                        Console.WriteLine("\n\nCosine");
                        Console.Write("Please enter in an angle in radians form: ");
                        double radi = double.Parse(Console.ReadLine());
                        Console.WriteLine($"The cosine of {radi} is: {Math.Cos(radi)}\n\n");
                        break;

                    case 6:
                        Console.Clear(); // Added a clear window selection, in case user wants a fresh screen to perform calculations.
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