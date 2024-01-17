using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndIndexers
{
    class Items<T>
    {
        public T[] items;
        private int count;

        public Items()
        {
            items = new T[4];
            count = 0;
        }

        public int Counter { get { return count; } }

        public void Add(T item)
        {
            items[count] = item;
            count++;
        }

        public T this [int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }
    }
}
