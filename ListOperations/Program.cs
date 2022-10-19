using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> userNums = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "End")
            {
                if (commands[0] == "Add")
                {
                    userNums.Add(int.Parse(commands[1]));
                }
                else if(commands[0] == "Insert")
                {
                    if (int.Parse(commands[2]) >= userNums.Count || int.Parse(commands[2]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        userNums.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                    }
                }
                else if(commands[0] == "Remove")
                {
                    if (int.Parse(commands[1]) >= userNums.Count || int.Parse(commands[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        userNums.RemoveAt(int.Parse(commands[1]));
                    }
                }
                else if(commands[0] == "Shift")
                {
                    if (commands[1] == "left")
                    {
                        for(int i =0; i < int.Parse(commands[2]); i++)
                        {
                            userNums.Add(userNums[0]);
                            userNums.RemoveAt(0);
                        }
                    }
                    else if (commands[1] == "right")
                    {
                        for (int i = 0; i < int.Parse(commands[2]); i++)
                        {
                            userNums.Insert(0, userNums[userNums.Count - 1]);
                            userNums.RemoveAt(userNums.Count - 1);
                        }
                    }
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(String.Join(" ", userNums));
        }
    }
}
