using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().
                Split(" ",StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToList();
            int sum = 0;
            while(pokemons.Count > 0)
            {
                int pokemonIndex = int.Parse(Console.ReadLine());
                int value = RemoveElement(pokemonIndex, pokemons);
                ChangeElementsValues(value, pokemons);
                sum += value;
            }
            Console.WriteLine(sum);
        }

        static int RemoveElement(int index, List<int> list) //returns the value of Removed element. 
        {
            int value;
            if(index < 0)
            {
                value = list[0];
                list[0] = list[list.Count - 1];
            }
            else if(index >= list.Count)
            {
                value = list[list.Count - 1];
                list[list.Count - 1] = list[0];
            }
            else
            {
                value = list[index];
                list.RemoveAt(index);
            }
            return value;
        }

        static void ChangeElementsValues(int value, List<int> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i] <= value)
                {
                    list[i] += value;
                }
                else
                {
                    list[i] -= value;
                }
            }
        }
    }
}
