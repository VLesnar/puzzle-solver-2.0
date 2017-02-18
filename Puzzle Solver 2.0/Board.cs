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
 *  Last updated on: February 18, 2017 
 *  Board - A class containing all Cell spaces in a Nurikabe puzzle;
 *      Properties: cells, row, col
 *      Methods: CreateBoard(), FindNeighbors(), ChangeBoard(Board, int, int, Cell.Status)  */

namespace Puzzle_Solver_2._0
{
    class Board
    {
        private Cell[,] cells = null;    // Holds all cells in the board
        private int row;    // Determines the number of cells in a row
        private int col;    // Determines the number of cells in a column

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
            cells = new Cell[col, row];

            int count = 0;
            
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Cell cell = new Cell(numberValues[count + 2], (Cell.Status)(numberValues[count + cells.Length + 2]), i, j);
                    cells[i, j] = cell;
                    count++;
                }
            }

            foreach(Cell cell in cells)
            {
                Console.WriteLine("Number: " + cell.number + " Color: " + cell.color);
            }
        }

        // FindNeighbors() - Finds all adjacent neighbors of all cells including the diagonals
        public void FindNeighbors()
        {
            int posC = 0;
            int posR = 0;

            foreach(Cell cell in cells)
            {
                // North neighbors
                if (!(cell.posRow == 0))
                {
                    cell.nNeighbor = cells[cell.posCol, cell.posRow - 1]; // nNeighbor
                    if (!(cell.posCol == (col - 1)))
                    {
                        cell.neNeighbor = cells[cell.posCol + 1, cell.posRow - 1];    // neNeighbor
                    }
                    if(!(cell.posCol == 0))
                    {
                        cell.nwNeighbor = cells[cell.posCol - 1, cell.posRow - 1];    // nwNeighbor
                    }
                }

                // South neighbors
                if(!(cell.posRow == (row - 1)))
                {
                    cell.sNeighbor = cells[cell.posCol, cell.posRow + 1]; // sNeighbor
                    if (!(cell.posCol == (col - 1)))
                    {
                        cell.seNeighbor = cells[cell.posCol + 1, cell.posRow + 1];    // seNeighbor
                    }
                    if (!(cell.posCol == 0))
                    {
                        cell.swNeighbor = cells[cell.posCol - 1, cell.posRow + 1];    // swNeighbor
                    }
                }

                // East neighbor
                if(!(cell.posCol == row - 1))
                {
                    cell.eNeighbor = cells[cell.posCol + 1, cell.posRow];
                }

                // West neighbor
                if (!(cell.posCol == 0))
                {
                    cell.wNeighbor = cells[cell.posCol - 1, cell.posRow];
                }
            }
        }

        // ChangeBoard(Board, int, int, Cell.Status) - Changes a cell's color in a board
        public Board ChangeBoard(Board brd, int posC, int posR, Cell.Status col)
        {
            Board board = brd;

            board.cells[posC, posR].color = col;    // Change the color of the piece
      
            return board;
        }
    }
}
