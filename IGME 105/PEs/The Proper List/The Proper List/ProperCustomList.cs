//Conor Race
//Oct. 25th, 2021
//Purpose: Serves as a simple list object class with
//exceptions thrown to main when needed.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Proper_List
{
    class ProperCustomList<T>
    {
        private T[] myList;
        private int count;

        /// <summary>
        /// Default constructor for the object class. Uses constructor chaining by passing 4 as a
        /// default value for list's length.
        /// </summary>
        public ProperCustomList() : this(4)
        {
        }
        
        /// <summary>
        /// Parameterized constructor for the object class. Consrtucts a list via a passed in integer
        /// value. Also tests for and throws an Exception if the parameter is less than 0.
        /// </summary>
        /// <param name="length"> The initial length of the list. </param>
        public ProperCustomList(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Error Found: Invalid starting index for list creation!");
            }

            myList = new T[length];
            count = 0;
        }

        /// <summary>
        /// Indexer for object class. Allows the myList variable to have list-like properties. For both
        /// get and set, an exception is thrown if the passed in index is greater than the last index
        /// value of the list or if the index value is less than 0.
        /// </summary>
        /// <param name="index"> An index of the list. </param>
        /// <returns> Reutrns the element that's held at the particular index. </returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Error Found: Provided index out of range!");
                }
                else
                {
                    return myList[index];
                }

            }

            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Error Found: Provided index out of range!");
                }
                else
                {
                    myList[index] = value;
                }
            }
        }

        /// <summary>
        /// Simply adds a generic item to the end of the list. Does NOT extend the list.
        /// </summary>
        /// <param name="aThing"> A generic thing to be added. </param>
        public void Add(T aThing)
        {
            myList[count] = aThing;
            count++;
        }
    }
}
