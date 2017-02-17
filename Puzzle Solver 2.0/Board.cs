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
 *  Last updated on: February 16, 2017 
 *  Board - A class containing all Cell spaces in a Nurikabe puzzle;
 *      Properties: cells, row, col
 *      Methods: CreateBoard()  */

namespace Puzzle_Solver_2._0
{
    class Board
    {
        private List<Cell> cells = new List<Cell>();    // Holds all cells in the board
        private int row;    // Determines the number of cells in a row
        private int col;    // Determines the number of cells in a column

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

            for(int i = 2; i < ((numberValues.Length / 2) + 1); i++)
            {
                Cell cell = new Cell(numberValues[i], (Cell.Status)(numberValues[i + (numberValues.Length / 2) - 1]));
                cells.Add(cell);
            }

            foreach(Cell cell in cells)
            {
                Console.WriteLine("Number: " + cell.number + " Color: " + cell.color);
            }

            Console.WriteLine(cells.Count);
        }
    }
}
