using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Slutproject3
{
    public partial class MainWindow : Window 
    {
        List<Ellipse> Positions = new List<Ellipse>();
        List<Ellipse> RedGoalPath = new List<Ellipse>(); 
        List<Ellipse> GreenGoalPath = new List<Ellipse>(); 
        List<Ellipse> YellowGoalPath = new List<Ellipse>();
        List<Ellipse> BlueGoalPath = new List<Ellipse>();

        List<Image> DiceSides = new List<Image>();

        List<String> Turn = new List<String>();
        

        ImageBrush redPieceImage = new ImageBrush();
        ImageBrush bluePieceImage = new ImageBrush();

        Player redPlayer = new Player(); 
        Player bluePlayer = new Player();

        int diceNumber = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetupGame()
        {
            Turn.Add("Red");
            Turn.Add("Green");
            Turn.Add("Yellow");
            Turn.Add("Blue");

            redPieceImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/RödPjäs.png"));
            bluePieceImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/BlåPjäs.png"));
            
            for (int i = 1; i <= 4; i++)
            {
                Rectangle redPiece = new Rectangle()
                {
                    Height = 80,
                    Width = 140,
                    Fill = redPieceImage,
                    Name = "RedPiece" + i,
                };
                Grid.SetColumn(redPiece, 10);
                Grid.SetRow(redPiece, 2);
                MyGrid.Children.Add(redPiece);
                redPlayer.PieceOne = redPiece;
            }
            redPlayer.pieceOneTotalPosition = -1; 
            redPlayer.pieceTwoTotalPosition = -1; 
            redPlayer.pieceThreeTotalPosition = -1; 
            redPlayer.pieceFourTotalPosition = -1;

            for (int i = 1; i <= 4; i++)
            {
                Rectangle bluePiece = new Rectangle()
                {
                    Height = 80,
                    Width = 140,
                    Fill = bluePieceImage,
                    Name = "BluePlayer" + i,
                };
                Grid.SetColumn(bluePiece, 2);
                Grid.SetRow(bluePiece, 2);
                MyGrid.Children.Add(bluePiece);
                bluePlayer.PieceOne = bluePiece;
                bluePlayer.pieceOneTotalPosition = -1;
            }
        }

        private void MovePlayer(Rectangle player, int g)
        {
            if (g >= 40)
            {
                g -= 40;
                if (g >= 4)
                {
                    g = 4;
                    foreach (var element in MyGrid.Children)
                    {
                        if (element is TextBox Winning)
                        {
                            if (Winning.Name == "TextBox")
                            {
                                Winning.Text += player.Name + " won!!";
                            }
                        }
                    }
                }
                
                if (player.Name.StartsWith("Red"))
                {
                    Grid.SetColumn(player, Grid.GetColumn(RedGoalPath[g]));
                    Grid.SetRow(player, Grid.GetRow(RedGoalPath[g]));
                }
                else if (player.Name.StartsWith("Green"))
                {
                    Grid.SetColumn(player, Grid.GetColumn(GreenGoalPath[g]));
                    Grid.SetRow(player, Grid.GetRow(GreenGoalPath[g]));
                }
                else if (player.Name.StartsWith("Yellow"))
                {
                    Grid.SetColumn(player, Grid.GetColumn(YellowGoalPath[g]));
                    Grid.SetRow(player, Grid.GetRow(YellowGoalPath[g]));
                }
                else if (player.Name.StartsWith("Blue"))
                {
                    Grid.SetColumn(player, Grid.GetColumn(BlueGoalPath[g]));
                    Grid.SetRow(player, Grid.GetRow(BlueGoalPath[g]));
                }
            }
            else
            {
                Grid.SetColumn(player, Grid.GetColumn(Positions[g]));
                Grid.SetRow(player, Grid.GetRow(Positions[g]));
            }
        }

        private void RollDice(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            diceNumber = random.Next(1, 7);

            foreach (var element in MyGrid.Children)
            {
                if (element is TextBox text)
                {
                    if (text.Name == "TextBox")
                    {
                        text.Text = "Du slog en " + diceNumber.ToString() + ":a." + "\r\n" + "Vilken pjäs vill du flytta?";
                    }
                }
            }
        }

        public void AddCircleToList(Brush fill, Brush stroke, int radius, int i, int row, int collumn, string färg)
        {
            Ellipse rec = new Ellipse()
            {
                Fill = fill,
                Stroke = stroke,
                Width = radius,
                Height = radius,
            };
            Grid.SetRow(rec, row);
            Grid.SetColumn(rec, collumn);
            MyGrid.Children.Add(rec);
            rec.Name = färg + i.ToString();

            if (rec.Name.StartsWith("RedGoal"))
            {
                RedGoalPath.Add(rec);
            }
            else if (rec.Name.StartsWith("GreenGoal"))
            {
                GreenGoalPath.Add(rec);
            }
            else if (rec.Name.StartsWith("YellowGoal"))
            {
                YellowGoalPath.Add(rec);
            }
            else if (rec.Name.StartsWith("BlueGoal"))
            {
                BlueGoalPath.Add(rec);
            }
            else
            {
                Positions.Add(rec);
            }          
        }

        public void AddCircleToGrid(Brush fill, Brush stroke, int radius, int i, int row, int collumn, string färg)
        {
            Ellipse rec = new Ellipse()
            {
                Fill = fill,
                Stroke = stroke,
                Width = radius,
                Height = radius,
            };
            Grid.SetRow(rec, row);
            Grid.SetColumn(rec, collumn);
            MyGrid.Children.Add(rec);
            rec.Name = färg + i.ToString();
        }

        public void MyGrid_Loaded(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                var row = new RowDefinition();
                row.Height = new GridLength(60);
                MyGrid.RowDefinitions.Add(row);
                var col = new ColumnDefinition();
                col.Width = new GridLength(60);
                MyGrid.ColumnDefinitions.Add(col);
            }

            for (int j = 1; j < 6; j++)
            {
                int i = 1;
                AddCircleToList(Brushes.White, Brushes.Black, 58, i, j, 7, "RedPath");
                i += 1;
            }

            for (int j = 8; j < 12; j++)
            {
                int i = 6;
                AddCircleToList(Brushes.White, Brushes.Black, 58, i, 5, j, "RedPath");
                i += 1;
            }

            AddCircleToList(Brushes.White, Brushes.Black, 58, 10, 6, 11, "RedPath");

            for (int j = 11; j > 6; j--)
            {
                int i = 1;
                AddCircleToList(Brushes.White, Brushes.Black, 58, i, 7, j, "GreenPath");
                i += 1;
            }

            for (int j = 8; j < 12; j++)
            {
                int i = 6;
                AddCircleToList(Brushes.White, Brushes.Black, 58, i, j, 7, "GreenPath");
                i += 1;
            }

            AddCircleToList(Brushes.White, Brushes.Black, 58, 10, 11, 6, "GreenPath");

            for (int j = 11; j > 6; j--)
            {
                int i = 5;
                AddCircleToList(Brushes.White, Brushes.Black, 58, i, j, 5, "YellowPath");
                i += 1;
            }

            for (int j = 4; j > 0; j--)
            {
                int i = 9;
                AddCircleToList(Brushes.White, Brushes.Black, 58, i, 7, j, "YellowPath");
                i += 1;
            }

            AddCircleToList(Brushes.White, Brushes.Black, 58, 10, 6, 1, "YellowPath");

            for (int j = 1; j < 6; j++)
            {
                int i = 1;
                AddCircleToList(Brushes.White, Brushes.Black, 58, i, 5, j, "BluePath");
                i += 1;
            }

            for (int j = 4; j > 0; j--)
            {
                int i = 6;
                AddCircleToList(Brushes.White, Brushes.Black, 58, i, j, 5, "BluePath");
                i += 1;
            }

            AddCircleToList(Brushes.White, Brushes.Black, 58, 10, 1, 6, "BluePath");

            for (int j = 2; j < 7; j++)
            {
                int i = 1;
                AddCircleToList(Brushes.Red, Brushes.Black, 58, i, j, 6, "RedGoalPath"); 
                i += 1;
            }

            for (int j = 10; j > 6; j--)
            {
                int i = 4;
                AddCircleToList(Brushes.Green, Brushes.Black, 58, i, 6, j, "GreenGoalPath");
                i += 1;
            }

            for (int j = 7; j < 11; j++)
            {
                int i = 4;
                AddCircleToList(Brushes.Yellow, Brushes.Black, 58, i, j, 6, "YellowGoalPath");
                i += 1;
            }

            for (int j = 2; j < 6; j++)
            {
                int i = 1;
                AddCircleToList(Brushes.Blue, Brushes.Black, 58, i, 6, j, "BlueGoalPath");
                i += 1;
            }

            AddCircleToGrid(Brushes.Blue, Brushes.Black, 58, 1, 5, 1, "EndastDesign");

            AddCircleToGrid(Brushes.Red, Brushes.Black, 58, 2, 1, 7, "EndastDesign");

            AddCircleToGrid(Brushes.Green, Brushes.Black, 58, 3, 7, 11, "EndastDesign");

            AddCircleToGrid(Brushes.Yellow, Brushes.Black, 58, 4, 11, 5, "EndastDesign");

            Ellipse BlueStart = new Ellipse()
            {
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                Width = 130,
                Height = 130,
            };
            Grid.SetRow(BlueStart, 1);
            Grid.SetColumn(BlueStart, 1);
            MyGrid.Children.Add(BlueStart);
            Grid.SetColumnSpan(BlueStart, 3);
            Grid.SetRowSpan(BlueStart, 3);

            Ellipse RedStart = new Ellipse()
            {
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                Width = 130,
                Height = 130,
            };
            Grid.SetRow(RedStart, 1);
            Grid.SetColumn(RedStart, 9);
            MyGrid.Children.Add(RedStart);
            Grid.SetColumnSpan(RedStart, 3);
            Grid.SetRowSpan(RedStart, 3);

            Ellipse GreenStart = new Ellipse()
            {
                Fill = Brushes.Green,
                Stroke = Brushes.Black,
                Width = 130,
                Height = 130,
            };
            Grid.SetRow(GreenStart, 9);
            Grid.SetColumn(GreenStart, 9);
            MyGrid.Children.Add(GreenStart);
            Grid.SetColumnSpan(GreenStart, 3);
            Grid.SetRowSpan(GreenStart, 3);

            Ellipse YellowStart = new Ellipse()
            {
                Fill = Brushes.Yellow,
                Stroke = Brushes.Black,
                Width = 130,
                Height = 130,
            };
            Grid.SetRow(YellowStart, 9);
            Grid.SetColumn(YellowStart, 1);
            MyGrid.Children.Add(YellowStart);
            Grid.SetColumnSpan(YellowStart, 3);
            Grid.SetRowSpan(YellowStart, 3);

            Button Dice = new Button()
            {
                Content = "Dice",
                Width = 120,
                Height = 120,
                Background = Brushes.Gray,
                BorderBrush = Brushes.Black, 
                
            };
            Grid.SetRow(Dice, 3);
            Grid.SetColumn(Dice, 14);
            Grid.SetColumnSpan(Dice, 2);
            Grid.SetRowSpan(Dice, 2);
            MyGrid.Children.Add(Dice);
            Dice.Click += RollDice;

            Button One = new Button()
            {
                Content = "One",
                Width = 60,
                Height = 60,
                Background = Brushes.LightGray,
                BorderBrush = Brushes.Black,
            };
            Grid.SetRow(One, 6);
            Grid.SetColumn(One, 14);
            MyGrid.Children.Add(One);
            One.Click += OneMove;

            Button Two = new Button()
            {
                Content = "Two",
                Width = 60,
                Height = 60,
                Background = Brushes.LightGray,
                BorderBrush = Brushes.Black,
            };
            Grid.SetRow(Two, 6);
            Grid.SetColumn(Two, 15);
            MyGrid.Children.Add(Two);
            Two.Click += TwoMove;

            Button Three = new Button()
            {
                Content = "Three",
                Width = 60,
                Height = 60,
                Background = Brushes.LightGray,
                BorderBrush = Brushes.Black,
            };
            Grid.SetRow(Three, 7);
            Grid.SetColumn(Three, 14);
            MyGrid.Children.Add(Three);
            Three.Click += ThreeMove;

            Button Four = new Button()
            {
                Content = "Four",
                Width = 60,
                Height = 60,
                Background = Brushes.LightGray,
                BorderBrush = Brushes.Black,
            };
            Grid.SetRow(Four, 7);
            Grid.SetColumn(Four, 15);
            MyGrid.Children.Add(Four);
            Four.Click += FourMove;

            TextBox Winning = new TextBox
            {
                Height = 50,
                Width = 150,
                Background = Brushes.White,
                BorderBrush = Brushes.Black,
                Name = "TextBox",
            };
            Grid.SetColumn(Winning, 14);
            Grid.SetRow(Winning, 5);
            Grid.SetColumnSpan(Winning, 2);
            Grid.SetColumnSpan(Winning, 2);
            MyGrid.Children.Add(Winning);

            SetupGame();
        }

        private void OneMove(object sender, RoutedEventArgs e)
        {

            foreach (var element in MyGrid.Children)
            {
                if (element is Rectangle rect)
                {
                    if (rect.Name.StartsWith("Red"))
                    {
                        if (rect.Name.EndsWith("1"))
                        {
                            redPlayer.pieceOneTotalPosition += diceNumber;
                            MovePlayer(rect, redPlayer.pieceOneTotalPosition);
                            diceNumber = 0;
                        }
                    }
                }
            }
        }
        private void TwoMove(object sender, RoutedEventArgs e)
        {

            foreach (var element in MyGrid.Children)
            {
                if (element is Rectangle rect)
                {
                    if (rect.Name.StartsWith("Red"))
                    {
                        if (rect.Name.EndsWith("2"))
                        {
                            redPlayer.pieceTwoTotalPosition += diceNumber;
                            MovePlayer(rect, redPlayer.pieceTwoTotalPosition);
                            diceNumber = 0;
                        }
                    }
                }
            }
        }
        private void ThreeMove(object sender, RoutedEventArgs e)
        {
            foreach (var element in MyGrid.Children)
            {
                if (element is Rectangle rect)
                {
                    if (rect.Name.StartsWith("Red"))
                    {
                        if (rect.Name.EndsWith("3"))
                        {
                            redPlayer.pieceThreeTotalPosition += diceNumber;
                            MovePlayer(rect, redPlayer.pieceThreeTotalPosition);
                            diceNumber = 0;
                        }
                    }
                }
            }
        }
        private void FourMove(object sender, RoutedEventArgs e)
        {
            foreach (var element in MyGrid.Children)
            {
                if (element is Rectangle rect)
                {
                    if (rect.Name.StartsWith("Red"))
                    {
                        if (rect.Name.EndsWith("4"))
                        {
                            redPlayer.pieceFourTotalPosition += diceNumber;
                            MovePlayer(rect, redPlayer.pieceFourTotalPosition);
                            diceNumber = 0;
                        }
                    }
                }
            }
        }
    }
}