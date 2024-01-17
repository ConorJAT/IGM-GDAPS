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
    class CustomLinkNode<T>
    {
        // Fields:
        private T data;
        private CustomLinkNode<T> next;
        private CustomLinkNode<T> prev;


        // Constructor:

        /// <summary>
        /// Constructor for each node. Each node, when created, contains generic data passed
        /// in via parameter and the next/previous nodes are set to null by default.
        /// </summary>
        /// <param name="data"> Generic data which the node holds. </param>
        public CustomLinkNode(T data)
        {
            this.data = data;
            next = null;
            prev = null;
        }


        // Properties:

        /// <summary>
        /// Allows for the retrieval and setting of generic data which the node holds.
        /// </summary>
        public T Data { get { return data; } set { data = value; } }

        /// <summary>
        /// Allows for the retrieval and setting of the node that follows THIS node.
        /// </summary>
        public CustomLinkNode<T> Next { get { return next; } set { next = value; } }

        /// <summary>
        /// Allows for the retrieval and setting of the node that precedes THIS node.
        /// </summary>
        public CustomLinkNode<T> Prev { get { return prev; } set { prev = value; } }
    }
}
