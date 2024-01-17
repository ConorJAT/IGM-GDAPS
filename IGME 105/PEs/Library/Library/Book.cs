//Conor Race
//IGME.105.01 - Oct. 6th, 2021
//Purpose: Creates and manages "Book" objects

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {
        private string title;
        private string author;
        private int pageTotal;
        private string owner;
        private int timesRead;

        /// <summary>
        /// Constructs a book object accepting 4 parameters as values, along with one
        /// additional default value.
        /// </summary>
        /// <param name="bookName"> The name of the book. </param>
        /// <param name="writer"> The author of the book. </param>
        /// <param name="pages"> How many pages are in the book. </param>
        /// <param name="holder"> Who's the current owner of the book. </param>
        public Book(string bookName, string writer, int pages, string holder)
        {
            title = bookName;
            author = writer;
            pageTotal = pages;
            owner = holder; 
            timesRead = 0;
        }

        /// <summary>
        /// Gets book title.
        /// </summary>
        public string Title { get { return title; } }

        /// <summary>
        /// Gets book author.
        /// </summary>
        public string Author { get { return author; } }

        /// <summary>
        /// Gets the total page count of the book.
        /// </summary>
        public int NumberOfPages { get { return pageTotal; } }

        /// <summary>
        /// Gets and sets the owner of the book. Will not accept null or empty strings as users.
        /// </summary>
        public string Owner
        {
            get { return owner; }

            set
            {
                if (value != null && value != "") { owner = value; } //If the user enters in an empty string, the name will not change.
            }
        }
        
        /// <summary>
        /// Gets and sets how many times the book has been read.
        /// </summary>
        public int TimesRead { get { return timesRead; } set { timesRead = value; } }

        /// <summary>
        /// Gets a boolean value for whether the book has been used or not.
        /// </summary>
        public Boolean IsUsed
        {
            get
            {
                if (timesRead == 0) { return false; }
                else { return true; }  
            }
        }

        /// <summary>
        /// Outputs all of the book's current information.
        /// </summary>
        public void Print()
        {
            Console.WriteLine("   Book Title:\t\t" + title);
            Console.WriteLine("   Author of Book:\t" + author);
            Console.WriteLine("   Page Count:\t\t" + pageTotal);
            Console.WriteLine("   Current Owner:\t" + owner);
            Console.WriteLine("   Times Read:\t\t" + timesRead);
            Console.WriteLine("   Book Is Used:\t" + IsUsed);
        }
    }
}
