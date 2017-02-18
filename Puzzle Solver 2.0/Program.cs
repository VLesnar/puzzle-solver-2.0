using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Nurikabe Puzzle Solver
 *  Version 2.0
 *  Veronica Lesnar
 *  Created on: February 16, 2017
 *  Last updated on: February 16, 2017  */

namespace Puzzle_Solver_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.CreateBoard();
            board.FindNeighbors();
            Console.ReadLine();
        }
    }
}
