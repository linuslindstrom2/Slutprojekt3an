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
        Rectangle player;

        List<string> Positions = new List<string>();

        ImageBrush redPlayerImage = new ImageBrush();
        ImageBrush bluePlayerImage = new ImageBrush();
       
        public MainWindow()
        {
            InitializeComponent();

            SetupGame();
        }

        private void SetupGame()
        {
            redPlayerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/RödPjäs.png"));
            
           
            
            for (int i = 0; i < 10; i++)
            {
                Positions.Add("RedPath" + i+1);
            }
            for (int i = 0; i < 10; i++)
            {
                Positions.Add("GreenPath" + i + 1);
            }
            for (int i = 0; i < 10; i++)
            {
                Positions.Add("YellowPath" + i + 1);
            }
            for (int i = 0; i < 10; i++)
            {
                Positions.Add("RedPath" + i + 1);
            }

            player = new Rectangle
            {
                Height = 30,
                Width = 30,
                Fill = redPlayerImage,
                StrokeThickness = 2
            };

            MovePlayer(player, Positions[4]);
        }

        private void RestartGame()
        {

        }

        private int CheckKnuff(int num)
        {
            return num;
        }

        private void MovePlayer(Rectangle player, string positionName)
        {
           
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
            Positions.Add(rec.Name);            //Vet ej hur jag ska lägga till cirklarna i Listan
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
                AddCircleToGrid(Brushes.White, Brushes.Black, 58, i, j, 7, "RedPath");
                i += 1;
            }

            for (int j = 8; j < 12; j++)
            {
                int i = 6;
                AddCircleToGrid(Brushes.White, Brushes.Black, 58, i, 5, j, "RedPath");
                i += 1;
            }

            for (int j = 7; j < 12; j++)
            {
                int i = 5;
                AddCircleToGrid(Brushes.White, Brushes.Black, 58, i, 7, j, "GreenPath");
                i -= 1;
            }

            for (int j = 8; j < 12; j++)
            {
                int i = 6;
                AddCircleToGrid(Brushes.White, Brushes.Black, 58, i, j, 7, "GreenPath");
                i += 1;
            }
            
            for (int j = 7; j < 12; j++)
            {
                int i = 5;
                AddCircleToGrid(Brushes.White, Brushes.Black, 58, i, j, 5, "YellowPath");
                i -= 1;
            }

            for (int j = 1; j < 5; j++)
            {
                int i = 9;
                AddCircleToGrid(Brushes.White, Brushes.Black, 58, i, 7, j, "YellowPath");
                i -= 1;
            }

            for (int j = 1; j < 6; j++)
            {
                int i = 1;
                AddCircleToGrid(Brushes.White, Brushes.Black, 58, i, 5, j, "BluePath");
                i += 1;
            }

            for (int j = 1; j < 5; j++)
            {
                int i = 9;
                AddCircleToGrid(Brushes.White, Brushes.Black, 58, i, j, 5, "BluePath");
                i -= 1;
            }

            AddCircleToGrid(Brushes.White, Brushes.Black, 58, 10, 1, 6, "BluePath");

            AddCircleToGrid(Brushes.White, Brushes.Black, 58, 10, 6, 11, "RedPath");

            AddCircleToGrid(Brushes.White, Brushes.Black, 58, 10, 11, 6, "GreenPath");

            AddCircleToGrid(Brushes.White, Brushes.Black, 58, 10, 6, 1, "YellowPath");

            for (int j = 2; j < 6; j++)
            {
                int i = 1;
                AddCircleToGrid(Brushes.Blue, Brushes.Black, 58, i, 6, j, "BluePath");
                i += 1;
            }

            for (int j = 2; j < 6; j++)
            {
                int i = 1;
                AddCircleToGrid(Brushes.Red, Brushes.Black, 58, i, j, 6, "BluePath");
                i += 1;
            }

            for (int j = 7; j < 11; j++)
            {
                int i = 4;
                AddCircleToGrid(Brushes.Green, Brushes.Black, 58, i, 6, j, "BluePath");
                i -= 1;
            }

            for (int j = 7; j < 11; j++)
            {
                int i = 4;
                AddCircleToGrid(Brushes.Yellow, Brushes.Black, 58, i, j, 6, "BluePath");
                i -= 1;
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
        }
    }
}
