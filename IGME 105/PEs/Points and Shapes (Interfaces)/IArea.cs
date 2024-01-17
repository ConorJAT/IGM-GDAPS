// Conor Race
// Nov. 1st, 2021
// Purpose: Interface used to provide a set of properties and methods a class should
// consist of should it be implemented. Centered around areas of shapes on graphs.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points_and_Shapes__Interfaces_
{
    interface IArea
    {
        // Properties
        double Area { get; }
        double Perimeter { get; }

        // Methods

        // Is a coordinate within the area of this object?
        bool ContainsPosition(IPosition position);

        // Is this area larger than the area of another object?
        bool IsLargerThan(IArea areaToCheck);
    }
}
