using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace task3reb
{
    class Table
    {
        public static void Create(string[] moveset)
        {
            var table = new ConsoleTable("User's move", "Computer's move", "Result");
            foreach (string i in moveset)
            {
                foreach (string j in moveset)
                {
                    table.AddRow(i, j, Rules.Judje(moveset, Array.IndexOf(moveset, i, 0), moveset.Length, Array.IndexOf(moveset, j, 0)));
                }
            }
            table.Write();
        }
    }
}
