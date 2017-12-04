using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqFaroShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting of Linq program.");

            var startingDeck = from s in Suits()
                               from r in Ranks()
                               select new { Suit = s , Rank = r};
            /*What's the type of the deck ? */
            Console.WriteLine("Printing the starting deck::::::::::::::::");
            foreach(var c in startingDeck){
                Console.WriteLine(c);
            }
            
            var top = startingDeck.Take(26);
            var bottom = startingDeck.Skip(26);
            // var shuffle = top.InterleaveSequenceWith(bottom);

            // Console.WriteLine("Printing the shuffeled deck::::::::::::::::");
            // foreach(var c in shuffle){
            //     Console.WriteLine(c);
            // }

            var times = 0;
            var shuffle = startingDeck;

            do
            {
                // shuffle = shuffle.Take(26).InterleaveSequenceWith(shuffle.Skip(26));
                shuffle = shuffle.Skip(26).InterleaveSequenceWith(shuffle.Take(26));
                //2nd line is very painful and hangs the system
                foreach (var c in shuffle)
                {
                    Console.WriteLine(c);
                }

                Console.WriteLine();
                times++;
            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);

        }

        // static void PrintDeck(var startingDeck){

        //     foreach (var c in startingDeck)
        //     {
        //         Console.WriteLine(c);
        //     }

        // }
        /*Iterator methods below */
        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }
    }
}
