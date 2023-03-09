using System;


namespace ShootingDice
{
    // TODO: Complete this class

    // A Player that throws an exception when they lose to the other player
    // Where might you catch this exception????

    [Serializable]
    class SoreLoserException : Exception
    {
        public SoreLoserException() { }

        public SoreLoserException(string message)
            : base(String.Format(message))
        {

        }
    }

    public class SoreLoserPlayer : Player
    {
        public override void Play(Player other)
        {
            // Call roll for "this" object and for the "other" object
            int myRoll = Roll();
            int otherRoll = other.Roll();

            Console.WriteLine($"{Name} rolls a {myRoll}");
            Console.WriteLine($"{other.Name} rolls a {otherRoll}");

            try
            {

                if (myRoll <= otherRoll)
                {
                    throw new SoreLoserException("I never win. I quit.");

                }
                else
                {
                    Console.WriteLine($"{Name} Wins!");
                }

            }
            catch (SoreLoserException ex)
            {
                Console.WriteLine(ex.Message);
            };

        }


    }
}