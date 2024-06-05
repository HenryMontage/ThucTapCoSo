using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative))
        };

        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z.png", UriKind.Relative))
        };

        private readonly Image[,] imageControls;
        private readonly int easyMaxDelay = 1000;
        private readonly int easyMinDelay = 75;
        private readonly int easyDelayDecrease = 25;

        private readonly int hardMaxDelay = 800;
        private readonly int hardMinDelay = 50;
        private readonly int hardDelayDecrease = 35;
        private bool isEasyMode = false;
        private bool isHardMode = false;
        private int elapsedTimeInSeconds = 0;
        private DispatcherTimer gameTimer;

        private bool gameStarted = false;

        private GameState gameState = new GameState();

        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.GameGrid);
        }

   
        private Image[,] SetupGameCanvas(GameGrid grid)
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;
            for(int r = 0; r < grid.Rows; r++)
            {
                for(int c = 0; c < grid.Columns; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }
            return imageControls;
        }
        private void DrawGrid(GameGrid grid)
        {
            for(int r = 0;r < grid.Rows; r++)
            {
                for(int c = 0;c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    imageControls[r, c].Opacity = 1;
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }

        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TilePositions())
            {
                imageControls[p.Row, p.Column].Opacity = 1;
                imageControls[p.Row, p.Column].Source = tileImages[block.Id];
            }
        }

        private void DrawNextBlock(BlockQueue blockQueue)
        {
            Block next = blockQueue.NextBlock;
            NextImage.Source = blockImages[next.Id];
        }

        private void DrawHeldBlock(Block heldBlock)
        {
            if(heldBlock == null)
            {
                HoldImage.Source = blockImages[0];
            }
            else
            {
                HoldImage.Source = blockImages[heldBlock.Id];
            }
        }
        private void DrawGhostBlock(Block block)
        {
            int dropDistanse = gameState.BlockDropDistance();
            foreach(Position p in block.TilePositions())
            {
                imageControls[p.Row + dropDistanse, p.Column].Opacity = 0.25;
                imageControls[p.Row + dropDistanse, p.Column].Source = tileImages[block.Id];
            }
        }

        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawGhostBlock(gameState.CurrentBlock);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.BlockQueue);
            DrawHeldBlock(gameState.HeldBlock);
            ScoreText.Text = $"Score: {gameState.Score}";           
        }

        private async Task GameLoop()
        {
            Draw(gameState);
            StartGameTimer(); // Bắt đầu đồng hồ đếm thời gian
            while (!gameState.GameOver)
            {
                UpdateElapsedTime();
                int delay = CalculateDelay();
                if (isEasyMode)
                {
                    delay = Math.Max(easyMinDelay, easyMaxDelay - (gameState.Score * easyDelayDecrease));
                }
                else if (isHardMode)
                {
                    delay = Math.Max(hardMinDelay, hardMaxDelay - (gameState.Score * hardDelayDecrease));
                }
                await Task.Delay(delay);
                gameState.MoveBlockDown();
                Draw(gameState);
            }
            StopGameTimer(); // Dừng đồng hồ đếm ngược khi game kết thúc

            GameOverMenu.Visibility = Visibility.Visible;
            FinalScoretext.Text = $"Score: {gameState.Score}";
            // Cập nhật thời gian đã chơi cuối cùng vào FinalTimePlayedText
            FinalTimePlayedText.Text = $"Time played: {FormatTime(elapsedTimeInSeconds)}";
        }
             
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (!gameStarted)
            {
                return;
            }
            switch (e.Key)
            {
                case Key.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameState.MoveBlockRight();
                    break;
                case Key.Down:
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    gameState.RotateBlockCW();
                    break;
                case Key.Z:
                    gameState.RotateBlockCCW();
                    break;
                case Key.C:
                    gameState.HoldBlock();
                    break;
                case Key.Space:
                    gameState.DropBlock();
                    break;
                default:
                    return;
            }
            Draw(gameState);
        }

        private void StartGameTimer()
        {
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }
        private void StopGameTimer()
        {
            gameTimer.Stop();
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            elapsedTimeInSeconds++;
            UpdateElapsedTime();
        }
        private void UpdateElapsedTime()
        {
            ElapsedTimeText.Text = $"Time: {FormatTime(elapsedTimeInSeconds)}";
        }
        private string FormatTime(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"mm\:ss");
        }
        private int CalculateDelay()
        {
            return 0;
        }
        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            gameStarted = true;
            PlayButton.Visibility = Visibility.Collapsed;
            ScoreText.Visibility = Visibility.Visible;
            HoldPanel.Visibility = Visibility.Visible;
            NextPanel.Visibility = Visibility.Visible;
            GameCanvas.Visibility = Visibility.Visible;
            ElapsedTimeText.Visibility = Visibility.Visible;

            isEasyMode = EasyModeRadioButton.IsChecked == true;
            isHardMode = HardModeRadioButton.IsChecked == true;
            if (isEasyMode)
            {
                ModeIndicator.Text = "Easy Mode";
                ModeIndicator.Visibility = Visibility.Visible;
            }
            else if (isHardMode)
            {
                ModeIndicator.Text = "Hard Mode";
                ModeIndicator.Visibility = Visibility.Visible;
            }
            else
            {
                // If neither mode is selected, hide the ModeIndicator
                ModeIndicator.Visibility = Visibility.Collapsed;
            }
                await GameLoop(); // Bắt đầu vòng lặp trò chơi khi nhấn nút Play
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Đóng ứng dụng khi nhấn nút Exit
        }

        private async void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            elapsedTimeInSeconds = 0; // Đặt lại thời gian về 0
            UpdateElapsedTime(); // Cập nhật giao diện người dùng hiển thị thời gian đã chơi
            gameState = new GameState();
            GameOverMenu.Visibility = Visibility.Hidden;
            await GameLoop();
        }

    }
}
