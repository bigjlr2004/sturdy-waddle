using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new SmackTalkingPlayer("You can't Beat me.");
            player1.Name = "Bob";

            Player player2 = new Player();
            player2.Name = "Sue";

            player1.Play(player2);

            Console.WriteLine("-------------------");

            Player player3 = new Player();
            player3.Name = "Wilma";

            player3.Play(player2);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            Player higher = new OneHigherPlayer();
            higher.Name = "Dice on Fire";

            // Console.WriteLine("------Large Player-------");
            // Console.WriteLine("------------------");
            // player1.Play(large);
            // Console.WriteLine("");

            // Console.WriteLine("------Higher-------");
            // Console.WriteLine("-------------------");
            // higher.Play(player1);
            // Console.WriteLine("-------------------");
            // higher.Play(player2);
            // Console.WriteLine("-------------------");
            // higher.Play(large);

            Console.WriteLine("------Human-------");
            Console.WriteLine("------------------");
            Console.WriteLine("What is your player name?");
            string HumanPlayerName = Console.ReadLine();

            Player Human = new HumanPlayer();
            Human.Name = HumanPlayerName;
            Human.Play(player2);
            Human.Play(player3);


            Console.WriteLine("-------------------");

            List<Player> players = new List<Player>() {
                player1, player2, player3, large
            };

            PlayMany(players);
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play noe another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                if (player2.Name == "Bob")
                {
                    Console.WriteLine("------Round 1--------");
                    player2.Play(player1);
                    Console.WriteLine("------Rematch--------");
                    player2.Play(player1);
                }
                else
                {
                    Console.WriteLine("------Round 1--------");
                    player1.Play(player2);
                    Console.WriteLine("------Rematch--------");
                    player1.Play(player2);
                }
            }
        }
    }
}