using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisSSs
{
    public class MPoint
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public MPoint(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
