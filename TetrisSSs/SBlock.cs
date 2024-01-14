using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TetrisSSs
{
    internal class SBlock : Tetrino
    {
        private readonly MPoint[][] blocks = new MPoint[][]
     {
            new MPoint[] {new(0,1),new(0,2),new(1,0),new(1,1)},
            new MPoint[] {new(0,1),new(1,1),new(1,2),new(2,2)},
            new MPoint[] {new(1,1),new(1,2),new(2,0),new(2,1)},
            new MPoint[] {new(0,0),new(1,0),new(1,1),new(2,1)},
     };
        protected override MPoint StartPoint => new MPoint(0, 3);
        public override Color Id => Colors.Green;

        protected override int RotationIndex => 1;

        protected override MPoint[][] Blocks => blocks;
    }
}
