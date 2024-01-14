using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TetrisSSs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Rectangle[,] rectangles;
        private readonly Rectangle[,] previewRects;
        private GameHandel gameHandel = new GameHandel();

        private Rectangle[,] InitGameCanvas() 
        {
            Rectangle[,] regs = new Rectangle[gameHandel.Rows, gameHandel.Cols];
            int rectsize = 25;

            for (int r = 0; r < gameHandel.Rows; r++) 
            {
                for (int c = 0; c < gameHandel.Cols; c++)
                {
                    Rectangle rect = new Rectangle
                    {
                        Width = rectsize,
                        Height = rectsize,
                        Fill = new SolidColorBrush(Colors.White),
                        StrokeThickness = 2,
                        
                    };
                    Canvas.SetTop(rect, (r - 2) * rectsize);
                    Canvas.SetLeft(rect, c * rectsize);

                    GameCanvas.Children.Add(rect);
                    regs[r, c] = rect;

                }
            }
            return regs;
        }
        private Rectangle[,] InitPreviewCanvas()
        {
            Rectangle[,] regs = new Rectangle[5, 5];
            int rectsize = 5;

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    Rectangle rect = new Rectangle
                    {
                        Width = rectsize,
                        Height = rectsize,
                        Fill = new SolidColorBrush(Colors.White),
                        StrokeThickness = 2,

                    };
                    Canvas.SetTop(rect, (r - 2) * rectsize);
                    Canvas.SetLeft(rect, c * rectsize);

                    GameCanvas.Children.Add(rect);
                    regs[r, c] = rect;

                }
            }
            return regs;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await GameTimerEvent();
        }
        private void DrawGrid(Color[,] grid ) 
        {
            for (int r = 0; r < gameHandel.Rows; r++)
            {
                for (int c = 0; c < gameHandel.Cols; c++)
                {
                    Color color = grid[r, c];
                    rectangles[r, c].Fill = new SolidColorBrush(color);

                }
            }
        }
        private void Draw(GameHandel game) 
        {
            DrawGrid(game.grid);
            DrawTetrino(game.ActiveTetrino);
            Score.Text = $"Score :{game.Score}";
        }
        private void DrawNextPiece(Tetrino tetrino) 
        {
            foreach (MPoint p in tetrino.BlocksLocations())
            {
                previewRects[p.Row, p.Col].Fill = new SolidColorBrush(tetrino.Id);
            }
        }
        private void DrawTetrino(Tetrino tetrino) 
        {
            foreach(MPoint p in tetrino.BlocksLocations()) 
            {
                rectangles[p.Row,p.Col].Fill = new SolidColorBrush(tetrino.Id);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            rectangles = InitGameCanvas();
            previewRects = InitPreviewCanvas();
        }
        
        private async Task GameTimerEvent()
        {
            Draw(gameHandel);
            while (!gameHandel.GameOver) 
            {
                await Task.Delay(500);
                gameHandel.MoveBlockDown();
                Draw(gameHandel);
            }
        }

        private void m_GamePanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameHandel.GameOver) 
            {
                return;
            }
            switch (e.Key)
            {
                case Key.Left:
                    gameHandel.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameHandel.MoveBlockRight();
                    break;
                case Key.Up:
                    gameHandel.RotateBlockRight();
                    break;
                case Key.Down:
                    gameHandel.MoveBlockDown();
                    break;
                case Key.Z:
                    gameHandel.RotateBlockLeft();
                    break;
                default:
                    return;
            }
            Draw(gameHandel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
