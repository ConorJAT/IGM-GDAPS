// Conor Race
// Nov. 10th, 2021
// Purpose: Allows for the creation a custom made stack
// data structure.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Stacks_and_Queues
{
    class GameStack<T> : IStack<T>
    {
        private List<T> myStack;

        /// <summary>
        /// Constructor for custom stack. Only needs create a new generic list.
        /// </summary>
        public GameStack()
        {
            myStack = new List<T>();
        }

        /// <summary>
        /// Property; Returns true if stack is empty, false otherwise.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (myStack.Count == 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Property; Returns how many elements are in the stack.
        /// </summary>
        public int Count { get { return myStack.Count; } }

        /// <summary>
        /// Adds a generic 'thing' to the end of the stack (most recent).
        /// </summary>
        /// <param name="thing"> Generic item to be added. </param>
        public void Push(T thing)
        {
            myStack.Add(thing);
        }

        /// <summary>
        /// Removes and returns the most recent (the last) element of the stack.
        /// </summary>
        /// <returns> The generic item which was removed. </returns>
        public T Pop()
        {
            if (myStack.Count == 0)
            {
                throw new Exception("Error! Queue is empty!");
            }
            T hold = myStack[myStack.Count - 1];
            myStack.RemoveAt(myStack.Count - 1);
            return hold;
        }

        /// <summary>
        /// Returns what's the most recent (the last) element of the stack.
        /// </summary>
        /// <returns> The generic item at the "front" of the stack (last in list). </returns>
        public T Peek()
        {
            if (myStack.Count == 0)
            {
                throw new Exception("Error! Queue is empty!");
            }
            return myStack[myStack.Count - 1];
        }
    }
}
