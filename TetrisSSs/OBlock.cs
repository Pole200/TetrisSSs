using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisSSs
{
    internal class OBlock: Tetrino
    {
        private readonly MPoint[][] blocks = new MPoint[][]
        {
            new MPoint[] {new(0,0),new(0,1),new(1,0),new(1,1)},
        };
        protected override MPoint StartPoint => new MPoint(0, 4);
        public override Color Id => Colors.Yellow;

        protected override int RotationIndex => 1;

        protected override MPoint[][] Blocks => blocks;
    }
}
