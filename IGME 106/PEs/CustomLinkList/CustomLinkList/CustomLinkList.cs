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
    class CustomLinkList<T>
    {
        private int count;
        private CustomLinkNode<T> head;
        private CustomLinkNode<T> tail;

        public CustomLinkList()
        {
            count = 0;
        }

        public int Count { get { return count; } }

        public void Add(T data)
        {
            if (count == 0)
            {
                head = new CustomLinkNode<T>(data);
                tail = head;
                count++;
            }

            else
            {
                tail.Next = new CustomLinkNode<T>(data);
                tail = tail.Next;
                count++;
            }
        }

        public T GetData(int index)
        {
            if (index > count - 1 || index < 0)
            {
                throw new Exception("Error! Index out of bounds!");
            }

            CustomLinkNode<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public T RemoveAt(int index)
        {
            if (index > count - 1 || index < 0)
            {
                throw new Exception("Error! Index out of bounds!");
            }

            T removeData;

            if (index == 0)
            {
                if (count == 1)
                {
                    removeData = head.Data;
                    head = null;
                    tail = null;
                    count--;
                    return removeData;
                }

                else
                {
                    removeData = head.Data;
                    head = head.Next;
                    count--;
                    return removeData;
                }
            }

            else if (index == count - 1)
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

            else
            {
                CustomLinkNode<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                removeData = current.Next.Data;
                current.Next = current.Next.Next;
                count--;
                return removeData;
            }
        }
    }
}
