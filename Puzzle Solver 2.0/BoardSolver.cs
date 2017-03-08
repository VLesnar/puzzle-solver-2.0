using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Nurikabe Puzzle Solver
 *  Version 2.0
 *  Veronica Lesnar
 *  Created on: February 18, 2017
 *  Last updated on: March 7, 2017 
 *  BoardSolver - A class to solve a Nurikabe puzzle
 *      Properties: board, blackSpaceCount
 *      Methods: InitializeBoard(), SolveOnes()    */

namespace Puzzle_Solver_2._0
{
    class BoardSolver
    {
        private static Board board; // The beginning board to intialize and perform human-like 
                                    // solving strategies on
        int blackSpaceCount;    // Used to keep track of how many spaces are black
        Stack<Board> boardStack = new Stack<Board>();

        // InitializeBoard() - Initializes a board from the Board class and does initial board 
        //                     output
        public void InitializeBoard()
        {
            board = new Board();
            board.CreateBoard();
            board.FindNeighbors();
            blackSpaceCount = 0;

            Console.WriteLine("Initial Board:");
            Console.WriteLine("\nBoard Values:");
            board.PrintNumberBoard();
            Console.WriteLine("Color Values:");
            board.PrintColorBoard();
        }

        // SolveOnes() - Finds all grid spaces with a value of 1 and inputs black values around
        //               that space(s)
        public void SolveOnes()
        {
            foreach(Cell cell in board.cells)
            {
                if(cell.number == 1)
                {
                    if(cell.nNeighbor != null)
                    {
                        cell.nNeighbor.color = Cell.Status.black;
                        blackSpaceCount++;
                    }
                    if (cell.eNeighbor != null)
                    {
                        cell.eNeighbor.color = Cell.Status.black;
                        blackSpaceCount++;
                    }
                    if (cell.sNeighbor != null)
                    {
                        cell.sNeighbor.color = Cell.Status.black;
                        blackSpaceCount++;
                    }
                    if (cell.wNeighbor != null)
                    {
                        cell.wNeighbor.color = Cell.Status.black;
                        blackSpaceCount++;
                    }
                }
            }

            Console.WriteLine("\nAfter finding all grid spaces with a value of one:");
            board.PrintColorBoard();
        }

        public void SolvePuzzle()
        {
            foreach (Cell cell in board.cells)
            {
                if (cell.number > 1)
                {
                    board.FindPaths(cell);
                }
            }

            foreach(List<Cell> paths in board.islands)
            {
                for(int i = 0; i < paths.Count; i++)
                {
                    foreach (Cell cell in paths.ElementAt(i).adjacentNeighbors)
                    {
                       Console.WriteLine("Column: " + cell.posCol + " Row: " + cell.posRow);
                    }
                    Console.WriteLine("\n");
                }
            }
            Console.ReadLine();
        }
    }
}
