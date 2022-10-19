﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AnynomousThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            while(command != "3:1")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int firstIndex = int.Parse(commandArgs[1]);
                int lastIndex = int.Parse(commandArgs[2]);
                
                if (commandArgs[0] == "merge")
                {
                    CorrectIndexes(ref firstIndex, ref lastIndex, input);
                    Merge(firstIndex, lastIndex, input);
                }
                else if (commandArgs[0] == "divide")
                {
                    if(firstIndex < 0)
                    {
                        firstIndex = 0;
                    }
                    Divide(firstIndex, lastIndex, input);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", input));
        }

        static void CorrectIndexes(ref int firstIndex, ref int secondIndex, List<string> strings)
        {
            if(firstIndex < 0)
            {
                firstIndex = 0;
            }
            if(secondIndex >= strings.Count)
            {
                secondIndex = strings.Count - 1;
            }
        }

        static void Merge(int firstIndex, int lastIndex, List<string> strings)
        {
            for (int i = 0; i < lastIndex; i++)
            {
                strings[firstIndex] += strings[firstIndex + 1];
                strings.RemoveAt(firstIndex + 1);
            }
        }
        static void Divide(int firstIndex, int length, List<string> strings)
        {
            int wordsCount = strings[firstIndex].Length / length;
            for(int i = firstIndex + 1; i <= wordsCount + firstIndex; i++)
            {
                if(i == wordsCount + firstIndex)
                {
                    strings.Insert(i, strings[firstIndex]);
                    strings.RemoveAt(firstIndex);
                    break;
                }
                strings.Insert(i, strings[firstIndex].Substring(0, 2));
                strings[firstIndex] = strings[firstIndex].Substring(length);
            }

        }

    }
}
