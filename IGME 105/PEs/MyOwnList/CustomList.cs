//Conor Race
//Oct 13th, 2021
//Purpose: Object class for MyOwnList. Acts as a custom list object.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnList
{
    class CustomList<T>
    {
        private T[] list;
        private int count;

        /// <summary>
        /// Parameterized constructor for CustomList class.
        /// </summary>
        /// <param name="length"> The initial length of the list. </param>
        public CustomList(int length) 
        {
            list = new T[length];
            count = 0;
        }

        /// <summary>
        /// Unparameterized constructor for CustomList class. Utilizes
        /// constructor chaining.
        /// </summary>
        public CustomList() : this(4)
        {
        }

        /// <summary>
        /// Property; Returns the total count of elements in the list.
        /// </summary>
        public int GetCount { get { return count; } }

        /// <summary>
        /// Property; Returns the current length of the list.
        /// </summary>
        public int GetLength { get { return list.Length; } }

        /// <summary>
        /// Adds a word to the end of the list. Also extends the list's
        /// length if there is no more space.
        /// </summary>
        /// <param name="word"> The word to be added to the list. </param>
        public void Add(T word)
        {
            if (count == list.Length) //Checks for if there is no more space.
            {
                T[] biggerList = new T[2 * list.Length]; //Creates a new list with doubled length.
                for (int i = 0; i < list.Length; i++)
                {
                    biggerList[i] = list[i]; //Copies all elements from old list into new list.
                }
                
                list = biggerList; //New list is now set back into original variable.
            }

            list[count] = word;
            count++;
        }

        /// <summary>
        /// Indexer; Allows the CustomList object to be treated as an actual list
        /// </summary>
        /// <param name="index"> The index of list object. </param>
        /// <returns> Returns an element associated with the corresponing index. 
        /// Returns null otherwise. </returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    return default(T);
                }
                else
                {
                    return list[index];
                }
            }

            set
            {
                if (index > -1 && index < count)
                {
                    list[index] = value; //Only acts with a proper index.
                }
            }
        }
    }
}
