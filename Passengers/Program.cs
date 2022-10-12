using System;
using System.Collections.Generic;
using System.Linq;

namespace Passengers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons =
                Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();
            int maxPassengers = int.Parse(Console.ReadLine());
            string comm = Console.ReadLine();

            while(comm != "end")
            {
                string[] command = comm.Split();
                if (command[0] == "Add")
                {
                    wagons.Add(int.Parse(command[1]));
                }
                else
                {
                    int passengersToadd = int.Parse(comm);
                    for(int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengersToadd <= maxPassengers)
                        {
                            wagons[i] += passengersToadd;
                            break;
                        }
                    }
                }
                comm = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", wagons));
        }

       
    }
}
