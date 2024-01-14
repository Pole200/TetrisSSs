using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisSSs
{
    public abstract class Tetrino
    {
        protected abstract MPoint StartPoint { get; }
        protected abstract MPoint[][] Blocks { get; }
        public abstract Color Id { get; }
        protected abstract int RotationIndex { get; }

        private int rotationState;
        private MPoint currentOffset;

        public Tetrino()
        {
            currentOffset = new MPoint(StartPoint.Row, StartPoint.Col);
        }
        public IEnumerable<MPoint> BlocksLocations() 
        {
            foreach (MPoint p in Blocks[rotationState])
            {
                yield return new MPoint(p.Row + currentOffset.Row, p.Col + currentOffset.Col);
            }
        }
        public void RotateRight() 
        {
            rotationState = (rotationState + 1 ) % Blocks.Length;
        }
        public void RotateLeft() 
        {
            if (rotationState == 0) 
            {
                rotationState = Blocks.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }
        public void Move(int rows, int cols) 
        {
            currentOffset.Row += rows;
            currentOffset.Col += cols;
        }
        public void Reset() 
        {
            rotationState = 0;
            currentOffset.Col = StartPoint.Col;
            currentOffset.Row = StartPoint.Row;
        }
    }
}
