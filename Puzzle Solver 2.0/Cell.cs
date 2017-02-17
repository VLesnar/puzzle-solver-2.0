using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Nurikabe Puzzle Solver
 *  Version 2.0
 *  Veronica Lesnar
 *  Created on: February 16, 2017
 *  Last updated on: February 16, 2017 
 *  Cell - A class containing information in a space on the board;
 *      Enum: Status
 *      Properties: numberValue, color  */

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

        // Default Constructor - Sets number value to -1 and color to unknown
        public Cell()
        {
            number = -1;    // Indicates that there is no value in the cell
            color = Status.unknown;
        }

        // Constructor - Takes two ints, number value and color value of the cell
        public Cell(int num, Status col)
        {
            number = num;
            color = col;
        }
    }
}
