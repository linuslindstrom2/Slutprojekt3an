﻿using System;
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

        ImageBrush redPlayerImage = new ImageBrush();
        ImageBrush bluePlayerImage = new ImageBrush();
        int totalPosition = 0; 

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetupGame()
        {
            redPlayerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/RödPjäs.png"));
            bluePlayerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/BlåPjäs.png"));

            Rectangle redPlayer = new Rectangle()
            {
                Height = 80,
                Width = 140,
                Fill = redPlayerImage,
                Name = "RedPlayer"
            };
            Grid.SetColumn(redPlayer, 10);
            Grid.SetRow(redPlayer, 2);
            MyGrid.Children.Add(redPlayer);
            
            Rectangle bluePlayer = new Rectangle()
            {
                Height = 80,
                Width = 140,
                Fill = bluePlayerImage,
                Name = "BluePlayer"
            };
            Grid.SetColumn(bluePlayer, 2);
            Grid.SetRow(bluePlayer, 2);
            MyGrid.Children.Add(bluePlayer);
        }

        private void MovePlayer(Rectangle player, int g)
        {
            if (g >= 40)
            {
                g -= 40;
                if (g >= 5)
                {
                    g = 4;
                    foreach (var element in MyGrid.Children)
                    {
                        if (element is TextBox Winning)
                        {
                            if (Winning.Name == "winning")
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
            int diceNumber = random.Next(1, 7);

            totalPosition += diceNumber;

            foreach (var element in MyGrid.Children)
            {
                if (element is Rectangle rect)
                {
                    if (rect.Name== "RedPlayer")
                    {
                        MovePlayer(rect, totalPosition);
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
                Width = 100,
                Height = 100,
                Background = Brushes.Gray,
                BorderBrush = Brushes.Black, 
                
            };
            Grid.SetRow(Dice, 3);
            Grid.SetColumn(Dice, 14);
            Grid.SetColumnSpan(Dice, 2);
            Grid.SetRowSpan(Dice, 2);
            MyGrid.Children.Add(Dice);
            Dice.Click += RollDice;

            TextBox Winning = new TextBox
            {
                Height = 50,
                Width = 100,
                Background = Brushes.White,
                BorderBrush = Brushes.Black,
                Name = "winning", 
            };
            Grid.SetColumn(Winning, 14);
            Grid.SetRow(Winning, 1);
            Grid.SetColumnSpan(Winning, 2);

            MyGrid.Children.Add(Winning);

            SetupGame();
        }
    }
}
