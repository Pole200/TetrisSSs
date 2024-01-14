using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisSSs
{
    internal class IBlock : Tetrino
    {

        private readonly MPoint[][] blocks  = new MPoint[][]
        {
            new MPoint[] {new(1,0),new(1,1),new(1,2),new(1,3)},
            new MPoint[] {new(0,2),new(1,2),new(2,2),new(3,2)}, 
            new MPoint[] {new(2,0),new(2,1),new(2,2),new(2,3)},
            new MPoint[] {new(0,1),new(1,1),new(2,1),new(3,1)},
        };
        protected override MPoint StartPoint => new MPoint(-1,3);
        public override Color Id => Colors.LightBlue;

        protected override int RotationIndex => 1;

        protected override MPoint[][] Blocks => blocks;
    }
}
