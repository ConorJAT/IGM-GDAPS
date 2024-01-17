//Conor Race
//Oct 14th, 2021
//Purpose: Object class for "MyOwnListHW." Allows for the creation of a
//custom list object without relying one C#'s exclusive built-in list.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnListHW
{
    class CustomList<T>
    {   
        // Fields

        private T[] myList;
        private int count;

        // Constructors

        /// <summary>
        /// Unparameterized constructor for CustomList class. Utilizes
        /// constructor chaining.
        /// </summary>
        public CustomList() : this(4)
        {
        }

        /// <summary>
        /// Parameterized constructor for CustomList class.
        /// </summary>
        /// <param name="length"> The initial length of the list. </param>
        public CustomList(int index)
        {
            myList = new T[index];
            count = 0;
        }

        // Properties

        /// <summary>
        /// Indexer; Allows the CustomList object to be treated as an actual list.
        /// </summary>
        /// <param name="index"> The index of list object. </param>
        /// <returns> Returns an element associated with the corresponing index. 
        /// Returns default(T) otherwise. </returns>
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
                    return myList[index];
                }
            }

            set 
            {   
                if (index > -1 && index < count)
                {
                    myList[index] = value; //Only acts with a proper index.
                }
            }
        }

        /// <summary>
        /// Property; Returns the total count of elements in the list.
        /// </summary>
        public int GetCount { get { return count; } }

        /// <summary>
        /// Property; Returns the current length (capacity) of the list.
        /// </summary>
        public int GetLength { get { return myList.Length; } }

        // Methods

        /// <summary>
        /// Doubles the list's current length to help store more elements.
        /// </summary>
        /// <param name="oldList"> The older, smaller list to be extended. </param>
        /// <returns> Returns a new, bigger list, with all previous elements retained. </returns>
        public T[] IncreaseSize(T[] oldList)
        {
            T[] biggerList = new T[2 * oldList.Length]; //Creates a new list with doubled length.
            for (int i = 0; i < oldList.Length; i++)
            {
                biggerList[i] = oldList[i]; //Copies all elements from old list into new list.
            }

            return biggerList; //New bigger list is returned.
        }

        /// <summary>
        /// Adds an element to the end of the list. Also calls "IncreaseSize" method
        /// when more space is needed to add more elements.
        /// </summary>
        public void Add(T word)
        {
            if (count == myList.Length) //Checks for if there is no more space in list.
            {
                myList = IncreaseSize(myList);
            }
            
            myList[count] = word;
            count++;
        }

        /// <summary>
        /// Allows the user to insert an element at a particular index value. Also calls
        /// "IncreaseSize" method when more space is needed to add more elements and shifts
        /// elements appropriately.
        /// </summary>
        /// <param name="index"> Index for where the element is added. </param>
        /// <param name="word"> Element to be added to the list. </param>
        public void Insert(int index, T word)
        {
            if (count == myList.Length) //Checks for if there is no more space in list.
            {
                myList = IncreaseSize(myList); 
            }

            if (index < 0)
            {
                return;
            }
            else if (index >= count)
            {
                Add(word); //Simplified; If the index is greater than or equal to count, Add() is called instead.
            }

            for (int i = myList.Length - 1; i > index; i--)
            {
                myList[i] = myList[i - 1]; //Shifts all elemets LEFT of the index one space to the left.
            }
            
            myList[index] = word; //Fills in gap with new element.
            count++;
        }

        /// <summary>
        /// Checks the list for the index of a particular element.
        /// </summary>
        /// <param name="word"> Element to be checked for its index (if present). </param>
        /// <returns> Returns the index of the element if found. Returns -1 otherwise. </returns>
        public int IndexOf(T word)
        {
            for (int i = 0; i < myList.Length; i++)
            {
                if (word.Equals(myList[i])) //Compares the parameter with each value of the list until found
                                            //or the end of the list is reached.
                {
                    return i;
                }
            }
            
            return -1;
        }

        /// <summary>
        /// Checks the list to see if an element is in the list.
        /// </summary>
        /// <param name="word"> Element to be checked. </param>
        /// <returns> True if element is in the list. False otherwise. </returns>
        public Boolean Contains(T word)
        {
            if (IndexOf(word) > -1) //Simplified; Just check for IndexOf() value.
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes an element at a particular index. Also shifts all
        /// list elements appropriately (no gaps).
        /// </summary>
        /// <param name="index"> Index of element to be removed. </param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                return;
            }

            for (int i = index; i < myList.Length - 1; i++)
            {
                myList[i] = myList[i + 1]; //Shifts all elements LEFT of the index one space to the right.
                                           //This strategy automatically seals any gaps.
            }
            
            count--; //Decrements the total count of elements.
        }

        /// <summary>
        /// Removes the first occurance of an element present in the list, if able.
        /// </summary>
        /// <param name="word"> Element to be removed if able. </param>
        /// <returns> Returns true if removal was successful. False otherwise. </returns>
        public Boolean Remove(T word)
        {
            if (IndexOf(word) > -1)
            {
                RemoveAt(IndexOf(word)); //Simplified; Calls the use of both the IndexOf() and RemoveAt() methods
                return true;
            }

            return false;
        }

        /// <summary>
        /// Creates a new, empty list with the same size it had prior.
        /// </summary>
        public void Clear()
        {
            myList = new T[myList.Length];
            count = 0;
        }
    }
}
