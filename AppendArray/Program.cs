using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            List<int> result = new List<int>();
            for(int i = input.Length - 1; i >= 0; i--)
            {
                result.AddRange((input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)).Select(int.Parse));
            }
             Console.WriteLine(String.Join(" ", result));
        }
    }
}
