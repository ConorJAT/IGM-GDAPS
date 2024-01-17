// Conor Race
// IGME.106.07
// March 14th, 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkList
{
    class CustomLinkNode<T>
    {
        private T data;
        private CustomLinkNode<T> next;

        public CustomLinkNode(T data)
        {
            this.data = data;
            next = null;
        }

        public T Data { get { return data; } set { data = value; } }

        public CustomLinkNode<T> Next { get { return next; } set { next = value; } }

    }
}
