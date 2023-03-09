using System;
using System.Collections.Generic;

namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player

    //1) Create a list of Smack talking quotes,
    //2) Create a random number to choose a quote from the index of quotes.
    //3) Should be a random integer getter from the Play method on Program we can use.
    //4) Copy the Play from smack talker and paste it into CreativeSmackTalkingPlayer
    //5) Change Player one to be a CreativeSmackTalkingPlayer.
    public class CreativeSmackTalkingPlayer : Player
    {
        //1) Create a list of Smack talking quotes,
        public List<string> smacks = new List<string>()
        {
        "Here comes the heat!",
        "These dice are feeling awful lucky. For me of course!!",
        "You hear that? Thats the sound of these dice heating up.",
        "I can barely handle these dice they are so hot."

        };



        public override void Play(Player other)
        {
            // Call roll for "this" object and for the "other" object
            int myRoll = Roll();
            int otherRoll = other.Roll();
            //Creates a Random Number
            Random randomNumberGenerator = new Random();
            string Taunt = smacks[randomNumberGenerator.Next(0, smacks.Count)];
            Console.WriteLine($"{Name} Says {Taunt}");
            Console.WriteLine($"{Name} rolls a {myRoll}");
            Console.WriteLine($"{other.Name} rolls a {otherRoll}");
            if (myRoll > otherRoll)
            {

                Console.WriteLine($"{Name} Wins!");
            }
            else if (myRoll < otherRoll)
            {
                Console.WriteLine($"{other.Name} Wins!");
            }
            else
            {
                // if the rolls are equal it's a tie

                Console.WriteLine("It's a tie");
            }
        }
    }
}