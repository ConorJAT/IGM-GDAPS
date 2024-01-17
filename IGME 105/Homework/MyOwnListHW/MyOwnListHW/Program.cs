//Conor Race
//Oct 14th, 2021
//Purpose: Allows the user to create a custom list, in which they
//can add and manipulate a series of words of their choice.

using System;

namespace MyOwnListHW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to this Custom List Program");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Enter a starting list length: ");
            Console.ForegroundColor = ConsoleColor.White;

            CustomList<string> myWords = new CustomList<string>(int.Parse(Console.ReadLine())); //T = String in this scenario
            string choice = null;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nMenu of Actions: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("    Any Word - Adds word to end of list | \'Print\' - Prints all words in list");
            Console.WriteLine("   \'IndexOf\' - Find index of word       | \'Contains\' - Checks if a word is in list");
            Console.WriteLine("   \'Remove\' - Remove word from list     | \'RemoveAt\' - Remove word at specific index");
            Console.WriteLine("   \'Clear\' - Clears all words in list   | \'Insert\' - Insert word at specific index");
            Console.WriteLine("   \'Get\' - Find word at specific index  | \'Set\' - Replace word at specific index");
            Console.WriteLine("   \'Done\' - Close program               |");

            while (choice != "done")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nYour Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                string addWord = Console.ReadLine();
                choice = addWord.ToLower(); //addWord is used as original entry in case default is triggered.
                Console.ForegroundColor = ConsoleColor.Gray;

                switch (choice)
                {
                    case "print":

                        if (myWords.GetCount == 0)
                        {
                            Console.WriteLine("There are no words in this list");
                            break;
                        }

                        Console.WriteLine("List of Words:");
                        for (int i = 0; i < myWords.GetCount; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            if (myWords[i] == null)
                            {
                                continue; //Will not print any empty spaces in the list.
                            }
                            Console.WriteLine($"   {myWords[i]}");
                        }
                        break;

                    case "indexof":
                        Console.Write("Enter a word to search the index of: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string indexWord = Console.ReadLine();
                        int index = myWords.IndexOf(indexWord);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (index == -1)
                        {
                            Console.WriteLine($"The index of \'{indexWord}\' is -1 (Word does not exist in list)");
                        }
                        else
                        {
                            Console.WriteLine($"The index of \'{indexWord}\' is {index}");
                        }
                        break;

                    case "contains":
                        Console.Write("Enter a word to search: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string containsWord = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (myWords.Contains(containsWord))
                        {
                            Console.WriteLine($"The word \'{containsWord}\' is in your list");
                        }
                        else
                        {
                            Console.WriteLine($"The word \'{containsWord}\' is NOT in your list");
                        }
                        break;

                    case "remove":
                        Console.Write("Enter a word to remove: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string removeWord = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (myWords.Remove(removeWord))
                        {
                            Console.WriteLine($"\'{removeWord}\' successfully removed");
                        }
                        else
                        {
                            Console.WriteLine($"\'{removeWord}\' not found in list");
                        }
                        break;

                    case "removeat":
                        Console.Write("Enter an index of a word to remove: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        int delIndex = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (delIndex >= myWords.GetLength || delIndex < 0 || myWords[delIndex] == null) //Will not accept specific indicies.
                        {
                            Console.WriteLine("Invalid index. Please try again");
                        }
                        else
                        {
                            myWords.RemoveAt(delIndex);
                            Console.WriteLine($"Word located at index {delIndex} removed");
                        }
                        break;

                    case "clear":
                        myWords.Clear();
                        Console.WriteLine("List successfully cleared");
                        break;

                    case "insert":
                        Console.Write("Enter an index to insert: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        int insIndex = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (insIndex >= myWords.GetLength || insIndex < 0 || myWords[insIndex] == null) //Will not accept specific indicies.
                        {
                            Console.WriteLine("Invalid index. Please try again");
                        }
                        else
                        {
                            Console.Write("Enter a word to insert: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string insWord = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            myWords.Insert(insIndex, insWord);
                            Console.WriteLine($"Inserted \'{insWord}\' at index {insIndex}");
                        }
                        break;

                    case "get":
                        Console.Write("Enter an index of a word to retrieve: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        int getIndex = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (getIndex >= myWords.GetLength || getIndex < 0 || myWords[getIndex] == null) //Will not accept specific indicies.
                        {
                            Console.WriteLine("Invalid index. Please try again");
                        }
                        else
                        {
                            Console.WriteLine($"Word at index {getIndex} is \'{myWords[getIndex]}\'");
                        }
                        break;

                    case "set":
                        Console.Write("Enter an index of a word to replace: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        int setIndex = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (setIndex >= myWords.GetLength || setIndex < 0 || myWords[setIndex] == null) //Will not accept specific indicies.
                        {
                            Console.WriteLine("Invalid index. Please try again");
                        }
                        else
                        {
                            Console.Write("Enter a replacement word: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string setWord = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            myWords[setIndex] = setWord;
                            Console.WriteLine($"\'{setWord}\' has replaced the old word at index {setIndex}");
                        }
                        break;

                    case "done":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Have a Nice Day!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;

                    default:
                        myWords.Add(addWord);
                        Console.WriteLine($"\'{addWord}\' has been added to the list");
                        break;
                }
            }

            //CustomList<int> Test

            Console.WriteLine("\n-------------------------------------------------------------------------------");

            {
                CustomList<int> myNums = new CustomList<int>();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nTesting CustomList<int> (Refer to code in VS):");
                Console.ForegroundColor = ConsoleColor.Gray;

                myNums.Add(12);
                myNums.Add(45);
                myNums.Add(128);
                Console.WriteLine("Testing Add():");
                PrintNums(myNums);


                myNums.Insert(1, 37);
                myNums.Insert(-3, 99);
                Console.WriteLine("\nTesting Insert():");
                PrintNums(myNums);


                Console.WriteLine("\nTesting Contains():");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("   " + myNums.Contains(128));
                Console.WriteLine("   " + myNums.Contains(99));
                Console.ForegroundColor = ConsoleColor.Gray;


                myNums.Add(12);
                myNums.Remove(12);
                myNums.Remove(67);
                Console.WriteLine("\nTesting Remove():");
                PrintNums(myNums);


                myNums.RemoveAt(2);
                myNums.RemoveAt(50);
                myNums.RemoveAt(-20);
                Console.WriteLine("\nTesting RemoveAt():");
                PrintNums(myNums);


                myNums[2] = 9999;
                myNums[-3] = 0;
                myNums[99] = 69;
                Console.WriteLine("\nTesting Set:");
                PrintNums(myNums);


                Console.WriteLine("\nTesting Get:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("   " + myNums[1]);
                Console.WriteLine("   " + myNums[-4] + " (Result of the default(T))");
                Console.ForegroundColor = ConsoleColor.Gray;


                Console.WriteLine("\nTesting IndexOf():");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("    " + myNums.IndexOf(9999));
                Console.WriteLine("   " + myNums.IndexOf(12));
                Console.WriteLine("   " + myNums.IndexOf(-45));
                Console.ForegroundColor = ConsoleColor.Gray;


                Console.WriteLine("\nTesting Clear():");
                myNums.Clear();
                PrintNums(myNums);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[END OF CustomList<int> TEST]");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void PrintNums(CustomList<int> list)
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < list.GetCount; i++)
            {
                if (list[i] == 0)
                {
                    continue;
                }
                Console.WriteLine($"   {list[i]}");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
