using System;

namespace HelloVersionControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Version Control!");
            Console.WriteLine("Watch this, I can do loops!");
            int loopNum = 0;
            while (loopNum < 11)
            {
                Console.WriteLine(loopNum);
                loopNum += 2;
            }

            Console.WriteLine("Impressed? ;)");
            Console.WriteLine("Now let's do odd numbers!");
            loopNum = 1;
            while (loopNum < 10)
            {
                Console.WriteLine(loopNum);
                loopNum += 2;
            }

            Console.WriteLine("Still impressed? ;)");
        }
    }
}
