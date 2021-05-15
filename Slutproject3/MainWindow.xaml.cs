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

        ImageBrush redPlayerImage = new ImageBrush();
        ImageBrush bluePlayerImage = new ImageBrush();
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetupGame()
        {
            redPlayerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/RödPjäs.png"));

            Rectangle redPlayer = new Rectangle
            {
                Height = 80,
                Width = 140,
                Fill = redPlayerImage, 
            };
            MyGrid.Children.Add(redPlayer);

            MovePlayer(redPlayer, 41);
        }

        private void MovePlayer(Rectangle player, int g)
        {
            if (g >= 40)
            {
                g -= 40;
                Grid.SetColumn(player, Grid.GetColumn(RedGoalPath[g]));
                Grid.SetRow(player, Grid.GetRow(RedGoalPath[g]));
            }
            else
            {
                Grid.SetColumn(player, Grid.GetColumn(Positions[g]));
                Grid.SetRow(player, Grid.GetRow(Positions[g]));
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
            if (rec.Name.StartsWith("t"))
            {
                RedGoalPath.Add(rec);
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
            
            for (int i = 0; i < 13; i++)
            {
                var row = new RowDefinition();
                row.Height = new GridLength(60);
                MyGrid.RowDefinitions.Add(row);
                var col = new ColumnDefinition();
                col.Width = new GridLength(60);
                MyGrid.ColumnDefinitions.Add(col);
            }

            TextBox Text = new TextBox();

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

            for (int j = 2; j < 6; j++)
            {
                int i = 1;
                AddCircleToList(Brushes.Red, Brushes.Black, 58, i, j, 6, "tGoalPath"); // fixa rätt lista på dessa så de inte ligger i red
                i += 1;
            }

            for (int j = 7; j < 11; j++)
            {
                int i = 4;
                AddCircleToList(Brushes.Green, Brushes.Black, 58, i, 6, j, "tGoalPath");
                i += 1;
            }

            for (int j = 7; j < 11; j++)
            {
                int i = 4;
                AddCircleToList(Brushes.Yellow, Brushes.Black, 58, i, j, 6, "tGoalPath");
                i += 1;
            }

            for (int j = 2; j < 6; j++)
            {
                int i = 1;
                AddCircleToList(Brushes.Blue, Brushes.Black, 58, i, 6, j, "tGoalPath");
                i += 1;
            }

            AddCircleToGrid(Brushes.Blue, Brushes.Black, 58, 1, 5, 1, "EndastDesign");

            AddCircleToGrid(Brushes.Red, Brushes.Black, 58, 2, 1, 7, "EndastDesign");

            AddCircleToGrid(Brushes.Green, Brushes.Black, 58, 3, 7, 11, "EndastDesign");

            AddCircleToGrid(Brushes.Yellow, Brushes.Black, 58, 4, 11, 5, "EndastDesign");

            AddCircleToGrid(Brushes.Purple, Brushes.Black, 58, 1, 6, 6, "Goal");

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
            
            SetupGame();
        }
    }
}
