using System;
using System.Collections.Generic;
using System.Text;

namespace Messages__Delegates_
{
    class Dice
    {
        private int dieSide;
        private int rollCount;

        public event MessageDelegate RolledATwenty;
        Random rng = new Random();

        public Dice()
        {
            dieSide = 0;
            rollCount = 0;
        }

        public int Roll()
        {
            dieSide = rng.Next(1, 21);
            rollCount++;

            if (dieSide == 20 && RolledATwenty != null)
            {
                RolledATwenty("Rolled a 20", "This was roll #" + rollCount);
            }

            return dieSide;
        }
    }
}
