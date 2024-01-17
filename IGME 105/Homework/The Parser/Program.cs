//Conor Race
//IGME.105.01
//A manuel parsing program that's able to 
//parse strings into ints and doubles
//without using the parse method itself.
using System;

namespace The_Parser
{
    class Program
    {
        /// <summary>
        /// Accepts a string as a parameter by the user and converts
        /// the string into an integer if possible. The particular method
        /// does NOT treat decimals as important characters, and thus
        /// when the loops come upon a decimal, int.MinValue is returned.
        /// </summary>
        /// <param name="number"> The string which the user enters. </param>
        /// <returns> Returns an int that's the same as the string parameter if 
        /// the string was able to be converted. Returns int.MinValue otherwise. </returns>
        public static int ParseToInt(string number)
        {
            int parsedInt = 0;
            int tensExponent = number.Length - 1; //Integer is constructed via exponets of 10's

            if (number.Length < 1) //Tests for empty strings
            {
                return int.MinValue;
            }

            if (number[0] == '-' && number.Length > 1) //Tests for negative symbol at the start of the string
            {
                tensExponent--;
                for (int i = 1; i < number.Length; i++)
                {
                    switch (number[i]) //Switch tests for all 10 digits in the string
                    {
                        case '0':
                            break;

                        case '1':
                            parsedInt += 1 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '2':
                            parsedInt += 2 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '3':
                            parsedInt += 3 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '4':
                            parsedInt += 4 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '5':
                            parsedInt += 5 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '6':
                            parsedInt += 6 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '7':
                            parsedInt += 7 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '8':
                            parsedInt += 8 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '9':
                            parsedInt += 9 * (int)Math.Pow(10, tensExponent);
                            break;

                        default:
                            return int.MinValue; //Any character not a digit breaks the parsing sequence
                                                 //and returns int.MinValue.
                    }
                    tensExponent--;
                }
                parsedInt *= -1;
            }

            else
            {
                for (int i = 0; i < number.Length; i++)
                {
                    switch (number[i]) //Switch tests for all 10 digits in the string
                    {
                        case '0':
                            break;

                        case '1':
                            parsedInt += 1 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '2':
                            parsedInt += 2 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '3':
                            parsedInt += 3 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '4':
                            parsedInt += 4 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '5':
                            parsedInt += 5 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '6':
                            parsedInt += 6 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '7':
                            parsedInt += 7 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '8':
                            parsedInt += 8 * (int)Math.Pow(10, tensExponent);
                            break;

                        case '9':
                            parsedInt += 9 * (int)Math.Pow(10, tensExponent);
                            break;

                        default:
                            return int.MinValue; //Any character not a digit breaks the parsing sequence
                                                 //and returns int.MinValue.

                    }
                    tensExponent--;
                }
            }

            return parsedInt; //If the string is itself an int, the constructed int will be returned.
        }

        /// <summary>
        /// Accepts a string as a parameter by the user and converts
        /// the string into a double if possible. Returns double.NaN if not
        /// possible.
        /// </summary>
        /// <param name="number"> The string which the user enters. </param>
        /// <returns> Returns an double that's the same as the string parameter if 
        /// the string was able to be converted. Returns double.NaN otherwise. </returns>
        public static double ParseToDouble(string number)
        {
            double parsedDouble = 0;
            int tensExponent; //Integer is constructed via exponets of 10's
            int decimalCount = 0;
            int decimalIndex = -1;

            if (number.Length < 1) //Tests for empty strings
            {
                return double.NaN;
            }
            else if (number == ".") //Tests for single decimals
            {
                return double.NaN;
            }

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == '.')
                {
                    decimalCount++;
                    if (decimalCount < 2) //Ensures there is only 0 or 1 decimal. If 2 or more
                                          //are found, the method returns double.NaN.
                    {
                        decimalIndex = i;
                    }
                    else
                    {
                        return double.NaN;
                    }
                }
            }

            if (decimalCount == 0) //If the string has no decimals, it gets sent to ParseToInt
            {
                if (ParseToInt(number) == int.MinValue)
                {
                    return double.NaN;
                }
                else
                {
                    return (double)ParseToInt(number);
                }
            }

            tensExponent = decimalIndex - 1;

            if (number[0] == '-' && number.Length > 1) //Tests for negative symbol at the start of the string
            {
                tensExponent--;
                for (int i = 1; i < number.Length; i++) //Switch tests for all 10 digits in the string. Decimals are included here
                {
                    switch (number[i])
                    {
                        case '0':
                            break;

                        case '1':
                            parsedDouble += 1 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '2':
                            parsedDouble += 2 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '3':
                            parsedDouble += 3 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '4':
                            parsedDouble += 4 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '5':
                            parsedDouble += 5 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '6':
                            parsedDouble += 6 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '7':
                            parsedDouble += 7 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '8':
                            parsedDouble += 8 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '9':
                            parsedDouble += 9 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '.':
                            tensExponent = 0; //Swapping point where positve exponents become negative
                            break;

                        default:
                            return double.NaN; //Any character not a digit breaks the parsing sequence
                                               //and returns double.NaN
                    }
                    tensExponent--;
                }
                parsedDouble *= -1;
            }

            else
            {
                for (int i = 0; i < number.Length; i++)
                {
                    switch (number[i]) //Switch tests for all 10 digits in the string. Decimals are included here
                    {
                        case '0':
                            break;

                        case '1':
                            parsedDouble += 1 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '2':
                            parsedDouble += 2 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '3':
                            parsedDouble += 3 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '4':
                            parsedDouble += 4 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '5':
                            parsedDouble += 5 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '6':
                            parsedDouble += 6 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '7':
                            parsedDouble += 7 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '8':
                            parsedDouble += 8 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '9':
                            parsedDouble += 9 * (double)Math.Pow(10, tensExponent);
                            break;

                        case '.':
                            tensExponent = 0; //Swapping point where positve exponents become negative
                            break;

                        default:
                            return double.NaN; //Any character not a digit breaks the parsing sequence
                                               //and returns double.NaN

                    }
                    tensExponent--;
                }
            }

            return parsedDouble; //If the string is itself a double, the constructed double will be returned.
        }

        static void Main(string[] args)
        {
            String userInput = "";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to this Manuel Parser Program!");

            while (userInput != "Q" && userInput != "q")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPlease enter an int or enter \"Q\" to quit: ");
                Console.ForegroundColor = ConsoleColor.White;
                userInput = Console.ReadLine();
                if (userInput == "Q" || userInput == "q")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Time to move to decimals!");
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Your number {ParseToInt(userInput)} divided by 2 is: {ParseToInt(userInput) / 2}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-----------------------------------------------------");
            userInput = "";

            while (userInput != "Q" && userInput != "q")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPlease enter a double (decimal) or enter \"Q\" to quit: ");
                Console.ForegroundColor = ConsoleColor.White;
                userInput = Console.ReadLine();
                if (userInput == "Q" || userInput == "q")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Have a Nice Day! :)");
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Your number {ParseToDouble(userInput)} divided by 2 is: {ParseToDouble(userInput) / 2}");

            }
        }
    }
}
