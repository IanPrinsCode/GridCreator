using System;

namespace GridCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new GridCreator();
            generator.generateGrid();
            displayGrid(generator.getGrid());
        }

        private static void displayGrid(string[,] grid)
        {
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid.GetLength(1); j++)
                    Console.Write("{0} ", grid[i, j]);
                Console.WriteLine();
            }
        }
    }
}
