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
        Rectangle landingRec; 

        Rectangle redPlayer;
        Rectangle bluePlayer;

        List<Rectangle> Moves = new List<Rectangle>();

        DispatcherTimer gameTimer = new DispatcherTimer();

        ImageBrush redPlayerImage = new ImageBrush();
        ImageBrush bluePlayerImage = new ImageBrush();

        int i = -1;
        int j = -1;

        int redPlayerPosition;
        int redPLayerCurrentPosition;

        int bluePlayerPosition;
        int bluePLayerCurrentPosition;

        int images = -1;

        Random rand = new Random();

        bool redPLayerRound, bluePlayerRound;

        int tempPosition;

        public MainWindow()
        {
            InitializeComponent();

            SetupGame();
        }

        private void SetupGame()
        {
            int DefaultLeftPositionRed = 10;
            int DefaultTopPositionRed = 500;

            int a = 0;

            redPlayerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/RödPjäs.png"));
            

            

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
            
            for (int j = 1; j < 6; j++)
            {
                int i = 1;

                Ellipse rec = new Ellipse()
                {
                    Fill = Brushes.White,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };

                Grid.SetRow(rec, j);
                Grid.SetColumn(rec, 7);
                MyGrid.Children.Add(rec);
                rec.Name = "RedPath" + i;
                i += 1;
            }

            for (int j = 8; j < 12; j++)
            {
                int i = 6;

                Ellipse rec = new Ellipse()
                {
                    Fill = Brushes.White,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };

                Grid.SetRow(rec, 5);
                Grid.SetColumn(rec, j);
                MyGrid.Children.Add(rec);
                rec.Name = "RedPath" + i;
                i += 1;
            }

            for (int j = 7; j < 12; j++)
            {
                int i = 5;

                Ellipse rec = new Ellipse()
                {
                    Fill = Brushes.White,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };

                Grid.SetRow(rec, 7);
                Grid.SetColumn(rec, j);
                MyGrid.Children.Add(rec);
                rec.Name = "GreenPath" + i;
                i -= 1;
            }
            for (int j = 8; j < 12; j++)
            {
                int i = 6;

                Ellipse rec = new Ellipse()
                {
                    Fill = Brushes.White,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };

                Grid.SetRow(rec, j);
                Grid.SetColumn(rec, 7);
                MyGrid.Children.Add(rec);
                rec.Name = "GreenPath" + i;
                i += 1;

                }
            

            for (int j = 7; j < 12; j++)
            {
                int i = 5;

                Ellipse rec = new Ellipse()
                {
                    Fill = Brushes.White,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };

                Grid.SetRow(rec, j);
                Grid.SetColumn(rec, 5);
                MyGrid.Children.Add(rec);
                rec.Name = "YellowPath" + i;
                i -= 1;
            }

            for (int j = 1; j < 5; j++)
            {
                int i = 9; 
                    
                Ellipse rec = new Ellipse()
                {
                    Fill = Brushes.White,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };

                Grid.SetRow(rec, 7);
                Grid.SetColumn(rec, j);
                MyGrid.Children.Add(rec);
                rec.Name = "YellowPath" + i;
                i -= 1;
            }


            for (int j = 1; j < 6; j++)
            {
                int i = 1;

                Ellipse rec = new Ellipse()
                {
                    Fill = Brushes.White,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };

                Grid.SetRow(rec, 5);
                Grid.SetColumn(rec, j);
                MyGrid.Children.Add(rec);
                rec.Name = "BluePath" + i;
                i += 1;
            }


            for (int j = 1; j < 5; j++)
            {
                int i = 9;

                Ellipse rec = new Ellipse()
                {
                    Fill = Brushes.White,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };

                Grid.SetRow(rec, j);
                Grid.SetColumn(rec, 5);
                MyGrid.Children.Add(rec);
                rec.Name = "BluePath" + i;
                i -= 1;
            }


            Ellipse rec1 = new Ellipse()
            {
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(rec1, 1);
            Grid.SetColumn(rec1, 6);
            MyGrid.Children.Add(rec1);
            rec1.Name = "BluePath" + 10;

            Ellipse rec2 = new Ellipse()
            {
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(rec2, 6);
            Grid.SetColumn(rec2, 11);
            MyGrid.Children.Add(rec2);
            rec1.Name = "RedPath" + 10;

            Ellipse rec3 = new Ellipse()
            {
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(rec3, 11);
            Grid.SetColumn(rec3, 6);
            MyGrid.Children.Add(rec3);
            rec1.Name = "GreenPath" + 10;

            Ellipse rec4 = new Ellipse()
            {
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(rec4, 6);
            Grid.SetColumn(rec4, 1);
            MyGrid.Children.Add(rec4);
            rec1.Name = "YellowPath" + 10;


            for (int i = 2; i < 6; i++)
            {
                int nummer = 1;
                Ellipse BlåMålgång = new Ellipse()
                {
                    Fill = Brushes.Blue,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };
                Grid.SetRow(BlåMålgång, 6);
                Grid.SetColumn(BlåMålgång, i);
                MyGrid.Children.Add(BlåMålgång);
                BlåMålgång.Name = "BluePath" + i;
                nummer += 1;
            }

            for (int i = 2; i < 6; i++)
            {
                int nummer = 1;
                Ellipse RödMålgång = new Ellipse()
                {
                    Fill = Brushes.Red,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };
                Grid.SetRow(RödMålgång, i);
                Grid.SetColumn(RödMålgång, 6);
                MyGrid.Children.Add(RödMålgång);
                RödMålgång.Name = "BluePath" + i;
                nummer += 1;
            }

            for (int i = 7; i < 11; i++)
            {
                int nummer = 4;
                Ellipse GrönMålgång = new Ellipse()
                {
                    Fill = Brushes.Green,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };
                Grid.SetRow(GrönMålgång, 6);
                Grid.SetColumn(GrönMålgång, i);
                MyGrid.Children.Add(GrönMålgång);
                GrönMålgång.Name = "BluePath" + i;
                nummer -= 1;
            }

            for (int i = 7; i < 11; i++)
            {
                int nummer = 4;

                Ellipse GulMålgång = new Ellipse()
                {
                    Fill = Brushes.Yellow,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };
                Grid.SetRow(GulMålgång, i);
                Grid.SetColumn(GulMålgång, 6);
                MyGrid.Children.Add(GulMålgång);
                GulMålgång.Name = "BluePath" + i;
                nummer -= 1;
            }

            Ellipse FörstaBlå = new Ellipse()
            {
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(FörstaBlå, 5);
            Grid.SetColumn(FörstaBlå, 1);
            MyGrid.Children.Add(FörstaBlå);

            Ellipse FörstaRöd = new Ellipse()
            {
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(FörstaRöd, 1);
            Grid.SetColumn(FörstaRöd, 7);
            MyGrid.Children.Add(FörstaRöd);

            Ellipse FörstaGrön = new Ellipse()
            {
                Fill = Brushes.Green,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(FörstaGrön, 7);
            Grid.SetColumn(FörstaGrön, 11);
            MyGrid.Children.Add(FörstaGrön);

            Ellipse FörstaGul = new Ellipse()
            {
                Fill = Brushes.Yellow,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(FörstaGul, 11);
            Grid.SetColumn(FörstaGul, 5);
            MyGrid.Children.Add(FörstaGul);

            Ellipse Goal = new Ellipse()
            {
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(Goal, 6);
            Grid.SetColumn(Goal, 6);
            MyGrid.Children.Add(Goal);


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
