// Conor Race
// Nov. 10th, 2021
// Purpose: Allows for the creation a custom made queue
// data structure.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Stacks_and_Queues
{
    class GameQueue<T> : IQueue<T>
    {
        private List<T> myQueue;

        /// <summary>
        /// Constructor for custom queue. Only needs create a new generic list.
        /// </summary>
        public GameQueue()
        {
            myQueue = new List<T>();
        }

        /// <summary>
        /// Property; Returns true if queue is empty, false otherwise.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (myQueue.Count == 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Property; Returns how many elements are in the queue.
        /// </summary
        public int Count { get { return myQueue.Count; } }

        /// <summary>
        /// Adds a generic 'thing' to the end of the queue (most recent).
        /// </summary>
        /// <param name="thing"> Generic item to be added. </param>
        public void Enqueue(T thing)
        {
            myQueue.Add(thing);
        }

        /// <summary>
        /// Removes and returns the oldest (the first) element of the queue.
        /// </summary>
        /// <returns> The generic item which was removed. </returns>
        public T Dequeue()
        {
            if (myQueue.Count == 0)
            {
                throw new Exception("Error! Queue is empty!");
            }
            T hold = myQueue[0];
            myQueue.RemoveAt(0);
            return hold;
        }

        /// <summary>
        /// Returns what's the oldest (the first) element of the queue.
        /// </summary>
        /// <returns> The generic item at the "front" of the queue (first in list). </returns>
        public T Peek()
        {
            if (myQueue.Count == 0)
            {
                throw new Exception("Error! Queue is empty!");
            }
            return myQueue[0];
        }
    }
}
