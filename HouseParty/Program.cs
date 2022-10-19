using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();
            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split();
                if (command[2] == "going!")
                {
                    if (guests.Contains(command[0]))
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                        continue;
                    }
                    guests.Add(command[0]);
                }
                else if(command[2] == "not")
                {
                    if (!guests.Contains(command[0]))
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                        continue;
                    }
                    guests.Remove(command[0]);
                }
            }
            Console.WriteLine(String.Join(Environment.NewLine, guests));
        }
    }
}
