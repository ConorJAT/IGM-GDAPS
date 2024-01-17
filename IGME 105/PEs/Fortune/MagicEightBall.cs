//Conor Race
//IGME.105.01 - Sep. 29, 2021
//Purpose: Object class for the Program class 'Fortune.'

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortune
{
    class MagicEightBall
    {

        private string owner;
        private int timesShaken;
        private string[] fortunes = new string[5];
        private Random chooseFortune;

        /// <summary>
        /// Magic Eight Ball constructor. Accepts a string as a parameter and creates an object
        /// using the string parameter for the variable 'owner' and pre-setting all other
        /// variables for the object.
        /// </summary>
        /// <param name="name"> The parameter 'name' is used to set the variable 'owner' for rhw object. </param>
        public MagicEightBall(string name)
        {
            owner = name;
            timesShaken = 0;
            fortunes[0] = "Follow your heart!";
            fortunes[1] = "Come back another time; Timing is key!";
            fortunes[2] = "The stars alligned say yes!";
            fortunes[3] = "The odds against you say no!";
            fortunes[4] = "There lies potential for a lucky outcome!";
            chooseFortune = new Random();
        }

        /// <summary>
        /// Increases the total shakes by one and returns a random string element from the
        /// 'fortunes' array.
        /// </summary>
        /// <returns> Returns a random string element from the 'fortunes' array. </returns>
        public string ShakeBall()
        {
            timesShaken++;
            return fortunes[chooseFortune.Next(0, 5)];
        }

        /// <summary>
        /// Returns a string based on how many times the "ShakeBall()" has been called. This
        /// method does NOT print the string. Only returns a string.
        /// </summary>
        /// <returns> Returns a string report based on 'timesShaken' variable. </returns>
        public string Report()
        {
            if (timesShaken == 0)
            {
                return $"{owner} has not yet shaken the ball!";
            }
            else if (timesShaken > 0 && timesShaken < 4)
            {
                return $"{owner} has shaken the ball {timesShaken} times!";
            }
            else
            {
                return $"{owner} has shaken the ball {timesShaken} times! That's a lot of questions!";
            }

        }
    }
}
