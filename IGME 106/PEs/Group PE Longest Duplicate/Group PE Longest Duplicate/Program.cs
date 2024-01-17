using System;

namespace Group_PE_Longest_Duplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 2, 4, 10, 10, 10, 10, 4, 2, 2, 2, 4 };
            int[] numbers2 = { 5, 2, 4, 4, 6, 6, 6, 7, 7, 7, 1, 2 };
            Console.WriteLine(GetLongestDuplicate(numbers));
            Console.WriteLine(GetLongestDuplicate(numbers2));
        }

        public static int GetLongestDuplicate(int[] numsList)
        {
            int highStreak = 1;
            int dupCount = 1;
            int longestNum = numsList[0];

            for (int i = 0; i < numsList.Length - 1; i++)
            {
                if (numsList[i] == numsList[i + 1])
                {
                    dupCount++;
                }
                else
                {
                    dupCount = 1;
                }

                if (dupCount >= highStreak)
                {
                    highStreak = dupCount;
                    longestNum = numsList[i];
                }
            }

            return longestNum;
        }
    }
}
