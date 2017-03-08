using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    // Add the file classes

/*  Nurikabe Puzzle Solver
 *  Version 2.0
 *  Veronica Lesnar
 *  Created on: February 16, 2017
 *  Last updated on: March 7, 2017 
 *  Board - A class containing all Cell spaces in a Nurikabe puzzle and helper methods;
 *      Properties: cells, row, col, blackSpaces, islands
 *      Methods: CreateBoard(), FindNeighbors(), PrintNumberBoard(), PrintColorBoard(), 
 *               FindPaths() */

namespace Puzzle_Solver_2._0
{
    class Board
    {
        public Cell[,] cells = null;    // Holds all cells in the board
        public int row    // Determines the number of cells in a row
        {
            get; set;
        }

        public int col    // Determines the number of cells in a column
        {
            get; set;
        }

        public int blackSpaces  // Determines how many black cells are in the board
        {
            get; set;
        }

        public List<List<Cell>> islands
        {
            get; set;
        }

        private static int countIterations;   // Determines how many iterations to check for islands

        private List<Cell> path;

        // CreateBoard() - Reads in a file and creates Cell objects based on the information in the
        //                 file; Also grabs information for puzzle board dimensions
        public void CreateBoard()
        {
            // Open and loop through to read the file
            StreamReader input = null;
            string text = "";
            string[] stringValues = null;

            try
            {
                using (input = new StreamReader("easy.txt"))
                {
                    text = input.ReadToEnd();
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ioe.Message);
            }
            finally
            {
                input.Close();
            }

            // Split the text into an array for reading
            char[] delimiters = { ' ', '/' };

            stringValues = text.Split(delimiters);

            // Parse each number
            int[] numberValues = new int[stringValues.Length];
            for(int i = 0; i < stringValues.Length; i++)
            {
                numberValues[i] = int.Parse(stringValues[i]);
            }

            // Set the row and column values
            row = numberValues[0];
            col = numberValues[1];

            // Add Cell objects to the array
            cells = new Cell[row, col];

            int count = 0;
            
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Cell cell = new Cell(numberValues[count + 2], (Cell.Status)(numberValues[count + cells.Length + 2]), i, j);
                    cells[i, j] = cell;
                    count++;
                }
            }

            // Solve how many black spaces there are
            int whiteSpaces = 0;

            foreach(Cell cell in cells)
            {
                whiteSpaces += cell.number;
            }

            blackSpaces = cells.Length - whiteSpaces;

            // Initialize other helper variables
            countIterations = 1;
            path = new List<Cell>();
            islands = new List<List<Cell>>();

            //// Used as a preliminary board log
            //foreach(Cell cell in cells)
            //{
            //    Console.WriteLine("Number: " + cell.number + " Color: " + cell.color + " Row: " + cell.posRow + " Col: " + cell.posCol);
            //}
        }

        // FindNeighbors() - Finds all adjacent neighbors of all cells including the diagonals
        public void FindNeighbors()
        {
            int posR = 0;
            int posC = 0;

            foreach(Cell cell in cells)
            {
                // North neighbors
                if (!(cell.posCol == 0))
                {
                    cell.nNeighbor = cells[cell.posRow, cell.posCol - 1]; // nNeighbor
                    cell.adjacentNeighbors.Add(cell.nNeighbor);
                    if (!(cell.posRow == (row - 1)))
                    {
                        cell.neNeighbor = cells[cell.posRow + 1, cell.posCol - 1];    // neNeighbor
                    }
                    if(!(cell.posRow == 0))
                    {
                        cell.nwNeighbor = cells[cell.posRow - 1, cell.posCol - 1];    // nwNeighbor
                    }
                }

                // South neighbors
                if(!(cell.posCol == (col - 1)))
                {
                    cell.sNeighbor = cells[cell.posRow, cell.posCol + 1]; // sNeighbor
                    cell.adjacentNeighbors.Add(cell.sNeighbor);
                    if (!(cell.posRow == (row - 1)))
                    {
                        cell.seNeighbor = cells[cell.posRow + 1, cell.posCol + 1];    // seNeighbor
                    }
                    if (!(cell.posRow == 0))
                    {
                        cell.swNeighbor = cells[cell.posRow - 1, cell.posCol + 1];    // swNeighbor
                    }
                }

                // East neighbor
                if(!(cell.posRow == col - 1))
                {
                    cell.eNeighbor = cells[cell.posRow + 1, cell.posCol];
                    cell.adjacentNeighbors.Add(cell.eNeighbor);
                }

                // West neighbor
                if (!(cell.posRow == 0))
                {
                    cell.wNeighbor = cells[cell.posRow - 1, cell.posCol];
                    cell.adjacentNeighbors.Add(cell.wNeighbor);
                }
            }
        }

        // FindPaths() - Find all possible white islands from a number space
        public void FindPaths(Cell cell)
        {
            path.Add(cell);

            while (countIterations != path.ElementAt(0).number)
            {
                foreach (Cell nextCell in cell.adjacentNeighbors)
                {
                    if (countIterations != path.ElementAt(0).number)
                    {
                        countIterations++;
                        FindPaths(nextCell);
                    }
                    else
                    {
                        islands.Add(path);
                    }
                }
            }
        }

        // PrintNumberBoard() - Prints the Nurikabe board
        public void PrintNumberBoard()
        {
            foreach(Cell cell in cells)
            {
                Console.Write(cell.number);
                if(cell.posCol % col == col - 1)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }

        // PrintColorBoard() - Prints the values of each cell in a Nurikabe board
        public void PrintColorBoard()
        {
            foreach (Cell cell in cells)
            {
                Console.Write(cell.color + " ");
                if (cell.posCol % col == col - 1)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }
    }
}
