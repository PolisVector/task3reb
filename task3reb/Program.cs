using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;



namespace task3reb
{
    class Program
    {
        static void Main(string[] args)
        {
            while (args.Length < 2 || args.Length % 2 == 0)
            {
                Console.Write("Wrong moveset. Insert an odd amount and at least 3 variants:");
                args = Console.ReadLine().Split(' ');
            }

            int computerStep = Program.ComputerStep(args.Length - 1);              

            byte [] keybyte = KeyCreation.GenerateKey();
            string key = KeyCreation.GetHMAC(keybyte, args[computerStep]);
            Console.WriteLine($"HMAC: {key}");

            Rules.GiveMenu(args);

            string input = Console.ReadLine(); 

            if (input == "0") return;

            while (input == "?")
            {
                Table.Create(args);
                Console.Write("\nEnter your move:");
                input = Console.ReadLine();
                if (input == "0") return;
            }

            int userStep = Int32.Parse(input) - 1;
            Console.WriteLine("User's move:" + args[userStep] + "\nComputer's move:" + args[computerStep]);
            Console.WriteLine(Rules.Judje(args, userStep, args.Length - 1, computerStep));
            Console.WriteLine("HMAC key: " + BitConverter.ToString(keybyte).Replace("-", ""));

        }
        public static int ComputerStep(int variantsAmount)
        {
            return RandomNumberGenerator.GetInt32(0, variantsAmount);
        }

    }
}
