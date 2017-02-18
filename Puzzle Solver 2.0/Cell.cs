using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Nurikabe Puzzle Solver
 *  Version 2.0
 *  Veronica Lesnar
 *  Created on: February 16, 2017
 *  Last updated on: February 17, 2017 
 *  Cell - A class containing information in a space on the board;
 *      Enum: Status
 *      Properties: numberValue, color, posCol, posRow, nNeighbor, eNeighbor, sNeighbor, wNeighbor, neNeighbor, 
 *                  seNeighbor, swNeighbor, nwNeighbor  */

namespace Puzzle_Solver_2._0
{
    class Cell
    {
        public enum Status { unknown, black, white };  // If a cell is unknown (0), black (1), or 
                                                       // white (2)
        
        public int number  // Determines if the cell holds a value
        {
            get; set;
        }
        public Status color    // Determines what color the cell is
        {
            get; set;
        }

        public int posCol    // Determines what column the cell is in
        {
            get; set;
        }
        public int posRow    // Determines what column the cell is in
        {
            get; set;
        }

        public Cell nNeighbor   // The cell's North neighbor
        {
            get; set;
        }

        public Cell eNeighbor   // The cell's East neighbor
        {
            get; set;
        }

        public Cell sNeighbor   // The cell's South neighbor
        {
            get; set;
        }

        public Cell wNeighbor   // The cell's West neighbor
        {
            get; set;
        }

        public Cell neNeighbor   // The cell's Northeast neighbor
        {
            get; set;
        }

        public Cell seNeighbor   // The cell's Southeast neighbor
        {
            get; set;
        }

        public Cell swNeighbor   // The cell's Southwest neighbor
        {
            get; set;
        }

        public Cell nwNeighbor   // The cell's Northwest neighbor
        {
            get; set;
        }

        // Default Constructor - Sets number value to -1 and color to unknown
        public Cell()
        {
            number = -1;    // Indicates that there is no value in the cell
            color = Status.unknown;
        }

        // Constructor - Takes two ints, number value and color value of the cell
        public Cell(int num, Status colr, int col, int row)
        {
            number = num;
            color = colr;
            posCol = col;
            posRow = row;
        }
    }
}
