//Conor Race
//IGME.105.01 - Oct. 6th, 2021
//Purpose: Allows the user to enter in a book and its information,
//which can then be used to create a "Book" object. This program
//then allows the user to play around with the book object via a
//selection of settings.

using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            int userChoice = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the 2021 Virtual Book Reader!\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Please enter the title of the book: ");
            Console.ForegroundColor = ConsoleColor.White;
            string bookName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Please enter the author of the book: ");
            Console.ForegroundColor = ConsoleColor.White;
            string author = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Please enter the number of pages of the book: ");
            Console.ForegroundColor = ConsoleColor.White;
            int pageCount = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Please enter the current owner of the book: ");
            Console.ForegroundColor = ConsoleColor.White;
            string owner = Console.ReadLine();
            
            while (owner == "") // Will not allow the program to continue with an empty string as a user.
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Please enter a valid name: ");
                Console.ForegroundColor = ConsoleColor.White;
                owner = Console.ReadLine();
            }

            Book myBook = new Book(bookName, author, pageCount, owner);

            while (userChoice != 9)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\nWhat would you like to do?");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("   1. Print Title           2. Print Author    3. Print Page Count ");
                Console.WriteLine("   4. Print Current Owner   5. Read The Book   6. Check If Book Is Used");
                Console.WriteLine("   7. Print Book Summary    8. Clear Screen    9. Quit Program");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Your Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                userChoice = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Gray;

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("The title of this book is \"" + myBook.Title + "\"");
                        break;

                    case 2:
                        Console.WriteLine("The author of this book is " + myBook.Author);
                        break;

                    case 3:
                        Console.WriteLine("This book has " + myBook.NumberOfPages + " pages");
                        break;

                    case 4:
                        Console.Write("Switch book owner? (\"yes\" or \"no\"): ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string ownerSwap = Console.ReadLine().ToLower();
                        Console.ForegroundColor = ConsoleColor.Gray;

                        if (ownerSwap == "yes")
                        {
                            Console.Write("Please enter the new owner's name: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            myBook.Owner = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (ownerSwap == "no")
                        {
                            Console.Write("No owner change. ");
                        }
                        else
                        {
                            Console.Write("Invalid Choice. "); //Is user enters in something other than "yes" or "no," the name will not change.
                        }

                        Console.WriteLine("This book's current owner is " + myBook.Owner);
                        break;

                    case 5:
                        myBook.TimesRead++;
                        Console.WriteLine("You've read the book. You've now read this book " + myBook.TimesRead + " time(s)");
                        break;

                    case 6:
                        if (myBook.IsUsed)
                        {
                            Console.WriteLine("This book has been read before");
                        }
                        else
                        {
                            Console.WriteLine("This book has not been read yet");
                        }
                        break;

                    case 7:
                        myBook.Print();
                        break;

                    case 8:
                        Console.Clear(); //Allows the user to clear the console window if it becomes too cluttered.
                        break;

                    case 9:
                        Console.WriteLine("\nThank you for using our services today!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
