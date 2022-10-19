using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOneDeck = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();
            List<int> playerTwoDeck = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();
            while(playerOneDeck.Count > 0 && playerTwoDeck.Count > 0)
            {
                // if equals
                if (playerOneDeck[0] == playerTwoDeck[0])
                {
                    playerTwoDeck.RemoveAt(0);
                    playerOneDeck.RemoveAt(0);
                }
                // if player one's bigger
                else if (playerOneDeck[0] > playerTwoDeck[0])
                {
                    playerOneDeck.Add(playerTwoDeck[0]);
                    playerOneDeck.Add(playerOneDeck[0]);
                    playerOneDeck.RemoveAt(0);
                    playerTwoDeck.RemoveAt(0);
                }
                //if player two is bigger
                else
                {
                    playerTwoDeck.Add(playerOneDeck[0]);
                    playerTwoDeck.Add(playerTwoDeck[0]);
                    playerOneDeck.RemoveAt(0);
                    playerTwoDeck.RemoveAt(0);
                }
            }
            if(playerOneDeck.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwoDeck.Sum()}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {playerOneDeck.Sum()}");
             }
        }
    }
}
