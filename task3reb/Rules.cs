using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace task3reb
{
    class Rules
    {
        public static void GiveMenu(string[] moves)
        {
            int number = 1;
            Console.WriteLine("Available moves:");
            foreach (var move in moves)
            {
                Console.WriteLine($"{number} - {move}");
                number++;
            }
            Console.WriteLine("0 - Exit" + "\n? - Help");
        }

        public static string Judje(string[] input, int userStep, int variantsAmount, int computerStep)
        {
            string[] moveset = input;
            moveset = moveset.Concat(input).Concat(input).ToArray();
            string[] loseVariants = moveset[(userStep + variantsAmount)..(userStep + variantsAmount / 2 + variantsAmount + 1)];
            if (computerStep == userStep) return "Draw";
            else return (loseVariants.Contains(moveset[computerStep]) ? "You lose" : "You win");
        }
    }
}
