using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisSSs
{
    internal class GameHandel
    {

        private Tetrino activeTetrino;
        public Tetrino ActiveTetrino 
        { 
            get => activeTetrino;
            private set
            {
                activeTetrino = value;
                activeTetrino.Reset();
            }
        }
        public BlockPicker BlockPicker { get; }
        public bool GameOver { get; private set; }
        public int Score { get; private set; } = 0;
        public Color[,] grid { get; }
        public int Rows { get; }
        public int Cols { get; }
        public Color this[int row, int col]
        {
            get => grid[row, col];
            set => grid[row, col] = value;
        }

        public GameHandel()
        {
            BlockPicker = new BlockPicker();
            ActiveTetrino = BlockPicker.GetAndUpdate();
            this.Rows = 22;
            this.Cols = 10;
            grid = new Color[22, 10];
        }
        private bool CanMove() 
        {
            foreach (MPoint p in ActiveTetrino.BlocksLocations())
            {
                if (!(IsEmpty(p.Row,p.Col) && IsInSide(p.Row,p.Col))) 
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsEmpty(int r ,int c) 
        {
            if (!IsInSide(r, c)) 
            {
                return false; 
            }
            else 
            {
                return grid[r, c] == Colors.White;
            }
        }
        public void RotateBlockRight() 
        {
            ActiveTetrino.RotateRight();

            if (!CanMove()) 
            {
                ActiveTetrino.RotateLeft();
            }
        }
        public void RotateBlockLeft()
        {
            ActiveTetrino.RotateLeft();

            if (!CanMove())
            {
                ActiveTetrino.RotateRight();
            }
        }
        public void MoveBlockLeft() 
        {
            ActiveTetrino.Move(0, -1);
            if (!CanMove())
            {
                ActiveTetrino.Move(0, 1);
            }
        }
        public void MoveBlockRight()
        {
            ActiveTetrino.Move(0, 1);
            if (!CanMove())
            {
                ActiveTetrino.Move(0, -1);
            }
        }
        private bool IsGameOver() 
        {
            return !(ISRowEmpty(0) && ISRowEmpty(1));
        }
        private void PlaceBlock() 
        {
            foreach (MPoint p in ActiveTetrino.BlocksLocations()) 
            {
                grid[p.Row, p.Col] = ActiveTetrino.Id;
            }

             Score += ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else 
            {
                ActiveTetrino = BlockPicker.GetAndUpdate();
            }
        }

        public void MoveBlockDown() 
        {
            ActiveTetrino.Move(1, 0);

           if (!CanMove())
            {
                ActiveTetrino.Move(-1, 0);
                PlaceBlock();
            }

        }
        public bool IsInSide(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Cols;

        }
        public bool ISRowFull(int r)
        {
            for (int i = 0; i < Cols; i++)
            {
                if (grid[r, i] == Colors.White)
                {
                    return false;
                }
            }
            return true;
        }
        public bool ISRowEmpty(int r)
        {
            for (int i = 0; i < Cols; i++)
            {
                if (grid[r, i] != Colors.White)
                {
                    return false;
                }
            }
            return true;
        }
        public void ClearRow(int r)
        {
            for (int i = 0; i < Cols; i++)
            {
                grid[r, i] = Colors.White;
            }
        }
        public void MoveDown(int r, int numDown)
        {
            for (int i = 0; i < Cols; i++)
            {
                grid[r + numDown, i] = grid[r, i];
                grid[r, i] = Colors.White;
            }
        }
        public int ClearFullRows()
        {
            int dropIndex = 0;
            for (int r = Rows - 1; r >= 0; r--)
            {
                if (ISRowFull(r))
                {
                    ClearRow(r);
                    dropIndex++;
                }
                else if (dropIndex > 0)
                {
                    MoveDown(r, dropIndex);
                }
            }
            return dropIndex;
        }
    }
}
