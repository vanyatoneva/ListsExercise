using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();
            int[] bomb = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();
            while (numbers.Contains(bomb[0]))
            {
                int firstOcc = numbers.FindIndex(x => x == bomb[0]);
                //first remove right!
                if(firstOcc + bomb[1] >= numbers.Count)
                {
                    numbers.RemoveRange(firstOcc, firstOcc - bomb[1]);

                }
                else
                {
                    numbers.RemoveRange(firstOcc + 1, bomb[1]);
                }
                //Remove left
                if (bomb[1] >= firstOcc)
                {
                    numbers.RemoveRange(0, firstOcc);
                }
                else
                {
                    numbers.RemoveRange(firstOcc - bomb[1], bomb[1]);
                }
                numbers.Remove(bomb[0]);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
