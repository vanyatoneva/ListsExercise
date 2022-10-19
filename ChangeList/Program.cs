using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();
            String[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "end")
            {
                if (command[0] == "Delete")
                {
                    int numToRemove = int.Parse(command[1]);
                    ints.RemoveAll(x => x == numToRemove);
                }
                else if (command[0] == "Insert")
                {
                    if (int.Parse(command[2]) < ints.Count)
                    {
                        ints.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    }
                    else if(int.Parse(command[2]) == ints.Count)
                    {
                        ints.Add(int.Parse(command[1]));
                    }
                }

                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(String.Join(" ", ints));
        }
    }
}
