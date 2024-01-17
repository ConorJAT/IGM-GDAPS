// Conor Race
// Nov. 10th, 2021
// Purpose: Interface instructions for GameStack class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Stacks_and_Queues
{
    interface IStack <T>
    {
        bool IsEmpty { get; }
        int Count { get; }
        void Push(T s);
        T Pop();
        T Peek();
    }
}
