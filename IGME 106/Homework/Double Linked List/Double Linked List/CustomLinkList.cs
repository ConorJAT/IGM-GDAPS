// Conor Race
// March 22nd, 2022 - HW #4
// IGME.106.07

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_Linked_List
{
    class CustomLinkList<T>
    {
        // Fields:
        private int count;
        private CustomLinkNode<T> head;
        private CustomLinkNode<T> tail;


        // Constructor:

        /// <summary>
        /// Constructor for double link list. Each list, when created, has a default count of
        /// zero and have their head and tail set to null.
        /// </summary>
        public CustomLinkList()
        {
            count = 0;
            head = null;
            tail = null;
        }


        // Properties:

        /// <summary>
        /// Allows for the retrieval ONLY of the list's count.
        /// </summary>
        public int Count { get { return count; } }


        // Indexer:

        /// <summary>
        /// Indexer for double link list. Allows the list object to "act" like a list object
        /// (allows elements to be accessed/changed via "list[i]" format).
        /// </summary>
        /// <param name="index"> Index of the desired element. </param>
        /// <returns> Generic data for which the index aims towards. </returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count) // Exceptions thrown for whenever index is out of range.
                {
                    throw new Exception("Error! Cannot retrieve data from invalid index: " + index);
                }

                CustomLinkNode<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                return current.Data;
            }

            set
            {
                if (index < 0 || index >= count) // Exceptions thrown for whenever index is out of range.
                {
                    throw new Exception("Error! Cannot set data to invalid index: " + index);
                }

                CustomLinkNode<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                current.Data = value;
            }
        }


        // Methods:

        /// <summary>
        /// Adds data to the end of the list.
        /// </summary>
        /// <param name="data"> Generic data to be added. </param>
        public void Add(T data)
        {
            if (count == 0) // Adding data when list is empty:
            {
                head = new CustomLinkNode<T>(data);
                tail = head;
                count++;
            }

            else // Adding data when the list has data in it:
            {
                tail.Next = new CustomLinkNode<T>(data);

                CustomLinkNode<T> current = head;
                for (int i = 0; i < count - 1; i++)
                {
                    current = current.Next;
                }

                tail.Next.Prev = tail;
                tail = tail.Next;
                count++;
            }
        }

        
        /// <summary>
        /// Inserts data at a particular index of the list.
        /// </summary>
        /// <param name="data"> Generic data to be inserted. </param>
        /// <param name="index"> Index where data is inserted. </param>
        public void Insert(T data, int index)
        {
            if (index < 0 || index > count) // Exceptions thrown for whenever index is out of range.
            {
                throw new Exception("Error! Cannot insert data to invalid index: " + index);
            }

            if (count == 0 || index == count) // Inserting data when none exists OR inserting data at end of list:
            {
                Add(data);
            }

            else if (index == 0) // Inserting data at front of list:
            {
                head.Prev = new CustomLinkNode<T>(data);
                head.Prev.Next = head;
                head = head.Prev;
                count++;
            }

            else // Inserting data somewhere in middle of list:
            {
                CustomLinkNode<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                CustomLinkNode<T> hold = current.Next;

                current.Next = new CustomLinkNode<T>(data);
                current.Next.Next = hold;
                current.Next.Prev = current;

                current.Next.Next.Prev = current.Next;
                count++;
            }
        }


        /// <summary>
        /// Removes data at a particular index of the list.
        /// </summary>
        /// <param name="index"> index where data is to be removed. </param>
        /// <returns> Returns generic data that was removed. </returns>
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count) // Exceptions thrown for whenever index is out of range.
            {
                throw new Exception("Error! Cannot remove data from invalid index: " + index);
            }

            T removeData;

            if (index == 0) // Removing data at front of list:
            {
                if (count == 1) // When there is only one piece of data:
                {
                    removeData = head.Data;
                    head = null;
                    tail = null;
                    count--;
                    return removeData;
                }

                else // When there are multiple pieces of data:
                {
                    removeData = head.Data;
                    head = head.Next;
                    head.Prev = null;
                    count--;
                    return removeData;
                }
            }

            else if (index == count - 1) // Removing data at end of list:
            {
                removeData = tail.Data;

                CustomLinkNode<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = null;
                tail = current;
                count--;
                return removeData;
            }

            else // Removing data somewhere in middle of list:
            {
                CustomLinkNode<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                removeData = current.Next.Data;
                current.Next = current.Next.Next;
                current.Next.Prev = current;
                count--;
                return removeData;
            }
        }


        /// <summary>
        /// Clears list of all data.
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }


        /// <summary>
        /// Prints all data from the list, from head to tail.
        /// </summary>
        public void PrintForward()
        {
            Console.ForegroundColor = ConsoleColor.White;
            CustomLinkNode<T> current = head;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"  - {current.Data}");
                current = current.Next;
            }
        }

        
        /// <summary>
        /// Prints all data from the list, from tail to head.
        /// </summary>
        public void PrintReverse()
        {
            Console.ForegroundColor = ConsoleColor.White;
            CustomLinkNode<T> current = tail;
            for (int i = count - 1; i > -1; i--)
            {
                Console.WriteLine($"  - {current.Data}");
                current = current.Prev;
            }
        }
    }
}
