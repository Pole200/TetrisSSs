using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisSSs
{
    public class BlockPicker
    {
        private Random random = new Random();
        private readonly Tetrino[] tetrinos = new Tetrino[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock(),
        };
        public Tetrino NextBlock { get;private set; }
        public BlockPicker()
        {
            NextBlock = RadomTetrino();
        }
        private Tetrino RadomTetrino() 
        {
            return tetrinos[random.Next(tetrinos.Length)];
        }
        public Tetrino GetAndUpdate() 
        {
            Tetrino t = NextBlock;
            NextBlock = RadomTetrino();
            return t;
        }
    }
}
