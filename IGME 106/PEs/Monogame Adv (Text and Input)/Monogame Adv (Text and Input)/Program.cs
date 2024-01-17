using Monogame_Basics;
using System;

namespace Monogame_Adv__Text_and_Input_
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
